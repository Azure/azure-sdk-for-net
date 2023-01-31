// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinServiceClient methods dealing with Digital Twin operations.
    /// </summary>
    public class BulkTests : E2eTestBase
    {
        public BulkTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Bulk_Valid_Success()
        {
            DigitalTwinsClient client = GetClient();

            // TODO: Get Uris from env variables
            string jobId = await GetUniqueJobIdAsync(client, TestAssetDefaults.JobId).ConfigureAwait(false);
            var inputBlobUri = "https://bulksdktest.blob.core.windows.net/bulksdktest/bulkInputBlobSdkTest.ndjson";
            var outputBlobUri = "https://bulksdktest.blob.core.windows.net/bulksdktest/output.ndjson";
            var importJob = new BulkImportJob(inputBlobUri, outputBlobUri);

            try
            {
                // CREATE job
                var createResponse = await client.CreateImportJobsAsync(jobId, importJob).ConfigureAwait(false);
                Assert.IsNotNull(createResponse);
                Assert.AreEqual(ImportJobStatus.Notstarted, createResponse.Value.Status);

                // wait a bit for job to complete?

                // GET job - check for success
                var getSucceededResponse = await client.GetImportJobsByIdAsync(jobId).ConfigureAwait(false);
                Assert.IsNotNull(getSucceededResponse);
                Assert.AreEqual(ImportJobStatus.Succeeded, getSucceededResponse.Value.Status);

                // LIST all jobs
                var listResponse = await client.ListImportJobsAsync();
                Assert.IsNotNull(listResponse);
                var rawListResponse = listResponse.GetRawResponse();
                Assert.AreEqual(HttpStatusCode.OK, rawListResponse.Status);

                // DELETE job
                var deleteResponse = await client.DeleteImportJobsAsync(jobId).ConfigureAwait(false);
                Assert.IsNotNull(deleteResponse);
                Assert.AreEqual(HttpStatusCode.NoContent, deleteResponse.Status);

                // wait a bit for job to delete?

                // GET job - should fail
                var getDeletedJobResponse = await client.GetImportJobsByIdAsync(jobId).ConfigureAwait(false);
                Assert.IsNotNull(getDeletedJobResponse);
                var rawResponse = getDeletedJobResponse.GetRawResponse();
                Assert.AreEqual(HttpStatusCode.NotFound, rawResponse.Status);
                Assert.AreEqual(ImportJobStatus.Failed, getDeletedJobResponse.Value.Status);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
        }

        [Test]
        public async Task Bulk_Invalid_Fails()
        {
            DigitalTwinsClient client = GetClient();
            string jobId = await GetUniqueJobIdAsync(client, TestAssetDefaults.JobId).ConfigureAwait(false);
        }
    }
}
