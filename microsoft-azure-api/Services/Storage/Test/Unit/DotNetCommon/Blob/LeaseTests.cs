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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

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
        internal static void CreateBlob(ICloudBlob blob)
        {
            blob.Container.CreateIfNotExists();
            UploadText(blob, "LeaseTestBlobContent", Encoding.UTF8);
        }

#if TASK
         /// <summary>
        /// Create the given blob and, if necessary, its container.
        /// </summary>
        /// <param name="blob">The blob to create.</param>
        internal static void CreateBlobTask(ICloudBlob blob)
        {
            blob.Container.CreateIfNotExistsAsync().Wait();
            UploadTextTask(blob, "LeaseTestBlobContent", Encoding.UTF8);
        }
#endif

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
        internal void DeleteAll()
        {
            try
            {
                // Delete all containers with prefix
                foreach (CloudBlobContainer container in this.blobClient.ListContainers(this.prefix, ContainerListingDetails.None))
                {
                    try
                    {
                        container.BreakLease(TimeSpan.Zero);
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        container.Delete();
                    }
                    catch (Exception)
                    {
                    }
                }

                // Delete all blobs in root container with prefix
                CloudBlobContainer rc = this.blobClient.GetRootContainerReference();
                foreach (ICloudBlob blob in rc.ListBlobs(this.prefix, true, BlobListingDetails.None, null, null))
                {
                    try
                    {
                        blob.BreakLease(TimeSpan.Zero);
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        blob.Delete(DeleteSnapshotsOption.IncludeSnapshots, null /* access conditions */, null /* options */);
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

#if TASK
         /// <summary>
        /// Deletes all containers beginning with the current prefix, and all blobs in the root container beginning with the current prefix.
        /// Any existing lease is broken before the resource is deleted. All exceptions are ignored.
        /// </summary>
        internal void DeleteAllTask()
        {
            try
            {
                // Delete all containers with prefix
                foreach (CloudBlobContainer container in this.blobClient.ListContainers(this.prefix, ContainerListingDetails.None))
                {
                    try
                    {
                        container.BreakLeaseAsync(TimeSpan.Zero).Wait();
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        container.DeleteAsync().Wait();
                    }
                    catch (Exception)
                    {
                    }
                }

                // Delete all blobs in root container with prefix
                CloudBlobContainer rc = this.blobClient.GetRootContainerReference();
                foreach (ICloudBlob blob in rc.ListBlobs(this.prefix, true, BlobListingDetails.None, null, null))
                {
                    try
                    {
                        blob.BreakLeaseAsync(TimeSpan.Zero).Wait();
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        blob.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots, null /* access conditions */, null /* options */, new OperationContext());
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
#endif

        /// <summary>
        /// Puts the lease on the given blob in an available state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        internal static void SetAvailableState(ICloudBlob blob)
        {
            bool shouldBreakFirst = false;

            try
            {
                blob.DeleteIfExists();
            }
            catch (StorageException exception)
            {
                if (exception.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
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
                blob.BreakLease(TimeSpan.Zero);
                blob.Delete();
            }
            CreateBlob(blob);
        }

        /// <summary>
        /// Puts the lease on the given blob in an available state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        internal static void SetAvailableStateAPM(ICloudBlob blob)
        {
            bool shouldBreakFirst = false;

            try
            {
                blob.DeleteIfExists();
            }
            catch (StorageException exception)
            {
                if (exception.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
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
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = blob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    blob.EndBreakLease(result);
                    blob.Delete();
                }
            }
            CreateBlob(blob);
        }

#if TASK
        /// <summary>
        /// Puts the lease on the given blob in an available state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        internal static void SetAvailableStateTask(ICloudBlob blob)
        {
            bool shouldBreakFirst = false;

            try
            {
                blob.DeleteIfExistsAsync().Wait();
            }
            catch (AggregateException ex)
            {
                StorageException exception = ex.InnerException as StorageException;
                if (exception == null)
                {
                    throw;
                }
                
                if (exception.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
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
                blob.BreakLeaseAsync(TimeSpan.Zero).Wait();

                blob.DeleteAsync().Wait();
            }
            CreateBlobTask(blob);
        }
#endif

        /// <summary>
        /// Puts the lease on the given blob in a leased state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the new lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetLeasedState(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            SetAvailableState(blob);
            return blob.AcquireLease(leaseTime, leaseId);
        }

        /// <summary>
        /// Puts the lease on the given blob in a leased state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the new lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetLeasedStateAPM(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            SetAvailableStateAPM(blob);
            IAsyncResult result;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                result = blob.BeginAcquireLease(leaseTime, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
            }
            return blob.EndAcquireLease(result);
        }

#if TASK
        /// <summary>
        /// Puts the lease on the given blob in a leased state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the new lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetLeasedStateTask(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            SetAvailableStateTask(blob);
            return blob.AcquireLeaseAsync(leaseTime, leaseId).Result;
        }
#endif

        /// <summary>
        /// Puts the lease on the given blob in a renewed state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the renewed lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetRenewedState(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedState(blob, leaseTime);
            blob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a released state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static string SetReleasedState(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedState(blob, leaseTime);
            blob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a released state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static string SetReleasedStateAPM(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedStateAPM(blob, leaseTime);
            IAsyncResult result;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                result = blob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                blob.EndReleaseLease(result);
                return leaseId;
            }
        }

#if TASK
        /// <summary>
        /// Puts the lease on the given blob in a released state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static string SetReleasedStateTask(ICloudBlob blob, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedStateAPM(blob, leaseTime);
            blob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();
            return leaseId;
        }
#endif

        /// <summary>
        /// Puts the lease on the given blob in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static string SetBreakingState(ICloudBlob blob)
        {
            string leaseId = SetLeasedState(blob, null /* infinite lease */);
            blob.BreakLease(TimeSpan.FromSeconds(60));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static string SetBreakingStateAPM(ICloudBlob blob)
        {
            string leaseId = SetLeasedStateAPM(blob, null /* infinite lease */);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = blob.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                blob.EndBreakLease(result);
            }
            
            return leaseId;
        }

#if TASK
        /// <summary>
        /// Puts the lease on the given blob in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static string SetBreakingStateTask(ICloudBlob blob)
        {
            string leaseId = SetLeasedStateTask(blob, null /* infinite lease */);

            blob.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Wait();
            
            return leaseId;
        }
#endif

        /// <summary>
        /// Puts the lease on the given blob in a broken state due to the break period expiring.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetTimeBrokenState(ICloudBlob blob)
        {
            string leaseId = SetLeasedState(blob, null /* infinite lease */);
            blob.BreakLease(TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetInstantBrokenState(ICloudBlob blob)
        {
            string leaseId = SetLeasedState(blob, null /* infinite lease */);
            blob.BreakLease(TimeSpan.Zero);
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetInstantBrokenStateAPM(ICloudBlob blob)
        {
            string leaseId = SetLeasedStateAPM(blob, null /* infinite lease */);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = blob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                blob.EndBreakLease(result);
            }
            
            return leaseId;
        }

#if TASK
        /// <summary>
        /// Puts the lease on the given blob in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetInstantBrokenStateTask(ICloudBlob blob)
        {
            string leaseId = SetLeasedStateTask(blob, null /* infinite lease */);
            blob.BreakLeaseAsync(TimeSpan.Zero).Wait();            
            return leaseId;
        }
#endif

        /// <summary>
        /// Puts the lease on the given blob in an expired state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static string SetExpiredState(ICloudBlob blob)
        {
            string leaseId = SetLeasedState(blob, TimeSpan.FromSeconds(15));
            Thread.Sleep(TimeSpan.FromSeconds(17));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given blob in an expired state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static string SetExpiredStateAPM(ICloudBlob blob)
        {
            string leaseId = SetLeasedStateAPM(blob, TimeSpan.FromSeconds(15));
            Thread.Sleep(TimeSpan.FromSeconds(17));
            return leaseId;
        }

#if TASK
        /// <summary>
        /// Puts the lease on the given blob in an expired state.
        /// </summary>
        /// <param name="blob">The blob with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static string SetExpiredStateTask(ICloudBlob blob)
        {
            string leaseId = SetLeasedStateTask(blob, TimeSpan.FromSeconds(15));
            Thread.Sleep(TimeSpan.FromSeconds(17));
            return leaseId;
        }
#endif

        /// <summary>
        /// Puts the lease on the given container in an unleased state (either available or broken).
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        internal static void SetUnleasedState(CloudBlobContainer container)
        {
            if (!container.CreateIfNotExists())
            {
                try
                {
                    container.BreakLease(TimeSpan.Zero);
                }
                catch (StorageException e)
                {
                    if (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseAlreadyBroken ||
                        e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation)
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
        /// Puts the lease on the given container in an unleased state (either available or broken).
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        internal static void SetUnleasedStateAPM(CloudBlobContainer container)
        {
            if (!container.CreateIfNotExists())
            {
                try
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        IAsyncResult result = container.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                        waitHandle.WaitOne();
                        container.EndBreakLease(result);
                    }
                }
                catch (StorageException e)
                {
                    if (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseAlreadyBroken ||
                        e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation)
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
        internal static string SetLeasedState(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            SetUnleasedState(container);
            return container.AcquireLease(leaseTime, leaseId);
        }

        /// <summary>
        /// Puts the lease on the given container in a leased state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the new lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetLeasedStateAPM(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = Guid.NewGuid().ToString();
            SetUnleasedStateAPM(container);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginAcquireLease(leaseTime, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                return container.EndAcquireLease(result);
            }
        }

        /// <summary>
        /// Puts the lease on the given container in a renewed state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the renewed lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetRenewedState(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedState(container, leaseTime);
            container.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a renewed state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the renewed lease.</param>
        /// <returns>The lease ID of the current lease.</returns>
        internal static string SetRenewedStateAPM(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedStateAPM(container, leaseTime);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                container.EndRenewLease(result);
                return leaseId;
            }
        }

        /// <summary>
        /// Puts the lease on the given container in a released state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static string SetReleasedState(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedState(container, leaseTime);
            container.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a released state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <param name="leaseTime">The amount of time on the released lease.</param>
        /// <returns>The lease ID of the released lease.</returns>
        internal static string SetReleasedStateAPM(CloudBlobContainer container, TimeSpan? leaseTime)
        {
            string leaseId = SetLeasedStateAPM(container, leaseTime);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                container.EndReleaseLease(result);
                return leaseId;
            }
        }

        /// <summary>
        /// Puts the lease on the given container in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static string SetBreakingState(CloudBlobContainer container)
        {
            string leaseId = SetLeasedState(container, null /* infinite lease */);
            container.BreakLease(TimeSpan.FromSeconds(60));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a breaking state for 60 seconds.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the current (but breaking) lease.</returns>
        internal static string SetBreakingStateAPM(CloudBlobContainer container)
        {
            string leaseId = SetLeasedStateAPM(container, null /* infinite lease */);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                container.EndBreakLease(result);
                return leaseId;
            }
        }

        /// <summary>
        /// Puts the lease on the given container in a broken state due to the break period expiring.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetTimeBrokenState(CloudBlobContainer container)
        {
            string leaseId = SetLeasedState(container, null /* infinite lease */);
            container.BreakLease(TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a broken state due to the break period expiring.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetTimeBrokenStateAPM(CloudBlobContainer container)
        {
            string leaseId = SetLeasedStateAPM(container, null /* infinite lease */);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginBreakLease(TimeSpan.FromSeconds(1), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                container.EndBreakLease(result);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                return leaseId;
            }
        }

        /// <summary>
        /// Puts the lease on the given container in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetInstantBrokenState(CloudBlobContainer container)
        {
            string leaseId = SetLeasedState(container, null /* infinite lease */);
            container.BreakLease(TimeSpan.Zero);
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in a broken state due to a break period of zero.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the broken lease.</returns>
        internal static string SetInstantBrokenStateAPM(CloudBlobContainer container)
        {
            string leaseId = SetLeasedStateAPM(container, null /* infinite lease */);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                container.EndBreakLease(result);
                return leaseId;
            }
        }

        /// <summary>
        /// Puts the lease on the given container in an expired state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static string SetExpiredState(CloudBlobContainer container)
        {
            string leaseId = SetLeasedState(container, TimeSpan.FromSeconds(15));
            Thread.Sleep(TimeSpan.FromSeconds(17));
            return leaseId;
        }

        /// <summary>
        /// Puts the lease on the given container in an expired state.
        /// </summary>
        /// <param name="container">The container with the lease.</param>
        /// <returns>The lease ID of the expired lease.</returns>
        internal static string SetExpiredStateAPM(CloudBlobContainer container)
        {
            string leaseId = SetLeasedStateAPM(container, TimeSpan.FromSeconds(15));
            Thread.Sleep(TimeSpan.FromSeconds(17));
            return leaseId;
        }

        [TestMethod]
        [Description("Test lease acquire semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobAcquireLeaseSemanticTests()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            SetAvailableState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(TimeSpan.FromSeconds(15), null /* proposed lease ID */);
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            SetAvailableState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(TimeSpan.FromSeconds(60), null /* proposed lease ID */);
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            SetAvailableState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(null /* infinite lease */, null /* proposed lease ID */);
            this.BlobAcquireRenewLeaseTest(leasedBlob, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            SetReleasedState(leasedBlob, null /* infinite lease */);
            leaseId = leasedBlob.AcquireLease(TimeSpan.FromSeconds(15), leaseId);
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId = leasedBlob.AcquireLease(TimeSpan.FromSeconds(15), leaseId);
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            SetExpiredState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(null /* infinite lease */, leaseId);
            this.BlobAcquireRenewLeaseTest(leasedBlob, null /* infinite lease */, TimeSpan.FromSeconds(20), tolerance);

            SetInstantBrokenState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(TimeSpan.FromSeconds(15), leaseId);
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease renew semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobRenewLeaseSemanticTests()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(15));
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(60));
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            this.BlobAcquireRenewLeaseTest(leasedBlob, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            this.BlobAcquireRenewLeaseTest(leasedBlob, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            this.DeleteAll();
        }

        /// <summary>
        /// Verifies the behavior of a lease while the lease holds. Once the lease expires, this method confirms that write operations succeed.
        /// The test is cut short once the <c>testLength</c> time has elapsed. (This last feature is necessary for infinite leases.)
        /// </summary>
        /// <param name="leasedBlob">The blob to test.</param>
        /// <param name="duration">The duration of the lease.</param>
        /// <param name="testLength">The maximum length of time to run the test.</param>
        /// <param name="tolerance">The allowed lease time error.</param>
        internal void BlobAcquireRenewLeaseTest(ICloudBlob leasedBlob, TimeSpan? duration, TimeSpan testLength, TimeSpan tolerance)
        {
            DateTime beginTime = DateTime.UtcNow;

            bool testOver = false;
            do
            {
                try
                {
                    // Attempt to write to the blob with no lease ID.
                    leasedBlob.SetMetadata();

                    // The write succeeded, which means that the lease must have expired.

                    // If the lease was infinite then there is an error because it should not have expired.
                    Assert.IsNotNull(duration, "An infinite lease should not expire.");

                    // The lease should be past its expiration time.
                    Assert.IsTrue(DateTime.UtcNow - beginTime > duration - tolerance, "Writes should not succeed while lease is present.");

                    // Since the lease has expired, the test is over.
                    testOver = true;
                }
                catch (StorageException exception)
                {
                    if (exception.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
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
                leasedBlob.FetchAttributes();

                // Wait 1 second before trying again.
                if (!testOver)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
            while (!testOver);

            // The lease expired. Write to and read from the blob once more.
            leasedBlob.SetMetadata();
            leasedBlob.FetchAttributes();
        }

        [TestMethod]
        [Description("Test blob leasing with invalid inputs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeaseInvalidInputTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string invalidLeaseId = "invalid";
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CreateBlob(leasedBlob);

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedBlob.AcquireLease(TimeSpan.Zero, null /* proposed lease ID */),
                "acquire a lease with 0 duration");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedBlob.AcquireLease(TimeSpan.FromSeconds(-1), null /* proposed lease ID */),
                "acquire a lease with -1 duration");

            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(TimeSpan.FromSeconds(1), null /* proposed lease ID */),
                "acquire a lease with 1 s duration",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(TimeSpan.FromSeconds(14), null /* proposed lease ID */),
                "acquire a lease that is too short",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(TimeSpan.FromSeconds(61), null /* proposed lease ID */),
                "acquire a lease that is too long",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(null /* infinite lease */, invalidLeaseId),
                "acquire a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            // The following tests assume that the blob is leased
            leaseId = leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedBlob.RenewLease(null /* access condition */),
                "renew with null access condition");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedBlob.RenewLease(AccessCondition.GenerateEmptyCondition()),
                "renew with no lease ID");

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedBlob.ChangeLease(proposedLeaseId, null /* access condition */),
                "change with null access condition");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateEmptyCondition()),
                "change with no lease ID");

            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(invalidLeaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedBlob.ChangeLease(null /* proposed lease ID */, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a lease with no proposed lease ID");

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedBlob.ReleaseLease(null /* access condition */),
                "release with null access condition");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateEmptyCondition()),
                "release with no lease ID");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedBlob.BreakLease(TimeSpan.FromSeconds(-1)),
                "break with negative break time");

            TestHelper.ExpectedException(
                () => leasedBlob.BreakLease(TimeSpan.FromSeconds(61)),
                "break with too large break time",
                HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobAcquireLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Acquire the lease while in available state, make idempotent call
            SetAvailableState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);
            leaseId2 = leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);
            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while in leased state (conflict)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(null /* infinite lease */, leaseId),
                "acquire a lease while in the breaking state (same ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.AcquireLease(null /* infinite lease */, leaseId);
            leasedBlob.AcquireLease(null /* infinite lease */, leaseId);

            // Acquire the lease while in broken state (new ID), make idempotent call
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);
            leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);

            // Acquire the lease while in released state (same ID), make idempotent call
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.AcquireLease(null /* infinite lease */, leaseId);
            leasedBlob.AcquireLease(null /* infinite lease */, leaseId);

            // Acquire the lease while in released state (new ID), make idempotent call
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);
            leasedBlob.AcquireLease(null /* infinite lease */, proposedLeaseId);

            // Acquire with no proposed ID (non-idempotent)
            SetAvailableState(leasedBlob);
            leaseId = leasedBlob.AcquireLease(null /* infinite lease */, null /* proposed lease ID */);
            TestHelper.ExpectedException(
                () => leasedBlob.AcquireLease(null /* infinite lease */, null /* proposed lease ID */),
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Delete the blob
            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobAcquireLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Acquire the lease while in available state, make idempotent call
            SetAvailableStateAPM(leasedBlob);
            IAsyncResult result;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedBlob.EndAcquireLease(result);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndAcquireLease(result);

                Assert.AreEqual(leaseId, leaseId2);

                // Acquire the lease while in leased state (conflict)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease while in leased state (conflict)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);

                // Acquire the lease while breaking (same ID)
                leaseId = SetBreakingStateAPM(leasedBlob);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease while in the breaking state (same ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

                // Acquire the lease while breaking (different ID)
                leaseId = SetBreakingStateAPM(leasedBlob);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease while breaking (different ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);

                // Acquire the lease while in broken state (same ID), make idempotent call
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire the lease while in broken state (new ID), make idempotent call
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire the lease while in released state (same ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire the lease while in released state (new ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire with no proposed ID (non-idempotent)
                SetAvailableStateAPM(leasedBlob);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease twice with no proposed lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);
            }

            // Delete the blob
            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobAcquireLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Acquire the lease while in available state, make idempotent call
            SetAvailableStateAPM(leasedBlob);
            IAsyncResult result;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedBlob.EndAcquireLease(result);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndAcquireLease(result);

                Assert.AreEqual(leaseId, leaseId2);

                // Acquire the lease while in leased state (conflict)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease while in leased state (conflict)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);

                // Acquire the lease while breaking (same ID)
                leaseId = SetBreakingStateAPM(leasedBlob);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease while in the breaking state (same ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

                // Acquire the lease while breaking (different ID)
                leaseId = SetBreakingStateAPM(leasedBlob);

                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease while breaking (different ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);

                // Acquire the lease while in broken state (same ID), make idempotent call
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire the lease while in broken state (new ID), make idempotent call
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire the lease while in released state (same ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire the lease while in released state (new ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);

                // Acquire with no proposed ID (non-idempotent)
                SetAvailableStateAPM(leasedBlob);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndAcquireLease(result);
                result = leasedBlob.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndAcquireLease(result),
                    "acquire a lease twice with no proposed lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);
            }
            // Delete the blob
            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobAcquireLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Acquire the lease while in available state, make idempotent call
            SetAvailableStateTask(leasedBlob);

            leaseId = leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Result;

            leaseId2 = leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Result;

            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            SetLeasedStateTask(leasedBlob, null /* infinite lease */);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while in leased state (conflict)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = SetBreakingStateTask(leasedBlob);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId),
                "acquire a lease while in the breaking state (same ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            SetBreakingStateTask(leasedBlob);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();

            // Acquire the lease while in broken state (new ID), make idempotent call
            SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();

            // Acquire the lease while in released state (same ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            
            // Acquire the lease while in released state (new ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
            SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            OperationContext context = new OperationContext();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, context).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, context).Wait();

            // Acquire with no proposed ID (non-idempotent)
            SetAvailableStateTask(leasedBlob);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */, null, null, context).Wait();

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */, null, null, context),
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);
            

            // Delete the blob
            this.DeleteAllTask();
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobAcquireLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Acquire the lease while in available state, make idempotent call
            SetAvailableStateTask(leasedBlob);

            leaseId = leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Result;
            leaseId2 = leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Result;

            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while in leased state (conflict)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = SetBreakingStateTask(leasedBlob);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId),
                "acquire a lease while in the breaking state (same ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            leaseId = SetBreakingStateTask(leasedBlob);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            
            // Acquire the lease while in broken state (new ID), make idempotent call
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();
            
            // Acquire the lease while in released state (same ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            
            // Acquire the lease while in released state (new ID), make idempotent call. Also, use the other overload for BeginAcquireLease.
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            OperationContext context = new OperationContext();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, context).Wait();
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId, null, null, context).Wait();

            // Acquire with no proposed ID (non-idempotent)
            SetAvailableStateTask(leasedBlob);
            leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */, null, null, context).Wait();

            TestHelper.ExpectedExceptionTask(
                leasedBlob.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */, null, null, context),
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);
            
            // Delete the blob
            this.DeleteAllTask();
        }
