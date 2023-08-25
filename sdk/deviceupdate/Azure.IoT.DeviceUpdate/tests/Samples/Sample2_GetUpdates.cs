// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public void GetUpdates()
        {
            #region Snippet:AzDeviceUpdateSample2_CreateDeviceUpdateClient
#if SNIPPET
            Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
            string instanceId = "<instance-id>";
            TokenCredential credentials = new DefaultAzureCredential();
#else
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            TokenCredential credentials = TestEnvironment.Credential;
#endif
            DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);
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
            Response response = client.GetUpdate(provider, name, version);
            JsonDocument update = JsonDocument.Parse(response.Content.ToMemory());
            Console.WriteLine("Update:");
            Console.WriteLine($"  Provider: {update.RootElement.GetProperty("updateId").GetProperty("provider").GetString()}");
            Console.WriteLine($"  Name: {update.RootElement.GetProperty("updateId").GetProperty("name").GetString()}");
            Console.WriteLine($"  Version: {update.RootElement.GetProperty("updateId").GetProperty("version").GetString()}");
            Console.WriteLine("Metadata:");
            Console.WriteLine(update.RootElement.ToString());
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFileIdentities
            Pageable<BinaryData> fileIds = client.GetFiles(provider, name, version);
            List<string> files = new List<string>();
            foreach (var fileId in fileIds)
            {
                JsonDocument doc = JsonDocument.Parse(fileId.ToMemory());
                files.Add(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFiles
            foreach (var file in files)
            {
                Console.WriteLine("\nFile:");
                Console.WriteLine($"  FileId: {file}");
                Response fileResponse = client.GetFile(provider, name, version, file);
                JsonDocument fileDoc = JsonDocument.Parse(fileResponse.Content.ToMemory());
                Console.WriteLine("Metadata:");
                Console.WriteLine(fileDoc.RootElement.ToString());
            }
            #endregion
        }

        [Test]
        public async Task GetUpdatesAsync()
        {
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            TokenCredential credentials = TestEnvironment.Credential;
            DeviceUpdateClient client = new DeviceUpdateClient(endpoint, instanceId, credentials);

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
            Response response = await client.GetUpdateAsync(provider, name, version);
            JsonDocument update = JsonDocument.Parse(response.Content.ToMemory());
            Console.WriteLine("Update:");
            Console.WriteLine($"  Provider: {update.RootElement.GetProperty("updateId").GetProperty("provider").GetString()}");
            Console.WriteLine($"  Name: {update.RootElement.GetProperty("updateId").GetProperty("name").GetString()}");
            Console.WriteLine($"  Version: {update.RootElement.GetProperty("updateId").GetProperty("version").GetString()}");
            Console.WriteLine("Metadata:");
            Console.WriteLine(update.RootElement.ToString());
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFileIdentitiesAsync
            AsyncPageable<BinaryData> fileIds = client.GetFilesAsync(provider, name, version);
            List<string> files = new List<string>();
            await foreach (var fileId in fileIds)
            {
                JsonDocument doc = JsonDocument.Parse(fileId.ToMemory());
                files.Add(doc.RootElement.GetString());
            }
            #endregion

            #region Snippet:AzDeviceUpdateSample2_EnumerateUpdateFilesAsync
            foreach (var file in files)
            {
                Console.WriteLine("\nFile:");
                Console.WriteLine($"  FileId: {file}");
                Response fileResponse = await client.GetFileAsync(provider, name, version, file);
                JsonDocument fileDoc = JsonDocument.Parse(fileResponse.Content.ToMemory());
                Console.WriteLine("Metadata:");
                Console.WriteLine(fileDoc.RootElement.ToString());
            }
            #endregion
        }
    }
}
