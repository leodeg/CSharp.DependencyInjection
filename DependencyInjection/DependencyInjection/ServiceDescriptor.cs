using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependencyInjection
{
	public class ServiceDescriptor
	{
		public Type ServiceType { get; }
		public Type ImplementationType { get; }
		public object Implementation { get; internal set; }
		public ServiceLifetime Lifetime { get; }

		public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
		{
			ServiceType = serviceType;
			ImplementationType = implementationType;
			Lifetime = lifetime;
		}

		public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
		{
			ServiceType = implementation.GetType();
			Implementation = implementation;
			Lifetime = lifetime;
		}

		public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
		{
			ServiceType = serviceType;
			Lifetime = lifetime;
		}
	}
}