#endif

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobRenewLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Renew lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew infinite lease (wrong lease)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = SetExpiredState(leasedBlob);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after read
            leaseId = SetExpiredState(leasedBlob);
            string content = DownloadText(leasedBlob, Encoding.UTF8);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after write
            leaseId = SetExpiredState(leasedBlob);
            leasedBlob.SetMetadata();
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew an expired lease that has been modified",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew finite lease
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(60));
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease (wrong lease)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = SetReleasedState(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = SetReleasedState(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobRenewLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Renew lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew infinite lease (wrong lease)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = SetExpiredState(leasedBlob);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after read
            leaseId = SetExpiredState(leasedBlob);
            string content = DownloadText(leasedBlob, Encoding.UTF8);
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after write
            leaseId = SetExpiredState(leasedBlob);
            leasedBlob.SetMetadata();
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew an expired lease that has been modified",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew finite lease
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(60));
            leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease (wrong lease)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = SetReleasedState(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = SetReleasedState(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobRenewLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Renew lease in available state
                SetAvailableStateAPM(leasedBlob);
                IAsyncResult result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a lease while in the available state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew infinite lease
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew infinite lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew an infinite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released lease (wrong lease)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released infinite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released lease
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew expired lease
                leaseId = SetExpiredStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew expired lease after read
                leaseId = SetExpiredStateAPM(leasedBlob);
                string content = DownloadText(leasedBlob, Encoding.UTF8);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew expired lease after write
                leaseId = SetExpiredStateAPM(leasedBlob);
                leasedBlob.SetMetadata();
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew an expired lease that has been modified",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew finite lease
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew finite lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a finite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released finite lease (wrong ID)
                leaseId = SetReleasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released finite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released finite lease (right ID)
                leaseId = SetReleasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released finite lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew a breaking lease (same ID)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a lease while in the breaking state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

                // Renew a breaking lease (different ID)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a lease while in the breaking state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew broken lease (same ID)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a broken lease with the same lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

                // Renew broken lease (different ID)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a broken lease with a different lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                this.DeleteAll();
            }
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobRenewLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Renew lease in available state
                SetAvailableStateAPM(leasedBlob);
                IAsyncResult result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a lease while in the available state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew infinite lease
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew infinite lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew an infinite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released lease (wrong lease)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released infinite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released lease
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew expired lease
                leaseId = SetExpiredStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew expired lease after read
                leaseId = SetExpiredStateAPM(leasedBlob);
                string content = DownloadText(leasedBlob, Encoding.UTF8);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew expired lease after write
                leaseId = SetExpiredStateAPM(leasedBlob);
                leasedBlob.SetMetadata();
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew an expired lease that has been modified",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew finite lease
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndRenewLease(result);

                // Renew finite lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a finite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released finite lease (wrong ID)
                leaseId = SetReleasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released finite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released finite lease (right ID)
                leaseId = SetReleasedStateAPM(leasedBlob, TimeSpan.FromSeconds(60));
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a released finite lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew a breaking lease (same ID)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a lease while in the breaking state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

                // Renew a breaking lease (different ID)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a lease while in the breaking state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew broken lease (same ID)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a broken lease with the same lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

                // Renew broken lease (different ID)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndRenewLease(result),
                    "renew a broken lease with a different lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                this.DeleteAll();
            }
        }

#if TASK
        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobRenewLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Renew lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew infinite lease (wrong lease)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = SetExpiredStateTask(leasedBlob);
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew expired lease after read
            leaseId = SetExpiredStateTask(leasedBlob);
            string content = DownloadTextTask(leasedBlob, Encoding.UTF8);
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew expired lease after write
            leaseId = SetExpiredStateTask(leasedBlob);
            leasedBlob.SetMetadataAsync().Wait();
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew an expired lease that has been modified",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew finite lease
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew finite lease (wrong lease)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = SetReleasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = SetReleasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = SetBreakingStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = SetBreakingStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, new OperationContext()),
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAllTask();
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobRenewLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Renew lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew infinite lease (wrong lease)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = SetExpiredStateTask(leasedBlob);
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew expired lease after read
            leaseId = SetExpiredStateTask(leasedBlob);
            string content = DownloadTextTask(leasedBlob, Encoding.UTF8);
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew expired lease after write
            leaseId = SetExpiredStateTask(leasedBlob);
            leasedBlob.SetMetadataAsync().Wait();
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew an expired lease that has been modified",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew finite lease
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew finite lease (wrong lease)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = SetReleasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = SetReleasedStateTask(leasedBlob, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = SetBreakingStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = SetBreakingStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, new OperationContext()),
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAllTask();
        }
