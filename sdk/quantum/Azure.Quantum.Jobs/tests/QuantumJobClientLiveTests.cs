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

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientLiveTests: RecordedTestBase<QuantumJobClientTestEnvironment>
    {
        public QuantumJobClientLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new QuantumJobClientRecordedTestSanitizer();

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
            string blobName = $"input-{TestEnvironment.GetRandomId("BlobName")}.json";
            var inputDataUri = (await client.GetStorageSasUriAsync(
                new BlobDetails("testcontainer")
                {
                    BlobName = blobName,
                })).Value.SasUri;

            // Upload input data to blob (if not in Playback mode)
            if (Mode != RecordedTestMode.Playback)
            {
                var problemFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "problem.json");

                using (var problemStreamToUpload = new MemoryStream())
                {
                    using (FileStream problemFileStream = File.OpenRead(problemFilePath))
                    {
                        using (var gzip = new GZipStream(problemStreamToUpload, CompressionMode.Compress, leaveOpen: true))
                        {
                            byte[] buffer = new byte[8192];
                            int count;
                            while ((count = problemFileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                gzip.Write(buffer, 0, count);
                            }
                        }
                    }

                    problemStreamToUpload.Position = 0;

                    // Upload input data to blob
                    var blobClient = new BlobClient(new Uri(inputDataUri));
                    var blobHeaders = new BlobHttpHeaders
                    {
                        ContentType = "application/json",
                        ContentEncoding = "gzip"
                    };
                    var blobUploadOptions = new BlobUploadOptions { HttpHeaders = blobHeaders };
                    blobClient.Upload(problemStreamToUpload, options: blobUploadOptions);
                }
            }

            // Submit job
            var jobId = $"job-{TestEnvironment.GetRandomId("JobId")}";
            var jobName = $"jobName-{TestEnvironment.GetRandomId("JobName")}";
            var inputDataFormat = "microsoft.qio.v2";
            var outputDataFormat = "microsoft.qio-results.v2";
            var providerId = "microsoft";
            var target = "microsoft.paralleltempering-parameterfree.cpu";
            var inputParams = new Dictionary<string, object>() { { "params", new Dictionary<string, object>() } };
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
