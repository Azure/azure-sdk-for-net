// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
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
            var instanceId = "<instance-id>"
            var credentials = new DefaultAzureCredential();
#else
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            var credentials = TestEnvironment.Credential;
#endif
            var client = new DeviceUpdateClient(endpoint, instanceId, credentials);
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateProviders
            var providers = client.GetProviders();
            foreach (var provider in providers)
            {
                var doc = JsonDocument.Parse(provider.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateNames
#if SNIPPET
            string updateProvider = "<update-provider>";
#else
            string updateProvider = TestEnvironment.UpdateProvider;
#endif
            var names = client.GetNames(updateProvider);
            foreach (var name in names)
            {
                var doc = JsonDocument.Parse(name.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample1_EnumerateVersions
#if SNIPPET
            string updateName = "<update-name>";
#else
            string updateName = TestEnvironment.UpdateName;
#endif
            var versions = client.GetVersions(updateProvider, updateName);
            foreach (var version in versions)
            {
                var doc = JsonDocument.Parse(version.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion
        }
    }
}