#endif

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobChangeLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Change lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId));

            // Change lease (wrong lease specified)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease using the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change released lease
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change released lease (to previous lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change a breaking lease (same ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a breaking lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

            // Change a breaking lease (different ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change broken lease
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2)),
                "change a broken lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change broken lease (to previous lease)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a broken lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobChangeLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Change lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId));

            // Change lease (wrong lease specified)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease using the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change released lease
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change released lease (to previous lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change a breaking lease (same ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a breaking lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

            // Change a breaking lease (different ID)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change broken lease
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2)),
                "change a broken lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change broken lease (to previous lease)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a broken lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobChangeLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Change lease in available state
            SetAvailableStateAPM(leasedBlob);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a lease when no lease is held",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change leased lease, with idempotent change
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndChangeLease(result);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndChangeLease(result);

                // Change a leased lease, with same proposed ID but different lease ID
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndChangeLease(result);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndChangeLease(result);

                // Change lease (wrong lease specified)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndChangeLease(result);

                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a lease using the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Change released lease
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change released lease (to previous lease)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a released lease (to previous lease)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change a breaking lease (same ID). Use the other overload for BeginChangeLease.
                leaseId = SetBreakingStateAPM(leasedBlob);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a breaking lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

                // Change a breaking lease (different ID)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a breaking lease (with wrong ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Change broken lease
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a broken lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change broken lease (to previous lease)
                leaseId = SetInstantBrokenState(leasedBlob);
                result = leasedBlob.BeginChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a broken lease (to previous lease)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                this.DeleteAll();
            }
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobChangeLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Change lease in available state
            SetAvailableStateAPM(leasedBlob);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a lease when no lease is held",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change leased lease, with idempotent change
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndChangeLease(result);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndChangeLease(result);

                // Change a leased lease, with same proposed ID but different lease ID
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndChangeLease(result);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndChangeLease(result);

                // Change lease (wrong lease specified)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedBlob.EndChangeLease(result);

                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a lease using the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Change released lease
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change released lease (to previous lease)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a released lease (to previous lease)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change a breaking lease (same ID). Use the other overload for BeginChangeLease.
                leaseId = SetBreakingStateAPM(leasedBlob);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a breaking lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

                // Change a breaking lease (different ID)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a breaking lease (with wrong ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Change broken lease
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a broken lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change broken lease (to previous lease)
                leaseId = SetInstantBrokenState(leasedBlob);
                result = leasedBlob.BeginChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndChangeLease(result),
                    "change a broken lease (to previous lease)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                this.DeleteAll();
            }
        }

#if TASK
        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobChangeLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Change lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), null, new OperationContext()).Result;
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, new OperationContext()).Result;
            
            this.DeleteAllTask();
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobChangeLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Change lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), null, new OperationContext()).Result;
            leaseId2 = leasedBlob.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, new OperationContext()).Result;
            
            this.DeleteAllTask();
        }
#endif

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobReleaseLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Release lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release lease in released state (old lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "release a released lease (using previous lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease in released state (unknown lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a released lease (using wrong lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release breaking lease (right lease)
            leaseId = SetBreakingState(leasedBlob);
            leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release breaking lease (wrong lease)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release broken lease (right lease)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release broken lease (wrong lease)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a broken lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReleaseLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Release lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release lease in released state (old lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "release a released lease (using previous lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease in released state (unknown lease)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a released lease (using wrong lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release breaking lease (right lease)
            leaseId = SetBreakingState(leasedBlob);
            leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release breaking lease (wrong lease)
            leaseId = SetBreakingState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release broken lease (right lease)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release broken lease (wrong lease)
            leaseId = SetInstantBrokenState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a broken lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobReleaseLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Release lease in available state
            SetAvailableStateAPM(leasedBlob);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a lease when no lease is held",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease (right lease)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndReleaseLease(result);

                // Release lease in released state (old lease)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a released lease (using previous lease ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease in released state (unknown lease), Use overload for BeginReleaseLease.
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a released lease (using wrong lease ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release breaking lease (right lease), Use overload for BeginReleaseLease.
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndReleaseLease(result);

                // Release breaking lease (wrong lease), Use overload for BeginReleaseLease.
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a breaking lease (with wrong ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release broken lease (right lease), Use overload for BeginReleaseLease.
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndReleaseLease(result);

                // Release broken lease (wrong lease)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();

                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a broken lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                this.DeleteAll();
            }
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReleaseLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Release lease in available state
            SetAvailableStateAPM(leasedBlob);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a lease when no lease is held",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease (right lease)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndReleaseLease(result);

                // Release lease in released state (old lease)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a released lease (using previous lease ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease in released state (unknown lease), Use overload for BeginReleaseLease.
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a released lease (using wrong lease ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release breaking lease (right lease), Use overload for BeginReleaseLease.
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndReleaseLease(result);

                // Release breaking lease (wrong lease), Use overload for BeginReleaseLease.
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a breaking lease (with wrong ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release broken lease (right lease), Use overload for BeginReleaseLease.
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndReleaseLease(result);

                // Release broken lease (wrong lease)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();

                TestHelper.ExpectedException(
                    () => leasedBlob.EndReleaseLease(result),
                    "release a broken lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                this.DeleteAll();
            }
        }

#if TASK
        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobReleaseLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Release lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, new OperationContext()).Wait();

            this.DeleteAllTask();
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReleaseLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Release lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leasedBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, new OperationContext());

            this.DeleteAllTask();
        }
#endif

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobBreakLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Break lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.BreakLease(null /* default break period */),
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(null /* default break period */);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(TimeSpan.FromSeconds(1));

            // Break infinite lease (60 seconds break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(TimeSpan.FromSeconds(60));

            // Break breaking lease (zero break time)
            leaseId = SetBreakingState(leasedBlob);
            leaseTime = leasedBlob.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = SetBreakingState(leasedBlob);
            leasedBlob.BreakLease(null /* default break time */);

            // Break finite lease (longer than lease time)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLease(TimeSpan.FromSeconds(60));

            // Break finite lease (zero break time)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLease(null /* default break time */);

            // Break instant broken lease (default break time)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.BreakLease(null /* default break time */);

            // Break instant broken lease (nonzero break time)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.BreakLease(TimeSpan.FromSeconds(1));

            // Break instant broken lease (zero break time)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.BreakLease(TimeSpan.Zero);

            // Break released lease (default break time)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.BreakLease(null /* default break time */),
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobBreakLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Break lease in available state
            SetAvailableState(leasedBlob);
            TestHelper.ExpectedException(
                () => leasedBlob.BreakLease(null /* default break period */),
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(null /* default break period */);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(TimeSpan.FromSeconds(1));

            // Break infinite lease (60 seconds break time)
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLease(TimeSpan.FromSeconds(60));

            // Break breaking lease (zero break time)
            leaseId = SetBreakingState(leasedBlob);
            leaseTime = leasedBlob.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = SetBreakingState(leasedBlob);
            leasedBlob.BreakLease(null /* default break time */);

            // Break finite lease (longer than lease time)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLease(TimeSpan.FromSeconds(60));

            // Break finite lease (zero break time)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLease(null /* default break time */);

            // Break instant broken lease (default break time)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.BreakLease(null /* default break time */);

            // Break instant broken lease (nonzero break time)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.BreakLease(TimeSpan.FromSeconds(1));

            // Break instant broken lease (zero break time)
            leaseId = SetInstantBrokenState(leasedBlob);
            leasedBlob.BreakLease(TimeSpan.Zero);

            // Break released lease (default break time)
            leaseId = SetReleasedState(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedBlob.BreakLease(null /* default break time */),
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobBreakLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Break lease in available state
            SetAvailableStateAPM(leasedBlob);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;

                result = leasedBlob.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndBreakLease(result),
                    "break a lease when no lease is present",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Break infinite lease (default break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break infinite lease (zero break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break infinite lease (1 second break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(1), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);

                // Break infinite lease (60 seconds break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                
                // Break breaking lease (zero break time)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break breaking lease (default break time)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(null /* default break time */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);
                
                // Break finite lease (longer than lease time)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(50));
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);
                
                // Break finite lease (zero break time)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(50));
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break finite lease (default break time)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(50));
                result = leasedBlob.BeginBreakLease(null /* default break time */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);
                
                // Break instant broken lease (default break time). Use the other overload for BeginBreakLease.
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginBreakLease(null /* default break time */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);
                
                // Break instant broken lease (nonzero break time)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(1), null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);
                
                // Break instant broken lease (zero break time)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);
                
                // Break released lease (default break time)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(null /* default break time */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndBreakLease(result),
                    "break a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                this.DeleteAll();
            }
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobBreakLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Break lease in available state
            SetAvailableStateAPM(leasedBlob);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;

                result = leasedBlob.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndBreakLease(result),
                    "break a lease when no lease is present",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Break infinite lease (default break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break infinite lease (zero break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break infinite lease (1 second break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(1), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);

                // Break infinite lease (60 seconds break time)
                leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);

                // Break breaking lease (zero break time)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break breaking lease (default break time)
                leaseId = SetBreakingStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(null /* default break time */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);

                // Break finite lease (longer than lease time)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(50));
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);

                // Break finite lease (zero break time)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(50));
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedBlob.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break finite lease (default break time)
                leaseId = SetLeasedStateAPM(leasedBlob, TimeSpan.FromSeconds(50));
                result = leasedBlob.BeginBreakLease(null /* default break time */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);

                // Break instant broken lease (default break time). Use the other overload for BeginBreakLease.
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                OperationContext context = new OperationContext();
                result = leasedBlob.BeginBreakLease(null /* default break time */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);

                // Break instant broken lease (nonzero break time)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(TimeSpan.FromSeconds(1), null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);

                // Break instant broken lease (zero break time)
                leaseId = SetInstantBrokenStateAPM(leasedBlob);
                result = leasedBlob.BeginBreakLease(TimeSpan.Zero, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedBlob.EndBreakLease(result);

                // Break released lease (default break time)
                leaseId = SetReleasedStateAPM(leasedBlob, null /* infinite lease */);
                result = leasedBlob.BeginBreakLease(null /* default break time */, null, null, context, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedBlob.EndBreakLease(result),
                    "break a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                this.DeleteAll();
            }
        }

#if TASK
        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobBreakLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Break lease in available state
            SetAvailableStateTask(leasedBlob);

            TestHelper.ExpectedExceptionTask(
                leasedBlob.BreakLeaseAsync(null /* default break period */),
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(null /* default break period */).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(1)).Result;

            // Break infinite lease (60 seconds break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Result;
                
            // Break breaking lease (zero break time)
            leaseId = SetBreakingStateTask(leasedBlob);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = SetBreakingStateTask(leasedBlob);
            leasedBlob.BreakLeaseAsync(null /* default break time */).Wait();
                
            // Break finite lease (longer than lease time)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(50));
            leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Wait();
                
            // Break finite lease (zero break time)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(50));
            leasedBlob.BreakLeaseAsync(null /* default break time */).Wait();
                
            // Break instant broken lease (default break time). Use the other overload for BeginBreakLease.
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            OperationContext context = new OperationContext();
            leasedBlob.BreakLeaseAsync(null /* default break time */, null, null, context).Wait();
                
            // Break instant broken lease (nonzero break time)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(1), null, null, context).Wait();
                
            // Break instant broken lease (zero break time)
            leaseId = SetInstantBrokenStateAPM(leasedBlob);
            leasedBlob.BreakLeaseAsync(TimeSpan.Zero, null, null, context).Wait();
                
            // Break released lease (default break time)
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.BreakLeaseAsync(null /* default break time */, null, null, context),
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAllTask();
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobBreakLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            TimeSpan leaseTime;

            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");

            // Break lease in available state
            SetAvailableStateTask(leasedBlob);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.BreakLeaseAsync(null /* default break period */),
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(null /* default break period */).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(1)).Result;

            // Break infinite lease (60 seconds break time)
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Result;

            // Break breaking lease (zero break time)
            leaseId = SetBreakingStateTask(leasedBlob);
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = SetBreakingStateTask(leasedBlob);
            leasedBlob.BreakLeaseAsync(null /* default break time */).Wait();

            // Break finite lease (longer than lease time)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Result;

            // Break finite lease (zero break time)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = SetLeasedStateTask(leasedBlob, TimeSpan.FromSeconds(50));
            leaseTime = leasedBlob.BreakLeaseAsync(null /* default break time */).Result;

            // Break instant broken lease (default break time)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.BreakLeaseAsync(null /* default break time */).Wait();

            // Break instant broken lease (nonzero break time)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.BreakLeaseAsync(TimeSpan.FromSeconds(1)).Wait();

            // Break instant broken lease (zero break time)
            leaseId = SetInstantBrokenStateTask(leasedBlob);
            leasedBlob.BreakLeaseAsync(TimeSpan.Zero, null, null, null).Wait();

            // Break released lease (default break time)
            leaseId = SetReleasedStateTask(leasedBlob, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedBlob.BreakLeaseAsync(null /* default break time */),
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAllTask();
        }
#endif

        [TestMethod]
        [Description("Tests blob write and delete APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeasedWriteTests()
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
            SetAvailableState(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobWriteExpectLeaseFailure(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "write blob using a lease when no lease is held");

            // From leased state, verify that writes/deletes without a lease do not succeed.
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            this.BlobWriteExpectLeaseFailure(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "write blob using no lease when a lease is held");

            // From leased state, verify that writes/deletes with the wrong lease fail.
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobWriteExpectLeaseFailure(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "write blob using a lease when a different lease is held");

            // From leased state, verify that writes/deletes with the right lease succeed.
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            this.BlobWriteExpectLeaseSuccess(leasedBlob, sourceBlob, testAccessCondition);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Tests blob write and delete APIs in the presence of a lease using APM.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeasedWriteTestsAPM()
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
            SetAvailableStateAPM(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobWriteExpectLeaseFailureAPM(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "write blob using a lease when no lease is held");

            // From leased state, verify that writes/deletes without a lease do not succeed.
            leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            this.BlobWriteExpectLeaseFailureAPM(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "write blob using no lease when a lease is held");

            // From leased state, verify that writes/deletes with the wrong lease fail.
            leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobWriteExpectLeaseFailureAPM(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "write blob using a lease when a different lease is held");

            // From leased state, verify that writes/deletes with the right lease succeed.
            leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            this.BlobWriteExpectLeaseSuccessAPM(leasedBlob, sourceBlob, testAccessCondition);

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Tests blob write and delete APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeasedWriteTestsTask()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CloudBlockBlob sourceBlob = leasedBlob.Container.GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            // Verify that blob creation fails when a lease is supplied.
            // RdBug 243397: Blob creation operations should fail when lease id is specified and blob does not exist
            // testAccessCondition.LeaseId = fakeLease;
            // BlobCreateExpectLeaseFailureTask(leasedBlob, sourceBlob, testAccessCondition, BlobErrorCodeStrings.LeaseNotPresent, "create blob using a lease");

            // From available state, verify that writes/deletes that pass a lease fail if none is present.
            SetAvailableStateTask(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobWriteExpectLeaseFailureTask(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "write blob using a lease when no lease is held");

            // From leased state, verify that writes/deletes without a lease do not succeed.
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            this.BlobWriteExpectLeaseFailureTask(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "write blob using no lease when a lease is held");

            // From leased state, verify that writes/deletes with the wrong lease fail.
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobWriteExpectLeaseFailureTask(leasedBlob, sourceBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "write blob using a lease when a different lease is held");

            // From leased state, verify that writes/deletes with the right lease succeed.
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            this.BlobWriteExpectLeaseSuccessTask(leasedBlob, sourceBlob, testAccessCondition);

            this.DeleteAllTask();
        }
#endif

        /// <summary>
        /// Test blob write and creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobWriteExpectLeaseFailure(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            this.BlobCreateExpectLeaseFailure(testBlob, sourceBlob, testAccessCondition, expectedStatusCode, expectedErrorCode, description);

            TestHelper.ExpectedException(
                () => testBlob.SetMetadata(testAccessCondition, null /* options */),
                description + " (Set Metadata)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => testBlob.SetProperties(testAccessCondition, null /* options */),
                description + " (Set Properties)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => testBlob.Delete(DeleteSnapshotsOption.None, testAccessCondition, null /* options */),
                description + " (Delete)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test blob write and creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobWriteExpectLeaseFailureAPM(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            this.BlobCreateExpectLeaseFailure(testBlob, sourceBlob, testAccessCondition, expectedStatusCode, expectedErrorCode, description);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testBlob.BeginSetMetadata(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testBlob.EndSetMetadata(result),
                    description + " (Set Metadata)",
                    expectedStatusCode,
                    expectedErrorCode);

                result = testBlob.BeginSetProperties(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testBlob.EndSetProperties(result),
                    description + " (Set Properties)",
                    expectedStatusCode,
                    expectedErrorCode);

                result = testBlob.BeginDelete(DeleteSnapshotsOption.None, testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testBlob.EndDelete(result),
                    description + " (Delete)",
                    expectedStatusCode,
                    expectedErrorCode);
            }
        }

#if TASK
        /// <summary>
        /// Test blob write and creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobWriteExpectLeaseFailureTask(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            this.BlobCreateExpectLeaseFailureTask(testBlob, sourceBlob, testAccessCondition, expectedStatusCode, expectedErrorCode, description);

            TestHelper.ExpectedExceptionTask(
                testBlob.SetMetadataAsync(testAccessCondition, null /* options */, new OperationContext()),
                description + " (Set Metadata)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedExceptionTask(
                testBlob.SetPropertiesAsync(testAccessCondition, null /* options */, new OperationContext()),
                description + " (Set Properties)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedExceptionTask(
                testBlob.DeleteAsync(DeleteSnapshotsOption.None, testAccessCondition, null /* options */, new OperationContext()),
                description + " (Delete)",
                expectedStatusCode,
                expectedErrorCode);
        }
#endif

        /// <summary>
        /// Test blob creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobCreateExpectLeaseFailure(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => UploadText(testBlob, "No Dice", Encoding.UTF8, testAccessCondition, null /* options */),
                description + " (Upload Text)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => testBlob.StartCopyFromBlob(TestHelper.Defiddler(sourceBlob.Uri), null /* source access condition */, testAccessCondition, null /* options */),
                description + " (Copy From)",
                expectedStatusCode,
                expectedErrorCode);

            Stream stream = testBlob.OpenWrite(testAccessCondition, null /* options */);
            TestHelper.ExpectedException(
                () =>
                {
                    stream.WriteByte(0);
                    stream.Flush();
                },
                description + " (Write Stream)",
                expectedStatusCode,
                expectedErrorCode);
        }

