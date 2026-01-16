// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class DistributionPolicyLiveTests : RouterLiveTestBase
    {
        public DistributionPolicyLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Distribution Policy Tests

        #region best worker mode constructors
        [Test]
        public async Task CreateDistributionPolicyTest_BestWorker_DefaultScoringRule()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            // test best worker mode constructors

            // --- default scoring rule
            var bestWorkerModeDistributionPolicyId = GenerateUniqueId($"{IdPrefix}-Default-DistributionPolicy");
            var bestWorkerModeDistributionPolicyName = $"{bestWorkerModeDistributionPolicyId}-Name";
            var bestWorkerModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(bestWorkerModeDistributionPolicyId, TimeSpan.FromSeconds(60), new BestWorkerMode())
                {
                    Name = bestWorkerModeDistributionPolicyName
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(bestWorkerModeDistributionPolicyId)));
            Assert.That(bestWorkerModeDistributionPolicyResponse.Value, Is.Not.Null);

            var bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.BypassSelectors, Is.False);

            bestWorkerModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                new DistributionPolicy(bestWorkerModeDistributionPolicyId)
                {
                    OfferExpiresAfter = TimeSpan.FromSeconds(60),
                    Mode = new BestWorkerMode
                    {
                        ScoringRuleOptions = new ScoringRuleOptions { DescendingOrder = false },
                        BypassSelectors = true
                    },
                    Name = bestWorkerModeDistributionPolicyName
                });

            Assert.That(bestWorkerModeDistributionPolicyResponse.Value, Is.Not.Null);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.BypassSelectors, Is.True);

            bestWorkerModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                new DistributionPolicy(bestWorkerModeDistributionPolicyId)
                {
                    Mode = new BestWorkerMode
                    {
                        MinConcurrentOffers = 1,
                        MaxConcurrentOffers = 2,
                        BypassSelectors = true
                    }
                });

            Assert.That(bestWorkerModeDistributionPolicyResponse.Value, Is.Not.Null);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(2));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.BypassSelectors, Is.True);
        }

        [Test]
        [LiveOnly(Reason = "ClientId is sanitized in test recordings.")]
        public async Task CreateDistributionPolicyTest_BestWorker_AzureRuleFunctions()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var bestWorkerModeDistributionPolicyId = GenerateUniqueId($"{IdPrefix}-Best-DistributionPolicy");
            var bestWorkerModeDistributionPolicyName = $"{bestWorkerModeDistributionPolicyId}-Name";
            // ----- custom scoring rule - with azure function

            var bestWorkerModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(bestWorkerModeDistributionPolicyId, TimeSpan.FromSeconds(1),
                    new BestWorkerMode
                    {
                        ScoringRule = new FunctionRouterRule(new Uri("https://my.function.app/api/myfunction?code=Kg=="))
                        {
                            Credential = new FunctionRouterRuleCredential("MyAppKey", "MyClientId")
                        },
                        ScoringRuleOptions = new ScoringRuleOptions
                        {
                            ScoringParameters = { ScoringRuleParameterSelector.WorkerSelectors }
                        },
                        MinConcurrentOffers = 1,
                        MaxConcurrentOffers = 2
                    }
                ) { Name = bestWorkerModeDistributionPolicyName });

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(bestWorkerModeDistributionPolicyId)));
            Assert.That(bestWorkerModeDistributionPolicyResponse.Value, Is.Not.Null);

            var bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(2));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.BypassSelectors, Is.False);

            var paramSelectors = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRuleOptions
                .ScoringParameters;
            Assert.That(paramSelectors.Count, Is.EqualTo(1));
            Assert.That(paramSelectors.First(), Is.EqualTo(ScoringRuleParameterSelector.WorkerSelectors));

            var scoringRule = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRule;
            Assert.That(scoringRule, Is.Not.Null);
            var azureFuncScoringRule = (FunctionRouterRule)scoringRule;
            // Assert.AreEqual("https://my.function.app/api/myfunction?code=Kg==", azureFuncScoringRule.FunctionAppUrl);
            Assert.That(azureFuncScoringRule.Credential, Is.Not.Null);

            if (Mode != RecordedTestMode.Playback)
            {
                // any value will be sanitized when recordings are saved
                Assert.That(azureFuncScoringRule.Credential.AppKey, Is.EqualTo("MyAppKey"));
                Assert.That(string.IsNullOrWhiteSpace(azureFuncScoringRule.Credential.FunctionKey), Is.True);
            }

            Assert.That(azureFuncScoringRule.Credential.ClientId, Is.EqualTo("MyClientId"));

            bestWorkerModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                new DistributionPolicy(bestWorkerModeDistributionPolicyId)
                {
                    Mode = new BestWorkerMode
                    {
                        ScoringRule = new FunctionRouterRule(new Uri("https://my.function.app/api/myfunction?code=Kg=="))
                        {
                            Credential = new FunctionRouterRuleCredential("MyKey")
                        },
                        ScoringRuleOptions = new ScoringRuleOptions
                        {
                            ScoringParameters = { ScoringRuleParameterSelector.WorkerSelectors }
                        },
                        MinConcurrentOffers = 1,
                        MaxConcurrentOffers = 2
                    }
                });

            Assert.That(bestWorkerModeDistributionPolicyResponse.Value, Is.Not.Null);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(2));
            Assert.That(bestWorkerModeDistributionPolicy.Mode.BypassSelectors, Is.False);

            paramSelectors = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRuleOptions
                .ScoringParameters;
            Assert.That(paramSelectors.Count, Is.EqualTo(1));
            Assert.That(paramSelectors.First(), Is.EqualTo(ScoringRuleParameterSelector.WorkerSelectors));

            scoringRule = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRule;
            Assert.That(scoringRule, Is.Not.Null);
            azureFuncScoringRule = (FunctionRouterRule)scoringRule;
            Assert.That(azureFuncScoringRule.FunctionUri.ToString(), Is.EqualTo("https://my.function.app/api/myfunction?code=Kg=="));
            Assert.That(azureFuncScoringRule.Credential, Is.Not.Null);

            if (Mode != RecordedTestMode.Playback)
            {
                // any value will be sanitized when recordings are saved
                Assert.That(azureFuncScoringRule.Credential.FunctionKey, Is.EqualTo("MyKey"));
            }
        }

        #endregion best worker mode constructors

        #region longest idle mode constructors

        [Test]
        public async Task CreateDistributionPolicyTest_LongestIdle()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var longestIdleModeDistributionPolicyId = GenerateUniqueId($"{IdPrefix}-Longest-DistributionPolicy");
            var longestIdleModeDistributionPolicyName = $"{longestIdleModeDistributionPolicyId}-Name";

            var longestIdleModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(longestIdleModeDistributionPolicyId, TimeSpan.FromSeconds(1), new LongestIdleMode())
                {
                    Name = longestIdleModeDistributionPolicyName
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(longestIdleModeDistributionPolicyId)));
            Assert.That(longestIdleModeDistributionPolicyResponse.Value, Is.Not.Null);

            var longestIdleModeDistributionPolicy = longestIdleModeDistributionPolicyResponse.Value;
            Assert.That(longestIdleModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(longestIdleModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(1));
            Assert.That(longestIdleModeDistributionPolicy.Mode.BypassSelectors, Is.False);

            // specifying min and max concurrent offers
            longestIdleModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                new DistributionPolicy(longestIdleModeDistributionPolicyId)
                {
                    Mode = new LongestIdleMode
                    {
                        MinConcurrentOffers = 1,
                        MaxConcurrentOffers = 2,
                        BypassSelectors = true
                    },
                });

            Assert.That(longestIdleModeDistributionPolicyResponse.Value, Is.Not.Null);

            longestIdleModeDistributionPolicy = longestIdleModeDistributionPolicyResponse.Value;
            Assert.That(longestIdleModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(longestIdleModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(2));
            Assert.That(longestIdleModeDistributionPolicy.Mode.BypassSelectors, Is.True);
        }

        #endregion longest idle mode constructors

        #region round robin mode constructors

        [Test]
        public async Task CreateDistributionPolicyTest_RoundRobin()
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var roundRobinModeDistributionPolicyId = $"{IdPrefix}-RR-DistributionPolicy";
            var roundRobinModeDistributionPolicyName = $"{roundRobinModeDistributionPolicyId}-Name";

            var roundRobinModeDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(roundRobinModeDistributionPolicyId,
                    TimeSpan.FromSeconds(1),
                    new RoundRobinMode())
                {
                    Name = roundRobinModeDistributionPolicyName
                });

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(roundRobinModeDistributionPolicyId)));
            Assert.That(roundRobinModeDistributionPolicyResponse.Value, Is.Not.Null);

            var roundRobinModeDistributionPolicy = roundRobinModeDistributionPolicyResponse.Value;
            Assert.That(roundRobinModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(roundRobinModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(1));
            Assert.That(roundRobinModeDistributionPolicy.Mode.BypassSelectors, Is.False);

            // specifying min and max concurrent offers
            roundRobinModeDistributionPolicyResponse = await routerClient.UpdateDistributionPolicyAsync(
                new DistributionPolicy(roundRobinModeDistributionPolicyId)
                {
                    Mode = new LongestIdleMode
                    {
                        MinConcurrentOffers = 1,
                        MaxConcurrentOffers = 2,
                        BypassSelectors = true
                    },
                });

            Assert.That(roundRobinModeDistributionPolicyResponse.Value, Is.Not.Null);

            roundRobinModeDistributionPolicy = roundRobinModeDistributionPolicyResponse.Value;
            Assert.That(roundRobinModeDistributionPolicy.Mode.MinConcurrentOffers, Is.EqualTo(1));
            Assert.That(roundRobinModeDistributionPolicy.Mode.MaxConcurrentOffers, Is.EqualTo(2));
            Assert.That(roundRobinModeDistributionPolicy.Mode.BypassSelectors, Is.True);
        }

        #endregion round robin mode constructors

        #endregion Distribution Policy Tests
    }
}
