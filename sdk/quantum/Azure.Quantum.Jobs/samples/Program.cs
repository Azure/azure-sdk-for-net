// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Quantum.Jobs.Models;
using Azure.Storage.Blobs;
using Newtonsoft.Json;

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

            #region Snippet:Azure_Quantum_Jobs_UploadInputData
            // Get input data blob Uri with SAS key
            string blobName = $"myjobinput.json";
            var inputDataUri = (quantumJobClient.GetStorageSasUri(
                new BlobDetails(storageContainerName)
                {
                    BlobName = blobName,
                })).Value.SasUri;

            // Upload input data to blob
            var blobClient = new BlobClient(new Uri(inputDataUri));
            var problemFilename = "problem.json";
            blobClient.Upload(problemFilename, overwrite: true);
            #endregion

            Console.WriteLine($@"Input data Uri with SAS key:
    {inputDataUri}
");

            Console.WriteLine($@"Creating Quantum job...");

            #region Snippet:Azure_Quantum_Jobs_CreateJob
            // Submit job
            var jobId = $"job-{Guid.NewGuid():N}";
            var jobName = $"jobName-{Guid.NewGuid():N}";
            var inputDataFormat = "microsoft.qio.v2";
            var outputDataFormat = "microsoft.qio-results.v2";
            var providerId = "microsoft";
            var target = "microsoft.paralleltempering-parameterfree.cpu";
            var createJobDetails = new JobDetails(containerUri, inputDataFormat, providerId, target)
            {
                Id = jobId,
                InputDataUri = inputDataUri,
                Name = jobName,
                OutputDataFormat = outputDataFormat
            };
            JobDetails createdJob = (quantumJobClient.CreateJob(jobId, createJobDetails)).Value;
            #endregion

            Console.WriteLine($@"Job created:
    Id: {createdJob.Id}
    Name: {createdJob.Name}
    CreationTime: {createdJob.CreationTime}
    Status: {createdJob.Status}
");

            Console.WriteLine($@"Getting Quantum job...");

            #region Snippet:Azure_Quantum_Jobs_GetJob
            // Get the job that we've just created based on its jobId
            JobDetails myJob = (quantumJobClient.GetJob(jobId)).Value;
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
            // Get all jobs from the workspace (.ToList() will force all pages to be fetched)
            var allJobs = quantumJobClient.GetJobs().ToList();
            #endregion

            Console.WriteLine($"{allJobs.Count} jobs found. Listing the first 10...");
            foreach (JobDetails job in allJobs.Take(10))
            {
                Console.WriteLine($"  {job.Name}");
            }
            Console.WriteLine();

            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }

        private class AzLoginAccessTokenInfo : Core.TokenCredential
        {
            [JsonProperty("subscription")]
            public string SubscriptionId { get; set; }

            [JsonProperty("tenant")]
            public string TenantId { get; set; }

            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }

            [JsonProperty("expiresOn")]
            public DateTimeOffset ExpiresOn { get; set; }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken(AccessToken, ExpiresOn);
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(new AccessToken(AccessToken, ExpiresOn));
            }
        }

        private static AzLoginAccessTokenInfo GetAzLoginAccessTokenInfo()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (!isWindows)
            {
                return null;
            }

            var azProcess = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c az account get-access-token")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            azProcess.Start();
            azProcess.WaitForExit();
            var azProcessOutput = azProcess.StandardOutput.ReadToEnd();
            var accessTokenInfo = JsonConvert.DeserializeObject<AzLoginAccessTokenInfo>(azProcessOutput);
            return accessTokenInfo;
        }
    }
}