#if TASK
        /// <summary>
        /// Test blob creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobCreateExpectLeaseFailureTask(CloudBlockBlob testBlob, CloudBlockBlob sourceBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => UploadTextTask(testBlob, "No Dice", Encoding.UTF8, testAccessCondition, null /* options */),
                description + " (Upload Text)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedExceptionTask(
                testBlob.StartCopyFromBlobAsync(TestHelper.Defiddler(sourceBlob.Uri), null /* source access condition */, testAccessCondition, null /* options */, new OperationContext()),
                description + " (Copy From)",
                expectedStatusCode,
                expectedErrorCode);

            Stream stream = testBlob.OpenWriteAsync(testAccessCondition, null /* options */, new OperationContext()).Result;
            TestHelper.ExpectedException(
                () =>
                {
                    stream.WriteByte(0);
                    stream.Flush();
                },
                description + " (Write Stream)",
                expectedStatusCode,
                expectedErrorCode);
        }
#endif

        /// <summary>
        /// Test blob writing, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlobWriteExpectLeaseSuccess(CloudBlockBlob testBlob, ICloudBlob sourceBlob, AccessCondition testAccessCondition)
        {
            testBlob.SetMetadata(testAccessCondition, null /* options */);
            testBlob.SetProperties(testAccessCondition, null /* options */);
            UploadText(testBlob, "No Problem", Encoding.UTF8, testAccessCondition, null /* options */);
            testBlob.StartCopyFromBlob(TestHelper.Defiddler(sourceBlob.Uri), null /* source access condition */, testAccessCondition, null /* options */);

            while (testBlob.CopyState.Status == CopyStatus.Pending)
            {
                Thread.Sleep(1000);
                testBlob.FetchAttributes();
            }

            Stream stream = testBlob.OpenWrite(testAccessCondition, null /* options */);
            stream.WriteByte(0);
            stream.Flush();

            testBlob.Delete(DeleteSnapshotsOption.None, testAccessCondition, null /* options */);
        }

        /// <summary>
        /// Test blob writing, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlobWriteExpectLeaseSuccessAPM(CloudBlockBlob testBlob, ICloudBlob sourceBlob, AccessCondition testAccessCondition)
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testBlob.BeginSetMetadata(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testBlob.EndSetMetadata(result);

                result = testBlob.BeginSetProperties(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testBlob.EndSetProperties(result);

                UploadTextAPM(testBlob, "No Problem", Encoding.UTF8, testAccessCondition, null /* options */);
                result = testBlob.BeginStartCopyFromBlob(TestHelper.Defiddler(sourceBlob.Uri), null /* source access condition */, testAccessCondition, null /* options */, null /* operationContext */, ar=>waitHandle.Set(), null);
                waitHandle.WaitOne();
                testBlob.EndStartCopyFromBlob(result);

                while (testBlob.CopyState.Status == CopyStatus.Pending)
                {
                    Thread.Sleep(1000);
                    result = testBlob.BeginFetchAttributes(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    testBlob.EndFetchAttributes(result);
                }

                result = testBlob.BeginOpenWrite(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Stream stream = testBlob.EndOpenWrite(result);
                stream.WriteByte(0);
                stream.Flush();

                result = testBlob.BeginDelete(DeleteSnapshotsOption.None, testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testBlob.EndDelete(result);
            }
        }

#if TASK
        /// <summary>
        /// Test blob writing, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="sourceBlob">A blob to use as the source of a copy.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlobWriteExpectLeaseSuccessTask(CloudBlockBlob testBlob, ICloudBlob sourceBlob, AccessCondition testAccessCondition)
        {
            testBlob.SetMetadataAsync(testAccessCondition, null /* options */, new OperationContext()).Wait();
            testBlob.SetPropertiesAsync(testAccessCondition, null /* options */, new OperationContext()).Wait();
            UploadTextTask(testBlob, "No Problem", Encoding.UTF8, testAccessCondition, null /* options */, new OperationContext());
            testBlob.StartCopyFromBlobAsync(
                TestHelper.Defiddler(sourceBlob.Uri),
                null /* source access condition */,
                testAccessCondition,
                null /* options */,
                new OperationContext()).Wait();

            while (testBlob.CopyState.Status == CopyStatus.Pending)
            {
                Thread.Sleep(1000);
                testBlob.FetchAttributesAsync().Wait();
            }

            Stream stream = testBlob.OpenWriteAsync(testAccessCondition, null /* options */, new OperationContext()).Result;
            stream.WriteByte(0);
            stream.Flush();

            testBlob.DeleteAsync(DeleteSnapshotsOption.None, testAccessCondition, null /* options */, new OperationContext());
        }
#endif

        [TestMethod]
        [Description("Tests blob read APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeasedReadTests()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CloudBlockBlob targetBlob = leasedBlob.Container.GetBlockBlobReference("TargetBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            // From available state, verify that reads that pass a lease fail if none is present
            SetAvailableState(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobReadExpectLeaseFailure(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read blob using a lease when no lease is held");

            // Verify that reads without a lease succeed.
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            this.BlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobReadExpectLeaseFailure(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            this.BlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Tests blob read APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeasedReadTestsAPM()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CloudBlockBlob targetBlob = leasedBlob.Container.GetBlockBlobReference("TargetBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            // From available state, verify that reads that pass a lease fail if none is present
            SetAvailableStateAPM(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobReadExpectLeaseFailureAPM(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read blob using a lease when no lease is held");

            // Verify that reads without a lease succeed.
            leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            this.BlobReadExpectLeaseSuccessAPM(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobReadExpectLeaseFailureAPM(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            leaseId = SetLeasedStateAPM(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            this.BlobReadExpectLeaseSuccessAPM(leasedBlob, testAccessCondition);

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Tests blob read APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeasedReadTestsTask()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            CloudBlockBlob targetBlob = leasedBlob.Container.GetBlockBlobReference("TargetBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            // From available state, verify that reads that pass a lease fail if none is present
            SetAvailableStateTask(leasedBlob);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobReadExpectLeaseFailureTask(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read blob using a lease when no lease is held");

            // Verify that reads without a lease succeed.
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = null;
            this.BlobReadExpectLeaseSuccessTask(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = fakeLease;
            this.BlobReadExpectLeaseFailureTask(leasedBlob, targetBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            leaseId = SetLeasedStateTask(leasedBlob, null /* infinite lease */);
            testAccessCondition.LeaseId = leaseId;
            this.BlobReadExpectLeaseSuccessTask(leasedBlob, testAccessCondition);

            this.DeleteAllTask();
        }
#endif

        /// <summary>
        /// Test blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="targetBlob">The blob to use for the target of copy operations.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobReadExpectLeaseFailure(CloudBlockBlob testBlob, CloudBlockBlob targetBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            TestHelper.ExpectedException(
                () => testBlob.FetchAttributes(testAccessCondition, null /* options */),
                description + "(Fetch Attributes)",
                HttpStatusCode.PreconditionFailed);

            TestHelper.ExpectedException(
                () => testBlob.CreateSnapshot(null /* metadata */, testAccessCondition, null /* options */),
                description + " (Create Snapshot)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => DownloadText(testBlob, Encoding.UTF8, testAccessCondition, null /* options */),
                description + " (Download Text)",
                expectedStatusCode,
                expectedErrorCode);

            TestHelper.ExpectedException(
                () => testBlob.OpenRead(testAccessCondition, null /* options */),
                description + " (Read Stream)",
                expectedStatusCode/*,
                expectedErrorCode*/);
        }

        /// <summary>
        /// Test blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="targetBlob">The blob to use for the target of copy operations.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobReadExpectLeaseFailureAPM(CloudBlockBlob testBlob, CloudBlockBlob targetBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testBlob.BeginFetchAttributes(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testBlob.EndFetchAttributes(result),
                    description + "(Fetch Attributes)",
                    HttpStatusCode.PreconditionFailed);

                result = testBlob.BeginCreateSnapshot(null /* metadata */, testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testBlob.EndCreateSnapshot(result),
                    description + " (Create Snapshot)",
                    expectedStatusCode,
                    expectedErrorCode);

                TestHelper.ExpectedException(
                    () => DownloadTextAPM(testBlob, Encoding.UTF8, testAccessCondition, null /* options */),
                    description + " (Download Text)",
                    expectedStatusCode,
                    expectedErrorCode);

                result = testBlob.BeginOpenRead(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testBlob.EndOpenRead(result),
                    description + " (Read Stream)",
                    expectedStatusCode/*,
                expectedErrorCode*/);
            }
        }

#if TASK
        /// <summary>
        /// Test blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="targetBlob">The blob to use for the target of copy operations.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlobReadExpectLeaseFailureTask(CloudBlockBlob testBlob, CloudBlockBlob targetBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            TestHelper.ExpectedExceptionTask(
                testBlob.FetchAttributesAsync(testAccessCondition, null /* options */, new OperationContext()),
                description + "(Fetch Attributes)",
                HttpStatusCode.PreconditionFailed);

            TestHelper.ExpectedExceptionTask(
                testBlob.CreateSnapshotAsync(null /* metadata */, testAccessCondition, null /* options */, new OperationContext()),
                description + " (Create Snapshot)",
                expectedStatusCode,
                expectedErrorCode);

            TestHelper.ExpectedException(
                () => DownloadTextTask(testBlob, Encoding.UTF8, testAccessCondition, null /* options */),
                description + " (Download Text)",
                expectedStatusCode,
                expectedErrorCode);

            TestHelper.ExpectedExceptionTask(
                testBlob.OpenReadAsync(testAccessCondition, null /* options */, new OperationContext()),
                description + " (Read Stream)",
                expectedStatusCode/*,
                expectedErrorCode*/);
        }
#endif

        /// <summary>
        /// Test blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlobReadExpectLeaseSuccess(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            testBlob.FetchAttributes(testAccessCondition, null /* options */);
            testBlob.CreateSnapshot(null /* metadata */, testAccessCondition, null /* options */).Delete();
            DownloadText(testBlob, Encoding.UTF8, testAccessCondition, null /* options */);

            Stream stream = testBlob.OpenRead(testAccessCondition, null /* options */);
            stream.ReadByte();
        }

        /// <summary>
        /// Test blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlobReadExpectLeaseSuccessAPM(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testBlob.BeginFetchAttributes(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testBlob.EndFetchAttributes(result);

                result = testBlob.BeginCreateSnapshot(null /* metadata */, testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testBlob.EndCreateSnapshot(result).Delete();

                DownloadTextAPM(testBlob, Encoding.UTF8, testAccessCondition, null /* options */);

                result = testBlob.BeginOpenRead(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Stream stream = testBlob.EndOpenRead(result);
                stream.ReadByte();
            }
        }

#if TASK
        /// <summary>
        /// Test blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The blob to test.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlobReadExpectLeaseSuccessTask(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            testBlob.FetchAttributesAsync(testAccessCondition, null /* options */, new OperationContext());
            testBlob.CreateSnapshotAsync(null /* metadata */, testAccessCondition, null /* options */, new OperationContext()).Result.Delete();
            DownloadTextTask(testBlob, Encoding.UTF8, testAccessCondition, null /* options */);

            Stream stream = testBlob.OpenReadAsync(testAccessCondition, null /* options */, new OperationContext()).Result;
            stream.ReadByte();
        }
#endif

        [TestMethod]
        [Description("Tests page blob write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobLeasedWriteTests()
        {
            CloudPageBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            leasedBlob.Container.Create();

            // Verify that creating the page blob fails when a lease is supplied.
            // RdBug 243397: Blob creation operations should fail when lease id is specified and blob does not exist
            // testAccessCondition.LeaseId = fakeLease;
            // PageBlobCreateExpectLeaseFailure(leasedBlob, testAccessCondition, BlobErrorCodeStrings.LeaseNotPresent, "create page blob using a lease");

            // Create a page blob
            testAccessCondition.LeaseId = null;
            PageBlobCreateExpectSuccess(leasedBlob, testAccessCondition);

            // From available state, verify that writing the page blob fails when a lease is supplied.
            testAccessCondition.LeaseId = fakeLease;
            PageBlobWriteExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "write page blob with a lease when no lease is held");

            // Acquire a lease
            leaseId = leasedBlob.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that writes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            PageBlobWriteExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "write page blob with no lease when a lease is held");

            // Verify that writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            PageBlobWriteExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "write page blob using a lease when a different lease is held");

            // Verify that writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            PageBlobWriteExpectSuccess(leasedBlob, testAccessCondition);

            this.DeleteAll();
        }

        /// <summary>
        /// Test page blob creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The page blob to test.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void PageBlobCreateExpectLeaseFailure(CloudPageBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => testBlob.Create(8 * 512, testAccessCondition, null /* options */),
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
        private void PageBlobWriteExpectLeaseFailure(CloudPageBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            byte[] buffer = new byte[4 * 1024];
            Random random = new Random();
            random.NextBytes(buffer);
            Stream pageStream = new MemoryStream(buffer);

            PageBlobCreateExpectLeaseFailure(testBlob, testAccessCondition, expectedStatusCode, expectedErrorCode, description);

            TestHelper.ExpectedException(
                () => testBlob.ClearPages(512, 512, testAccessCondition, null /* options */),
                description + " (Clear Pages)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => testBlob.WritePages(pageStream, 512, null, testAccessCondition, null /* options */),
                description + " (Write Pages)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test page blob creation, expecting success.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The test access condition.</param>
        private void PageBlobCreateExpectSuccess(CloudPageBlob testBlob, AccessCondition testAccessCondition)
        {
            testBlob.Create(8 * 512, testAccessCondition, null /* options */);
        }

        /// <summary>
        /// Test page blob writes, expecting success.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void PageBlobWriteExpectSuccess(CloudPageBlob testBlob, AccessCondition testAccessCondition)
        {
            byte[] buffer = new byte[4 * 512];
            Random random = new Random();
            random.NextBytes(buffer);
            Stream pageStream = new MemoryStream(buffer);

            testBlob.ClearPages(512, 512, testAccessCondition, null /* options */);
            testBlob.WritePages(pageStream, 512, null, testAccessCondition, null /* options */);
        }

        [TestMethod]
        [Description("Tests page blob read APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobLeasedReadTests()
        {
            CloudPageBlob leasedBlob = this.GetContainerReference("lease-tests").GetPageBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            leasedBlob.Container.Create();

            // Create a page blob
            testAccessCondition.LeaseId = null;
            PageBlobCreateExpectSuccess(leasedBlob, testAccessCondition);

            // Verify that reading the page blob fails when a lease is supplied.
            testAccessCondition.LeaseId = fakeLease;
            PageBlobReadExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read page blob with a lease when no lease is held");

            // Acquire a lease
            leaseId = leasedBlob.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads without a lease succeed.
            testAccessCondition.LeaseId = null;
            PageBlobReadExpectSuccess(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            PageBlobReadExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read page blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            PageBlobReadExpectSuccess(leasedBlob, testAccessCondition);

            this.DeleteAll();
        }

        /// <summary>
        /// Test page blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void PageBlobReadExpectLeaseFailure(CloudPageBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => testBlob.GetPageRanges(null /* offset */, null /* length */, testAccessCondition, null /* options */),
                description + "(Get Page Ranges)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test page blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The page blob.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void PageBlobReadExpectSuccess(CloudPageBlob testBlob, AccessCondition testAccessCondition)
        {
            testBlob.GetPageRanges(null /* offset */, null /* length */, testAccessCondition, null /* options */);
        }

        [TestMethod]
        [Description("Tests block blob write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobLeasedWriteTests()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;
            List<string> blockList = new List<string>();

            leasedBlob.Container.Create();

            // Verify that creating the first block fails when a lease is supplied.
            // RdBug 243397: Blob creation operations should fail when lease id is specified and blob does not exist
            // testOptions.LeaseId = fakeLease;
            // BlockCreateExpectLeaseFailure(leasedBlob, testOptions, BlobErrorCodeStrings.LeaseNotPresent, "create initial block using a lease");

            // Create a block
            testAccessCondition.LeaseId = null;
            blockList.Add(BlockCreateExpectSuccess(leasedBlob, testAccessCondition));

            // Verify that creating an additional block fails when a lease is supplied.
            testAccessCondition.LeaseId = fakeLease;
            BlockCreateExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "create additional block using a lease");

            // Verify that block list writes that pass a lease fail if none is present.
            testAccessCondition.LeaseId = fakeLease;
            BlockBlobWriteExpectLeaseFailure(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "set initial block list using a lease when no lease is held");

            // Acquire a lease
            testAccessCondition.LeaseId = null;
            leaseId = leasedBlob.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that writes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            BlockCreateExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "create block using no lease when a lease is held");
            BlockBlobWriteExpectLeaseFailure(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "set initial block list using no lease when a lease is held");

            // Verify that writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            BlockCreateExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "create block using a lease when a different lease is held");
            BlockBlobWriteExpectLeaseFailure(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "set initial block list using a lease when a different lease is held");

            // Verify that writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            blockList.Add(BlockCreateExpectSuccess(leasedBlob, testAccessCondition));
            BlockBlobWriteExpectSuccess(leasedBlob, blockList, testAccessCondition);

            // Verify that writes with the wrong lease fail, with the block list already set.
            testAccessCondition.LeaseId = null;
            BlockCreateExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "create block using no lease when a lease is held");
            BlockBlobWriteExpectLeaseFailure(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "update block list using no lease when a lease is held");

            // Verify that writes with the wrong lease fail, with the block list already set.
            testAccessCondition.LeaseId = fakeLease;
            BlockCreateExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "create block using a lease when a different lease is held");
            BlockBlobWriteExpectLeaseFailure(leasedBlob, blockList, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "update block list using a lease when a different lease is held");

            // Verify that writes with the right lease succeed, with the block list already set.
            testAccessCondition.LeaseId = leaseId;
            blockList.Add(BlockCreateExpectSuccess(leasedBlob, testAccessCondition));
            BlockBlobWriteExpectSuccess(leasedBlob, blockList, testAccessCondition);

            this.DeleteAll();
        }

        /// <summary>
        /// Test block creation, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The block blob in which to attempt to create a block.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlockCreateExpectLeaseFailure(CloudBlockBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => BlockCreate(testBlob, testAccessCondition),
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
        private void BlockBlobWriteExpectLeaseFailure(CloudBlockBlob testBlob, IEnumerable<string> blockList, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => testBlob.PutBlockList(blockList, testAccessCondition, null /* options */),
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
        private string BlockCreateExpectSuccess(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            return BlockCreate(testBlob, testAccessCondition);
        }

        /// <summary>
        /// Create a block with a random name.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The access condition.</param>
        /// <returns>The name of the new block.</returns>
        private string BlockCreate(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            byte[] buffer = new byte[4 * 1024];
            Random random = new Random();
            random.NextBytes(buffer);
            string blockId = Guid.NewGuid().ToString("N");
            Stream blockData = new MemoryStream(buffer);
            testBlob.PutBlock(blockId, blockData, null /* content MD5 */, testAccessCondition, null /* options */);

            return blockId;
        }

        /// <summary>
        /// Test block blob creation (set block list), expecting success.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="blockList">The block list to set.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlockBlobWriteExpectSuccess(CloudBlockBlob testBlob, IEnumerable<string> blockList, AccessCondition testAccessCondition)
        {
            testBlob.PutBlockList(blockList, testAccessCondition, null /* options */);
        }

        [TestMethod]
        [Description("Tests block blob read APIs in the presence of a lease on a blob with no block list.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobLeasedReadTestsWithoutList()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;

            leasedBlob.Container.Create();

            // Create a block
            testAccessCondition.LeaseId = null;
            BlockCreateExpectSuccess(leasedBlob, testAccessCondition);

            // Verify that reads without a lease succeed
            testAccessCondition.LeaseId = null;
            BlockBlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            // Verify that reads with a lease fail
            testAccessCondition.LeaseId = fakeLease;
            BlockBlobReadExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read block blob using a lease when no lease is held");

            // Acquire a lease
            testAccessCondition.LeaseId = null;
            leaseId = leasedBlob.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads without a lease still succeed.
            testAccessCondition.LeaseId = null;
            BlockBlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            BlockBlobReadExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read block blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            BlockBlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Tests block blob read APIs in the presence of a lease on a blob with a block list.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobLeasedReadTestsWithList()
        {
            CloudBlockBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            string leaseId;
            List<string> blockList = new List<string>();

            leasedBlob.Container.Create();

            // Create a block
            testAccessCondition.LeaseId = null;
            blockList.Add(BlockCreateExpectSuccess(leasedBlob, testAccessCondition));

            // Put the block list
            testAccessCondition.LeaseId = null;
            BlockBlobWriteExpectSuccess(leasedBlob, blockList, testAccessCondition);

            // Verify that reads without a lease succeed
            testAccessCondition.LeaseId = null;
            BlockBlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            // Verify that reads with a lease fail
            testAccessCondition.LeaseId = fakeLease;
            BlockBlobReadExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithBlobOperation, "read block blob using a lease when no lease is held");

            // Acquire a lease
            testAccessCondition.LeaseId = null;
            leaseId = leasedBlob.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads without a lease still succeed.
            testAccessCondition.LeaseId = null;
            BlockBlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            // Verify that reads with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            BlockBlobReadExpectLeaseFailure(leasedBlob, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation, "read block blob using a lease when a different lease is held");

            // Verify that reads with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            BlockBlobReadExpectLeaseSuccess(leasedBlob, testAccessCondition);

            this.DeleteAll();
        }

        /// <summary>
        /// Test block blob reads, expecting lease failure.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void BlockBlobReadExpectLeaseFailure(CloudBlockBlob testBlob, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => testBlob.DownloadBlockList(BlockListingFilter.Committed, testAccessCondition, null /* options */),
                description + "(Download Block List)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test block blob reads, expecting success.
        /// </summary>
        /// <param name="testBlob">The block blob.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void BlockBlobReadExpectLeaseSuccess(CloudBlockBlob testBlob, AccessCondition testAccessCondition)
        {
            testBlob.DownloadBlockList(BlockListingFilter.Committed, testAccessCondition, null /* options */);
        }

        [TestMethod]
        [Description("Test reading the blob lease status and state after various lease actions.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobLeaseStatusTest()
        {
            string leaseId;
            ICloudBlob leasedBlob = this.GetContainerReference("lease-tests").GetBlockBlobReference("LeasedBlob");

            // Check uninitialized lease status
            SetAvailableState(leasedBlob);
            Assert.AreEqual(LeaseStatus.Unspecified, leasedBlob.Properties.LeaseStatus, "uninitialized lease status");
            Assert.AreEqual(LeaseState.Unspecified, leasedBlob.Properties.LeaseState, "uninitialized lease state");
            Assert.AreEqual(LeaseDuration.Unspecified, leasedBlob.Properties.LeaseDuration, "uninitialized lease duration");

            // Check lease status in initial state
            SetAvailableState(leasedBlob);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "initial lease state");

            // Check lease status after acquiring an infinite lease
            SetLeasedState(leasedBlob, null /* infinite lease */);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after acquire lease");

            // Check lease status after acquiring a finite lease
            SetLeasedState(leasedBlob, TimeSpan.FromSeconds(45));
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after acquire lease");

            // Check lease status after renewing an infinite lease
            SetRenewedState(leasedBlob, null /* infinite lease */);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after renew lease");

            // Check lease status after renewing a finite lease
            SetRenewedState(leasedBlob, TimeSpan.FromSeconds(45));
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after renew lease");

            // Check lease status after changing an infinite lease
            leaseId = SetLeasedState(leasedBlob, null /* infinite lease */);
            leasedBlob.ChangeLease(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after change lease");

            // Check lease status after changing a finite lease
            leaseId = SetLeasedState(leasedBlob, TimeSpan.FromSeconds(45));
            leasedBlob.ChangeLease(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after change lease");

            // Check lease status after releasing a lease
            SetReleasedState(leasedBlob, null /* infinite lease */);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "after release lease");

            // Check lease status while infinite lease is breaking
            SetBreakingState(leasedBlob);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Breaking, LeaseDuration.Unspecified, "while lease is breaking");

            // Check lease status after lease breaks
            SetTimeBrokenState(leasedBlob);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after break time elapses");

            // Check lease status after (infinite) acquire after break
            SetTimeBrokenState(leasedBlob);
            leasedBlob.AcquireLease(null /* infinite lease */, null /*proposed lease ID */);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after second acquire lease");

            // Check lease status after instant break with infinite lease
            SetInstantBrokenState(leasedBlob);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after instant break lease");

            // Check lease status after lease expires
            SetExpiredState(leasedBlob);
            this.CheckLeaseStatus(leasedBlob, LeaseStatus.Unlocked, LeaseState.Expired, LeaseDuration.Unspecified, "after lease expires");

            this.DeleteAll();
        }

        /// <summary>
        /// Checks the lease status of a blob, both from its attributes and from a blob listing.
        /// </summary>
        /// <param name="blob">The blob to test.</param>
        /// <param name="expectedStatus">The expected lease status.</param>
        /// <param name="expectedState">The expected lease state.</param>
        /// <param name="expectedDuration">The expected lease duration.</param>
        /// <param name="description">A description of the circumstances that lead to the expected status.</param>
        private void CheckLeaseStatus(
            ICloudBlob blob,
            LeaseStatus expectedStatus,
            LeaseState expectedState,
            LeaseDuration expectedDuration,
            string description)
        {
            blob.FetchAttributes();
            Assert.AreEqual(expectedStatus, blob.Properties.LeaseStatus, "LeaseStatus mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedState, blob.Properties.LeaseState, "LeaseState mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedDuration, blob.Properties.LeaseDuration, "LeaseDuration mismatch: " + description + " (from FetchAttributes)");

            BlobProperties propertiesInListing = (from ICloudBlob b in blob.Container.ListBlobs(
                                                      blob.Name,
                                                      true /* use flat blob listing */,
                                                      BlobListingDetails.None,
                                                      null /* options */)
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
        public void ContainerAcquireLeaseSemanticTests()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(TimeSpan.FromSeconds(15), null /* proposed lease ID */);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(TimeSpan.FromSeconds(60), null /* proposed lease ID */);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(null /* infinite lease */, null /* proposed lease ID */);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-4"); // make sure we use a new container
            SetReleasedState(leasedContainer, null /* infinite lease */);
            leaseId = leasedContainer.AcquireLease(TimeSpan.FromSeconds(15), leaseId);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-5"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId = leasedContainer.AcquireLease(TimeSpan.FromSeconds(15), leaseId);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-6"); // make sure we use a new container
            SetExpiredState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(null /* infinite lease */, leaseId);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-7"); // make sure we use a new container
            SetInstantBrokenState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(TimeSpan.FromSeconds(15), leaseId);
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease acquire semantics with various valid lease durations with APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerAcquireLeaseSemanticTestsAPM()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            SetUnleasedStateAPM(leasedContainer);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = leasedContainer.BeginAcquireLease(TimeSpan.FromSeconds(15), null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
                SetUnleasedStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(TimeSpan.FromSeconds(60), null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
                SetUnleasedStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-4"); // make sure we use a new container
                SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginAcquireLease(TimeSpan.FromSeconds(15), leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-5"); // make sure we use a new container
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginAcquireLease(TimeSpan.FromSeconds(15), leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-6"); // make sure we use a new container
                SetExpiredState(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(20), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-7"); // make sure we use a new container
                SetInstantBrokenState(leasedContainer);
                result = leasedContainer.BeginAcquireLease(TimeSpan.FromSeconds(15), leaseId, null, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedContainer.EndAcquireLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);
            }

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease acquire semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerAcquireLeaseSemanticTestsTask()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;
            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), null /* proposed lease ID */).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(60), null /* proposed lease ID */).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-4"); // make sure we use a new container
            SetReleasedState(leasedContainer, null /* infinite lease */);
            leaseId = leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-5"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId = leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-6"); // make sure we use a new container
            SetExpiredState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-7"); // make sure we use a new container
            SetInstantBrokenState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(TimeSpan.FromSeconds(15), leaseId, null, null, null).Result;
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            this.DeleteAll();
        }
#endif

        [TestMethod]
        [Description("Test lease renew semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerRenewLeaseSemanticTests()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;

            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(15));
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(60));
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));
            this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease renew semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerRenewLeaseSemanticTestsAPM()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;

            CloudBlobContainer leasedContainer;

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(15));
                IAsyncResult result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(60));
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

                leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);
                this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);
            }

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease renew semantics with various valid lease durations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerRenewLeaseSemanticTestsTask()
        {
            TimeSpan tolerance = TimeSpan.FromSeconds(2);
            string leaseId;

            CloudBlobContainer leasedContainer;

            leasedContainer = this.GetContainerReference("leased-container-1"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(15));
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(20), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-2"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(60));
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();
            this.ContainerAcquireRenewLeaseTest(leasedContainer, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(70), tolerance);

            leasedContainer = this.GetContainerReference("leased-container-3"); // make sure we use a new container
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), null, null).Wait();
            this.ContainerAcquireRenewLeaseTest(leasedContainer, null /* infinite lease */, TimeSpan.FromSeconds(70), tolerance);

            this.DeleteAll();
        }
#endif

        /// <summary>
        /// Verifies the behavior of a lease while the lease holds. Once the lease expires, this method confirms that write operations succeed.
        /// The test is cut short once the <c>testLength</c> time has elapsed.
        /// </summary>
        /// <param name="leasedContainer">The container.</param>
        /// <param name="duration">The duration of the lease.</param>
        /// <param name="testLength">The maximum length of time to run the test.</param>
        /// <param name="tolerance">The allowed lease time error.</param>
        internal void ContainerAcquireRenewLeaseTest(CloudBlobContainer leasedContainer, TimeSpan? duration, TimeSpan testLength, TimeSpan tolerance)
        {
            DateTime beginTime = DateTime.UtcNow;

            while (true)
            {
                try
                {
                    // Attempt to delete the container with no lease ID.
                    leasedContainer.Delete();

                    // The delete succeeded, which means that the lease must have expired.

                    // If the lease was infinite then there is an error because it should not have expired.
                    Assert.IsNotNull(duration, "An infinite lease should not expire.");

                    // The lease should be past its expiration time.
                    Assert.IsTrue(DateTime.UtcNow - beginTime > duration - tolerance, "Deletes should not succeed while lease is present.");

                    // Since the lease has expired (and the container was deleted), the test is over.
                    return;
                }
                catch (StorageException exception)
                {
                    if (exception.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing)
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
                leasedContainer.SetMetadata();
                leasedContainer.FetchAttributes();

                // Wait 1 second before trying again.
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        [TestMethod]
        [Description("Test container leasing with invalid inputs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeaseInvalidInputTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string invalidLeaseId = "invalid";
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            leasedContainer.Create();

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedContainer.AcquireLease(TimeSpan.Zero, null /* proposed lease ID */),
                "acquire a lease with 0 duration");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedContainer.AcquireLease(TimeSpan.FromSeconds(-1), null /* proposed lease ID */),
                "acquire a lease with -1 duration");

            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(TimeSpan.FromSeconds(1), null /* proposed lease ID */),
                "acquire a lease with 1 s duration",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(TimeSpan.FromSeconds(14), null /* proposed lease ID */),
                "acquire a lease that is too short",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(TimeSpan.FromSeconds(61), null /* proposed lease ID */),
                "acquire a lease that is too long",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(null /* infinite lease */, invalidLeaseId),
                "acquire a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            // The following tests assume that the container is leased
            leaseId = leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedContainer.RenewLease(null /* access condition */),
                "renew with null access condition");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedContainer.RenewLease(AccessCondition.GenerateEmptyCondition()),
                "renew with no lease ID");

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedContainer.ChangeLease(proposedLeaseId, null /* access condition */),
                "change with null access condition");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedContainer.ChangeLease(proposedLeaseId, AccessCondition.GenerateEmptyCondition()),
                "change with no lease ID");

            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(invalidLeaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a lease with an invalid proposed lease ID",
                HttpStatusCode.BadRequest);

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedContainer.ChangeLease(null /* proposed lease ID */, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a lease with no proposed lease ID");

            TestHelper.ExpectedException<ArgumentNullException>(
                () => leasedContainer.ReleaseLease(null /* access condition */),
                "release with null access condition");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateEmptyCondition()),
                "release with no lease ID");

            TestHelper.ExpectedException<ArgumentException>(
                () => leasedContainer.BreakLease(TimeSpan.FromSeconds(-1)),
                "break with negative break time");

            TestHelper.ExpectedException(
                () => leasedContainer.BreakLease(TimeSpan.FromSeconds(61)),
                "break with too large break time",
                HttpStatusCode.BadRequest);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerAcquireLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Acquire the lease while in available state, make idempotent call
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);
            leaseId2 = leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);
            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while in leased state (conflict)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(null /* infinite lease */, leaseId),
                "acquire a lease while in the breaking state (same ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.AcquireLease(null /* infinite lease */, leaseId);
            leasedContainer.AcquireLease(null /* infinite lease */, leaseId);

            // Acquire the lease while in broken state (new ID), make idempotent call
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);
            leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);

            // Acquire the lease while in released state (same ID), make idempotent call
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.AcquireLease(null /* infinite lease */, leaseId);
            leasedContainer.AcquireLease(null /* infinite lease */, leaseId);

            // Acquire the lease while in released state (new ID), make idempotent call
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);
            leasedContainer.AcquireLease(null /* infinite lease */, proposedLeaseId);

            // Acquire with no proposed ID (non-idempotent)
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLease(null /* infinite lease */, null /* proposed lease ID */);
            TestHelper.ExpectedException(
                () => leasedContainer.AcquireLease(null /* infinite lease */, null /* proposed lease ID */),
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Delete the blob
            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease acquire semantics from various lease states in APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerAcquireLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Acquire the lease while in available state, make idempotent call
            SetUnleasedStateAPM(leasedContainer);
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId = leasedContainer.EndAcquireLease(result);

                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedContainer.EndAcquireLease(result);
                Assert.AreEqual(leaseId, leaseId2);

                // Acquire the lease while in leased state (conflict)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndAcquireLease(result),
                    "acquire a lease while in leased state (conflict)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);

                // Acquire the lease while breaking (same ID)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndAcquireLease(result),
                    "acquire a lease while in the breaking state (same ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

                // Acquire the lease while breaking (different ID)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndAcquireLease(result),
                    "acquire a lease while breaking (different ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);

                // Acquire the lease while in broken state (same ID), make idempotent call
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);

                // Acquire the lease while in broken state (new ID), make idempotent call
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);

                // Acquire the lease while in released state (same ID), make idempotent call
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, leaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);

                // Acquire the lease while in released state (new ID), make idempotent call
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, proposedLeaseId, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);

                // Acquire with no proposed ID (non-idempotent)
                SetUnleasedStateAPM(leasedContainer);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndAcquireLease(result);
                result = leasedContainer.BeginAcquireLease(null /* infinite lease */, null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndAcquireLease(result),
                    "acquire a lease twice with no proposed lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseAlreadyPresent);
            }

            // Delete the blob
            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease acquire semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerAcquireLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Acquire the lease while in available state, make idempotent call
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Result;
            leaseId2 = leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Result;
            Assert.AreEqual(leaseId, leaseId2);

            // Acquire the lease while in leased state (conflict)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while in leased state (conflict)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while breaking (same ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId),
                "acquire a lease while in the breaking state (same ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeAcquired);

            // Acquire the lease while breaking (different ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId),
                "acquire a lease while breaking (different ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Acquire the lease while in broken state (same ID), make idempotent call
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();

            // Acquire the lease while in broken state (new ID), make idempotent call
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();

            // Acquire the lease while in released state (same ID), make idempotent call
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, leaseId).Wait();

            // Acquire the lease while in released state (new ID), make idempotent call
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();
            leasedContainer.AcquireLeaseAsync(null /* infinite lease */, proposedLeaseId).Wait();

            // Acquire with no proposed ID (non-idempotent)
            SetUnleasedState(leasedContainer);
            leaseId = leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */).Result;
            TestHelper.ExpectedExceptionTask(
                leasedContainer.AcquireLeaseAsync(null /* infinite lease */, null /* proposed lease ID */),
                "acquire a lease twice with no proposed lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseAlreadyPresent);

            // Delete the blob
            this.DeleteAll();
        }
