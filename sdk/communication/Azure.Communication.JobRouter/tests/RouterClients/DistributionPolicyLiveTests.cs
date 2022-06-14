// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class DistributionPolicyLiveTests : RouterLiveTestBase
    {
        /// <inheritdoc />
        public DistributionPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Distribution Policy Tests

        #region best worker mode constructors
        [Test]
        public async Task CreateDistributionPolicyTest_BestWorker_DefaultScoringRule()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // test best worker mode constructors

            // --- default scoring rule
            var bestWorkerModeDistributionPolicyId = GenerateUniqueId($"{IdPrefix}-Default-DistributionPolicy");
            var bestWorkerModeDistributionPolicyName = $"{bestWorkerModeDistributionPolicyId}-Name";
            var bestWorkerModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                60,
                new BestWorkerMode(),
                new CreateDistributionPolicyOptions()
                {
                    Name = bestWorkerModeDistributionPolicyName
                });

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            var bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            bestWorkerModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                new UpdateDistributionPolicyOptions()
                {
                    OfferTtlSeconds = 60,
                    Mode = new BestWorkerMode(bypassSelectors: true, sortDescending: false),
                    Name = bestWorkerModeDistributionPolicyName
                });

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsTrue(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            bestWorkerModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                new UpdateDistributionPolicyOptions()
                {
                    Mode = new BestWorkerMode(1, 2, true)
                });

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsTrue(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(bestWorkerModeDistributionPolicyId)));
        }

        [Test]
        public async Task CreateDistributionPolicyTest_BestWorker_AzureRuleFunctions()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var bestWorkerModeDistributionPolicyId = GenerateUniqueId($"{IdPrefix}-Best-DistributionPolicy");
            var bestWorkerModeDistributionPolicyName = $"{bestWorkerModeDistributionPolicyId}-Name";
            // ----- custom scoring rule - with azure function

            var bestWorkerModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                1,
                new BestWorkerMode(
                    new AzureFunctionRule("https://my.function.app/api/myfunction?code=Kg==", new AzureFunctionRuleCredential("MyAppKey", "MyClientId")),
                    new List<ScoringRuleParameterSelector>()
                    {
                        ScoringRuleParameterSelector.WorkerSelectors
                    },
                    minConcurrentOffers: 1, maxConcurrentOffers: 2),
                new CreateDistributionPolicyOptions()
                {
                    Name = bestWorkerModeDistributionPolicyName,
                });

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            var bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            var paramSelectors = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRuleOptions
                .ScoringParameters;
            Assert.AreEqual(1, paramSelectors.Count);
            Assert.AreEqual(ScoringRuleParameterSelector.WorkerSelectors, paramSelectors.First());

            var scoringRule = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRule;
            Assert.NotNull(scoringRule);
            var azureFuncScoringRule = (AzureFunctionRule)scoringRule;
            // Assert.AreEqual("https://my.function.app/api/myfunction?code=Kg==", azureFuncScoringRule.FunctionAppUrl);
            Assert.IsNotNull(azureFuncScoringRule.Credential);

            if (Mode != RecordedTestMode.Playback)
            {
                // any value will be sanitized when recordings are saved
                Assert.AreEqual("MyAppKey", azureFuncScoringRule.Credential.AppKey);
                Assert.IsTrue(string.IsNullOrWhiteSpace(azureFuncScoringRule.Credential.FunctionKey));
            }

            Assert.AreEqual("MyClientId", azureFuncScoringRule.Credential.ClientId);

            bestWorkerModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                new UpdateDistributionPolicyOptions()
                {
                    Mode = new BestWorkerMode(
                        new AzureFunctionRule("https://my.function.app/api/myfunction?code=Kg==", new AzureFunctionRuleCredential("MyKey")),
                        new List<ScoringRuleParameterSelector>()
                        {
                            ScoringRuleParameterSelector.WorkerSelectors
                        },
                        minConcurrentOffers: 1, maxConcurrentOffers: 2),
                });

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            paramSelectors = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRuleOptions
                .ScoringParameters;
            Assert.AreEqual(1, paramSelectors.Count);
            Assert.AreEqual(ScoringRuleParameterSelector.WorkerSelectors, paramSelectors.First());

            scoringRule = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRule;
            Assert.NotNull(scoringRule);
            azureFuncScoringRule = (AzureFunctionRule)scoringRule;
            // Assert.AreEqual("https://my.function.app/api/myfunction?code=Kg==", azureFuncScoringRule.FunctionAppUrl);
            Assert.IsNotNull(azureFuncScoringRule.Credential);

            if (Mode != RecordedTestMode.Playback)
            {
                // any value will be sanitized when recordings are saved
                Assert.AreEqual("MyKey", azureFuncScoringRule.Credential.FunctionKey);
            }

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(bestWorkerModeDistributionPolicyId)));
            // test longest idle mode constructors

            // test round robin mode constructors
        }

        #endregion best worker mode constructors

        #region longest idle mode constructors

        [Test]
        public async Task CreateDistributionPolicyTest_LongestIdle()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var longestIdleModeDistributionPolicyId = GenerateUniqueId($"{IdPrefix}-Longest-DistributionPolicy");
            var longestIdleModeDistributionPolicyName = $"{longestIdleModeDistributionPolicyId}-Name";

            var longestIdleModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                longestIdleModeDistributionPolicyId,
                1,
                new LongestIdleMode(),
                new CreateDistributionPolicyOptions()
                {
                    Name = longestIdleModeDistributionPolicyName
                });

            Assert.NotNull(longestIdleModeDistributionPolicyResponse.Value);

            var longestIdleModeDistributionPolicy = longestIdleModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, longestIdleModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, longestIdleModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(longestIdleModeDistributionPolicy.Mode.BypassSelectors);

            // specifying min and max concurrent offers
            longestIdleModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                longestIdleModeDistributionPolicyId,
                new UpdateDistributionPolicyOptions()
                {
                    Mode = new LongestIdleMode(1, 2, true),
                });

            Assert.NotNull(longestIdleModeDistributionPolicyResponse.Value);

            longestIdleModeDistributionPolicy = longestIdleModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, longestIdleModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, longestIdleModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsTrue(longestIdleModeDistributionPolicy.Mode.BypassSelectors);

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(longestIdleModeDistributionPolicyId)));
        }

        #endregion longest idle mode constructors

        #region round robin mode constructors

        [Test]
        public async Task CreateDistributionPolicyTest_RoundRobin()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var roundRobinModeDistributionPolicyId = $"{IdPrefix}-RR-DistributionPolicy";
            var roundRobinModeDistributionPolicyName = $"{roundRobinModeDistributionPolicyId}-Name";

            var roundRobinModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                roundRobinModeDistributionPolicyId,
                1,
                new RoundRobinMode(),
                new CreateDistributionPolicyOptions()
                {
                    Name = roundRobinModeDistributionPolicyName
                });

            Assert.NotNull(roundRobinModeDistributionPolicyResponse.Value);

            var roundRobinModeDistributionPolicy = roundRobinModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, roundRobinModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, roundRobinModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(roundRobinModeDistributionPolicy.Mode.BypassSelectors);

            // specifying min and max concurrent offers
            roundRobinModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                roundRobinModeDistributionPolicyId,
                new UpdateDistributionPolicyOptions()
                {
                    Mode = new LongestIdleMode(1, 2, true),
                });

            Assert.NotNull(roundRobinModeDistributionPolicyResponse.Value);

            roundRobinModeDistributionPolicy = roundRobinModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, roundRobinModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, roundRobinModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsTrue(roundRobinModeDistributionPolicy.Mode.BypassSelectors);

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(roundRobinModeDistributionPolicyId)));
        }

        #endregion round robin mode constructors

        #endregion Distribution Policy Tests
    }
}
