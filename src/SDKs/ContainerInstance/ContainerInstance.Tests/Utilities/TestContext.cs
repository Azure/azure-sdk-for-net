using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace ContainerInstance.Tests
{
	class TestContext : IDisposable
	{
		public const string DefaultTestPrefix = "defaulttestprefix-";
		public const string DefaultResourceGroupPrefix = "testresourcegroup-";
		public const string DefaultLocationId = "japaneast";
		public const string DefaultLocation = "Japan East";

		private readonly MockContext _mockContext;
		private readonly Dictionary<Type, IDisposable> _serviceClientCache = new Dictionary<Type, IDisposable>();
		private readonly List<ResourceGroup> _resourceGroups = new List<ResourceGroup>();
		private bool _disposedValue = false; // To detect redundant calls

		public TestContext(
			object suiteObject,
			[CallerMemberName]
			string testName="error_determining_test_name")
		{
			_mockContext = MockContext.Start(suiteObject.GetType().FullName, testName);
		}

		public TServiceClient GetClient<TServiceClient>() where TServiceClient : class, IDisposable
		{
			if (_serviceClientCache.TryGetValue(typeof(TServiceClient), out IDisposable clientObject))
			{
				return (TServiceClient)clientObject;
			}

			TServiceClient client = _mockContext.GetServiceClient<TServiceClient>();
			_serviceClientCache.Add(typeof(TServiceClient), client);
			return client;
		}

		public ResourceGroup CreateResourceGroup(string prefix = DefaultResourceGroupPrefix, string location = DefaultLocationId)
		{
			ResourceManagementClient resourceClient = GetClient<ResourceManagementClient>();

			string rgName = GenerateName(prefix);
			ResourceGroup resourceGroup = resourceClient.ResourceGroups.CreateOrUpdate(rgName,
				new ResourceGroup
				{
					Location = location,
					Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
				});

			_resourceGroups.Add(resourceGroup);

			return resourceGroup;
		}

		public string GenerateName(string prefix = DefaultTestPrefix, [CallerMemberName] string methodName="GenerateName_failed")
		{
			try
			{
				return HttpMockServer.GetAssetName(methodName, prefix);
			}
			catch (KeyNotFoundException e)
			{
				throw new KeyNotFoundException(string.Format("Generated name not found for calling method: {0}", methodName), e);
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					// Begin deleting resource groups
					ResourceManagementClient resourceClient = GetClient<ResourceManagementClient>();
					_resourceGroups.ForEach(rg => resourceClient.ResourceGroups.BeginDelete(rg.Name));

					// Dispose clients
					foreach (IDisposable client in _serviceClientCache.Values)
					{
						client.Dispose();
					}

					// Dispose context
					_mockContext.Dispose();
				}
				_disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
}
