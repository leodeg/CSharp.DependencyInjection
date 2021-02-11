using NUnit.Framework;
using DependencyInjection;

namespace DependencyInjection.Tests.Unit
{
	public class DiServiceCollection_Tests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void RegisterSingleton_ServiceRegisteredWithImplementation_ReturnService()
		{
			var services = new DiServiceCollection();

			services.RegisterSingleton(new RandomGuidGenerator());

			var container = services.GenerateContainer();

			var service = container.GetService<RandomGuidGenerator>();
			var service2 = container.GetService<RandomGuidGenerator>();

			Assert.AreEqual(service, service2);
		}

		[Test]
		public void RegisterSingleton_ServiceRegisteredWithoutImplementation_ReturnService()
		{
			var services = new DiServiceCollection();

			services.RegisterSingleton<RandomGuidGenerator>();

			var container = services.GenerateContainer();

			var service = container.GetService<RandomGuidGenerator>();
			var service2 = container.GetService<RandomGuidGenerator>();

			Assert.AreEqual(service, service2);
		}

		[Test]
		public void RegisterTransient_ServiceRegisteredWithImplementation_ReturnSameServices()
		{
			var services = new DiServiceCollection();

			services.RegisterTransient(new RandomGuidGenerator());

			var container = services.GenerateContainer();

			var service = container.GetService<RandomGuidGenerator>();
			var service2 = container.GetService<RandomGuidGenerator>();

			Assert.AreEqual(service, service2);
		}

		[Test]
		public void RegisterTransient_ServiceRegisteredWithoutImplementation_ReturnDifferentServices()
		{
			var services = new DiServiceCollection();

			services.RegisterTransient<RandomGuidGenerator>();

			var container = services.GenerateContainer();

			var service = container.GetService<RandomGuidGenerator>();
			var service2 = container.GetService<RandomGuidGenerator>();

			Assert.AreNotEqual(service, service2);
		}
	}
}