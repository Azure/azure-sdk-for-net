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
    /// Device Update for IoT Hub Sample: Enumerate updates
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Device Update for IoT Hub Sample: Enumerate updates
        /// </summary>
        static async Task Main()
        {
            Console.WriteLine("Device Update for IoT Hub Sample: Enumerate updates");
            Console.WriteLine();

            var credentials = new InteractiveBrowserCredential(Constant.TenantId, Constant.ClientId);
            var client = new DeviceUpdateClient(Constant.AccountEndpoint, Constant.Instance, credentials);

            Console.WriteLine($"Provider: {Constant.Provider}");
            Console.WriteLine($"Name    : {Constant.Name}");
            Console.WriteLine($"Versions: ");
            try
            {
                var response = client.GetVersionsAsync(Constant.Provider, Constant.Name);
                await foreach (var version in response)
                {
                    var versionDoc = JsonDocument.Parse(version.ToMemory());
                    Console.WriteLine("\t" + versionDoc.RootElement.GetString());
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
