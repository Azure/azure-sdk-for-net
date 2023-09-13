// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Identity;
using Azure.Quantum.Jobs.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Azure.Quantum.Jobs.Samples
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            #region Snippet:Azure_Quantum_Jobs_CreateClient
            // Create a QuantumJobClient
            var subscriptionId = "your_subscription_id";
            var resourceGroupName = "your_resource_group_name";
            var workspaceName = "your_quantum_workspace_name";
            var location = "your_location";
            var storageContainerName = "your_container_name";

            var credential = new DefaultAzureCredential(true);

            var quantumJobClient =
                new QuantumJobClient(
                    subscriptionId,
                    resourceGroupName,
                    workspaceName,
                    location,
                    credential);
            #endregion

            Console.WriteLine($@"Created QuantumJobClient for:
    SubscriptionId: {subscriptionId}
    ResourceGroup: {resourceGroupName}
    workspaceName: {workspaceName}
    location: {location}
");

            Console.WriteLine($@"Getting Container Uri with SAS key...");

            #region Snippet:Azure_Quantum_Jobs_GetContainerSasUri
            // Get container Uri with SAS key
            var containerUri = (quantumJobClient.GetStorageSasUri(
                new BlobDetails(storageContainerName))).Value.SasUri;
            #endregion

            Console.WriteLine($@"Container Uri with SAS key:
    {containerUri}
");

            Console.WriteLine($@"Creating Container if not exist...");

            // Create container if not exists
            var containerClient = new BlobContainerClient(new Uri(containerUri));
            containerClient.CreateIfNotExists();

            Console.WriteLine($@"Uploading data into a blob...");

            #region Snippet:Azure_Quantum_Jobs_UploadQIRBitCode
            string qirFilePath = "./BellState.bc";

            // Get input data blob Uri with SAS key
            string blobName = Path.GetFileName(qirFilePath);
            var inputDataUri = (quantumJobClient.GetStorageSasUri(
                new BlobDetails(storageContainerName)
                {
                    BlobName = blobName,
                })).Value.SasUri;

            // Upload QIR bitcode to blob storage
            var blobClient = new BlobClient(new Uri(inputDataUri));
            var blobHeaders = new BlobHttpHeaders
            {
                ContentType = "qir.v1"
            };
            var blobUploadOptions = new BlobUploadOptions { HttpHeaders = blobHeaders };
            using (FileStream qirFileStream = File.OpenRead(qirFilePath))
            {
                blobClient.Upload(qirFileStream, options: blobUploadOptions);
            }
            #endregion

            Console.WriteLine($@"Input data Uri with SAS key:
    {inputDataUri}
");

            Console.WriteLine($@"Creating Quantum job...");

            #region Snippet:Azure_Quantum_Jobs_CreateJob
            // Submit job
            var jobId = $"job-{Guid.NewGuid():N}";
            var jobName = $"jobName-{Guid.NewGuid():N}";
            var inputDataFormat = "qir.v1";
            var outputDataFormat = "microsoft.quantum-results.v1";
            var providerId = "quantinuum";
            var target = "quantinuum.sim.h1-1e";
            var inputParams = new Dictionary<string, object>()
            {
                { "entryPoint", "ENTRYPOINT__BellState" },
                { "arguments", new string[] { } },
                { "targetCapability", "AdaptiveExecution" },
            };
            var createJobDetails = new JobDetails(containerUri, inputDataFormat, providerId, target)
            {
                Id = jobId,
                InputDataUri = inputDataUri,
                Name = jobName,
                InputParams = inputParams,
                OutputDataFormat = outputDataFormat
            };

            JobDetails myJob = (quantumJobClient.CreateJob(jobId, createJobDetails)).Value;
            #endregion

            Console.WriteLine($@"Job created:
    Id: {myJob.Id}
    Name: {myJob.Name}
    CreationTime: {myJob.CreationTime}
    Status: {myJob.Status}
");

            Console.WriteLine($@"Awaiting job to complete...");
            while (myJob.Status == JobStatus.Waiting ||
                   myJob.Status == JobStatus.Executing)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                myJob = (quantumJobClient.GetJob(jobId)).Value;
                Console.WriteLine($@"Job status: {myJob.Status}");
            }
            if (myJob.Status == JobStatus.Failed)
            {
                Console.WriteLine($@"Job has failed with error: {myJob.ErrorData.Message}");
            }

            Console.WriteLine($@"Getting Quantum job...");

            #region Snippet:Azure_Quantum_Jobs_GetJob
            // Get the job that we've just created based on its jobId
            myJob = (quantumJobClient.GetJob(jobId)).Value;
            #endregion

            Console.WriteLine($@"Job obtained:
    Id: {myJob.Id}
    Name: {myJob.Name}
    CreationTime: {myJob.CreationTime}
    Status: {myJob.Status}
    BeginExecutionTime: {myJob.BeginExecutionTime}
    EndExecutionTime: {myJob.EndExecutionTime}
    CancellationTime: {myJob.CancellationTime}
    OutputDataFormat: {myJob.OutputDataFormat}
    OutputDataUri: {myJob.OutputDataUri}
");

            Console.WriteLine($@"Getting list of Quantum jobs...");

            #region Snippet:Azure_Quantum_Jobs_GetJobs
            foreach (JobDetails job in quantumJobClient.GetJobs())
            {
               Console.WriteLine($"{job.Name}");
            }
            #endregion

            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}
