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
            // We have to make sure the job Id is unique within the DT instance.

            string sampleImportJobId = await GetUniqueJobIdAsync(SamplesConstants.TemporaryJobPrefix, client);

            // upload a sample file to their storage blob? or should we require that they already have one uploaded and provide the name of the file as input?

            ImportJob sampleImportJob = new ImportJob(options.StorageAccountEndpoint + "/sampleInputBlob.ndjson", options.StorageAccountEndpoint + "/sampleOutputBlob.ndjson");

            // Then we create the import job
            try
            {
                #region Snippet:DigitalTwinsSampleCreateImportJob

                await client.CreateImportJobsAsync(sampleImportJobId, sampleImportJob);
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

                Response<ImportJob> sampleImportJobResponse = await client.GetImportJobsByIdAsync(sampleImportJobId);
                Console.WriteLine($"Retrieved job '{sampleImportJobResponse.Value.Id}'.");

                #endregion Snippet:DigitalTwinsSampleGetImportJob
            }
            catch (Exception ex)
            {
                FatalError($"Failed to get a model due to:\n{ex}");
            }

            // Now we cancel the job

            #region Snippet:DigitalTwinsSampleCancelImportJob

            try
            {
                await client.CancelImportJobsAsync(sampleImportJobId);
                Console.WriteLine($"Cancelled job '{sampleImportJobId}'.");
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to cancel job '{sampleImportJobId}' due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleCancelImportJob

            // Now we delete the job

            #region Snippet:DigitalTwinsSampleDeleteImportJob

            try
            {
                await client.DeleteImportJobsAsync(sampleImportJobId);
                Console.WriteLine($"Deleted job '{sampleImportJobId}'.");
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to delete job '{sampleImportJobId}' due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDeleteImportJob
        }
    }
}
