using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependencyInjection
{
	public enum ServiceLifetime
	{
		Transient = 0,
		Singleton = 1,
		Scoped = 2
	}
}
