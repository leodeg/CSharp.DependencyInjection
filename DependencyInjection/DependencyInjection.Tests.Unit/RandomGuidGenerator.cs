using NUnit.Framework;
using DependencyInjection;
using System;

namespace DependencyInjection.Tests.Unit
{

	public class RandomGuidGenerator
	{
		public Guid RandomGuid { get; set; } = Guid.NewGuid();
	}
}