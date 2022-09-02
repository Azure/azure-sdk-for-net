// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.AlphaIds.Models;
using NUnit.Framework;

namespace Azure.Communication.AlphaIds.Tests
{
    public class AlphaIdsClientTests : AlphaIdsClientTestBase
    {
        public AlphaIdsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetConfiguration()
        {
            AlphaIdsClient alphaIdsClient = CreateAlphaIdsClientClient();

            AlphaIdConfiguration response = null;

            await IgnoreSubscriptionNotEligibleErrorAsync(async () => response = await alphaIdsClient.GetConfigurationAsync());
        }

        [Test]
        public async Task UpsertConfiguration()
        {
            AlphaIdsClient alphaIdsClient = CreateAlphaIdsClientClient();

            AlphaIdConfiguration response = null;

            await IgnoreSubscriptionNotEligibleErrorAsync(async () => response = await alphaIdsClient.UpsertConfigurationAsync(enabled: false));
        }

        private async Task IgnoreSubscriptionNotEligibleErrorAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (RequestFailedException ex)
            {
                if (IsSubscriptionNotEligibleError(ex))
                {
                    return;
                }

                throw;
            }
        }

        private static bool IsSubscriptionNotEligibleError(RequestFailedException ex)
        {
            return ex.Status == 403 && ex.ErrorCode.Equals("Forbidden", StringComparison.OrdinalIgnoreCase);
        }
    }
}
