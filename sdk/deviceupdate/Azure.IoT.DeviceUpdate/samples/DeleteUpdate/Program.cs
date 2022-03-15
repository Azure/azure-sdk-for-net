// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.IoT.DeviceUpdate;

namespace Samples
{
    /// <summary>
    /// Device Update for IoT Hub Sample: Delete update
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Device Update for IoT Hub Sample: Delete update version
        /// </summary>
        /// <param name="updateVersion">Update version to delete.</param>
        static async Task Main(string updateVersion)
        {
            Console.WriteLine("Device Update for IoT Hub Sample: Delete update version");
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(updateVersion))
            {
                throw new ArgumentException("You have to provider a valid update version.");
            }

            var credentials = new InteractiveBrowserCredential(Constant.TenantId, Constant.ClientId);
            var client = new DeviceUpdateClient(Constant.AccountEndpoint, Constant.Instance, credentials);

            Console.WriteLine("Deleting update:");
            Console.WriteLine($"    Provider: {Constant.Provider}");
            Console.WriteLine($"    Name    : {Constant.Name}");
            Console.WriteLine($"    Version : {updateVersion}");

            try
            {
                var response = await client.DeleteUpdateAsync(true, Constant.Provider, Constant.Name, updateVersion);
                var doc = JsonDocument.Parse(response.Value.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("status").ToString());
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
