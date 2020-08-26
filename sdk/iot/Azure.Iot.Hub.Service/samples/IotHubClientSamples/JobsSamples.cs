// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample shows how to start the import and export jobs and check their status.
    /// </summary>
    internal class JobsSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();
        public readonly Uri ContainerSasUri;

        public JobsSamples(IotHubServiceClient client, Uri containerSasUri)
        {
            IoTHubServiceClient = client;
            ContainerSasUri = containerSasUri;
        }

        public async Task RunSampleAsync()
        {
            // Create import or export job.
            Response<JobProperties> importResponse = await CreateExportJobAsync();

            // Get import export job to check status.
            await WaitForJobCompletionAsync(importResponse.Value.JobId);

            // Create import or export job.
            Response<JobProperties> exportResponse = await CreateImportJobAsync();

            // Get import export job to check status.
            await WaitForJobCompletionAsync(exportResponse.Value.JobId);
        }

        /// <summary>
        /// Starts an import job to get devices from storage to IoTHub.
        /// </summary>
        private async Task<Response<JobProperties>> CreateImportJobAsync()
        {
            try
            {
                #region Snippet:IotHubImportJob

                SampleLogger.PrintHeader("START IMPORT JOB");

                //Import all devices from storage to create and provision devices on the IoTHub.
                Response<JobProperties> response = await IoTHubServiceClient.Jobs
                .CreateImportDevicesJobAsync(importBlobContainerUri: ContainerSasUri, outputBlobContainerUri: ContainerSasUri);

                SampleLogger.PrintSuccess($"Successfully started import job {response.Value.JobId}.");

                return response;

                #endregion Snippet:IotHubImportJob
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to start import job due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Starts an export job to store devices in IoTHub to storage.
        /// </summary>
        private async Task<Response<JobProperties>> CreateExportJobAsync()
        {
            try
            {
                #region Snippet:IotHubExportJob

                SampleLogger.PrintHeader("START EXPORT JOB");

                //Import all devices from storage to create and provision devices on the IoTHub.
                Response<JobProperties> response = await IoTHubServiceClient.Jobs
                .CreateExportDevicesJobAsync(outputBlobContainerUri: ContainerSasUri, excludeKeys: false);

                SampleLogger.PrintSuccess($"Successfully started export job {response.Value.JobId}.");

                return response;

                #endregion Snippet:IotHubExportJob
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to start export job due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Gets the status of an import or export job.
        /// </summary>
        private async Task<Response<JobProperties>> WaitForJobCompletionAsync(string jobId)
        {
            Response<JobProperties> response;

            try
            {
                // Wait for job to complete.
                do
                {
                    #region Snippet:GetImportExportJob

                    SampleLogger.PrintHeader("GET IMPORT/EXPORT JOB STATUS");

                    response = await IoTHubServiceClient.Jobs.GetImportExportJobAsync(jobId);
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    SampleLogger.PrintSuccess($"Job status is - {response.Value.Status}.");

                    #endregion Snippet:GetImportExportJob
                } while (!IsTerminalStatus(response.Value.Status));
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to get status of import export job due to:\n{ex}");
                throw;
            }

            return response;
        }

        private bool IsTerminalStatus(JobPropertiesStatus? status)
        {
            return status == JobPropertiesStatus.Completed
                || status == JobPropertiesStatus.Failed
                || status == JobPropertiesStatus.Cancelled;
        }
    }
}