#endif

        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerRenewLeaseStateTests()
        {
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Renew lease in available state
            SetUnleasedState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew infinite lease (wrong lease)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = SetExpiredState(leasedContainer);
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after read
            leaseId = SetExpiredState(leasedContainer);
            leasedContainer.FetchAttributes();
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew expired lease after write
            leaseId = SetExpiredState(leasedContainer);
            leasedContainer.SetMetadata();
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(60));
            leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Renew finite lease (wrong lease)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = SetReleasedState(leasedContainer, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = SetReleasedState(leasedContainer, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.RenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease renew semantics from various lease states in APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerRenewLeaseStateTestsAPM()
        {
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Renew lease in available state
                SetUnleasedStateAPM(leasedContainer);
                IAsyncResult result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a lease while in the available state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew infinite lease
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);

                // Renew infinite lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew an infinite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released lease (wrong lease)
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a released infinite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released lease
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew expired lease
                leaseId = SetExpiredStateAPM(leasedContainer);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);

                // Renew expired lease after read
                leaseId = SetExpiredStateAPM(leasedContainer);
                leasedContainer.FetchAttributes();
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);

                // Renew expired lease after write
                leaseId = SetExpiredStateAPM(leasedContainer);
                leasedContainer.SetMetadata();
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);

                // Renew finite lease
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(60));
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndRenewLease(result);

                // Renew finite lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(60));
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a finite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released finite lease (wrong ID)
                leaseId = SetReleasedStateAPM(leasedContainer, TimeSpan.FromSeconds(60));
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a released finite lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew released finite lease (right ID)
                leaseId = SetReleasedStateAPM(leasedContainer, TimeSpan.FromSeconds(60));
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a released finite lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew a breaking lease (same ID)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a lease while in the breaking state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

                // Renew a breaking lease (different ID)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a lease while in the breaking state",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Renew broken lease (same ID)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a broken lease with the same lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

                // Renew broken lease (different ID)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginRenewLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndRenewLease(result),
                    "renew a broken lease with a different lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);
            }

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease renew semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerRenewLeaseStateTestsTask()
        {
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Renew lease in available state
            SetUnleasedState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the available state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew infinite lease
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew infinite lease (wrong lease)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew an infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease (wrong lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released infinite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released lease
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew expired lease
            leaseId = SetExpiredState(leasedContainer);
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew expired lease after read
            leaseId = SetExpiredState(leasedContainer);
            leasedContainer.FetchAttributesAsync().Wait();
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew expired lease after write
            leaseId = SetExpiredState(leasedContainer);
            leasedContainer.SetMetadataAsync().Wait();
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew finite lease
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(60));
            leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Renew finite lease (wrong lease)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (wrong ID)
            leaseId = SetReleasedState(leasedContainer, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a released finite lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew released finite lease (right ID)
            leaseId = SetReleasedState(leasedContainer, TimeSpan.FromSeconds(60));
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a released finite lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew a breaking lease (same ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew a breaking lease (different ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a lease while in the breaking state",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Renew broken lease (same ID)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "renew a broken lease with the same lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBrokenAndCannotBeRenewed);

            // Renew broken lease (different ID)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.RenewLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "renew a broken lease with a different lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }
#endif

        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerChangeLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Change lease in available state
            SetUnleasedStateAPM(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId2 = leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId2 = leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            leaseId2 = leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId));

            // Change lease (wrong lease specified)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId2 = leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId));
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease using the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change released lease
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change released lease (to previous lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change a breaking lease (same ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a breaking lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

            // Change a breaking lease (different ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change broken lease
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2)),
                "change a broken lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change broken lease (to previous lease)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a broken lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease change semantics from various lease states in APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerChangeLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Change lease in available state
                SetUnleasedState(leasedContainer);
                IAsyncResult result = leasedContainer.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a lease when no lease is held",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change leased lease, with idempotent change
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedContainer.EndChangeLease(result);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedContainer.EndChangeLease(result);

                // Change a leased lease, with same proposed ID but different lease ID
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedContainer.EndChangeLease(result);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedContainer.EndChangeLease(result);

                // Change lease (wrong lease specified)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseId2 = leasedContainer.EndChangeLease(result);
                result = leasedContainer.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a lease using the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Change released lease
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change released lease (to previous lease)
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a released lease (to previous lease)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change a breaking lease (same ID)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a breaking lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

                // Change a breaking lease (different ID)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginChangeLease(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a breaking lease (with wrong ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Change broken lease
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginChangeLease(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a broken lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Change broken lease (to previous lease)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginChangeLease(leaseId, AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndChangeLease(result),
                    "change a broken lease (to previous lease)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);
            }
            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease change semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerChangeLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string proposedLeaseId2 = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;
            string leaseId2;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Change lease in available state
            SetUnleasedStateAPM(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change leased lease, with idempotent change
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId2 = leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;
            leaseId2 = leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;

            // Change a leased lease, with same proposed ID but different lease ID
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId2 = leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;
            leaseId2 = leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId)).Result;

            // Change lease (wrong lease specified)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseId2 = leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)).Result;
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a lease using the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change released lease
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change released lease (to previous lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a released lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change a breaking lease (same ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a breaking lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIsBreakingAndCannotBeChanged);

            // Change a breaking lease (different ID)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(proposedLeaseId2, AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "change a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Change broken lease
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(proposedLeaseId, AccessCondition.GenerateLeaseCondition(leaseId2)),
                "change a broken lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Change broken lease (to previous lease)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ChangeLeaseAsync(leaseId, AccessCondition.GenerateLeaseCondition(leaseId)),
                "change a broken lease (to previous lease)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }
#endif

        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerReleaseLeaseStateTests()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Release lease in available state
            SetUnleasedState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release lease in released state (old lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId)),
                "release a released lease (using previous lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease in released state (unknown lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a released lease (using wrong lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release breaking lease (right lease)
            leaseId = SetBreakingState(leasedContainer);
            leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release breaking lease (wrong lease)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release broken lease (right lease)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));

            // Release broken lease (wrong lease)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.ReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a broken lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease release semantics from various lease states in APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerReleaseLeaseStateTestsAPM()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Release lease in available state
                SetUnleasedStateAPM(leasedContainer);
                IAsyncResult result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndReleaseLease(result),
                    "release a lease when no lease is held",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease (wrong lease)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndReleaseLease(result),
                    "release a lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease (right lease)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndReleaseLease(result);

                // Release lease in released state (old lease)
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndReleaseLease(result),
                    "release a released lease (using previous lease ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release lease in released state (unknown lease)
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndReleaseLease(result),
                    "release a released lease (using wrong lease ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release breaking lease (right lease)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndReleaseLease(result);

                // Release breaking lease (wrong lease)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndReleaseLease(result),
                    "release a breaking lease (with wrong ID)",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

                // Release broken lease (right lease)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndReleaseLease(result);

                // Release broken lease (wrong lease)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginReleaseLease(AccessCondition.GenerateLeaseCondition(unknownLeaseId), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndReleaseLease(result),
                    "release a broken lease with the wrong lease ID",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);
            }

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease release semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerReleaseLeaseStateTestsTask()
        {
            string proposedLeaseId = Guid.NewGuid().ToString();
            string unknownLeaseId = Guid.NewGuid().ToString();
            string leaseId;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Release lease in available state
            SetUnleasedState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease when no lease is held",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (wrong lease)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease (right lease)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Release lease in released state (old lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)),
                "release a released lease (using previous lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release lease in released state (unknown lease)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a released lease (using wrong lease ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release breaking lease (right lease)
            leaseId = SetBreakingState(leasedContainer);
            leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Release breaking lease (wrong lease)
            leaseId = SetBreakingState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId)),
                "release a breaking lease (with wrong ID)",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            // Release broken lease (right lease)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId)).Wait();

            // Release broken lease (wrong lease)
            leaseId = SetInstantBrokenState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(unknownLeaseId), null, new OperationContext()),
                "release a broken lease with the wrong lease ID",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation);

            this.DeleteAll();
        }
