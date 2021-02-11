using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependencyInjection
{
	public class DiContainer
	{
		private Dictionary<Type, ServiceDescriptor> serviceDescriptors;

		public DiContainer(Dictionary<Type, ServiceDescriptor> serviceDescriptors)
		{
			this.serviceDescriptors = serviceDescriptors;
		}

		public T GetService<T>()
		{
			return (T)GetService(typeof(T));
		}

		public object GetService(Type serviceType)
		{
			ServiceDescriptor serviceDescriptor;
			if (serviceDescriptors.TryGetValue(serviceType, out serviceDescriptor))
			{
				if (serviceDescriptor.Implementation != null)
					return serviceDescriptor.Implementation;


				var actualType = serviceDescriptor.ImplementationType ?? serviceDescriptor.ServiceType;
				if (actualType.IsAbstract || actualType.IsInterface)
					throw new Exception($"Cannot instantiate abstract classes or interfaces: [{serviceType.Name}]");


				var constructorInfo = actualType.GetConstructors().First();
				var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();


				var implementation = Activator.CreateInstance(actualType, parameters);
				if (serviceDescriptor.Lifetime == ServiceLifetime.Singleton)
					serviceDescriptor.Implementation = implementation;


				return implementation;
			}

			throw new Exception($"Service of type {serviceType.Name} isn't registered");
		}
	}
}
