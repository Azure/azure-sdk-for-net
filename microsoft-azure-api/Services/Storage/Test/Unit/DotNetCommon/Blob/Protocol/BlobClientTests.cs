// -----------------------------------------------------------------------------------------
// <copyright file="BlobClientTest.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    internal class BlobClientTests
    {
        public BlobContext BlobContext { get; private set; }

        public BlobProperties Properties { get; private set; }
        public string LeaseId { get; private set; }
        public string BlobName { get; private set; }
        public string ContainerName { get; private set; }
        public string PublicBlobName { get; private set; }
        public string PublicContainerName { get; private set; }
        public byte[] Content { get; private set; }

        private Random random = new Random();

        public BlobClientTests(bool owner, bool isAsync, int timeout)
        {
            BlobContext = new BlobContext(owner, isAsync, timeout);
        }

        public void Initialize()
        {
            ContainerName = "defaultcontainer";
            PublicContainerName = "publiccontainer";
            BlobName = "defaultblob";
            PublicBlobName = "public";

            Content = new byte[7000];
            random.NextBytes(Content);

            CreateContainer(ContainerName, false);
            CreateBlob(ContainerName, BlobName, false);
            CreateContainer(PublicContainerName, true);
            CreateBlob(PublicContainerName, PublicBlobName, true);
        }

        public void Cleanup()
        {
            DeleteContainer(ContainerName);
            DeleteContainer(PublicContainerName);
        }

        public void CreateContainer(string containerName, bool isPublic)
        {
            CreateContainer(containerName, isPublic, 3);
        }

        public void CreateContainer(string containerName, bool isPublic, int retries)
        {
            // by default, sleep 35 seconds between retries
            CreateContainer(containerName, isPublic, retries, 35000);
        }

        public void CreateContainer(string containerName, bool isPublic, int retries, int millisecondsBetweenRetries)
        {
            while (true)
            {
                HttpWebRequest request = BlobTests.CreateContainerRequest(BlobContext, containerName);
                Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
                if (isPublic)
                {
                    request.Headers["x-ms-blob-public-access"] = "container";
                }
                if (BlobContext.Credentials != null)
                {
                    BlobTests.SignRequest(request, BlobContext);
                }
                HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
                HttpStatusCode statusCode = response.StatusCode;
                string statusDescription = response.StatusDescription;
                StorageExtendedErrorInformation error = StorageExtendedErrorInformation.ReadFromStream(response.GetResponseStream());
                response.Close();

                // if the container is being deleted, retry up to the specified times.
                if (statusCode == HttpStatusCode.Conflict && error != null && error.ErrorCode == BlobErrorCodeStrings.ContainerBeingDeleted && retries > 0)
                {
                    Thread.Sleep(millisecondsBetweenRetries);
                    retries--;
                    continue;
                }

                break;
            }
        }

        public void DeleteContainer(string containerName)
        {
            HttpWebRequest request = BlobTests.DeleteContainerRequest(BlobContext, containerName, null);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            HttpStatusCode statusCode = response.StatusCode;
            string statusDescription = response.StatusDescription;
            response.Close();
        }

        public void CreateBlob(string containerName, string blobName, bool isPublic)
        {
            Properties = new BlobProperties() { BlobType = BlobType.BlockBlob };
            HttpWebRequest request = BlobTests.PutBlobRequest(BlobContext, containerName, blobName, Properties, BlobType.BlockBlob, Content, 0, null);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");

            request.ContentLength = Content.Length;
            request.Timeout = 30000;
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            Stream stream = request.GetRequestStream();
            stream.Write(Content, 0, Content.Length);
            stream.Flush();
            stream.Close();
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            HttpStatusCode statusCode = response.StatusCode;
            string statusDescription = response.StatusDescription;
            response.Close();
            if (statusCode != HttpStatusCode.Created)
            {
                Assert.Fail(string.Format("Failed to create blob: {0}, Status: {1}, Status Description: {2}", containerName, statusCode, statusDescription));
            }
        }

        public void DeleteBlob(string containerName, string blobName)
        {
            HttpWebRequest request = BlobTests.DeleteBlobRequest(BlobContext, containerName, blobName, null);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            response.Close();
        }

        /// <summary>
        /// Scenario test for acquiring a lease.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="blobName">The name of the blob, if any.</param>
        /// <param name="leaseDuration">The lease duration.</param>
        /// <param name="proposedLeaseId">The proposed lease ID.</param>
        /// <param name="expectedError">The error status code to expect.</param>
        /// <returns>The lease ID.</returns>
        public string AcquireLeaseScenarioTest(string containerName, string blobName, int leaseDuration, string proposedLeaseId, HttpStatusCode? expectedError)
        {
            // Create and validate the web request
            HttpWebRequest request = BlobTests.AcquireLeaseRequest(BlobContext, containerName, blobName, leaseDuration, proposedLeaseId, null);

            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }

            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext))
            {
                BlobTests.AcquireLeaseResponse(response, proposedLeaseId, expectedError);

                return BlobHttpResponseParsers.GetLeaseId(response);
            }
        }

        /// <summary>
        /// Scenario test for renewing a lease.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="blobName">The name of the blob, if any.</param>
        /// <param name="leaseId">The lease ID.</param>
        /// <param name="expectedError">The error status code to expect.</param>
        public void RenewLeaseScenarioTest(string containerName, string blobName, string leaseId, HttpStatusCode? expectedError)
        {
            // Create and validate the web request
            HttpWebRequest request = BlobTests.RenewLeaseRequest(BlobContext, containerName, blobName, AccessCondition.GenerateLeaseCondition(leaseId));

            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }

            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext))
            {
                BlobTests.RenewLeaseResponse(response, leaseId, expectedError);
            }
        }

        /// <summary>
        /// Scenario test for changing a lease.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="blobName">The name of the blob, if any.</param>
        /// <param name="leaseId">The lease ID.</param>
        /// <param name="proposedLeaseId">The proposed lease ID.</param>
        /// <param name="expectedError">The error status code to expect.</param>
        /// <returns>The lease ID.</returns>
        public string ChangeLeaseScenarioTest(string containerName, string blobName, string leaseId, string proposedLeaseId, HttpStatusCode? expectedError)
        {
            // Create and validate the web request
            HttpWebRequest request = BlobTests.ChangeLeaseRequest(BlobContext, containerName, blobName, proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId));

            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }

            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext))
            {
                BlobTests.ChangeLeaseResponse(response, proposedLeaseId, expectedError);

                return BlobHttpResponseParsers.GetLeaseId(response);
            }
        }

        /// <summary>
        /// Scenario test for releasing a lease.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="blobName">The name of the blob, if any.</param>
        /// <param name="leaseId">The lease ID.</param>
        /// <param name="expectedError">The error status code to expect.</param>
        public void ReleaseLeaseScenarioTest(string containerName, string blobName, string leaseId, HttpStatusCode? expectedError)
        {
            // Create and validate the web request
            HttpWebRequest request = BlobTests.ReleaseLeaseRequest(BlobContext, containerName, blobName, AccessCondition.GenerateLeaseCondition(leaseId));

            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }

            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext))
            {
                BlobTests.ReleaseLeaseResponse(response, expectedError);
            }
        }

        /// <summary>
        /// Scenario test for breaking a lease.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="blobName">The name of the blob, if any.</param>
        /// <param name="breakPeriod">The break period.</param>
        /// <param name="expectedRemainingTime">The expected remaining time.</param>
        /// <param name="expectedError">The error status code to expect.</param>
        /// <returns>The remaining lease time.</returns>
        public int BreakLeaseScenarioTest(string containerName, string blobName, int? breakPeriod, int? expectedRemainingTime, HttpStatusCode? expectedError)
        {
            // Create and validate the web request
            HttpWebRequest request = BlobTests.BreakLeaseRequest(BlobContext, containerName, blobName, breakPeriod, null);

            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }

            using (HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext))
            {
                int expectedTime = expectedRemainingTime ?? breakPeriod.Value;
                int errorMargin = 10;
                BlobTests.BreakLeaseResponse(response, expectedTime, errorMargin, expectedError);

                return expectedError.HasValue ? 0 : BlobHttpResponseParsers.GetRemainingLeaseTime(response).Value;
            }
        }

        /// <summary>
        /// Test acquire lease semantics.
        /// </summary>
        /// <param name="containerName">The container.</param>
        /// <param name="blobName">The blob, if any.</param>
        public void AcquireLeaseTests(string containerName, string blobName)
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            // Acquire the lease while in available state
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Acquire the lease while in leased state (idempotent)
            leaseId2 = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Acquire the lease while in leased state (conflict)
            AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId2, HttpStatusCode.Conflict);

            // Break lease for 60 seconds
            BreakLeaseScenarioTest(containerName, blobName, 60, 60, null);

            // Acquire the lease while in breaking state (conflict)
            AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, HttpStatusCode.Conflict);
            AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId2, HttpStatusCode.Conflict);

            // Break lease instantly
            BreakLeaseScenarioTest(containerName, blobName, 0, 0, null);

            // Acquire the lease while in broken state (same ID)
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease instantly
            BreakLeaseScenarioTest(containerName, blobName, 0, 0, null);

            // Acquire the lease while in broken state (new ID)
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId2, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Acquire the lease while in released state (same ID)
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId2, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Acquire the lease while in released state (new ID)
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Acquire a lease that is too short
            AcquireLeaseScenarioTest(containerName, blobName, 14, proposedLeaseId, HttpStatusCode.BadRequest);

            // Acquire a lease that is too long
            AcquireLeaseScenarioTest(containerName, blobName, 61, proposedLeaseId, HttpStatusCode.BadRequest);

            // Acquire minimum finite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, 15, proposedLeaseId, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Acquire maximum finite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, 60, proposedLeaseId, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Acquire with no proposed ID (non-idempotent)
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, null, null);

            // Acquire with no proposed ID (attempt to use as though idempotent)
            AcquireLeaseScenarioTest(containerName, blobName, -1, null, HttpStatusCode.Conflict);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);
        }

        /// <summary>
        /// Test renew lease semantics.
        /// </summary>
        /// <param name="containerName">The container.</param>
        /// <param name="blobName">The blob, if any.</param>
        public void RenewLeaseTests(string containerName, string blobName)
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            // Renew lease (no lease)
            RenewLeaseScenarioTest(containerName, blobName, null, HttpStatusCode.BadRequest);

            // Renew lease in available state
            RenewLeaseScenarioTest(containerName, blobName, proposedLeaseId, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Renew infinite lease
            RenewLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Renew released lease (wrong lease)
            RenewLeaseScenarioTest(containerName, blobName, unknownLeaseId, HttpStatusCode.Conflict);

            // Renew released infinite lease
            RenewLeaseScenarioTest(containerName, blobName, leaseId, HttpStatusCode.Conflict);

            // Acquire finite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, 60, proposedLeaseId, null);

            // Renew finite lease
            RenewLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Renew lease (wrong lease)
            RenewLeaseScenarioTest(containerName, blobName, unknownLeaseId, HttpStatusCode.Conflict);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Renew released finite lease
            RenewLeaseScenarioTest(containerName, blobName, leaseId, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease for 60 seconds
            BreakLeaseScenarioTest(containerName, blobName, 60, 60, null);

            // Renew breaking lease
            RenewLeaseScenarioTest(containerName, blobName, leaseId, HttpStatusCode.Conflict);

            // Break lease instantly
            BreakLeaseScenarioTest(containerName, blobName, 0, 0, null);

            // Renew broken lease
            RenewLeaseScenarioTest(containerName, blobName, leaseId, HttpStatusCode.Conflict);
        }

        /// <summary>
        /// Test change lease semantics.
        /// </summary>
        /// <param name="containerName">The container.</param>
        /// <param name="blobName">The blob, if any.</param>
        public void ChangeLeaseTests(string containerName, string blobName)
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            // Change lease (no lease)
            ChangeLeaseScenarioTest(containerName, blobName, null, proposedLeaseId2, HttpStatusCode.BadRequest);

            // Change lease (no proposed lease)
            ChangeLeaseScenarioTest(containerName, blobName, proposedLeaseId, null, HttpStatusCode.BadRequest);

            // Change lease in available state
            ChangeLeaseScenarioTest(containerName, blobName, proposedLeaseId, proposedLeaseId2, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Change lease
            leaseId2 = ChangeLeaseScenarioTest(containerName, blobName, leaseId, proposedLeaseId2, null);

            // Change lease (idempotent)
            leaseId2 = ChangeLeaseScenarioTest(containerName, blobName, leaseId, proposedLeaseId2, null);

            // Change lease (idempotent, other source)
            leaseId2 = ChangeLeaseScenarioTest(containerName, blobName, unknownLeaseId, proposedLeaseId2, null);

            // Change lease (wrong lease)
            ChangeLeaseScenarioTest(containerName, blobName, unknownLeaseId, proposedLeaseId, HttpStatusCode.Conflict);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId2, null);

            // Change released lease
            ChangeLeaseScenarioTest(containerName, blobName, leaseId2, proposedLeaseId, HttpStatusCode.Conflict);

            // Change released lease (idempotent attempt)
            ChangeLeaseScenarioTest(containerName, blobName, leaseId, proposedLeaseId2, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease for 60 seconds
            BreakLeaseScenarioTest(containerName, blobName, 60, 60, null);

            // Change breaking lease
            ChangeLeaseScenarioTest(containerName, blobName, leaseId, proposedLeaseId2, HttpStatusCode.Conflict);

            // Change breaking lease (idempotent attempt)
            ChangeLeaseScenarioTest(containerName, blobName, leaseId2, proposedLeaseId, HttpStatusCode.Conflict);

            // Break lease instantly
            BreakLeaseScenarioTest(containerName, blobName, 0, 0, null);

            // Change broken lease
            ChangeLeaseScenarioTest(containerName, blobName, leaseId, proposedLeaseId2, HttpStatusCode.Conflict);

            // Change broken lease (idempotent attempt)
            ChangeLeaseScenarioTest(containerName, blobName, leaseId2, proposedLeaseId, HttpStatusCode.Conflict);
        }

        /// <summary>
        /// Test release lease semantics.
        /// </summary>
        /// <param name="containerName">The container.</param>
        /// <param name="blobName">The blob, if any.</param>
        public void ReleaseLeaseTests(string containerName, string blobName)
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            // Release lease (no lease)
            ReleaseLeaseScenarioTest(containerName, blobName, null, HttpStatusCode.BadRequest);

            // Release lease in available state (unknown lease)
            ReleaseLeaseScenarioTest(containerName, blobName, proposedLeaseId, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Release lease (wrong lease)
            ReleaseLeaseScenarioTest(containerName, blobName, unknownLeaseId, HttpStatusCode.Conflict);

            // Release lease (right lease)
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Release lease (old lease)
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, HttpStatusCode.Conflict);

            // Release lease in released state (unknown lease)
            ReleaseLeaseScenarioTest(containerName, blobName, unknownLeaseId, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease for 60 seconds
            BreakLeaseScenarioTest(containerName, blobName, 60, 60, null);

            // Release breaking lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease instantly
            BreakLeaseScenarioTest(containerName, blobName, 0, 0, null);

            // Release broken lease (right lease)
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Release broken lease (wrong lease)
            ReleaseLeaseScenarioTest(containerName, blobName, unknownLeaseId, HttpStatusCode.Conflict);
        }

        /// <summary>
        /// Test break lease semantics.
        /// </summary>
        /// <param name="containerName">The container.</param>
        /// <param name="blobName">The blob, if any.</param>
        public void BreakLeaseTests(string containerName, string blobName)
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            int leaseTime;

            // Break lease in available state
            BreakLeaseScenarioTest(containerName, blobName, null, 0, HttpStatusCode.Conflict);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease (negative break time)
            BreakLeaseScenarioTest(containerName, blobName, -1, null, HttpStatusCode.BadRequest);

            // Break lease (too large break time)
            BreakLeaseScenarioTest(containerName, blobName, 61, null, HttpStatusCode.BadRequest);

            // Break lease (default break time)
            BreakLeaseScenarioTest(containerName, blobName, null, 0, null);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease (zero break time)
            BreakLeaseScenarioTest(containerName, blobName, 0, null, null);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease (1 second break time)
            BreakLeaseScenarioTest(containerName, blobName, 1, null, null);

            // Wait for lease to break
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Break lease (60 seconds break time)
            BreakLeaseScenarioTest(containerName, blobName, 60, null, null);

            // Break breaking lease (zero break time)
            BreakLeaseScenarioTest(containerName, blobName, 0, null, null);

            // Acquire finite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, 59, proposedLeaseId, null);

            // Break lease (longer than lease time)
            BreakLeaseScenarioTest(containerName, blobName, 60, 59, null);

            // Break lease (zero break time)
            BreakLeaseScenarioTest(containerName, blobName, 0, null, null);

            // Acquire finite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, 60, proposedLeaseId, null);

            // Break lease (default break time)
            leaseTime = BreakLeaseScenarioTest(containerName, blobName, null, 60, null);

            // Break breaking lease (default break time)
            BreakLeaseScenarioTest(containerName, blobName, null, leaseTime, null);

            // Break breaking lease (zero break time)
            BreakLeaseScenarioTest(containerName, blobName, 0, null, null);

            // Acquire infinite lease
            leaseId = AcquireLeaseScenarioTest(containerName, blobName, -1, proposedLeaseId, null);

            // Release lease
            ReleaseLeaseScenarioTest(containerName, blobName, leaseId, null);

            // Break released lease
            BreakLeaseScenarioTest(containerName, blobName, null, 0, HttpStatusCode.Conflict);
        }

        public void PutBlobScenarioTest(string containerName, string blobName, BlobProperties properties, BlobType blobType, byte[] content, HttpStatusCode? expectedError)
        {
            HttpWebRequest request = BlobTests.PutBlobRequest(BlobContext, containerName, blobName, properties, blobType, content, content.Length, null);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            request.ContentLength = content.Length;
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            BlobTestUtils.SetRequest(request, BlobContext, content);
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.PutBlobResponse(response, BlobContext, expectedError);
            }
            finally
            {
                response.Close();
            }
        }

        public void ClearPageRangeScenarioTest(string containerName, string blobName, HttpStatusCode? expectedError)
        {
            // 1. Create Sparse Page Blob
            int blobSize = 128 * 1024;

            BlobProperties properties = new BlobProperties() { BlobType = BlobType.PageBlob };
            Uri uri = BlobTests.ConstructPutUri(BlobContext.Address, containerName, blobName);
            OperationContext opContext = new OperationContext();
            HttpWebRequest webRequest = BlobHttpWebRequestFactory.Put(uri, BlobContext.Timeout, properties, BlobType.PageBlob, blobSize, null, opContext);

            BlobTests.SignRequest(webRequest, BlobContext);

            using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
            {
                BlobTests.PutBlobResponse(response, BlobContext, expectedError);
            }

            // 2. Now upload some page ranges
            for (int m = 0; m * 512 * 4 < blobSize; m++)
            {
                int startOffset = 512 * 4 * m;
                int length = 512;
                
                PageRange range = new PageRange(startOffset, startOffset + length - 1);
                opContext = new OperationContext();
                HttpWebRequest pageRequest = BlobHttpWebRequestFactory.PutPage(uri, BlobContext.Timeout, range, PageWrite.Update, null, opContext);
                pageRequest.ContentLength = 512;
                BlobTests.SignRequest(pageRequest, BlobContext);

                Stream outStream = pageRequest.GetRequestStream();

                for (int n = 0; n < 512; n++)
                {
                    outStream.WriteByte((byte)m);
                }

                outStream.Close();
                using (HttpWebResponse pageResponse = pageRequest.GetResponse() as HttpWebResponse)
                {
                }
            }

            // 3. Now do a Get Page Ranges
            List<PageRange> pageRanges = new List<PageRange>();
            opContext = new OperationContext();
            HttpWebRequest pageRangeRequest = BlobHttpWebRequestFactory.GetPageRanges(uri, BlobContext.Timeout, null, null, null, null, opContext);
            BlobTests.SignRequest(pageRangeRequest, BlobContext);
            using (HttpWebResponse pageRangeResponse = pageRangeRequest.GetResponse() as HttpWebResponse)
            {
                GetPageRangesResponse getPageRangesResponse = new GetPageRangesResponse(pageRangeResponse.GetResponseStream());
                pageRanges.AddRange(getPageRangesResponse.PageRanges.ToList());
            }

            // 4. Now Clear some pages
            bool skipFlag = false;
            foreach (PageRange pRange in pageRanges)
            {
                skipFlag = !skipFlag;
                if (skipFlag)
                {
                    continue;
                }

                opContext = new OperationContext();
                HttpWebRequest clearPageRequest = BlobHttpWebRequestFactory.PutPage(uri, BlobContext.Timeout, pRange, PageWrite.Clear, null, opContext);
                clearPageRequest.ContentLength = 0;
                BlobTests.SignRequest(clearPageRequest, BlobContext);
                using (HttpWebResponse clearResponse = clearPageRequest.GetResponse() as HttpWebResponse)
                {
                }
            }

            // 5. Get New Page ranges and verify
            List<PageRange> newPageRanges = new List<PageRange>();

            opContext = new OperationContext();
            HttpWebRequest newPageRangeRequest = BlobHttpWebRequestFactory.GetPageRanges(uri, BlobContext.Timeout, null, null, null, null, opContext);
            BlobTests.SignRequest(newPageRangeRequest, BlobContext);
            using (HttpWebResponse newPageRangeResponse = newPageRangeRequest.GetResponse() as HttpWebResponse)
            {
                GetPageRangesResponse getNewPageRangesResponse = new GetPageRangesResponse(newPageRangeResponse.GetResponseStream());
                newPageRanges.AddRange(getNewPageRangesResponse.PageRanges.ToList());
            }

            Assert.AreEqual(pageRanges.Count(), newPageRanges.Count() * 2);
            for (int l = 0; l < newPageRanges.Count(); l++)
            {
                Assert.AreEqual(pageRanges[2 * l].StartOffset, newPageRanges[l].StartOffset);
                Assert.AreEqual(pageRanges[2 * l].EndOffset, newPageRanges[l].EndOffset);
            }
        }

        public void GetBlobScenarioTest(string containerName, string blobName, BlobProperties properties, string leaseId,
            byte[] content, HttpStatusCode? expectedError)
        {
            HttpWebRequest request = BlobTests.GetBlobRequest(BlobContext, containerName, blobName, AccessCondition.GenerateLeaseCondition(leaseId));
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.GetBlobResponse(response, BlobContext, properties, content, expectedError);
            }
            finally
            {
                response.Close();
            }
        }

        /// <summary>
        /// Sends a get blob range request with the given parameters and validates both request and response.
        /// </summary>
        /// <param name="containerName">The blob's container's name.</param>
        /// <param name="blobName">The blob's name.</param>
        /// <param name="leaseId">The lease ID, or null if there is no lease.</param>
        /// <param name="content">The total contents of the blob.</param>
        /// <param name="offset">The offset of the contents we will get.</param>
        /// <param name="count">The number of bytes we will get, or null to get the rest of the blob.</param>
        /// <param name="expectedError">The error code we expect from this operation, or null if we expect it to succeed.</param>
        public void GetBlobRangeScenarioTest(string containerName, string blobName, string leaseId, byte[] content, long offset, long? count, HttpStatusCode? expectedError)
        {
            HttpWebRequest request = BlobTests.GetBlobRangeRequest(BlobContext, containerName, blobName, offset, count, AccessCondition.GenerateLeaseCondition(leaseId));
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");

            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }

            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);

            try
            {
                long endRange = count.HasValue ? count.Value + offset - 1 : content.Length - 1;
                byte[] selectedContent = null;

                // Compute expected content only if call is expected to succeed.
                if (expectedError == null)
                {
                    selectedContent = new byte[endRange - offset + 1];
                    Array.Copy(content, offset, selectedContent, 0, selectedContent.Length);
                }

                BlobTests.CheckBlobRangeResponse(response, BlobContext, selectedContent, offset, endRange, content.Length, expectedError);
            }
            finally
            {
                response.Close();
            }
        }

        public void ListBlobsScenarioTest(string containerName, BlobListingContext listingContext, HttpStatusCode? expectedError, params string[] expectedBlobs)
        {
            HttpWebRequest request = BlobTests.ListBlobsRequest(BlobContext, containerName, listingContext);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.ListBlobsResponse(response, BlobContext, expectedError);
                ListBlobsResponse listBlobsResponse = new ListBlobsResponse(response.GetResponseStream());
                int i = 0;
                foreach (IListBlobEntry item in listBlobsResponse.Blobs)
                {
                    ListBlobEntry blob = item as ListBlobEntry;
                    if (expectedBlobs == null)
                    {
                        Assert.Fail("Should not have blobs.");
                    }
                    Assert.IsTrue(i < expectedBlobs.Length, "Unexpected blob: " + blob.Name);
                    Assert.AreEqual<string>(expectedBlobs[i++], blob.Name, "Incorrect blob.");
                }
                if (expectedBlobs != null && i < expectedBlobs.Length)
                {
                    Assert.Fail("Missing blob: " + expectedBlobs[i] + "(and " + (expectedBlobs.Length - i - 1) + " more).");
                }
            }
            finally
            {
                response.Close();
            }
        }

        public void ListContainersScenarioTest(ListingContext listingContext, HttpStatusCode? expectedError, params string[] expectedContainers)
        {
            HttpWebRequest request = BlobTests.ListContainersRequest(BlobContext, listingContext);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.ListContainersResponse(response, BlobContext, expectedError);
                ListContainersResponse listContainersResponse = new ListContainersResponse(response.GetResponseStream());
                int i = 0;
                foreach (BlobContainerEntry item in listContainersResponse.Containers)
                {
                    if (expectedContainers == null)
                    {
                        Assert.Fail("Should not have containers.");
                    }
                    Assert.IsTrue(i < expectedContainers.Length, "Unexpected container: " + item.Name);
                    Assert.AreEqual<string>(expectedContainers[i++], item.Name, "Incorrect container.");
                }
                if (expectedContainers != null && i < expectedContainers.Length)
                {
                    Assert.Fail("Missing container: " + expectedContainers[i] + "(and " + (expectedContainers.Length - i - 1) + " more).");
                }
            }
            finally
            {
                response.Close();
            }
        }

        public void PutBlockScenarioTest(string containerName, string blobName, string blockId, string leaseId, byte[] content, HttpStatusCode? expectedError)
        {
            HttpWebRequest request = BlobTests.PutBlockRequest(BlobContext, containerName, blobName, blockId, AccessCondition.GenerateLeaseCondition(leaseId));
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            request.ContentLength = content.Length;
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            BlobTestUtils.SetRequest(request, BlobContext, content);
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.PutBlockResponse(response, BlobContext, expectedError);
            }
            finally
            {
                response.Close();
            }
        }

        public void PutBlockListScenarioTest(string containerName, string blobName, List<PutBlockListItem> blocks, BlobProperties blobProperties, string leaseId, HttpStatusCode? expectedError)
        {
            HttpWebRequest request = BlobTests.PutBlockListRequest(BlobContext, containerName, blobName, blobProperties, AccessCondition.GenerateLeaseCondition(leaseId));
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            byte[] content;
            using (MemoryStream stream = new MemoryStream())
            {
                BlobRequest.WriteBlockListBody(blocks, stream);
                stream.Seek(0, SeekOrigin.Begin);
                content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
            }
            request.ContentLength = content.Length;
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            BlobTestUtils.SetRequest(request, BlobContext, content);
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.PutBlockListResponse(response, BlobContext, expectedError);
            }
            finally
            {
                response.Close();
            }
        }

        public void GetBlockListScenarioTest(string containerName, string blobName, BlockListingFilter typesOfBlocks, string leaseId, HttpStatusCode? expectedError, params string[] expectedBlocks)
        {
            HttpWebRequest request = BlobTests.GetBlockListRequest(BlobContext, containerName, blobName, typesOfBlocks, AccessCondition.GenerateLeaseCondition(leaseId));
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            if (BlobContext.Credentials != null)
            {
                BlobTests.SignRequest(request, BlobContext);
            }
            HttpWebResponse response = BlobTestUtils.GetResponse(request, BlobContext);
            try
            {
                BlobTests.GetBlockListResponse(response, BlobContext, expectedError);
                GetBlockListResponse getBlockListResponse = new GetBlockListResponse(response.GetResponseStream());
                int i = 0;
                foreach (ListBlockItem item in getBlockListResponse.Blocks)
                {
                    if (expectedBlocks == null)
                    {
                        Assert.Fail("Should not have blocks.");
                    }
                    Assert.IsTrue(i < expectedBlocks.Length, "Unexpected block: " + item.Name);
                    Assert.AreEqual<string>(expectedBlocks[i++], item.Name, "Incorrect block.");
                }
                if (expectedBlocks != null && i < expectedBlocks.Length)
                {
                    Assert.Fail("Missing block: " + expectedBlocks[i] + "(and " + (expectedBlocks.Length - i - 1) + " more).");
                }
            }
            finally
            {
                response.Close();
            }
        }

        public static Uri ConstructUri(string address, params string[] folders)
        {
            Assert.IsNotNull(address);

            string uriString = address;
            foreach (string folder in folders)
            {
                uriString = String.Format("{0}/{1}", uriString, folder);
            }
            Uri uri = null;
            uri = new Uri(uriString);
            return uri;
        }

        public void CopyFromToRestoreSnapshot(BlobContext context, string containerName, string blobName)
        {
            string oldText = "Old stuff";
            string newText = "New stuff";

            StorageCredentials accountAndKey = new StorageCredentials(context.Account, context.Key);
            CloudStorageAccount account = new CloudStorageAccount(accountAndKey, false);
            CloudBlobClient blobClient = new CloudBlobClient(new Uri(context.Address), account.Credentials);
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
            BlobTestBase.UploadText(blob, oldText, Encoding.UTF8);
            CloudBlockBlob snapshot = blob.CreateSnapshot();
            Assert.IsNotNull(snapshot.SnapshotTime);
            BlobTestBase.UploadText(blob, newText, Encoding.UTF8);

            Uri sourceUri = new Uri(snapshot.Uri.AbsoluteUri + "?snapshot=" + BlobRequest.ConvertDateTimeToSnapshotString(snapshot.SnapshotTime.Value));
            OperationContext opContext = new OperationContext();
            HttpWebRequest request = BlobHttpWebRequestFactory.CopyFrom(blob.Uri, 30, sourceUri, null, null, opContext);
            Assert.IsTrue(request != null, "Failed to create HttpWebRequest");
            BlobTests.SignRequest(request, context);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Assert.AreEqual<HttpStatusCode>(response.StatusCode, HttpStatusCode.Accepted);

            string text = BlobTestBase.DownloadText(blob, Encoding.UTF8);
            Assert.AreEqual<string>(text, oldText);

            blob.Delete(DeleteSnapshotsOption.IncludeSnapshots, null, null);
        }
    }
}