#endif

        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerBreakLeaseStateTests()
        {
            string leaseId;
            TimeSpan leaseTime;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Break lease in available state
            SetUnleasedState(leasedContainer);
            TestHelper.ExpectedException(
                () => leasedContainer.BreakLease(null /* default break period */),
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLease(null /* default break period */);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLease(TimeSpan.FromSeconds(1));

            // Break infinite lease (60 seconds break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLease(TimeSpan.FromSeconds(60));

            // Break breaking lease (zero break time)
            leaseId = SetBreakingState(leasedContainer);
            leaseTime = leasedContainer.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = SetBreakingState(leasedContainer);
            leasedContainer.BreakLease(null /* default break period */);

            // Break finite lease (longer than lease time)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = leasedContainer.BreakLease(TimeSpan.FromSeconds(60));

            // Break finite lease (zero break time)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = leasedContainer.BreakLease(TimeSpan.Zero);
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = leasedContainer.BreakLease(null /* default break period */);

            // Break broken lease (default break time)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.BreakLease(null /* default break period */);

            // Break instant broken lease (nonzero break time)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.BreakLease(TimeSpan.FromSeconds(1));

            // Break instant broken lease (zero break time)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.BreakLease(TimeSpan.Zero);

            // Break released lease (default break time)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedException(
                () => leasedContainer.BreakLease(null /* default break period */),
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Test lease break semantics from various lease states in APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerBreakLeaseStateTestsAPM()
        {
            string leaseId;
            TimeSpan leaseTime;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Break lease in available state
                SetUnleasedStateAPM(leasedContainer);
                IAsyncResult result = leasedContainer.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndBreakLease(result),
                    "break a lease when no lease is present",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

                // Break infinite lease (default break time)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break infinite lease (zero break time)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break infinite lease (1 second break time)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginBreakLease(TimeSpan.FromSeconds(1), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break infinite lease (60 seconds break time)
                leaseId = SetLeasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break breaking lease (zero break time)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break breaking lease (default break time)
                leaseId = SetBreakingStateAPM(leasedContainer);
                result = leasedContainer.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leasedContainer.EndBreakLease(result);

                // Break finite lease (longer than lease time)
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(50));
                result = leasedContainer.BeginBreakLease(TimeSpan.FromSeconds(60), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break finite lease (zero break time)
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(50));
                result = leasedContainer.BeginBreakLease(TimeSpan.Zero, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);
                Assert.AreEqual(TimeSpan.Zero, leaseTime);

                // Break finite lease (default break time)
                leaseId = SetLeasedStateAPM(leasedContainer, TimeSpan.FromSeconds(50));
                result = leasedContainer.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break broken lease (default break time)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break instant broken lease (nonzero break time)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginBreakLease(TimeSpan.FromSeconds(1), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break instant broken lease (zero break time)
                leaseId = SetInstantBrokenStateAPM(leasedContainer);
                result = leasedContainer.BeginBreakLease(TimeSpan.Zero, null, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                leaseTime = leasedContainer.EndBreakLease(result);

                // Break released lease (default break time)
                leaseId = SetReleasedStateAPM(leasedContainer, null /* infinite lease */);
                result = leasedContainer.BeginBreakLease(null /* default break period */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => leasedContainer.EndBreakLease(result),
                    "break a released lease",
                    HttpStatusCode.Conflict,
                    BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);
            }
            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Test lease break semantics from various lease states")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerBreakLeaseStateTestsTask()
        {
            string leaseId;
            TimeSpan leaseTime;

            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Break lease in available state
            SetUnleasedState(leasedContainer);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.BreakLeaseAsync(null /* default break period */),
                "break a lease when no lease is present",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            // Break infinite lease (default break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLeaseAsync(null /* default break period */).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (zero break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break infinite lease (1 second break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(1)).Result;

            // Break infinite lease (60 seconds break time)
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leaseTime = leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Result;

            // Break breaking lease (zero break time)
            leaseId = SetBreakingState(leasedContainer);
            leaseTime = leasedContainer.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break breaking lease (default break time)
            leaseId = SetBreakingState(leasedContainer);
            leasedContainer.BreakLeaseAsync(null /* default break period */).Wait();

            // Break finite lease (longer than lease time)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(60)).Result;

            // Break finite lease (zero break time)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = leasedContainer.BreakLeaseAsync(TimeSpan.Zero).Result;
            Assert.AreEqual(TimeSpan.Zero, leaseTime);

            // Break finite lease (default break time)
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(50));
            leaseTime = leasedContainer.BreakLeaseAsync(null /* default break period */).Result;

            // Break broken lease (default break time)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.BreakLeaseAsync(null /* default break period */).Wait();

            // Break instant broken lease (nonzero break time)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.BreakLeaseAsync(TimeSpan.FromSeconds(1)).Wait();

            // Break instant broken lease (zero break time)
            leaseId = SetInstantBrokenState(leasedContainer);
            leasedContainer.BreakLeaseAsync(TimeSpan.Zero, null, null, null).Wait();

            // Break released lease (default break time)
            leaseId = SetReleasedState(leasedContainer, null /* infinite lease */);
            TestHelper.ExpectedExceptionTask(
                leasedContainer.BreakLeaseAsync(null /* default break period */),
                "break a released lease",
                HttpStatusCode.Conflict,
                BlobErrorCodeStrings.LeaseNotPresentWithLeaseOperation);

            this.DeleteAll();
        }
#endif
        [TestMethod]
        [Description("Tests container delete APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeasedDeleteTests()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();

            // Create the container
            leasedContainer.Create();

            // Verify that deletes that pass a lease fail if none is present.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerDeleteExpectLeaseFailure(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "delete container using a lease when no lease is held");

            // Acquire a lease
            string leaseId = leasedContainer.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that deletes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            this.ContainerDeleteExpectLeaseFailure(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "delete container using no lease when a lease is held");

            // Verify that deletes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerDeleteExpectLeaseFailure(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "delete container using a lease when a different lease is held");

            // Verify that deletes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            this.ContainerDeleteExpectLeaseSuccess(leasedContainer, testAccessCondition);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Tests container delete APIs in the presence of a lease usign APM.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeasedDeleteTestsAPM()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();

            // Create the container
            leasedContainer.Create();

            // Verify that deletes that pass a lease fail if none is present.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerDeleteExpectLeaseFailureAPM(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "delete container using a lease when no lease is held");

            // Acquire a lease
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = leasedContainer.BeginAcquireLease(null /* lease duration */, null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                string leaseId = leasedContainer.EndAcquireLease(result);

                // Verify that deletes without a lease do not succeed.
                testAccessCondition.LeaseId = null;
                this.ContainerDeleteExpectLeaseFailureAPM(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "delete container using no lease when a lease is held");

                // Verify that deletes with the wrong lease fail.
                testAccessCondition.LeaseId = fakeLease;
                this.ContainerDeleteExpectLeaseFailureAPM(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "delete container using a lease when a different lease is held");

                // Verify that deletes with the right lease succeed.
                testAccessCondition.LeaseId = leaseId;
                this.ContainerDeleteExpectLeaseSuccessAPM(leasedContainer, testAccessCondition);
            }
            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Tests container delete APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeasedDeleteTestsTask()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();

            // Create the container
            leasedContainer.CreateAsync().Wait();

            // Verify that deletes that pass a lease fail if none is present.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerDeleteExpectLeaseFailureTask(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "delete container using a lease when no lease is held");

            // Acquire a lease
            string leaseId = leasedContainer.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */).Result;

            // Verify that deletes without a lease do not succeed.
            testAccessCondition.LeaseId = null;
            this.ContainerDeleteExpectLeaseFailureTask(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMissing, "delete container using no lease when a lease is held");

            // Verify that deletes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerDeleteExpectLeaseFailureTask(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "delete container using a lease when a different lease is held");

            // Verify that deletes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            this.ContainerDeleteExpectLeaseSuccessTask(leasedContainer, testAccessCondition);

            this.DeleteAll();
        }
#endif

        /// <summary>
        /// Test container deletion, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void ContainerDeleteExpectLeaseFailure(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedException(
                () => testContainer.Delete(testAccessCondition, null /* options */),
                description + " (Delete)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test container deletion, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void ContainerDeleteExpectLeaseFailureAPM(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testContainer.BeginDelete(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testContainer.EndDelete(result),
                    description + " (Delete)",
                    expectedStatusCode,
                    expectedErrorCode);
            }
        }

