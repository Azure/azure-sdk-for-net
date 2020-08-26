// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Authentication;
using CommandLine;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Azure.Iot.Hub.Service.Samples
{
    public class Program
    {
        /// <summary>
        /// Main entry point to the sample.
        /// </summary>
        public static async Task Main(string[] args)
        {
            // Parse and validate parameters

            CommandLineOptions options = null;
            ParserResult<CommandLineOptions> result = Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(parsedOptions =>
                {
                    options = parsedOptions;
                })
                .WithNotParsed(errors =>
                {
                    Environment.Exit(1);
                });

            // Instantiate the client

            #region Snippet:IotHubServiceClientInitializeWithIotHubSasCredential

            // Create an IotHubSasCredential type to use sas tokens to authenticate against your IoT Hub instance.
            // The default lifespan of the sas token is 30 minutes, and it is set to be renewed when at 15% or less of its lifespan.
            var credential = new IotHubSasCredential(options.IotHubSharedAccessPolicy, options.IotHubSharedAccessKey);

            IotHubServiceClient hubClient = new IotHubServiceClient(options.Endpoint, credential);

            #endregion Snippet:IotHubServiceClientInitializeWithIotHubSasCredential

            // Run the samples

            var deviceIdentityLifecycleSamples = new DeviceIdentityLifecycleSamples(hubClient);
            await deviceIdentityLifecycleSamples.RunSampleAsync();

            var moduleIdentityLifecycleSamples = new ModuleIdentityLifecycleSamples(hubClient);
            await moduleIdentityLifecycleSamples.RunSampleAsync();

            var bulkDeviceIdentityLifecycleSamples = new BulkDeviceIdentityLifecycleSamples(hubClient);
            await bulkDeviceIdentityLifecycleSamples.RunSampleAsync();

            var bulkModuledentityLifecycleSamples = new BulkModuleIdentityLifecycleSamples(hubClient);
            await bulkModuledentityLifecycleSamples.RunSampleAsync();

            var querySamples = new QueryTwinSamples(hubClient);
            await querySamples.RunSampleAsync();

            var statisticsSample = new StatisticsSamples(hubClient);
            await statisticsSample.RunSampleAsync();

            // Get SAS token to 'jobs' container in the  storage account.
            Uri containerSasUri = await GetSasUriAsync(options.StorageAccountConnectionString, "jobs").ConfigureAwait(false);

            var jobsSample = new JobsSamples(hubClient, containerSasUri);
            await jobsSample.RunSampleAsync();

            // Run samples that require the device sample to be running.
            if (options.IsDeviceSampleRunning == true)
            {
                // This sample requires the device sample to be running so that it can connect to the device.
                var methodInvocationSamples = new MethodInvocationSamples(hubClient);
                await methodInvocationSamples.RunSampleAsync();
            }
        }

        private static async Task<Uri> GetSasUriAsync(string storageAccountConnectionString, string containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageAccountConnectionString);
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer CloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            await CloudBlobContainer.CreateIfNotExistsAsync().ConfigureAwait(false);

            Uri containerUri = CloudBlobContainer.Uri;
            var constraints = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Read
                    | SharedAccessBlobPermissions.Write
                    | SharedAccessBlobPermissions.Create
                    | SharedAccessBlobPermissions.List
                    | SharedAccessBlobPermissions.Add
                    | SharedAccessBlobPermissions.Delete,
                SharedAccessStartTime = DateTimeOffset.UtcNow,
            };

            string sasContainerToken = CloudBlobContainer.GetSharedAccessSignature(constraints);
            Uri sasUri = new Uri($"{containerUri}{sasContainerToken}");
            return sasUri;
        }
    }
}
