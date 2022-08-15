// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Net;
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
        public void GetDevice()
        {
            #region Snippet:AzDeviceUpdateSample5_CreateDeviceManagementClient

#if SNIPPET
            Uri endpoint = new Uri("https://<account-id>.api.adu.microsoft.com");
            var instanceId = "<instance-id>"
            var credentials = new DefaultAzureCredential();
#else
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            var credentials = TestEnvironment.Credential;
#endif
            var client = new DeviceManagementClient(endpoint, instanceId, credentials);

            #endregion

            #region Snippet:AzDeviceUpdateSample5_EnumerateDevices

            var devices = client.GetDevices();
            foreach (var device in devices)
            {
                var doc = JsonDocument.Parse(device.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("deviceId").GetString());
            }

            #endregion

            #region Snippet:AzDeviceUpdateSample5_EnumerateGroups

            var groups = client.GetGroups();
            foreach (var group in groups)
            {
                var doc = JsonDocument.Parse(group.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("groupId").GetString());
            }

            #endregion

            #region Snippet:AzDeviceUpdateSample5_EnumerateDeviceClasses

            var deviceClasses = client.GetDeviceClasses();
            foreach (var deviceClass in deviceClasses)
            {
                var doc = JsonDocument.Parse(deviceClass.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("deviceClassId").GetString());
            }

            #endregion

            #region Snippet:AzDeviceUpdateSample5_GetBestUpdates

#if SNIPPET
            string groupId = "<group-id>";
#else
            string groupId = TestEnvironment.DeviceGroup;
#endif
            var updates = client.GetBestUpdatesForGroups(groupId);
            foreach (var update in updates)
            {
                var e = JsonDocument.Parse(update.ToMemory()).RootElement;
                Console.WriteLine($"For device class '{e.GetProperty("deviceClassId").GetString()}' in group '{groupId}', the best update is:");
                e = e.GetProperty("update").GetProperty("updateId");
                Console.WriteLine(e.GetProperty("provider").GetString());
                Console.WriteLine(e.GetProperty("name").GetString());
                Console.WriteLine(e.GetProperty("version").GetString());
            }

            #endregion
        }

        [Test]
        public async Task GetDeviceAsync()
        {
            Uri endpoint = TestEnvironment.AccountEndPoint;
            string instanceId = TestEnvironment.InstanceId;
            var credentials = TestEnvironment.Credential;
            var client = new DeviceManagementClient(endpoint, instanceId, credentials);

            #region Snippet:AzDeviceUpdateSample5_EnumerateDevicesAsync

            var devices = client.GetDevicesAsync();
            await foreach (var device in devices)
            {
                var doc = JsonDocument.Parse(device.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("deviceId").GetString());
            }

            #endregion

            #region Snippet:AzDeviceUpdateSample5_EnumerateGroupsAsync

            var groups = client.GetGroupsAsync();
            await foreach (var group in groups)
            {
                var doc = JsonDocument.Parse(group.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("groupId").GetString());
            }

            #endregion

            #region Snippet:AzDeviceUpdateSample5_EnumerateDeviceClassesAsync

            var deviceClasses = client.GetDeviceClassesAsync();
            await foreach (var deviceClass in deviceClasses)
            {
                var doc = JsonDocument.Parse(deviceClass.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("deviceClassId").GetString());
            }

            #endregion

            #region Snippet:AzDeviceUpdateSample5_GetBestUpdatesAsync

#if SNIPPET
            string groupId = "<group-id>";
#else
            string groupId = TestEnvironment.DeviceGroup;
#endif
            var updates = client.GetBestUpdatesForGroupsAsync(groupId);
            await foreach (var update in updates)
            {
                var e = JsonDocument.Parse(update.ToMemory()).RootElement;
                Console.WriteLine($"For device class '{e.GetProperty("deviceClassId").GetString()}' in group '{groupId}', the best update is:");
                e = e.GetProperty("update").GetProperty("updateId");
                Console.WriteLine(e.GetProperty("provider").GetString());
                Console.WriteLine(e.GetProperty("name").GetString());
                Console.WriteLine(e.GetProperty("version").GetString());
            }

            #endregion
        }
    }
}
