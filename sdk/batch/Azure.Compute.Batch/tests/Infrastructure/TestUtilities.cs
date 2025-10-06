// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public static class TestUtilities
    {
        #region Wait helpers

        public static async Task WaitForPoolToReachStateAsync(BatchClient client, string poolId, AllocationState targetAllocationState, TimeSpan timeout, bool isPlayback)
        {
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(timeout);

            BatchPool pool = await client.GetPoolAsync(poolId);

            while (pool.AllocationState != targetAllocationState)
            {
                if (!isPlayback)
                { await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(continueOnCapturedContext: false); }

                pool = await client.GetPoolAsync(poolId);

                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("RefreshBasedPollingWithTimeout: Timed out waiting for condition to be met.");
                }
            }
        }

        /// <summary>
        /// Will throw if timeout is exceeded.
        /// </summary>
        /// <param name="refreshing"></param>
        /// <param name="condition"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static async Task RefreshBasedPollingWithTimeoutAsync(Func<Task<bool>> condition, TimeSpan timeout)
        {
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(timeout);

            while (!(await condition().ConfigureAwait(continueOnCapturedContext: false)))
            {
                await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(continueOnCapturedContext: false);
                //await refreshing.RefreshAsync().ConfigureAwait(continueOnCapturedContext: false);

                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("RefreshBasedPollingWithTimeout: Timed out waiting for condition to be met.");
                }
            }
        }
        #endregion
        #region Naming helpers

        public static string GenerateResourceId(
            string baseId = null,
            int? maxLength = null,
            [CallerMemberName] string caller = null)
        {
            int actualMaxLength = maxLength ?? 50;

            var guid = Guid.NewGuid().ToString("N");
            if (baseId == null && caller == null)
            {
                return guid;
            }
            else
            {
                const int minRandomCharacters = 10;
                // make the ID only contain alphanumeric or underscore or dash:
                var id = baseId ?? caller;
                var safeBaseId = Regex.Replace(id, "[^A-Za-z0-9_-]", "");
                safeBaseId = safeBaseId.Length > actualMaxLength - minRandomCharacters ? safeBaseId.Substring(0, actualMaxLength - minRandomCharacters) : safeBaseId;
                var result = $"{safeBaseId}_{guid}";
                return result.Length > actualMaxLength ? result.Substring(0, actualMaxLength) : result;
            }
        }

        public static string GetMyName()
        {
            string domainName = Environment.GetEnvironmentVariable("USERNAME");

            return domainName;
        }

        public static string GetTimeStamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd_hh-mm-ss");
        }

        public static string GenerateRandomPassword()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion
    }
}
