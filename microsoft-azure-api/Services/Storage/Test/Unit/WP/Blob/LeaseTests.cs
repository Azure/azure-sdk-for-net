// -----------------------------------------------------------------------------------------
// <copyright file="LeaseTests.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class LeaseTests : BlobTestBase
    {
        /// <summary>
        /// The prefix to use for the current test. New containers and blobs in the root container begin with this prefix
        /// to avoid conflicting with other tests or concurrent runs of the same test. This also allows a test to easily
        /// clean itself up and to have a persistent recoverable state if a test fails.
        /// </summary>
        private string prefix;

        /// <summary>
        /// The client for the blob service.
        /// </summary>
        private CloudBlobClient blobClient;

        /// <summary>
        /// Create the given blob and, if necessary, its container.
        /// </summary>
        /// <param name="blob">The blob to create.</param>
        internal static async Task CreateBlobAsync(ICloudBlob blob)
        {
            await blob.Container.CreateIfNotExistsAsync();
            await UploadTextAsync(blob, "LeaseTestBlobContent", Encoding.UTF8);
        }

        /// <summary>
        /// Get a reference to a container of the given name, prepending the current prefix.
        /// </summary>
        /// <param name="rootName">The name of the container to which the prefix will be prepended.</param>
        /// <returns>A reference to the container.</returns>
        internal CloudBlobContainer GetContainerReference(string rootName)
        {
            return this.blobClient.GetContainerReference(string.Format("{0}-{1}", this.prefix, rootName));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.blobClient = GenerateCloudBlobClient();

            // Create and log a new prefix for this test.
            this.prefix = Guid.NewGuid().ToString("N");

            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Retire this test's prefix. No other cleanup is done here.
            this.prefix = null;

            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        /// <summary>
        /// Deletes all containers beginning with the current prefix, and all blobs in the root container beginning with the current prefix.
        /// Any existing lease is broken before the resource is deleted. All exceptions are ignored.
        /// </summary>
        internal async Task DeleteAllAsync()
        {
            try
            {
                // Delete all containers with prefix
                ContainerResultSegment containers = await this.blobClient.ListContainersSegmentedAsync(this.prefix, ContainerListingDetails.None, null, null, null, null);
                foreach (CloudBlobContainer container in containers.Results)
                {
                    try
                    {
                        await container.BreakLeaseAsync(TimeSpan.Zero);
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        await container.DeleteAsync();
                    }
                    catch (Exception)
                    {
                    }
                }

                // Delete all blobs in root container with prefix
                CloudBlobContainer rc = this.blobClient.GetRootContainerReference();
                BlobResultSegment blobs = await rc.ListBlobsSegmentedAsync(this.prefix, true, BlobListingDetails.None, null, null, null, null);
                foreach (ICloudBlob blob in blobs.Results)
                {
                    try
                    {
                        await blob.BreakLeaseAsync(TimeSpan.Zero);
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        await blob.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots, null /* access conditions */, null /* options */, null);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Puts the lease on the given blob in an available state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        internal static async Task SetAvailableStateAsync(ICloudBlob blob)
        {
            bool shouldBreakFirst = false;

            OperationContext operationContext = new OperationContext();
            try
            {
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.None, null, null, operationContext);
            }
            catch (Exception)
            {
                if (operationContext.LastResult.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
                {
                    shouldBreakFirst = true;
                }
                else
                {
                    throw;
                }
            }

            if (shouldBreakFirst)
            {
                await blob.BreakLeaseAsync(TimeSpan.Zero);
                await blob.DeleteAsync();
            }
            await CreateBlobAsync(blob);
        }

        /// <summary>
        /// Puts the lease on the given blob in a leased state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the new lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static async Task<string> SetLeasedStateAsync(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            await SetAvailableStateAsync(blob);
            return await blob.AcquireLeaseAsync(leaseTime, leaseId);
        }

        /// <summary>
        /// Puts the lease on the given blob in a renewed state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the renewed lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static async Task<string> SetRenewedStateAsync(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = await SetLeasedStateAsync(blob, leaseTime);
            await blob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a released state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static async Task<string> SetReleasedStateAsync(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = await SetLeasedStateAsync(blob, leaseTime);
            await blob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static async Task<string> SetBreakingStateAsync(ICloudBlob blob)
        {
            string leaseId = await SetLeasedStateAsync(blob, null /* infinite lease */);
            await blob.BreakLeaseAsync(TimeSpan.FromSeconds(60));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a broken state due to the break period expiring.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static async Task<string> SetTimeBrokenStateAsync(ICloudBlob blob)
        {
            string leaseId = await SetLeasedStateAsync(blob, null /* infinite lease */);
            await blob.BreakLeaseAsync(TimeSpan.FromSeconds(1));
            await Task.Delay(TimeSpan.FromSeconds(2));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static async Task<string> SetInstantBrokenStateAsync(ICloudBlob blob)
        {
            string leaseId = await SetLeasedStateAsync(blob, null /* infinite lease */);
            await blob.BreakLeaseAsync(TimeSpan.Zero);
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in an expired state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static async Task<string> SetExpiredStateAsync(ICloudBlob blob)
        {
            string leaseId = await SetLeasedStateAsync(blob, TimeSpan.FromSeconds(15));
            await Task.Delay(TimeSpan.FromSeconds(17));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in an unleased state (either available or broken).
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        internal static async Task SetUnleasedStateAsync(CloudBlobContainer container)
        {
            if (!await container.CreateIfNotExistsAsync())
            {
                OperationContext operationContext = new OperationContext();
                try
                {
                    await container.BreakLeaseAsync(TimeSpan.Zero, null, null, operationContext);
                }
                catch (Exception)
                {
                    if (operationContext.LastResult.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseAlreadyBroken ||
                        operationContext.LastResult.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation)
                    {
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Puts the lease on the given container in a leased state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the new lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static async Task<string> SetLeasedStateAsync(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            await SetUnleasedStateAsync(container);
            return await container.AcquireLeaseAsync(leaseTime, leaseId);
        }

        /// <summary>
        /// Puts the lease on the given container in a renewed state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the renewed lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static async Task<string> SetRenewedStateAsync(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = await SetLeasedStateAsync(container, leaseTime);
            await container.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a released state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static async Task<string> SetReleasedStateAsync(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = await SetLeasedStateAsync(container, leaseTime);
            await container.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static async Task<string> SetBreakingStateAsync(CloudBlobContainer container)
        {
            string leaseId = await SetLeasedStateAsync(container, null /* infinite lease */);
            await container.BreakLeaseAsync(TimeSpan.FromSeconds(60));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a broken state due to the break period expiring.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static async Task<string> SetTimeBrokenStateAsync(CloudBlobContainer container)
        {
            string leaseId = await SetLeasedStateAsync(container, null /* infinite lease */);
            await container.BreakLeaseAsync(TimeSpan.FromSeconds(1));
            await Task.Delay(TimeSpan.FromSeconds(2));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static async Task<string> SetInstantBrokenStateAsync(CloudBlobContainer container)
        {
            string leaseId = await SetLeasedStateAsync(container, null /* infinite lease */);
            await container.BreakLeaseAsync(TimeSpan.Zero);
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in an expired state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static async Task<string> SetExpiredStateAsync(CloudBlobContainer container)
        {
            string leaseId = await SetLeasedStateAsync(container, TimeSpan.FromSeconds(15));
            await Task.Delay(TimeSpan.FromSeconds(17));
            return leaseId;
        }

        [TestMethod]
        [Description("Test lease acquire semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobAcquireLeaseSemanticTestsAsync()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            await SetAvailableStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(15), null /* proposed lease ID */);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            await SetAvailableStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(60), null /* proposed lease ID */);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            await SetAvailableStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseId = await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseId = await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            await SetExpiredStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, null /* infinite lease */, TimeSpan.FromSeconds(20), tolerance);

            await SetInstantBrokenStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId);
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease renew semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobRenewLeaseSemanticTestsAsync()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(15));
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(60));
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            await this.BlobAcquireRenewLeaseTestAsync(leasedBlob, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Verifies the behavior of a lease while the lease holds. Once the lease expires, this method confirms that write operations succeed.
        /// The test is cut short once the <c>testLength</c> time has elapsed. (This last feature is necessary for infinite leases.)
        /// </summary>
        /// <param name="leasedBlob">The blob to test.</param>
        /// <param name="duration">The duration of the lease.</param>
        /// <param name="testLength">The maximum length of time to run the test.</param>
        /// <param name="tolerance">The allowed lease time error.</param>
        internal async Task BlobAcquireRenewLeaseTestAsync(ICloudBlob leasedBlob, TimeSpan? duration, TimeSpan testLength, TimeSpan tolerance)
        {
            OperationContext operationContext = new OperationContext();
            DateTime beginTime = DateTime.UtcNow;

            bool testOver = false;
            do
            {
                try
                {
                    // Attempt to write to the blob with no lease ID.
                    await leasedBlob.SetMetadataAsync(null, null, operationContext);

                    // The write succeeded, which means that the lease must have expired.

                    // If the lease was infinite then there is an error because it should not have expired.
                    Assert.IsNotNull(duration, "An infinite lease should not expire.");

                    // The lease should be past its expiration time.
                    Assert.IsTrue(DateTime.UtcNow - beginTime > duration - tolerance, "Writes should not succeed while lease is present.");

                    // Since the lease has expired, the test is over.
                    testOver = true;
                }
                catch (Exception)
                {
                    if (operationContext.LastResult.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
                    {
                        // We got this error because the lease has not expired yet.

                        // Make sure the lease is not past its expiration time yet.
                        DateTime currentTime = DateTime.UtcNow;
                        if (duration.HasValue)
                        {
                            Assert.IsTrue(currentTime - beginTime < duration + tolerance, "Writes should succeed after a lease expires.");
                        }

                        // End the test early if necessary.
                        if (currentTime - beginTime > testLength)
                        {
                            // The lease has not expired, but we're not waiting any longer.
                            return;
                        }
                    }
                    else
                    {
                        // Some other error occurred. Rethrow the exception.
                        throw;
                    }
                }

                // Attempt to read from the blob. This should always succeed.
                await leasedBlob.FetchAttributesAsync();

                // Wait 1 second before trying again.
                if (!testOver)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
            while (!testOver);

            // The lease expired. Write to and read from the blob once more.
            await leasedBlob.SetMetadataAsync();
            await leasedBlob.FetchAttributesAsync();
        }

        [TestMethod]
        [Description("Test blob leasing with invalid inputs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobLeaseInvalidInputTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string invalidLeaseId = "invalid";
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            await CreateBlobAsync(leasedBlob);

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedBlob.AcquireLeaseAsync(TimeSpan.Zero, null /* proposed lease ID */),
                "acquire a lease with 0 duration");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(-1), null /* proposed lease ID */),
                "acquire a lease with -1 duration");

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(1), null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease with 1 s duration",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(14), null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease that is too short",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(TimeSpan.FromSeconds(61), null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease that is too long",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, invalidLeaseId, null, null, operationContext),
                operationContext,
                "acquire a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            // The following tests assume that the blob is leased
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedBlob.RenewLeaseAsync(null /* access condition */, null, operationContext),
                "renew with null access condition");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateEmptyCondition(), null, operationContext),
                "renew with no lease ID");

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId, null /* access condition */, null, operationContext),
                "change with null access condition");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateEmptyCondition(), null, operationContext),
                "change with no lease ID");

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(invalidLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedBlob.ChangeLeaseAsync(null /* proposed lease ID */, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                "change a lease with no proposed lease ID");

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedBlob.ReleaseLeaseAsync(null /* access condition */, null, operationContext),
                "release with null access condition");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateEmptyCondition(), null, operationContext),
                "release with no lease ID");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(-1), null, null, operationContext),
                "break with negative break time");

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(61), null, null, operationContext),
                operationContext,
                "break with too large break time",
                HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobAcquireLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Acquire the lease while in available state, make idempotent call
            await SetAvailableStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            leaseId2 = await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
               async () => await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, operationContext),
               operationContext,
               "acquire a lease while in leased state (conflict)",
               HttpStatusCode.Conflict,
               BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId, null, null, operationContext),
                operationContext,
                "acquire a lease while in the breaking state (same ID)",
               HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, operationContext),
                operationContext,
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId);

            // Acquire the lease while in broken state (new ID), make idempotent call
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);

            // Acquire the lease while in released state (same ID), make idempotent call
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId);

            // Acquire the lease while in released state (new ID), make idempotent call
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);

            // Acquire with no proposed ID (non-idempotent)
            await SetAvailableStateAsync(leasedBlob);
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Delete the blob
            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobRenewLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Renew lease in available state
            await SetAvailableStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew infinite lease (wrong lease)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = await SetExpiredStateAsync(leasedBlob);
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after read
            leaseId = await SetExpiredStateAsync(leasedBlob);
            string content = await DownloadTextAsync(leasedBlob, Encoding.UTF8);
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after write
            leaseId = await SetExpiredStateAsync(leasedBlob);
            await leasedBlob.SetMetadataAsync();
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
               operationContext,
                "renew an expired lease that has been modified",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew finite lease
            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(60));
            await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease (wrong lease)
            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(60));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = await SetReleasedStateAsync(leasedBlob, TimeSpan.FromSeconds(60));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = await SetReleasedStateAsync(leasedBlob, TimeSpan.FromSeconds(60));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobChangeLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Change lease in available state
            await SetAvailableStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseId2 = await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseId2 = await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId));

            // Change lease (wrong lease specified)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseId2 = await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "change a lease using the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change released lease
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change released lease (to previous lease)
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a released lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change a breaking lease (same ID)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a breaking lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

            // Change a breaking lease (different ID)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "change a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change broken lease
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2), null, operationContext),
                operationContext,
                "change a broken lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change broken lease (to previous lease)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ChangeLeaseAsync(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a broken lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobReleaseLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Release lease in available state
            await SetAvailableStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release lease in released state (old lease)
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "release a released lease (using previous lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease in released state (unknown lease)
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a released lease (using wrong lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release breaking lease (right lease)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release breaking lease (wrong lease)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release broken lease (right lease)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release broken lease (wrong lease)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a broken lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobBreakLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Break lease in available state
            await SetAvailableStateAsync(leasedBlob);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.BreakLeaseAsync(null /* default break period */, null, null, operationContext),
                operationContext,
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseTime = await leasedBlob.BreakLeaseAsync(null /* default break period */);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseTime = await leasedBlob.BreakLeaseAsync(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseTime = await leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(1));

            // Break infinite lease (60 seconds break time)
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            leaseTime = await leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(60));

            // Break breaking lease (zero break time)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            leaseTime = await leasedBlob.BreakLeaseAsync(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = await SetBreakingStateAsync(leasedBlob);
            await leasedBlob.BreakLeaseAsync(null /* default break time */);

            // Break finite lease (longer than lease time)
            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = await leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(60));

            // Break finite lease (zero break time)
            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = await leasedBlob.BreakLeaseAsync(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = await leasedBlob.BreakLeaseAsync(null /* default break time */);

            // Break instant broken lease (default break time)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await leasedBlob.BreakLeaseAsync(null /* default break time */);

            // Break instant broken lease (nonzero break time)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(1));

            // Break instant broken lease (zero break time)
            leaseId = await SetInstantBrokenStateAsync(leasedBlob);
            await leasedBlob.BreakLeaseAsync(TimeSpan.Zero);

            // Break released lease (default break time)
            leaseId = await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedBlob.BreakLeaseAsync(null /* default break time */, null, null, operationContext),
                operationContext,
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Tests blob write and delete APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobLeasedWriteTestsAsync()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CloudBlockBlob sourceBlob = leasedBlob.Container.GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            // Verify that blob creation fails when a lease is supplied.
            // RdBug 243397: Blob creation operations should fail when lease id is specified and blob does not exist
            // testAccessCondition.LeaseId = fakeLease;
            // BlobCreateExpectLeaseFailure(leasedBlob, sourceBlob, testAccessCondition, BlobErrorCodeStrings.LeaseNotPresent, "create blob using a lease");

            // From available state, verify that writes/deletes that pass a lease fail if none is present.
            await SetAvailableStateAsync(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            await this.BlobWriteExpectLeaseFailureAsync(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "write blob using a lease when no lease is held");

            // From leased state, verify that writes/deletes without a lease do not succeed.
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            await this.BlobWriteExpectLeaseFailureAsync(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "write blob using no lease when a lease is held");

            // From leased state, verify that writes/deletes with the wrong lease fail.
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            await this.BlobWriteExpectLeaseFailureAsync(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "write blob using a lease when a different lease is held");

            // From leased state, verify that writes/deletes with the right lease succeed.
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            await this.BlobWriteExpectLeaseSuccessAsync(leasedBlob, sourceBlob, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test blob write and creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task BlobWriteExpectLeaseFailureAsync(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            await this.BlobCreateExpectLeaseFailureAsync(testBlob, sourceBlob, testAccessCondition, expectedStatusCode, expectedErrorCode, description);

            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.SetMetadataAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Set Metadata)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.SetPropertiesAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Set Properties)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.DeleteAsync(DeleteSnapshotsOption.None, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Delete)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test blob creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task BlobCreateExpectLeaseFailureAsync(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await UploadTextAsync(testBlob, "No Dice", Encoding.UTF8, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Upload Text)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.StartCopyFromBlobAsync(TestHelper.Defiddler(sourceBlob.Uri), null /* source access condition */, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Copy From)",
                expectedStatusCode,
                expectedErrorCode);

            Stream writeStream = await testBlob.OpenWriteAsync(testAccessCondition, null /* options */, operationContext);
            Stream stream = writeStream;
            await TestHelper.ExpectedExceptionAsync(
                async () =>
                {
                    stream.WriteByte(0);
                    await stream.FlushAsync();
                },
                operationContext,
                description + " (Write Stream)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test blob writing, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task BlobWriteExpectLeaseSuccessAsync(CloudBlockBlob testBlob, ICloudBlob sourceBlob, AccessCondition testAccessCondition)
        {
            await testBlob.SetMetadataAsync(testAccessCondition, null /* options */, null);
            await testBlob.SetPropertiesAsync(testAccessCondition, null /* options */, null);
            await UploadTextAsync(testBlob, "No Problem", Encoding.UTF8, testAccessCondition, null /* options */, null);
            await testBlob.StartCopyFromBlobAsync(TestHelper.Defiddler(sourceBlob.Uri), null /* source access condition */, testAccessCondition, null /* options */, null);

            while (testBlob.CopyState.Status == CopyStatus.Pending)
            {
                await Task.Delay(1000);
                await testBlob.FetchAttributesAsync();
            }

            Stream writeStream = await testBlob.OpenWriteAsync(testAccessCondition, null /* options */, null);
            Stream stream = writeStream;
            stream.WriteByte(0);
            await stream.FlushAsync();

            await testBlob.DeleteAsync(DeleteSnapshotsOption.None, testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Tests blob read APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobLeasedReadTestsAsync()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CloudBlockBlob targetBlob = leasedBlob.Container.GetBlockBlobReference("TargetBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            // From available state, verify that reads that pass a lease fail if none is present
            await SetAvailableStateAsync(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            await this.BlobReadExpectLeaseFailureAsync(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read blob using a lease when no lease is held");

            // Verify that reads without a lease succeed.
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            await this.BlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            await this.BlobReadExpectLeaseFailureAsync(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            await this.BlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="targetBlob">The blob to use for the target of copy operations.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task BlobReadExpectLeaseFailureAsync(CloudBlockBlob testBlob, CloudBlockBlob targetBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();

            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.FetchAttributesAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + "(Fetch Attributes)",
                HttpStatusCode.PreconditionFailed);

            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.CreateSnapshotAsync(null /* metadata */, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Create Snapshot)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await DownloadTextAsync(testBlob, Encoding.UTF8, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Download Text)",
                expectedStatusCode,
                expectedErrorCode);

            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.OpenReadAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Read Stream)",
                expectedStatusCode/*,
                expectedErrorCode*/);
        }

        /// <summary>
        /// Test blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="targetBlob">The blob to use for the target of copy operations.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task BlobReadExpectLeaseSuccessAsync(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            await testBlob.FetchAttributesAsync(testAccessCondition, null /* options */, null);
            await (await testBlob.CreateSnapshotAsync(null /* metadata */, testAccessCondition, null /* options */, null)).DeleteAsync();
            await DownloadTextAsync(testBlob, Encoding.UTF8, testAccessCondition, null /* options */, null);

            Stream readStream = await testBlob.OpenReadAsync(testAccessCondition, null /* options */, null);
            Stream stream = readStream;
            stream.ReadByte();
        }

        [TestMethod]
        [Description("Tests page blob write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobLeasedWriteTestsAsync()
        {
            CloudPageBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            await leasedBlob.Container.CreateAsync();

            // Verify that creating the page blob fails when a lease is supplied.
            // RdBug 243397: Blob creation operations should fail when lease id is specified and blob does not exist
            // testAccessCondition.LeaseId = fakeLease;
            // PageBlobCreateExpectLeaseFailure(leasedBlob, testAccessCondition, BlobErrorCodeStrings.LeaseNotPresent, "create page blob using a lease");

            // Create a page blob
            testAccessCondition.LeaseId = null;
            await PageBlobCreateExpectSuccessAsync(leasedBlob, testAccessCondition);

            // From available state, verify that writing the page blob fails when a lease is supplied.
            testAccessCondition.LeaseId = fakeLease;
            await PageBlobWriteExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "write page blob with a lease when no lease is held");

            // Acquire a lease
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that writes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            await PageBlobWriteExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "write page blob with no lease when a lease is held");

            // Verify that writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await PageBlobWriteExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "write page blob using a lease when a different lease is held");

            // Verify that writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            await PageBlobWriteExpectSuccessAsync(leasedBlob, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test page blob creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The page blob to test.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task PageBlobCreateExpectLeaseFailureAsync(CloudPageBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.CreateAsync(8 * 512, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Create Page Blob)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test page blob writes, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task PageBlobWriteExpectLeaseFailureAsync(CloudPageBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            byte[] buffer = new byte[4 * 1024];
            Random random = new Random();
            random.NextBytes(buffer);
            Stream pageStream = new MemoryStream(buffer);

            await PageBlobCreateExpectLeaseFailureAsync(testBlob, testAccessCondition, expectedStatusCode, expectedErrorCode, description);

            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.ClearPagesAsync(512, 512, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Clear Pages)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.WritePagesAsync(pageStream, 512, null, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Write Pages)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test page blob creation, expecting success.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The test access condition.</param>
        private async Task PageBlobCreateExpectSuccessAsync(CloudPageBlob testBlob, AccessCondition testAccessCondition)
        {
            await testBlob.CreateAsync(8 * 512, testAccessCondition, null /* options */, null);
        }

        /// <summary>
        /// Test page blob writes, expecting success.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task PageBlobWriteExpectSuccessAsync(CloudPageBlob testBlob, AccessCondition testAccessCondition)
        {
            byte[] buffer = new byte[4 * 512];
            Random random = new Random();
            random.NextBytes(buffer);
            Stream pageStream = new MemoryStream(buffer);

            await testBlob.ClearPagesAsync(512, 512, testAccessCondition, null /* options */, null);
            await testBlob.WritePagesAsync(pageStream, 512, null, testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Tests page blob read APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobLeasedReadTestsAsync()
        {
            CloudPageBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            await leasedBlob.Container.CreateAsync();

            // Create a page blob
            testAccessCondition.LeaseId = null;
            await PageBlobCreateExpectSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reading the page blob fails when a lease is supplied.
            testAccessCondition.LeaseId = fakeLease;
            await PageBlobReadExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read page blob with a lease when no lease is held");

            // Acquire a lease
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads without a lease succeed.
            testAccessCondition.LeaseId = null;
            await PageBlobReadExpectSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await PageBlobReadExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read page blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            await PageBlobReadExpectSuccessAsync(leasedBlob, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test page blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task PageBlobReadExpectLeaseFailureAsync(CloudPageBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.GetPageRangesAsync(null /* offset */, null /* length */, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + "(Get Page Ranges)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test page blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task PageBlobReadExpectSuccessAsync(CloudPageBlob testBlob, AccessCondition testAccessCondition)
        {
            await testBlob.GetPageRangesAsync(null /* offset */, null /* length */, testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Tests block blob write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobLeasedWriteTestsAsync()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;
            List<string> blockList = new List<string>();

            await leasedBlob.Container.CreateAsync();

            // Verify that creating the first block fails when a lease is supplied.
            // RdBug 243397: Blob creation operations should fail when lease id is specified and blob does not exist
            // testOptions.LeaseId = fakeLease;
            // await BlockCreateExpectLeaseFailureAsync(leasedBlob, testOptions, BlobErrorCodeStrings.LeaseNotPresent, "create initial block using a lease");

            // Create a block
            testAccessCondition.LeaseId = null;
            blockList.Add(await BlockCreateExpectSuccessAsync(leasedBlob, testAccessCondition));

            // Verify that creating an additional block fails when a lease is supplied.
            testAccessCondition.LeaseId = fakeLease;
            await BlockCreateExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "create additional block using a lease");

            // Verify that block list writes that pass a lease fail if none is present.
            testAccessCondition.LeaseId = fakeLease;
            await BlockBlobWriteExpectLeaseFailureAsync(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "set initial block list using a lease when no lease is held");

            // Acquire a lease
            testAccessCondition.LeaseId = null;
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that writes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            await BlockCreateExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "create block using no lease when a lease is held");
            await BlockBlobWriteExpectLeaseFailureAsync(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "set initial block list using no lease when a lease is held");

            // Verify that writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await BlockCreateExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "create block using a lease when a different lease is held");
            await BlockBlobWriteExpectLeaseFailureAsync(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "set initial block list using a lease when a different lease is held");

            // Verify that writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            blockList.Add(await BlockCreateExpectSuccessAsync(leasedBlob, testAccessCondition));
            await BlockBlobWriteExpectSuccessAsync(leasedBlob, blockList, testAccessCondition);

            // Verify that writes with the wrong lease fail, with the block list already set.
            testAccessCondition.LeaseId = null;
            await BlockCreateExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "create block using no lease when a lease is held");
            await BlockBlobWriteExpectLeaseFailureAsync(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "update block list using no lease when a lease is held");

            // Verify that writes with the wrong lease fail, with the block list already set.
            testAccessCondition.LeaseId = fakeLease;
            await BlockCreateExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "create block using a lease when a different lease is held");
            await BlockBlobWriteExpectLeaseFailureAsync(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "update block list using a lease when a different lease is held");

            // Verify that writes with the right lease succeed, with the block list already set.
            testAccessCondition.LeaseId = leaseId;
            blockList.Add(await BlockCreateExpectSuccessAsync(leasedBlob, testAccessCondition));
            await BlockBlobWriteExpectSuccessAsync(leasedBlob, blockList, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test block creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The block blob in which to attempt to create a block.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task BlockCreateExpectLeaseFailureAsync(CloudBlockBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await BlockCreateAsync(testBlob, testAccessCondition, operationContext),
                operationContext,
                description + " (Put Block)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test block blob creation (block list setting), expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="blockList">An appropriate block list to set.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task BlockBlobWriteExpectLeaseFailureAsync(CloudBlockBlob testBlob, IEnumerable<string> blockList, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.PutBlockListAsync(blockList, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Put Block List)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test block creation, expecting success.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The test access condition.</param>
        /// <returns>The name of the new block.</returns>
        private async Task<string> BlockCreateExpectSuccessAsync(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            return await BlockCreateAsync(testBlob, testAccessCondition, null);
        }

        /// <summary>
        /// Create a block with a random name.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The access condition.</param>
        /// <returns>The name of the new block.</returns>
        private async Task<string> BlockCreateAsync(CloudBlockBlob testBlob, AccessCondition testAccessCondition, OperationContext operationContext)
        {
            byte[] buffer = new byte[4 * 1024];
            Random random = new Random();
            random.NextBytes(buffer);
            string blockId = Guid.NewGuid().ToString("N");
            Stream blockData = new MemoryStream(buffer);
            await testBlob.PutBlockAsync(blockId, blockData, null /* content MD5 */, testAccessCondition, null /* options */, operationContext);

            return blockId;
        }

        /// <summary>
        /// Test block blob creation (set block list), expecting success.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="blockList">The block list to set.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task BlockBlobWriteExpectSuccessAsync(CloudBlockBlob testBlob, IEnumerable<string> blockList, AccessCondition testAccessCondition)
        {
            await testBlob.PutBlockListAsync(blockList, testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Tests block blob read APIs in the presence of a lease on a blob with no block list.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobLeasedReadTestsWithoutListAsync()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            await leasedBlob.Container.CreateAsync();

            // Create a block
            testAccessCondition.LeaseId = null;
            await BlockCreateExpectSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads without a lease succeed
            testAccessCondition.LeaseId = null;
            await BlockBlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads with a lease fail
            testAccessCondition.LeaseId = fakeLease;
            await BlockBlobReadExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read block blob using a lease when no lease is held");

            // Acquire a lease
            testAccessCondition.LeaseId = null;
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads without a lease still succeed.
            testAccessCondition.LeaseId = null;
            await BlockBlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await BlockBlobReadExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read block blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            await BlockBlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Tests block blob read APIs in the presence of a lease on a blob with a block list.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobLeasedReadTestsWithListAsync()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;
            List<string> blockList = new List<string>();

            await leasedBlob.Container.CreateAsync();

            // Create a block
            testAccessCondition.LeaseId = null;
            blockList.Add(await BlockCreateExpectSuccessAsync(leasedBlob, testAccessCondition));

            // Put the block list
            testAccessCondition.LeaseId = null;
            await BlockBlobWriteExpectSuccessAsync(leasedBlob, blockList, testAccessCondition);

            // Verify that reads without a lease succeed
            testAccessCondition.LeaseId = null;
            await BlockBlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads with a lease fail
            testAccessCondition.LeaseId = fakeLease;
            await BlockBlobReadExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read block blob using a lease when no lease is held");

            // Acquire a lease
            testAccessCondition.LeaseId = null;
            leaseId = await leasedBlob.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads without a lease still succeed.
            testAccessCondition.LeaseId = null;
            await BlockBlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await BlockBlobReadExpectLeaseFailureAsync(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read block blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            await BlockBlobReadExpectLeaseSuccessAsync(leasedBlob, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test block blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task BlockBlobReadExpectLeaseFailureAsync(CloudBlockBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await testBlob.DownloadBlockListAsync(BlockListingFilter.Committed, testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + "(Download Block List)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test block blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task BlockBlobReadExpectLeaseSuccessAsync(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            await testBlob.DownloadBlockListAsync(BlockListingFilter.Committed, testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Test reading the blob lease status and state after various lease actions.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobLeaseStatusTestAsync()
        {
            string leaseId;
            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Check uninitialized lease status
            await SetAvailableStateAsync(leasedBlob);
            Assert.AreEqual(LeaseStatus.Unspecified, leasedBlob.Properties.LeaseStatus, "uninitialized lease status");
            Assert.AreEqual(LeaseState.Unspecified, leasedBlob.Properties.LeaseState, "uninitialized lease state");
            Assert.AreEqual(LeaseDuration.Unspecified, leasedBlob.Properties.LeaseDuration, "uninitialized lease duration");

            // Check lease status in initial state
            await SetAvailableStateAsync(leasedBlob);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "initial lease state");

            // Check lease status after acquiring an infinite lease
            await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after acquire lease");

            // Check lease status after acquiring a finite lease
            await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(45));
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after acquire lease");

            // Check lease status after renewing an infinite lease
            await SetRenewedStateAsync(leasedBlob, null /* infinite lease */);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after renew lease");

            // Check lease status after renewing a finite lease
            await SetRenewedStateAsync(leasedBlob, TimeSpan.FromSeconds(45));
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after renew lease");

            // Check lease status after changing an infinite lease
            leaseId = await SetLeasedStateAsync(leasedBlob, null /* infinite lease */);
            await leasedBlob.ChangeLeaseAsync(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after change lease");

            // Check lease status after changing a finite lease
            leaseId = await SetLeasedStateAsync(leasedBlob, TimeSpan.FromSeconds(45));
            await leasedBlob.ChangeLeaseAsync(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after change lease");

            // Check lease status after releasing a lease
            await SetReleasedStateAsync(leasedBlob, null /* infinite lease */);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "after release lease");

            // Check lease status while infinite lease is breaking
            await SetBreakingStateAsync(leasedBlob);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Breaking, LeaseDuration.Unspecified, "while lease is breaking");

            // Check lease status after lease breaks
            await SetTimeBrokenStateAsync(leasedBlob);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after break time elapses");

            // Check lease status after (infinite) acquire after break
            await SetTimeBrokenStateAsync(leasedBlob);
            await leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /*proposed lease ID */);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after second acquire lease");

            // Check lease status after instant break with infinite lease
            await SetInstantBrokenStateAsync(leasedBlob);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after instant break lease");

            // Check lease status after lease expires
            await SetExpiredStateAsync(leasedBlob);
            await this.CheckLeaseStatusAsync(leasedBlob, LeaseStatus.Unlocked, LeaseState.Expired, LeaseDuration.Unspecified, "after lease expires");

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Checks the lease status of a blob, both from its attributes and from a blob listing.
        /// </summary>
        /// <param name="blob">The blob to test.</param>
        /// <param name="expectedStatus">The expected lease status.</param>
        /// <param name="expectedState">The expected lease state.</param>
        /// <param name="expectedDuration">The expected lease duration.</param>
        /// <param name="description">A description of the circumstances that lead to the expected status.</param>
        private async Task CheckLeaseStatusAsync(
            ICloudBlob blob,
            LeaseStatus expectedStatus,
            LeaseState expectedState,
            LeaseDuration expectedDuration,
            string description)
        {
            await blob.FetchAttributesAsync();
            Assert.AreEqual(expectedStatus, blob.Properties.LeaseStatus, "LeaseStatus mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedState, blob.Properties.LeaseState, "LeaseState mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedDuration, blob.Properties.LeaseDuration, "LeaseDuration mismatch: " + description + " (from FetchAttributes)");

            BlobResultSegment blobs = await blob.Container.ListBlobsSegmentedAsync(blob.Name, true, BlobListingDetails.None, null, null, null, null);
            BlobProperties propertiesInListing = (from ICloudBlob b in blobs.Results
                                                  where b.Name == blob.Name
                                                  select b.Properties).Single();

            Assert.AreEqual(expectedStatus, propertiesInListing.LeaseStatus, "LeaseStatus mismatch: " + description + " (from ListBlobs)");
            Assert.AreEqual(expectedState, propertiesInListing.LeaseState, "LeaseState mismatch: " + description + " (from ListBlobs)");
            Assert.AreEqual(expectedDuration, propertiesInListing.LeaseDuration, "LeaseDuration mismatch: " + description + " (from ListBlobs)");
        }

        [TestMethod]
        [Description("Test lease acquire semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerAcquireLeaseSemanticTestsAsync()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            await SetUnleasedStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), null /* proposed lease ID */);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
            await SetUnleasedStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(60), null /* proposed lease ID */);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
            await SetUnleasedStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-4"); // make sure we use a new container
            await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseId = await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-5"); // make sure we use a new container
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseId = await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-6"); // make sure we use a new container
            await SetExpiredStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-7"); // make sure we use a new container
            await SetInstantBrokenStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId);
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease renew semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerRenewLeaseSemanticTestsAsync()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;

            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(15));
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(60));
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
            await this.ContainerAcquireRenewLeaseTestAsync(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Verifies the behavior of a lease while the lease holds. Once the lease expires, this method confirms that write operations succeed.
        /// The test is cut short once the <c>testLength</c> time has elapsed.
        /// </summary>
        /// <param name="leasedContainer">The container.</param>
        /// <param name="duration">The duration of the lease.</param>
        /// <param name="testLength">The maximum length of time to run the test.</param>
        /// <param name="tolerance">The allowed lease time error.</param>
        internal async Task ContainerAcquireRenewLeaseTestAsync(CloudBlobContainer leasedContainer, TimeSpan? duration, TimeSpan testLength, TimeSpan tolerance)
        {
            OperationContext operationContext = new OperationContext();
            DateTime beginTime = DateTime.UtcNow;

            while (true)
            {
                try
                {
                    // Attempt to delete the container with no lease ID.
                    await leasedContainer.DeleteAsync(null, null, operationContext);

                    // The delete succeeded, which means that the lease must have expired.

                    // If the lease was infinite then there is an error because it should not have expired.
                    Assert.IsNotNull(duration, "An infinite lease should not expire.");

                    // The lease should be past its expiration time.
                    Assert.IsTrue(DateTime.UtcNow - beginTime > duration - tolerance, "Deletes should not succeed while lease is present.");

                    // Since the lease has expired (and the container was deleted), the test is over.
                    return;
                }
                catch (Exception)
                {
                    if (operationContext.LastResult.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
                    {
                        // We got this error because the lease has not expired yet.

                        // Make sure the lease is not past its expiration time yet.
                        DateTime currentTime = DateTime.UtcNow;
                        if (duration.HasValue)
                        {
                            Assert.IsTrue(currentTime - beginTime < duration + tolerance, "Deletes should succeed after a lease expires.");
                        }

                        // End the test early if necessary
                        if (currentTime - beginTime > testLength)
                        {
                            // The lease has not expired, but we're not waiting any longer.
                            return;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }

                // Attempt to write to and read from the container. This should always succeed.
                await leasedContainer.SetMetadataAsync();
                await leasedContainer.FetchAttributesAsync();

                // Wait 1 second before trying again.
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        [TestMethod]
        [Description("Test container leasing with invalid inputs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerLeaseInvalidInputTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string invalidLeaseId = "invalid";
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            await leasedContainer.CreateAsync();

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedContainer.AcquireLeaseAsync(TimeSpan.Zero, null /* proposed lease ID */),
                "acquire a lease with 0 duration");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(-1), null /* proposed lease ID */),
                "acquire a lease with -1 duration");

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(1), null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease with 1 s duration",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(14), null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease that is too short",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(61), null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease that is too long",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, invalidLeaseId, null, null, operationContext),
                operationContext,
                "acquire a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            // The following tests assume that the container is leased
            leaseId = await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedContainer.RenewLeaseAsync(null /* access condition */),
                "renew with null access condition");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateEmptyCondition()),
                "renew with no lease ID");

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId, null /* access condition */),
                "change with null access condition");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateEmptyCondition()),
                "change with no lease ID");

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(invalidLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedContainer.ChangeLeaseAsync(null /* proposed lease ID */, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a lease with no proposed lease ID");

            await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                async () => await leasedContainer.ReleaseLeaseAsync(null /* access condition */),
                "release with null access condition");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateEmptyCondition()),
                "release with no lease ID");

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(-1)),
                "break with negative break time");

            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(61), null, null, operationContext),
                operationContext,
                "break with too large break time",
                HttpStatusCode.BadRequest);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerAcquireLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Acquire the lease while in available state, make idempotent call
            await SetUnleasedStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            leaseId2 = await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, operationContext),
                operationContext,
                "acquire a lease while in leased state (conflict)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId, null, null, operationContext),
                operationContext,
                "acquire a lease while in the breaking state (same ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, operationContext),
                operationContext,
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId);

            // Acquire the lease while in broken state (new ID), make idempotent call
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);

            // Acquire the lease while in released state (same ID), make idempotent call
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId);

            // Acquire the lease while in released state (new ID), make idempotent call
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId);

            // Acquire with no proposed ID (non-idempotent)
            await SetUnleasedStateAsync(leasedContainer);
            leaseId = await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */, null, null, operationContext),
                operationContext,
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Delete the blob
            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerRenewLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Renew lease in available state
            await SetUnleasedStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew infinite lease (wrong lease)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = await SetExpiredStateAsync(leasedContainer);
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after read
            leaseId = await SetExpiredStateAsync(leasedContainer);
            await leasedContainer.FetchAttributesAsync();
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after write
            leaseId = await SetExpiredStateAsync(leasedContainer);
            await leasedContainer.SetMetadataAsync();
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(60));
            await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease (wrong lease)
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(60));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a finite lease with the wrong lease ID",
               HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = await SetReleasedStateAsync(leasedContainer, TimeSpan.FromSeconds(60));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = await SetReleasedStateAsync(leasedContainer, TimeSpan.FromSeconds(60));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerChangeLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Change lease in available state
            await SetUnleasedStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseId2 = await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseId2 = await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId));

            // Change lease (wrong lease specified)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseId2 = await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "change a lease using the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change released lease
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change released lease (to previous lease)
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a released lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change a breaking lease (same ID)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a breaking lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

            // Change a breaking lease (different ID)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "change a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change broken lease
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2), null, operationContext),
                operationContext,
                "change a broken lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change broken lease (to previous lease)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ChangeLeaseAsync(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "change a broken lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerReleaseLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Release lease in available state
            await SetUnleasedStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release lease in released state (old lease)
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, operationContext),
                operationContext,
                "release a released lease (using previous lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease in released state (unknown lease)
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a released lease (using wrong lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release breaking lease (right lease)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release breaking lease (wrong lease)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release broken lease (right lease)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release broken lease (wrong lease)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, operationContext),
                operationContext,
                "release a broken lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerBreakLeaseStateTestsAsync()
        {
            OperationContext operationContext = new OperationContext();
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Break lease in available state
            await SetUnleasedStateAsync(leasedContainer);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.BreakLeaseAsync(null /* default break period */, null, null, operationContext),
                operationContext,
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseTime = await leasedContainer.BreakLeaseAsync(null /* default break period */);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseTime = await leasedContainer.BreakLeaseAsync(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseTime = await leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(1));

            // Break infinite lease (60 seconds break time)
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            leaseTime = await leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(60));

            // Break breaking lease (zero break time)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            leaseTime = await leasedContainer.BreakLeaseAsync(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = await SetBreakingStateAsync(leasedContainer);
            await leasedContainer.BreakLeaseAsync(null /* default break period */);

            // Break finite lease (longer than lease time)
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = await leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(60));

            // Break finite lease (zero break time)
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = await leasedContainer.BreakLeaseAsync(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = await leasedContainer.BreakLeaseAsync(null /* default break period */);

            // Break broken lease (default break time)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await leasedContainer.BreakLeaseAsync(null /* default break period */);

            // Break instant broken lease (nonzero break time)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(1));

            // Break instant broken lease (zero break time)
            leaseId = await SetInstantBrokenStateAsync(leasedContainer);
            await leasedContainer.BreakLeaseAsync(TimeSpan.Zero);

            // Break released lease (default break time)
            leaseId = await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await TestHelper.ExpectedExceptionAsync(
                async () => await leasedContainer.BreakLeaseAsync(null /* default break period */, null, null, operationContext),
                operationContext,
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            await this.DeleteAllAsync();
        }

        [TestMethod]
        [Description("Tests container delete APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerLeasedDeleteTestsAsync()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();

            // Create the container
            await leasedContainer.CreateAsync();

            // Verify that deletes that pass a lease fail if none is present.
            testAccessCondition.LeaseId = fakeLease;
            await this.ContainerDeleteExpectLeaseFailureAsync(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "delete container using a lease when no lease is held");

            // Acquire a lease
            string leaseId = await leasedContainer.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that deletes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            await this.ContainerDeleteExpectLeaseFailureAsync(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "delete container using no lease when a lease is held");

            // Verify that deletes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await this.ContainerDeleteExpectLeaseFailureAsync(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "delete container using a lease when a different lease is held");

            // Verify that deletes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            await this.ContainerDeleteExpectLeaseSuccessAsync(leasedContainer, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test container deletion, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task ContainerDeleteExpectLeaseFailureAsync(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();
            await TestHelper.ExpectedExceptionAsync(
                async () => await testContainer.DeleteAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Delete)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test container deletion, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task ContainerDeleteExpectLeaseSuccessAsync(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            await testContainer.DeleteAsync(testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Tests container read and write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerLeasedReadWriteTestsAsync()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            await leasedContainer.CreateAsync();

            // Verify that reads and writes that pass a lease fail if none is present
            testAccessCondition.LeaseId = fakeLease;
            await this.ContainerReadWriteExpectLeaseFailureAsync(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "read/write container using a lease when no lease is held");

            // Acquire a lease
            string leaseId = await leasedContainer.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads and writes without a lease succeed.
            testAccessCondition.LeaseId = null;
            await this.ContainerReadWriteExpectLeaseSuccessAsync(leasedContainer, testAccessCondition);

            // Verify that reads and writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            await this.ContainerReadWriteExpectLeaseFailureAsync(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "read/write container using a lease when a different lease is held");

            // Verify that reads and writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            await this.ContainerReadWriteExpectLeaseSuccessAsync(leasedContainer, testAccessCondition);

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Test container reads and writes, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private async Task ContainerReadWriteExpectLeaseFailureAsync(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            OperationContext operationContext = new OperationContext();

            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            await TestHelper.ExpectedExceptionAsync(
                async () => await testContainer.FetchAttributesAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + "(Fetch Attributes)",
                HttpStatusCode.PreconditionFailed);

            await TestHelper.ExpectedExceptionAsync(
                async () => await testContainer.GetPermissionsAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Get Permissions)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await testContainer.SetMetadataAsync(testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Set Metadata)",
                expectedStatusCode,
                expectedErrorCode);
            await TestHelper.ExpectedExceptionAsync(
                async () => await testContainer.SetPermissionsAsync(new BlobContainerPermissions(), testAccessCondition, null /* options */, operationContext),
                operationContext,
                description + " (Set Permissions)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test container reads and writes, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private async Task ContainerReadWriteExpectLeaseSuccessAsync(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            await testContainer.FetchAttributesAsync(testAccessCondition, null /* options */, null);
            await testContainer.GetPermissionsAsync(testAccessCondition, null /* options */, null);
            await testContainer.SetMetadataAsync(testAccessCondition, null /* options */, null);
            await testContainer.SetPermissionsAsync(new BlobContainerPermissions(), testAccessCondition, null /* options */, null);
        }

        [TestMethod]
        [Description("Test reading the container lease status after various lease actions.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ContainerLeaseStatusTestAsync()
        {
            string leaseId;
            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Check uninitialized lease status
            await SetUnleasedStateAsync(leasedContainer);
            Assert.AreEqual(LeaseStatus.Unspecified, leasedContainer.Properties.LeaseStatus, "uninitialized lease status");
            Assert.AreEqual(LeaseState.Unspecified, leasedContainer.Properties.LeaseState, "uninitialized lease state");
            Assert.AreEqual(LeaseDuration.Unspecified, leasedContainer.Properties.LeaseDuration, "uninitialized lease duration");

            // Check lease status in initial state
            await SetUnleasedStateAsync(leasedContainer);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "initial lease state");

            // Check lease status after acquiring an infinite lease
            await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after acquire lease");

            // Check lease status after acquiring a finite lease
            await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(45));
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after acquire lease");

            // Check lease status after renewing an infinite lease
            await SetRenewedStateAsync(leasedContainer, null /* infinite lease */);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after renew lease");

            // Check lease status after renewing a finite lease
            await SetRenewedStateAsync(leasedContainer, TimeSpan.FromSeconds(45));
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after renew lease");

            // Check lease status after changing an infinite lease
            leaseId = await SetLeasedStateAsync(leasedContainer, null /* infinite lease */);
            await leasedContainer.ChangeLeaseAsync(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after change lease");

            // Check lease status after changing a finite lease
            leaseId = await SetLeasedStateAsync(leasedContainer, TimeSpan.FromSeconds(45));
            await leasedContainer.ChangeLeaseAsync(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after change lease");

            // Check lease status after releasing a lease
            await SetReleasedStateAsync(leasedContainer, null /* infinite lease */);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "after release lease");

            // Check lease status while infinite lease is breaking
            await SetBreakingStateAsync(leasedContainer);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Breaking, LeaseDuration.Unspecified, "while lease is breaking");

            // Check lease status after lease breaks
            await SetTimeBrokenStateAsync(leasedContainer);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after break time elapses");

            // Check lease status after (infinite) acquire after break
            await SetTimeBrokenStateAsync(leasedContainer);
            await leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /*proposed lease ID */);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after second acquire lease");

            // Check lease status after instant break with infinite lease
            await SetInstantBrokenStateAsync(leasedContainer);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after instant break lease");

            // Check lease status after lease expires
            await SetExpiredStateAsync(leasedContainer);
            await this.CheckLeaseStatusAsync(leasedContainer, LeaseStatus.Unlocked, LeaseState.Expired, LeaseDuration.Unspecified, "after lease expires");

            await this.DeleteAllAsync();
        }

        /// <summary>
        /// Checks the lease status of a container, both from its attributes and from a container listing.
        /// </summary>
        /// <param name="container">The container to test.</param>
        /// <param name="expectedStatus">The expected lease status.</param>
        /// <param name="expectedState">The expected lease state.</param>
        /// <param name="expectedDuration">The expected lease duration.</param>
        /// <param name="description">A description of the circumstances that lead to the expected status.</param>
        private async Task CheckLeaseStatusAsync(
            CloudBlobContainer container,
            LeaseStatus expectedStatus,
            LeaseState expectedState,
            LeaseDuration expectedDuration,
            string description)
        {
            await container.FetchAttributesAsync();
            Assert.AreEqual(expectedStatus, container.Properties.LeaseStatus, "LeaseStatus mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedState, container.Properties.LeaseState, "LeaseState mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedDuration, container.Properties.LeaseDuration, "LeaseDuration mismatch: " + description + " (from FetchAttributes)");

            ContainerResultSegment containers = await this.blobClient.ListContainersSegmentedAsync(container.Name, ContainerListingDetails.None, null, null, null, null);
            BlobContainerProperties propertiesInListing = (from CloudBlobContainer c in containers.Results
                                                           where c.Name == container.Name
                                                           select c.Properties).Single();

            Assert.AreEqual(expectedStatus, propertiesInListing.LeaseStatus, "LeaseStatus mismatch: " + description + " (from ListContainers)");
            Assert.AreEqual(expectedState, propertiesInListing.LeaseState, "LeaseState mismatch: " + description + " (from ListContainers)");
            Assert.AreEqual(expectedDuration, propertiesInListing.LeaseDuration, "LeaseDuration mismatch: " + description + " (from ListContainers)");
        }
    }
}
