// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core;
using Azure.DigitalTwins.Core.Samples;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Samples
{
    internal class JobLifecycleSamples
    {
        /// <summary>
        /// Creates a new model with a random Id
        /// Decommission the newly created model and check for success
        /// </summary>
        public async Task RunSamplesAsync(DigitalTwinsClient client, Options options)
        {
            PrintHeader("JOB LIFECYCLE SAMPLE");

            // For the purpose of this example we will create an import job to import models, twins, and relationships.
            // We have to make sure the job Id is unique within the DT instance, and we have to upload a sample input blob to the customer's storage container.

            string sampleImportJobId = await GetUniqueJobIdAsync(SamplesConstants.TemporaryJobPrefix, client);
            Uri inputBlobUri = new Uri(options.StorageAccountContainerEndpoint + "/" + options.InputBlobName);
            Uri outputBlobUri = new Uri(options.StorageAccountContainerEndpoint + "/sampleOutputBlob.ndjson");

            ImportJob sampleImportJob = new ImportJob(inputBlobUri, outputBlobUri);

            try
            {
                await ImportJobHelper.UploadInputBlobToStorageContainerAsync(options).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                FatalError($"Failed to upload input blob to storage container due to:\n{ex}");
            }

            // Then we create the import job
            try
            {
                #region Snippet:DigitalTwinsSampleCreateImportJob

                await client.ImportGraphAsync(sampleImportJobId, sampleImportJob);
                Console.WriteLine($"Created jobs '{sampleImportJobId}' and '{sampleImportJob}'.");

                #endregion Snippet:DigitalTwinsSampleCreateImportJob
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                Console.WriteLine($"Job with id {sampleImportJobId} already existed.");
            }
            catch (Exception ex)
            {
                FatalError($"Failed to create job due to:\n{ex}");
            }

            // Get Job
            try
            {
                #region Snippet:DigitalTwinsSampleGetImportJob

                Response<ImportJob> sampleImportJobResponse = await client.GetImportJobAsync(sampleImportJobId);
                Console.WriteLine($"Retrieved job '{sampleImportJobResponse.Value.Id}'.");

                #endregion Snippet:DigitalTwinsSampleGetImportJob
            }
            catch (Exception ex)
            {
                FatalError($"Failed to get an import job due to:\n{ex}");
            }

            // Now we cancel the job

            #region Snippet:DigitalTwinsSampleCancelImportJob

            try
            {
                await client.CancelImportJobAsync(sampleImportJobId);
                Console.WriteLine($"Cancelled job '{sampleImportJobId}'.");
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to cancel import job '{sampleImportJobId}' due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleCancelImportJob

            // Now we delete the job

            #region Snippet:DigitalTwinsSampleDeleteImportJob

            try
            {
                await client.DeleteImportJobAsync(sampleImportJobId);
                Console.WriteLine($"Deleted job '{sampleImportJobId}'.");
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to delete import job '{sampleImportJobId}' due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDeleteImportJob
        }
    }
}
