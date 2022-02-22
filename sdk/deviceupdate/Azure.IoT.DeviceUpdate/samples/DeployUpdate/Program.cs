// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.IoT.DeviceUpdate;

namespace Samples
{
    /// <summary>
    /// Device Update for IoT Hub Sample: Deploy update to a test device
    /// </summary>
    internal class Program
    {
        private const int DefaultRetryAfterValue = 5000;

        /// <summary>
        /// Device Update for IoT Hub Sample: Deploy update to a test device
        /// </summary>
        /// <param name="updateVersion">Update version to retrieve.</param>
        /// <param name="deviceGroup">Device group to deploy the update to.</param>
        static async Task Main(string updateVersion, string deviceGroup)
        {
            Console.WriteLine("Device Update for IoT Hub Sample: Deploy update to a test device");
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(updateVersion))
            {
                throw new ArgumentException("You have to provider a valid update version.");
            }

            var credentials = new InteractiveBrowserCredential(Constant.TenantId, Constant.ClientId);
            var client = new DeviceManagementClient(Constant.AccountEndpoint, Constant.Instance, credentials);

            Console.WriteLine("Retrieve update:");
            Console.WriteLine($"    Provider: {Constant.Provider}");
            Console.WriteLine($"    Name    : {Constant.Name}");
            Console.WriteLine($"    Version : {updateVersion}");

            Console.WriteLine();
            Console.WriteLine($"Checking existence of device group '{deviceGroup}'...");
            try
            {
                var response = await client.GetGroupAsync(deviceGroup);
                if (response.Status == (int)HttpStatusCode.NotFound)
                {
                    throw new ApplicationException($"Group '{deviceGroup}' doesn't exist. Create it before you create a deployment.");
                }
                Console.WriteLine($"Group '{deviceGroup}' already exists.");
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine();
            Console.WriteLine($"Creating deployment of update '{updateVersion}' to device group '{deviceGroup}'...");
            var deploymentId = $"test{DateTime.UtcNow.ToString("MMddhhmmss")}";
            var deployment = new
            {
                deploymentId,
                startDateTime = DateTime.UtcNow.ToString("O"),
                groupId = deviceGroup,
                updateId = new
                {
                    manufacturer = Constant.Provider,
                    name = Constant.Name,
                    version = updateVersion
                }
            };
            var body = JsonSerializer.Serialize(deployment);

            Console.WriteLine();
            Console.WriteLine($"Deploying update '{updateVersion}' to device group '{deviceGroup}'...");
            Console.WriteLine($"(this may take a long time to finish)");
            try
            {
                var response = await client.CreateOrUpdateDeploymentAsync(deviceGroup, deploymentId, RequestContent.Create(body));

                bool repeat = true;
                while (repeat)
                {
                    response = await client.GetDeploymentStatusAsync(deviceGroup, deploymentId);
                    var doc = JsonDocument.Parse(response.Content.ToMemory());
                    if (doc.RootElement.TryGetProperty("devicesCompletedSucceededCount", out var deviceCountValue) && deviceCountValue.GetInt32() > 0)
                    {
                        Console.WriteLine($"\nSuccessfully deployed to {deviceCountValue.GetInt32()} devices.");
                        repeat = false;
                    }
                    else
                    {
                        Console.Write(".");
                        await Task.Delay(DefaultRetryAfterValue);
                    }
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
