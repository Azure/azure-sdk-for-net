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
    /// Device Update for IoT Hub Sample: Get update
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Device Update for IoT Hub Sample: Get update version
        /// </summary>
        /// <param name="updateVersion">Update version to retrieve.</param>
        static async Task Main(string updateVersion)
        {
            Console.WriteLine("Device Update for IoT Hub Sample: Get update version");
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(updateVersion))
            {
                throw new ArgumentException("You have to provider a valid update version.");
            }

            var credentials = new InteractiveBrowserCredential(Constant.TenantId, Constant.ClientId);
            var client = new DeviceUpdateClient(Constant.AccountEndpoint, Constant.Instance, credentials);

            Console.WriteLine("Retrieve update:");
            Console.WriteLine($"    Provider: {Constant.Provider}");
            Console.WriteLine($"    Name    : {Constant.Name}");
            Console.WriteLine($"    Version : {updateVersion}");

            Console.WriteLine();
            Console.WriteLine("Update content:");
            try
            {
                var response = await client.GetUpdateAsync(Constant.Provider, Constant.Name, updateVersion);
                Console.WriteLine(response.Content.ToString());
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine();
            Console.WriteLine("Update files:");
            try
            {
                var files = client.GetFilesAsync(Constant.Provider, Constant.Name, updateVersion);
                await foreach (var fileItem in files)
                {
                    var doc = JsonDocument.Parse(fileItem.ToMemory());
                    var file = await client.GetFileAsync(Constant.Provider, Constant.Name, updateVersion, doc.RootElement.GetString());
                    Console.WriteLine(file.Content.ToString());
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
