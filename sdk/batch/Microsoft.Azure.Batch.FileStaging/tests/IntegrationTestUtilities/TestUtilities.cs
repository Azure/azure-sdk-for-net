// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Batch.FileStaging.Tests.IntegrationTestUtilities
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;

    public static class TestUtilities
    {
        #region Credentials helpers

        public static BatchSharedKeyCredentials GetCredentialsFromEnvironment()
        {
            return new BatchSharedKeyCredentials(
                TestCommon.Configuration.BatchAccountUrl, 
                TestCommon.Configuration.BatchAccountName, 
                TestCommon.Configuration.BatchAccountKey);
        }

        public static BatchClient OpenBatchClient(BatchSharedKeyCredentials sharedKeyCredentials, bool addDefaultRetryPolicy = true)
        {
            BatchClient client = BatchClient.Open(sharedKeyCredentials);

            //Force us to get exception if the server returns something we don't expect
            //TODO: To avoid including this test assembly via "InternalsVisibleTo" we resort to some reflection trickery... maybe this property
            //TODO: should just be public?

            //TODO: Disabled for now because the swagger spec does not accurately reflect all properties returned by the server
            //SetDeserializationSettings(client);

            //Set up some common stuff like a retry policy
            if (addDefaultRetryPolicy)
            {
                client.CustomBehaviors.Add(RetryPolicyProvider.LinearRetryProvider(TimeSpan.FromSeconds(3), 5));
            }

            return client;
        }

        public static BatchClient OpenBatchClientFromEnvironment()
        {
            BatchClient client = OpenBatchClient(GetCredentialsFromEnvironment());
            return client;
        }

        public static StagingStorageAccount GetStorageCredentialsFromEnvironment()
        {
            string storageAccountKey = TestCommon.Configuration.StorageAccountKey;
            string storageAccountName = TestCommon.Configuration.StorageAccountName;
            string storageAccountBlobEndpoint = TestCommon.Configuration.StorageAccountBlobEndpoint;

            StagingStorageAccount storageStagingCredentials = new StagingStorageAccount(storageAccountName, storageAccountKey, storageAccountBlobEndpoint);

            return storageStagingCredentials;
        }

        #endregion

        #region Naming helpers

        public static string GetMyName()
        {
            string domainName = Environment.GetEnvironmentVariable("USERNAME");

            return domainName;
        }

        #endregion

        #region Deletion helpers

        public static async Task DeleteJobIfExistsAsync(BatchClient client, string jobId)
        {
            try
            {
                await client.JobOperations.DeleteJobAsync(jobId).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the job and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        public static async Task DeleteJobScheduleIfExistsAsync(BatchClient client, string jobScheduleId)
        {
            try
            {
                await client.JobScheduleOperations.DeleteJobScheduleAsync(jobScheduleId).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the job and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        public static async Task DeletePoolIfExistsAsync(BatchClient client, string poolId)
        {
            try
            {
                await client.PoolOperations.DeletePoolAsync(poolId).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the job and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        public static async Task DeleteCertificateIfExistsAsync(BatchClient client, string thumbprintAlgorithm, string thumbprint)
        {
            try
            {
                await client.CertificateOperations.DeleteCertificateAsync(thumbprintAlgorithm, thumbprint).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the cert and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        #endregion

        #region Wait helpers

        public static async Task WaitForPoolToReachStateAsync(BatchClient client, string poolId, AllocationState targetAllocationState, TimeSpan timeout)
        {
            CloudPool pool = await client.PoolOperations.GetPoolAsync(poolId);

            await RefreshBasedPollingWithTimeoutAsync(
                    refreshing: pool,
                    condition: () => Task.FromResult(pool.AllocationState == targetAllocationState),
                    timeout: timeout).ConfigureAwait(false);
        }

        /// <summary>
        /// Will throw if timeout is exceeded.
        /// </summary>
        /// <param name="refreshing"></param>
        /// <param name="condition"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static async Task RefreshBasedPollingWithTimeoutAsync(IRefreshable refreshing, Func<Task<bool>> condition, TimeSpan timeout)
        {
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(timeout);

            while (!(await condition().ConfigureAwait(continueOnCapturedContext: false)))
            {
                await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(continueOnCapturedContext: false);
                await refreshing.RefreshAsync().ConfigureAwait(continueOnCapturedContext: false);

                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("RefreshBasedPollingWithTimeout: Timed out waiting for condition to be met.");
                }
            }
        }

        #endregion

        #region Private helpers

        private static bool IsExceptionNotFound(BatchException e)
        {
            return e.RequestInformation != null && e.RequestInformation.HttpStatusCode == HttpStatusCode.NotFound;
        }

        private static bool IsExceptionConflict(BatchException e)
        {
            return e.RequestInformation != null && e.RequestInformation.HttpStatusCode == HttpStatusCode.Conflict;
        }

        #endregion
    }
}
