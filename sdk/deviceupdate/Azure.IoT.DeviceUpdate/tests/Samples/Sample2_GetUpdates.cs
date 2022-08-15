// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests.Samples
{
    public partial class DeviceUpdateSamples : SamplesBase<DeviceUpdateClientTestEnvironment>
    {
        [Test]
        public void GetUpdates()
        {
            #region Snippet:AzDeviceUpdateSample2_CreateDeviceUpdateClient
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

            #region Snippet:AzDeviceUpdateSample2_GetUpdate
#if SNIPPET
            string provider = "<update-provider>";
            string name = "<update-name>";
            string version = "<update-version>";
#else
            string provider = TestEnvironment.UpdateProvider;
            string name = TestEnvironment.UpdateName;
            string version = TestEnvironment.UpdateVersion;
#endif
            var response = client.GetUpdate(provider, name, version);
            Console.WriteLine(response.Content.ToString());
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFileIdentities
            var fileIds = client.GetFiles(provider, name, version);
            foreach (var fileId in fileIds)
            {
                var doc = JsonDocument.Parse(fileId.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFiles
            var files = client.GetFiles(provider, name, version);
            foreach (var file in files)
            {
                var doc = JsonDocument.Parse(file.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion
        }

        [Test]
        public async Task GetUpdatesAsync()
        {
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            var credentials = TestEnvironment.Credential;
            var client = new DeviceUpdateClient(endpoint, instanceId, credentials);

            #region Snippet:AzDeviceUpdateSample2_GetUpdateAsync
#if SNIPPET
            string provider = "<update-provider>";
            string name = "<update-name>";
            string version = "<update-version>";
#else
            string provider = TestEnvironment.UpdateProvider;
            string name = TestEnvironment.UpdateName;
            string version = TestEnvironment.UpdateVersion;
#endif
            var response = await client.GetUpdateAsync(provider, name, version);
            Console.WriteLine(response.Content.ToString());
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFileIdentitiesAsync
            var fileIds = client.GetFilesAsync(provider, name, version);
            await foreach (var fileId in fileIds)
            {
                var doc = JsonDocument.Parse(fileId.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFilesAsync
            var files = client.GetFilesAsync(provider, name, version);
            await foreach (var file in files)
            {
                var doc = JsonDocument.Parse(file.ToMemory());
                Console.WriteLine(doc.RootElement.GetString());
            }
            #endregion
        }
    }
}
