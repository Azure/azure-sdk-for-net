// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests.Samples
{
    public partial class DeviceUpdateSamples : SamplesBase<DeviceUpdateClientTestEnvironment>
    {
        [Test]
        public void HelloWorld()
        {
            #region Snippet:AzDeviceUpdateSample1_CreateDeviceUpdateClient
#if SNIPPET
            Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
            string instanceId = "<instance-id>"
            TokenCredential credentials = new DefaultAzureCredential();
#else
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            TokenCredential credentials = TestEnvironment.Credential;
#endif
            DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateProviders
            Pageable<BinaryData> providers = client.GetProviders();
            foreach (var provider in providers)
            {
                JsonDocument doc = JsonDocument.Parse(provider.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateNames
#if SNIPPET
            string updateProvider = "<update-provider>";
#else
            string updateProvider = TestEnvironment.UpdateProvider;
#endif
            Pageable<BinaryData> names = client.GetNames(updateProvider);
            foreach (var name in names)
            {
                JsonDocument doc = JsonDocument.Parse(name.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateVersions
#if SNIPPET
            string updateName = "<update-name>";
#else
            string updateName = TestEnvironment.UpdateName;
#endif
            Pageable<BinaryData> versions = client.GetVersions(updateProvider, updateName);
            foreach (var version in versions)
            {
                JsonDocument doc = JsonDocument.Parse(version.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion
        }

        [Test]
        public async Task HelloWorldAsync()
        {
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            TokenCredential credentials = TestEnvironment.Credential;
            DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);

            #region Snippet:AzDeviceUpdateSample1_EnumerateProvidersAsync
            AsyncPageable<BinaryData> providers = client.GetProvidersAsync();
            await foreach (var provider in providers)
            {
                JsonDocument doc = JsonDocument.Parse(provider.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateNamesAsync
#if SNIPPET
            string updateProvider = "<update-provider>";
#else
            string updateProvider = TestEnvironment.UpdateProvider;
#endif
            AsyncPageable<BinaryData> names = client.GetNamesAsync(updateProvider);
            await foreach (var name in names)
            {
                JsonDocument doc = JsonDocument.Parse(name.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateVersionsAsync
#if SNIPPET
            string updateName = "<update-name>";
#else
            string updateName = TestEnvironment.UpdateName;
#endif
            AsyncPageable<BinaryData> versions = client.GetVersionsAsync(updateProvider, updateName);
            await foreach (var version in versions)
            {
                JsonDocument doc = JsonDocument.Parse(version.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion
        }
    }
}
