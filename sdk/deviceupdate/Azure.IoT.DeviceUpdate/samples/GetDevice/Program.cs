// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.IoT.DeviceUpdate;

namespace Samples
{
    /// <summary>
    /// Device Update for IoT Hub Sample: Get device
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Device Update for IoT Hub Sample: Get device
        /// </summary>
        /// <param name="device">Device identifier.</param>
        static async Task Main(string device)
        {
            Console.WriteLine("Device Update for IoT Hub Sample: Get device");
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(device))
            {
                throw new ArgumentException("You have to provider a valid device identifier.");
            }

            var credentials = new InteractiveBrowserCredential(Constant.TenantId, Constant.ClientId);
            var client = new DeviceManagementClient(Constant.AccountEndpoint, Constant.Instance, credentials);

            Console.WriteLine("Retrieve device information:");
            Console.WriteLine($"    Device: {device}");

            Console.WriteLine();
            Console.WriteLine("Information:");
            try
            {
                var response = await client.GetDeviceAsync(device);
                Console.WriteLine(response.Content.ToString());
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
