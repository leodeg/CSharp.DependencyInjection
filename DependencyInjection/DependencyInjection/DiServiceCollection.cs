using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependencyInjection
{
	public class DiServiceCollection
	{
		private Dictionary<Type, ServiceDescriptor> serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

		public void RegisterSingleton<T>()
		{
			serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), ServiceLifetime.Singleton));
		}

		public void RegisterSingleton<TService>(TService implementation)
		{
			serviceDescriptors.Add(implementation.GetType(), new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
		}

		public void RegisterSingleton<TService, TImplementation>(TService service, TImplementation implementation) where TImplementation : TService
		{
			serviceDescriptors.Add(service.GetType(), new ServiceDescriptor(service.GetType(), implementation.GetType(), ServiceLifetime.Singleton));
		}

		public void RegisterTransient<T>()
		{
			serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), ServiceLifetime.Transient));
		}

		public void RegisterTransient<TService>(TService implementation)
		{
			serviceDescriptors.Add(implementation.GetType(), new ServiceDescriptor(implementation, ServiceLifetime.Transient));
		}

		public void RegisterTransient<TService, TImplementation>(TService service, TImplementation implementation) where TImplementation : TService
		{
			serviceDescriptors.Add(service.GetType(), new ServiceDescriptor(service.GetType(), implementation.GetType(), ServiceLifetime.Transient));
		}

		public DiContainer GenerateContainer()
		{
			return new DiContainer(serviceDescriptors);
		}
	}
}