#if TASK
         /// <summary>
        /// Test container deletion, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void ContainerDeleteExpectLeaseFailureTask(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            TestHelper.ExpectedExceptionTask(
                testContainer.DeleteAsync(testAccessCondition, null /* options */, null /* operationContext */),
                description + " (Delete)",
                expectedStatusCode,
                expectedErrorCode);
        }

#endif

        /// <summary>
        /// Test container deletion, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void ContainerDeleteExpectLeaseSuccess(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            testContainer.Delete(testAccessCondition, null /* options */);
        }

        /// <summary>
        /// Test container deletion, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void ContainerDeleteExpectLeaseSuccessAPM(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testContainer.BeginDelete(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testContainer.EndDelete(result);
            }
        }

#if TASK
        /// <summary>
        /// Test container deletion, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void ContainerDeleteExpectLeaseSuccessTask(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            testContainer.DeleteAsync(testAccessCondition, null /* options */, null /* operationContext */).Wait();
        }
#endif

        [TestMethod]
        [Description("Tests container read and write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeasedReadWriteTests()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            leasedContainer.Create();

            // Verify that reads and writes that pass a lease fail if none is present
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerReadWriteExpectLeaseFailure(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "read/write container using a lease when no lease is held");

            // Acquire a lease
            string leaseId = leasedContainer.AcquireLease(null /* lease duration */, null /* proposed lease ID */);

            // Verify that reads and writes without a lease succeed.
            testAccessCondition.LeaseId = null;
            this.ContainerReadWriteExpectLeaseSuccess(leasedContainer, testAccessCondition);

            // Verify that reads and writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerReadWriteExpectLeaseFailure(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "read/write container using a lease when a different lease is held");

            // Verify that reads and writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            this.ContainerReadWriteExpectLeaseSuccess(leasedContainer, testAccessCondition);

            this.DeleteAll();
        }

        [TestMethod]
        [Description("Tests container read and write APIs in the presence of a lease using APM.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeasedReadWriteTestsAPM()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            leasedContainer.Create();

            // Verify that reads and writes that pass a lease fail if none is present
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerReadWriteExpectLeaseFailureAPM(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "read/write container using a lease when no lease is held");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {

                // Acquire a lease
                IAsyncResult result = leasedContainer.BeginAcquireLease(null /* lease duration */, null /* proposed lease ID */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                string leaseId = leasedContainer.EndAcquireLease(result);

                // Verify that reads and writes without a lease succeed.
                testAccessCondition.LeaseId = null;
                this.ContainerReadWriteExpectLeaseSuccessAPM(leasedContainer, testAccessCondition);

                // Verify that reads and writes with the wrong lease fail.
                testAccessCondition.LeaseId = fakeLease;
                this.ContainerReadWriteExpectLeaseFailureAPM(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "read/write container using a lease when a different lease is held");

                // Verify that reads and writes with the right lease succeed.
                testAccessCondition.LeaseId = leaseId;
                this.ContainerReadWriteExpectLeaseSuccessAPM(leasedContainer, testAccessCondition);
            }

            this.DeleteAll();
        }

#if TASK
        [TestMethod]
        [Description("Tests container read and write APIs in the presence of a lease.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeasedReadWriteTestsTask()
        {
            CloudBlobContainer leasedContainer = this.GetContainerReference("leased-container");
            AccessCondition testAccessCondition = AccessCondition.GenerateEmptyCondition();
            string fakeLease = Guid.NewGuid().ToString();
            leasedContainer.CreateAsync().Wait();

            // Verify that reads and writes that pass a lease fail if none is present
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerReadWriteExpectLeaseFailureTask(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseNotPresentWithContainerOperation, "read/write container using a lease when no lease is held");

            // Acquire a lease
            string leaseId = leasedContainer.AcquireLeaseAsync(null /* lease duration */, null /* proposed lease ID */).Result;

            // Verify that reads and writes without a lease succeed.
            testAccessCondition.LeaseId = null;
            this.ContainerReadWriteExpectLeaseSuccessTask(leasedContainer, testAccessCondition);

            // Verify that reads and writes with the wrong lease fail.
            testAccessCondition.LeaseId = fakeLease;
            this.ContainerReadWriteExpectLeaseFailureTask(leasedContainer, testAccessCondition, HttpStatusCode.PreconditionFailed, BlobErrorCodeStrings.LeaseIdMismatchWithContainerOperation, "read/write container using a lease when a different lease is held");

            // Verify that reads and writes with the right lease succeed.
            testAccessCondition.LeaseId = leaseId;
            this.ContainerReadWriteExpectLeaseSuccessTask(leasedContainer, testAccessCondition);

            this.DeleteAll();
        }
#endif
        /// <summary>
        /// Test container reads and writes, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void ContainerReadWriteExpectLeaseFailure(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            TestHelper.ExpectedException(
                () => testContainer.FetchAttributes(testAccessCondition, null /* options */),
                description + "(Fetch Attributes)",
                HttpStatusCode.PreconditionFailed);

            TestHelper.ExpectedException(
                () => testContainer.GetPermissions(testAccessCondition, null /* options */),
                description + " (Get Permissions)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => testContainer.SetMetadata(testAccessCondition, null /* options */),
                description + " (Set Metadata)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedException(
                () => testContainer.SetPermissions(new BlobContainerPermissions(), testAccessCondition, null /* options */),
                description + " (Set Permissions)",
                expectedStatusCode,
                expectedErrorCode);
        }

        /// <summary>
        /// Test container reads and writes, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void ContainerReadWriteExpectLeaseFailureAPM(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testContainer.BeginFetchAttributes(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
                TestHelper.ExpectedException(
                    () => testContainer.EndFetchAttributes(result),
                    description + "(Fetch Attributes)",
                    HttpStatusCode.PreconditionFailed);

                result = testContainer.BeginGetPermissions(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testContainer.EndGetPermissions(result),
                    description + " (Get Permissions)",
                    expectedStatusCode,
                    expectedErrorCode);

                result = testContainer.BeginSetMetadata(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testContainer.EndSetMetadata(result),
                    description + " (Set Metadata)",
                    expectedStatusCode,
                    expectedErrorCode);

                result = testContainer.BeginSetPermissions(new BlobContainerPermissions(), testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => testContainer.EndSetPermissions(result),
                    description + " (Set Permissions)",
                    expectedStatusCode,
                    expectedErrorCode);
            }
        }

#if TASK
         /// <summary>
        /// Test container reads and writes, expecting lease failure.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The failing access condition to use.</param>
        /// <param name="expectedErrorCode">The expected error code.</param>
        /// <param name="description">The reason why these calls should fail.</param>
        private void ContainerReadWriteExpectLeaseFailureTask(CloudBlobContainer testContainer, AccessCondition testAccessCondition, HttpStatusCode expectedStatusCode, string expectedErrorCode, string description)
        {
            // FetchAttributes is a HEAD request with no extended error info, so it returns with the generic ConditionFailed error code.
            TestHelper.ExpectedExceptionTask(
                testContainer.FetchAttributesAsync(testAccessCondition, null /* options */, null /* operationContext */),
                description + "(Fetch Attributes)",
                HttpStatusCode.PreconditionFailed);

            TestHelper.ExpectedExceptionTask(
                testContainer.GetPermissionsAsync(testAccessCondition, null /* options */, null /* operationContext */),
                description + " (Get Permissions)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedExceptionTask(
                testContainer.SetMetadataAsync(testAccessCondition, null /* options */, null /* operationContext */),
                description + " (Set Metadata)",
                expectedStatusCode,
                expectedErrorCode);
            TestHelper.ExpectedExceptionTask(
                testContainer.SetPermissionsAsync(new BlobContainerPermissions(), testAccessCondition, null /* options */, null /* operationContext */),
                description + " (Set Permissions)",
                expectedStatusCode,
                expectedErrorCode);
        }
#endif

        /// <summary>
        /// Test container reads and writes, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void ContainerReadWriteExpectLeaseSuccess(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            testContainer.FetchAttributes(testAccessCondition, null /* options */);
            testContainer.GetPermissions(testAccessCondition, null /* options */);
            testContainer.SetMetadata(testAccessCondition, null /* options */);
            testContainer.SetPermissions(new BlobContainerPermissions(), testAccessCondition, null /* options */);
        }

        /// <summary>
        /// Test container reads and writes, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void ContainerReadWriteExpectLeaseSuccessAPM(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = testContainer.BeginFetchAttributes(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testContainer.EndFetchAttributes(result);

                result = testContainer.BeginGetPermissions(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testContainer.EndGetPermissions(result);

                result = testContainer.BeginSetMetadata(testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testContainer.EndSetMetadata(result);

                result = testContainer.BeginSetPermissions(new BlobContainerPermissions(), testAccessCondition, null /* options */, null /* operationContext */, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                testContainer.EndSetPermissions(result);
            }
        }

#if TASK
        /// <summary>
        /// Test container reads and writes, expecting success.
        /// </summary>
        /// <param name="testContainer">The container.</param>
        /// <param name="testAccessCondition">The access condition to use.</param>
        private void ContainerReadWriteExpectLeaseSuccessTask(CloudBlobContainer testContainer, AccessCondition testAccessCondition)
        {
            testContainer.FetchAttributesAsync(testAccessCondition, null /* options */, null /* operationContext */).Wait();
            testContainer.GetPermissionsAsync(testAccessCondition, null /* options */, null /* operationContext */).Wait();
            testContainer.SetMetadataAsync(testAccessCondition, null /* options */, null /* operationContext */).Wait();
            testContainer.SetPermissionsAsync(new BlobContainerPermissions(), testAccessCondition, null /* options */, null /* operationContext */).Wait();
        }
#endif

        [TestMethod]
        [Description("Test reading the container lease status after various lease actions.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ContainerLeaseStatusTest()
        {
            string leaseId;
            CloudBlobContainer leasedContainer = this.GetContainerReference("lease-tests");

            // Check uninitialized lease status
            SetUnleasedState(leasedContainer);
            Assert.AreEqual(LeaseStatus.Unspecified, leasedContainer.Properties.LeaseStatus, "uninitialized lease status");
            Assert.AreEqual(LeaseState.Unspecified, leasedContainer.Properties.LeaseState, "uninitialized lease state");
            Assert.AreEqual(LeaseDuration.Unspecified, leasedContainer.Properties.LeaseDuration, "uninitialized lease duration");

            // Check lease status in initial state
            SetUnleasedState(leasedContainer);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "initial lease state");

            // Check lease status after acquiring an infinite lease
            SetLeasedState(leasedContainer, null /* infinite lease */);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after acquire lease");

            // Check lease status after acquiring a finite lease
            SetLeasedState(leasedContainer, TimeSpan.FromSeconds(45));
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after acquire lease");

            // Check lease status after renewing an infinite lease
            SetRenewedState(leasedContainer, null /* infinite lease */);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after renew lease");

            // Check lease status after renewing a finite lease
            SetRenewedState(leasedContainer, TimeSpan.FromSeconds(45));
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after renew lease");

            // Check lease status after changing an infinite lease
            leaseId = SetLeasedState(leasedContainer, null /* infinite lease */);
            leasedContainer.ChangeLease(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after change lease");

            // Check lease status after changing a finite lease
            leaseId = SetLeasedState(leasedContainer, TimeSpan.FromSeconds(45));
            leasedContainer.ChangeLease(Guid.NewGuid().ToString(), AccessCondition.GenerateLeaseCondition(leaseId));
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Fixed, "after change lease");

            // Check lease status after releasing a lease
            SetReleasedState(leasedContainer, null /* infinite lease */);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Unlocked, LeaseState.Available, LeaseDuration.Unspecified, "after release lease");

            // Check lease status while infinite lease is breaking
            SetBreakingState(leasedContainer);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Breaking, LeaseDuration.Unspecified, "while lease is breaking");

            // Check lease status after lease breaks
            SetTimeBrokenState(leasedContainer);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after break time elapses");

            // Check lease status after (infinite) acquire after break
            SetTimeBrokenState(leasedContainer);
            leasedContainer.AcquireLease(null /* infinite lease */, null /*proposed lease ID */);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Locked, LeaseState.Leased, LeaseDuration.Infinite, "after second acquire lease");

            // Check lease status after instant break with infinite lease
            SetInstantBrokenState(leasedContainer);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Unlocked, LeaseState.Broken, LeaseDuration.Unspecified, "after instant break lease");

            // Check lease status after lease expires
            SetExpiredState(leasedContainer);
            this.CheckLeaseStatus(leasedContainer, LeaseStatus.Unlocked, LeaseState.Expired, LeaseDuration.Unspecified, "after lease expires");

            this.DeleteAll();
        }

        /// <summary>
        /// Checks the lease status of a container, both from its attributes and from a container listing.
        /// </summary>
        /// <param name="container">The container to test.</param>
        /// <param name="expectedStatus">The expected lease status.</param>
        /// <param name="expectedState">The expected lease state.</param>
        /// <param name="expectedDuration">The expected lease duration.</param>
        /// <param name="description">A description of the circumstances that lead to the expected status.</param>
        private void CheckLeaseStatus(
            CloudBlobContainer container,
            LeaseStatus expectedStatus,
            LeaseState expectedState,
            LeaseDuration expectedDuration,
            string description)
        {
            container.FetchAttributes();
            Assert.AreEqual(expectedStatus, container.Properties.LeaseStatus, "LeaseStatus mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedState, container.Properties.LeaseState, "LeaseState mismatch: " + description + " (from FetchAttributes)");
            Assert.AreEqual(expectedDuration, container.Properties.LeaseDuration, "LeaseDuration mismatch: " + description + " (from FetchAttributes)");

            BlobContainerProperties propertiesInListing = (from CloudBlobContainer c in this.blobClient.ListContainers(
                                                               container.Name,
                                                               ContainerListingDetails.None)
                                                           where c.Name == container.Name
                                                           select c.Properties).Single();

            Assert.AreEqual(expectedStatus, propertiesInListing.LeaseStatus, "LeaseStatus mismatch: " + description + " (from ListContainers)");
            Assert.AreEqual(expectedState, propertiesInListing.LeaseState, "LeaseState mismatch: " + description + " (from ListContainers)");
            Assert.AreEqual(expectedDuration, propertiesInListing.LeaseDuration, "LeaseDuration mismatch: " + description + " (from ListContainers)");
        }
    }
}
