// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinServiceClient methods dealing with Digital Twin Import operations.
    /// </summary>
    public class ImportTests : E2eTestBase
    {
        public ImportTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Import_Lifecycle()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            string jobId = await GetUniqueJobIdAsync(client, TestAssetDefaults.ImportJobId).ConfigureAwait(false);
            var inputBlobUri = TestEnvironment.InputBlobUri;
            var outputBlobUri = $"{TestEnvironment.StorageContainerEndpoint}/output-{jobId}.ndjson";
            var importJob = new ImportJob(inputBlobUri, outputBlobUri);

            try
            {
                // act + assert

                // validate CREATE job
                var createResponse = await client.CreateImportJobsAsync(jobId, importJob).ConfigureAwait(false);
                Assert.IsNotNull(createResponse);
                var rawCreateResponse = createResponse.GetRawResponse();
                Assert.AreEqual((int)HttpStatusCode.Created, rawCreateResponse.Status);

                // Validate GET job
                var getResponse = await client.GetImportJobsByIdAsync(jobId).ConfigureAwait(false);
                Assert.IsNotNull(getResponse);
                var rawGetResponse = getResponse.GetRawResponse();
                Assert.AreEqual((int)HttpStatusCode.OK, rawGetResponse.Status);

                // validate LIST all jobs
                var listResponse = await client.ListImportJobsAsync();
                Assert.IsNotNull(listResponse);
                var rawListResponse = listResponse.GetRawResponse();
                Assert.AreEqual((int)HttpStatusCode.OK, rawListResponse.Status);

                // validate CANCEL job
                var cancelResponse = await client.CancelImportJobsAsync(jobId).ConfigureAwait(false);
                Assert.IsNotNull(cancelResponse);
                var rawCancelResponse = cancelResponse.GetRawResponse();
                Assert.AreEqual((int)HttpStatusCode.OK, rawCancelResponse.Status);

                // validate DELETE job
                var deleteResponse = await client.DeleteImportJobsAsync(jobId).ConfigureAwait(false);
                Assert.IsNotNull(deleteResponse);
                Assert.AreEqual((int)HttpStatusCode.NoContent, deleteResponse.Status);

                // validate GET job after deletion - should fail
                Func<Task> act = async () => await client.GetImportJobsByIdAsync(jobId).ConfigureAwait(false);
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
        }

        [Test]
        public async Task Import_MalformedInput_ThrowsBadRequest()
        {
            // arrange
            DigitalTwinsClient client = GetClient();
            string jobId = await GetUniqueJobIdAsync(client, TestAssetDefaults.ImportJobId).ConfigureAwait(false);
            string inputUri = "invalidUri";
            string outputUri = "invalidOutputUri";

            var importJob = new ImportJob(jobId, inputUri, outputUri, ImportJobStatus.Notstarted, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null);
            try
            {
                // act
                Func<Task> act = async () => await client.CreateImportJobsAsync(jobId, importJob).ConfigureAwait(false);

                // assert
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
        }

        [Test]
        public async Task Import_JobAlreadyExists_ThrowsConflictException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            string jobId = await GetUniqueJobIdAsync(client, TestAssetDefaults.ImportJobId).ConfigureAwait(false);
            var inputBlobUri = TestEnvironment.InputBlobUri;
            var outputBlobUri = $"{TestEnvironment.StorageContainerEndpoint}/output-{jobId}.ndjson";
            var importJob = new ImportJob(inputBlobUri, outputBlobUri);

            try
            {
                // Create import job once
                var createResponse = await client.CreateImportJobsAsync(jobId, importJob).ConfigureAwait(false);

                // Validation
                Assert.IsNotNull(createResponse);
                var rawCreateResponse = createResponse.GetRawResponse();
                Assert.AreEqual((int)HttpStatusCode.Created, rawCreateResponse.Status);

                // Create import job again
                Func<Task> act = async () => await client.CreateImportJobsAsync(jobId, importJob).ConfigureAwait(false);

                // not available from HttpStatusCode in net461
                var tooManyRequestsCode = 429;

                // Second request should fail - either with job id exists or because other job is running.
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().BeOneOf(new List<int> { (int)HttpStatusCode.Conflict, tooManyRequestsCode });
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
        }

        [Test]
        public void Import_JobIdNotExists_ThrowsNotFoundException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            try
            {
                // act
                Func<Task> act = async () => await client.GetImportJobsByIdAsync("doesnotexistid").ConfigureAwait(false);

                // assert
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
        }
    }
}
