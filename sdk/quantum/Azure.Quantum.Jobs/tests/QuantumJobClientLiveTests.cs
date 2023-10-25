// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Quantum.Jobs.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;
using Azure.Core.TestFramework.Models;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientLiveTests: RecordedTestBase<QuantumJobClientTestEnvironment>
    {
        public const string ZERO_UID = "00000000-0000-0000-0000-000000000000";
        public const string TENANT_ID = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        public const string PLACEHOLDER = "PLACEHOLDER";
        public const string RESOURCE_GROUP = "myresourcegroup";
        public const string WORKSPACE = "myworkspace";
        public const string LOCATION = "eastus";
        public const string STORAGE = "mystorage";

        public QuantumJobClientLiveTests(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..containerUri");
            JsonPathSanitizers.Add("$..inputDataUri");
            JsonPathSanitizers.Add("$..outputDataUri");
            JsonPathSanitizers.Add("$..sasUri");
            JsonPathSanitizers.Add("$..outputMappingBlobUri");
            JsonPathSanitizers.Add("$..containerUri");
            JsonPathSanitizers.Add("$..containerUri");
            JsonPathSanitizers.Add("$..containerUri");

            JsonPathSanitizers.Add("$..AZURE_QUANTUM_WORKSPACE_LOCATION");
            JsonPathSanitizers.Add("$..AZURE_QUANTUM_WORKSPACE_NAME");
            JsonPathSanitizers.Add("$..AZURE_QUANTUM_WORKSPACE_RG");

            var testEnvironment = new QuantumJobClientTestEnvironment();
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/resourceGroups/[a-z0-9-]+/", $"/resourceGroups/{RESOURCE_GROUP}/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/workspaces/[a-z0-9-]+/", $"/workspaces/{WORKSPACE}/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"https://[^\.]+.blob.core.windows.net/", $"https://{STORAGE}.blob.core.windows.net/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"https://[^\.]+.quantum.azure.com/", $"https://{LOCATION}.quantum.azure.com/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/workspaces/[a-z0-9-]+/", $"/workspaces/{WORKSPACE}/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/subscriptions/[a-z0-9-]+/", $"/subscriptions/{ZERO_UID}/"
            ));

            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private QuantumJobClient CreateClient()
        {
            var rawClient = new QuantumJobClient(
                TestEnvironment.SubscriptionId,
                TestEnvironment.WorkspaceResourceGroup,
                TestEnvironment.WorkspaceName,
                TestEnvironment.WorkspaceLocation,
                TestEnvironment.Credential,
                InstrumentClientOptions(new QuantumJobClientOptions()));

            return InstrumentClient(rawClient);
        }

        [RecordedTest]
        public async Task JobLifecycleTest()
        {
            var client = CreateClient();

            // Get container Uri with SAS key
            var containerName = "testcontainer";
            var containerUri = (await client.GetStorageSasUriAsync(
                new BlobDetails(containerName))).Value.SasUri;

            // Create container if not exists (if not in Playback mode)
            if (Mode != RecordedTestMode.Playback)
            {
                var containerClient = new BlobContainerClient(new Uri(containerUri));
                await containerClient.CreateIfNotExistsAsync();
            }

            // Get input data blob Uri with SAS key
            string blobName = $"input-{TestEnvironment.GetRandomId("BlobName")}.bc";
            var inputDataUri = (await client.GetStorageSasUriAsync(
                new BlobDetails("testcontainer")
                {
                    BlobName = blobName,
                })).Value.SasUri;

            // Upload QIR bitcode to blob storage (if not in Playback mode)
            if (Mode != RecordedTestMode.Playback)
            {
                var qirFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "BellState.bc");

                // Upload QIR bitcode to blob storage
                var blobClient = new BlobClient(new Uri(inputDataUri));
                var blobHeaders = new BlobHttpHeaders
                {
                    ContentType = "qir.v1"
                };
                var blobUploadOptions = new BlobUploadOptions { HttpHeaders = blobHeaders };
                using (FileStream qirFileStream = File.OpenRead(qirFilePath))
                {
                    await blobClient.UploadAsync(qirFileStream, options: blobUploadOptions);
                }
            }

            // Submit job
            var jobId = $"job-{TestEnvironment.GetRandomId("JobId")}";
            var jobName = $"jobName-{TestEnvironment.GetRandomId("JobName")}";
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
                OutputDataFormat = outputDataFormat,
                InputParams = inputParams,
            };
            var jobDetails = (await client.CreateJobAsync(jobId, createJobDetails)).Value;

            // Check if job was created correctly
            Assert.AreEqual(inputDataFormat, jobDetails.InputDataFormat);
            Assert.AreEqual(outputDataFormat, jobDetails.OutputDataFormat);
            Assert.AreEqual(providerId, jobDetails.ProviderId);
            Assert.AreEqual(target, jobDetails.Target);
            Assert.IsNotEmpty(jobDetails.Id);
            Assert.IsNotEmpty(jobDetails.Name);
            Assert.IsNotEmpty(jobDetails.InputDataUri);
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.IsTrue(jobDetails.Id.StartsWith("job-"));
                Assert.IsTrue(jobDetails.Name.StartsWith("jobName-"));
            }
            else
            {
                Assert.AreEqual(jobId, jobDetails.Id);
                Assert.AreEqual(jobName, jobDetails.Name);
                Assert.AreEqual(inputDataUri, jobDetails.InputDataUri);
            }

            // Get the job that we've just created based on the jobId
            var gotJob = (await client.GetJobAsync(jobId)).Value;
            Assert.AreEqual(jobDetails.InputDataFormat, gotJob.InputDataFormat);
            Assert.AreEqual(jobDetails.OutputDataFormat, gotJob.OutputDataFormat);
            Assert.AreEqual(jobDetails.ProviderId, gotJob.ProviderId);
            Assert.AreEqual(jobDetails.Target, gotJob.Target);
            Assert.AreEqual(jobDetails.Id, gotJob.Id);
            Assert.AreEqual(jobDetails.Name, gotJob.Name);
        }

        [RecordedTest]
        public async Task GetProviderStatusTest()
        {
            var client = CreateClient();

            int index = 0;
            await foreach (ProviderStatus status in client.GetProviderStatusAsync(CancellationToken.None))
            {
                Assert.IsNotEmpty(status.Id);
                Assert.IsNotNull(status.Targets);
                Assert.IsNotNull(status.CurrentAvailability);

                ++index;
            }

            // Should have at least one in the list.
            Assert.GreaterOrEqual(index, 1);
        }

        [RecordedTest]
        public async Task GetQuotasTest()
        {
            var client = CreateClient();

            int index = 0;
            await foreach (QuantumJobQuota quota in client.GetQuotasAsync(CancellationToken.None))
            {
                Assert.IsNotEmpty(quota.Dimension);
                Assert.IsNotNull(quota.Scope);
                Assert.IsNotEmpty(quota.ProviderId);
                Assert.IsNotNull(quota.Utilization);
                Assert.IsNotNull(quota.Holds);
                Assert.IsNotNull(quota.Period);
               ++index;
            }

            // Should have at least a couple in the list.
            Assert.GreaterOrEqual(index, 2);
        }
    }
}
