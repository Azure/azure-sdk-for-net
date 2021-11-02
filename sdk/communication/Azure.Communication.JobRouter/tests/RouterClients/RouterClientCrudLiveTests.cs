// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class RouterClientCrudLiveTests : RouterLiveTestBase
    {
        public RouterClientCrudLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Channel Tests
        [Test]
        public async Task CreateChannelTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = $"{IdPrefix}{nameof(CreateChannelTest)}";
            var createChannelResponse = await routerClient.SetChannelAsync(channelId);

            Assert.AreEqual(channelId, createChannelResponse.Value.Id);
            Assert.AreEqual(createChannelResponse.Value.Id, channelId);
            Assert.IsFalse(createChannelResponse.Value.AcsManaged);

            var channelName = "TestChannelName-ChannelId" + channelId;
            createChannelResponse = await routerClient.SetChannelAsync(channelId, channelName);

            Assert.AreEqual(channelId, createChannelResponse.Value.Id);
            Assert.AreEqual(channelName, createChannelResponse.Value.Name);
            Assert.AreEqual(createChannelResponse.Value.Id, channelId);
            Assert.IsFalse(createChannelResponse.Value.AcsManaged);
            AddForCleanup(new Task(async () => await routerClient.DeleteChannelAsync(createChannelResponse.Value.Id)));
        }

        [Test]
        public async Task GetManagedChannelTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            foreach (var managedChannel in new List<string>(){ ManagedChannels.AcsChatChannel, ManagedChannels.AcsSMSChannel, ManagedChannels.AcsVoiceChannel })
            {
                var getChannelResponse = await routerClient.GetChannelAsync(managedChannel);
                Assert.AreEqual(managedChannel, getChannelResponse.Value.Id);
                Assert.IsTrue(getChannelResponse.Value.AcsManaged);
            }
        }

        [Test]
        public async Task GetChannelTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var createChannelResponse = await CreateChannel(nameof(GetChannelTest));
            var getChannelResponse = await routerClient.GetChannelAsync(createChannelResponse.Value.Id);

            Assert.AreEqual(createChannelResponse.Value.Id, getChannelResponse.Value.Id);
            Assert.AreEqual(createChannelResponse.Value.Name, getChannelResponse.Value.Name);
            Assert.AreEqual(createChannelResponse.Value.AcsManaged, getChannelResponse.Value.AcsManaged);
        }

        [Test]
        public async Task DeleteChannelTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createChannelResponse = await CreateChannelAndValidate(nameof(DeleteChannelTest));
            bool exceptionThrown = false;

            await routerClient.DeleteChannelAsync(createChannelResponse.Value.Id);
            try
            {
                var getChannelResponse = await routerClient.GetChannelAsync(createChannelResponse.Value.Id);
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status, "Channel not found since it has been deleted");
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        [Test]
        public async Task GetChannelsTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createChannelResponse1 = await CreateChannelAndValidate(nameof(GetChannelsTest) + "1");
            var createChannelResponse2 = await CreateChannelAndValidate(nameof(GetChannelsTest) + "2");
            var createChannelResponse3 = await CreateChannelAndValidate(nameof(GetChannelsTest) + "3");

            var managedChannelIds = new List<string>()
            {
                ManagedChannels.AcsChatChannel, ManagedChannels.AcsSMSChannel, ManagedChannels.AcsVoiceChannel
            };
            var customChannelIds = new List<string>() { createChannelResponse1.Value.Id, createChannelResponse2.Value.Id, createChannelResponse3.Value.Id };
            var allChannelIds = new List<string>();
            allChannelIds.AddRange(managedChannelIds);
            allChannelIds.AddRange(customChannelIds);

            var allManagedChannels = routerClient.GetChannelsAsync("ManagedChannels");
            var allManagedChannelIdsRetrieved = new HashSet<string>();
            await foreach (var page in allManagedChannels.AsPages(pageSizeHint: 1))
            {
                // Assert.AreEqual(1, page.Values.Count); // TODO: Uncomment

                foreach (var routerChannel in page.Values)
                {
                    Assert.IsTrue(routerChannel.AcsManaged);
                    allManagedChannelIdsRetrieved.Add(routerChannel.Id);
                }
            }

            var allCustomChannels = routerClient.GetChannelsAsync("CustomChannels");
            var allCustomChannelIdsRetrieved = new HashSet<string>();
            await foreach (var page in allCustomChannels.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, page.Values.Count);

                foreach (var routerChannel in page.Values)
                {
                    Assert.IsFalse(routerChannel.AcsManaged);
                    allCustomChannelIdsRetrieved.Add(routerChannel.Id);
                }
            }

            var allChannels = routerClient.GetChannelsAsync();
            var allChannelIdsRetrieved = new HashSet<string>();
            await foreach (var page in allChannels.AsPages(pageSizeHint: 1))
            {
                // Assert.AreEqual(1, page.Values.Count); // TODO: Uncomment

                foreach (var routerChannel in page.Values)
                {
                    allChannelIdsRetrieved.Add(routerChannel.Id);
                }
            }

            Assert.IsTrue(allManagedChannelIdsRetrieved.IsSupersetOf(managedChannelIds));
            Assert.IsTrue(allCustomChannelIdsRetrieved.IsSupersetOf(customChannelIds));
            // Assert.IsTrue(allChannelIdsRetrieved.IsSupersetOf(allChannelIds)); // TODO: Uncomment
        }

        #endregion Channel Tests

        #region Distribution Policy Tests

        #region best worker mode constructors
        [Test]
        public async Task CreateDistributionPolicyTest_BestWorker_DefaultScoringRule()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // test best worker mode constructors

            // --- default scoring rule
            var bestWorkerModeDistributionPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-Default-DistributionPolicy");
            var bestWorkerModeDistributionPolicyName = $"{bestWorkerModeDistributionPolicyId}-Name";
            var bestWorkerModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1), new BestWorkerMode(),
                bestWorkerModeDistributionPolicyName);

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            var bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            bestWorkerModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1), new BestWorkerMode(bypassSelectors:true, sortDescending:false),
                bestWorkerModeDistributionPolicyName);

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsTrue(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            bestWorkerModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1), new BestWorkerMode(1, 2, true),
                bestWorkerModeDistributionPolicyName);

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
            var bestWorkerModeDistributionPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-Best-DistributionPolicy");
            var bestWorkerModeDistributionPolicyName = $"{bestWorkerModeDistributionPolicyId}-Name";
            // ----- custom scoring rule - with azure function

            var bestWorkerModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1),
                new BestWorkerMode(
                    new AzureFunctionRule("https://my.function.app/api/myfunction?code=Kg==", new AzureFunctionRuleCredential("MyAppKey", "MyClientId")),
                    new List<ScoringRuleParameterSelector>()
                    {
                        ScoringRuleParameterSelector.WorkerLabelsCollection
                    },
                    minConcurrentOffers:1, maxConcurrentOffers:2),
                bestWorkerModeDistributionPolicyName);

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            var bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            var paramSelectors = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRuleOptions
                .ScoringParameters;
            Assert.AreEqual(1, paramSelectors.Count);
            Assert.AreEqual(ScoringRuleParameterSelector.WorkerLabelsCollection, paramSelectors.First());

            var scoringRule = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRule;
            Assert.NotNull(scoringRule);
            var azureFuncScoringRule = (AzureFunctionRule)scoringRule;
            Assert.AreEqual("https://my.function.app/api/myfunction?code=Kg==", azureFuncScoringRule.FunctionAppUrl);
            Assert.IsNotNull(azureFuncScoringRule.Credential);

            if (Mode != RecordedTestMode.Playback)
            {
                // any value will be sanitized when recordings are saved
                Assert.AreEqual("MyAppKey", azureFuncScoringRule.Credential.AppKey);
                Assert.IsTrue(string.IsNullOrWhiteSpace(azureFuncScoringRule.Credential.FunctionKey));
            }

            Assert.AreEqual("MyClientId", azureFuncScoringRule.Credential.ClientId);

            bestWorkerModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                bestWorkerModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1),
                new BestWorkerMode(
                    new AzureFunctionRule("https://my.function.app/api/myfunction?code=Kg==", new AzureFunctionRuleCredential("MyKey")),
                    new List<ScoringRuleParameterSelector>()
                    {
                        ScoringRuleParameterSelector.WorkerLabelsCollection
                    },
                    minConcurrentOffers: 1, maxConcurrentOffers: 2),
                bestWorkerModeDistributionPolicyName);

            Assert.NotNull(bestWorkerModeDistributionPolicyResponse.Value);

            bestWorkerModeDistributionPolicy = bestWorkerModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, bestWorkerModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, bestWorkerModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(bestWorkerModeDistributionPolicy.Mode.BypassSelectors);

            paramSelectors = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRuleOptions
                .ScoringParameters;
            Assert.AreEqual(1, paramSelectors.Count);
            Assert.AreEqual(ScoringRuleParameterSelector.WorkerLabelsCollection, paramSelectors.First());

            scoringRule = ((BestWorkerMode)bestWorkerModeDistributionPolicy.Mode).ScoringRule;
            Assert.NotNull(scoringRule);
            azureFuncScoringRule = (AzureFunctionRule)scoringRule;
            Assert.AreEqual("https://my.function.app/api/myfunction?code=Kg==", azureFuncScoringRule.FunctionAppUrl);
            Assert.IsNotNull(azureFuncScoringRule.Credential);

            if (Mode != RecordedTestMode.Playback)
            {
                // any value will be sanitized when recordings are saved
                Assert.AreEqual("MyKey", azureFuncScoringRule.Credential.FunctionKey);
                Assert.IsTrue(string.IsNullOrWhiteSpace(azureFuncScoringRule.Credential.AppKey) && string.IsNullOrWhiteSpace(azureFuncScoringRule.Credential.ClientId));
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
            var longestIdleModeDistributionPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-Longest-DistributionPolicy");
            var longestIdleModeDistributionPolicyName = $"{longestIdleModeDistributionPolicyId}-Name";

            var longestIdleModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                longestIdleModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1),
                new LongestIdleMode(),
                longestIdleModeDistributionPolicyName);

            Assert.NotNull(longestIdleModeDistributionPolicyResponse.Value);

            var longestIdleModeDistributionPolicy = longestIdleModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, longestIdleModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, longestIdleModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(longestIdleModeDistributionPolicy.Mode.BypassSelectors);

            // specifying min and max concurrent offers
            longestIdleModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                longestIdleModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1),
                new LongestIdleMode(1,2, true),
                longestIdleModeDistributionPolicyName);

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

            var roundRobinModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                roundRobinModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1),
                new RoundRobinMode(),
                roundRobinModeDistributionPolicyName);

            Assert.NotNull(roundRobinModeDistributionPolicyResponse.Value);

            var roundRobinModeDistributionPolicy = roundRobinModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, roundRobinModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(1, roundRobinModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsFalse(roundRobinModeDistributionPolicy.Mode.BypassSelectors);

            // specifying min and max concurrent offers
            roundRobinModeDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(
                roundRobinModeDistributionPolicyId,
                TimeSpan.FromMilliseconds(1),
                new LongestIdleMode(1, 2, true),
                roundRobinModeDistributionPolicyName);

            Assert.NotNull(roundRobinModeDistributionPolicyResponse.Value);

            roundRobinModeDistributionPolicy = roundRobinModeDistributionPolicyResponse.Value;
            Assert.AreEqual(1, roundRobinModeDistributionPolicy.Mode.MinConcurrentOffers);
            Assert.AreEqual(2, roundRobinModeDistributionPolicy.Mode.MaxConcurrentOffers);
            Assert.IsTrue(roundRobinModeDistributionPolicy.Mode.BypassSelectors);

            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(roundRobinModeDistributionPolicyId)));
        }

        #endregion round robin mode constructors

        #endregion Distribution Policy Tests

        #region Classification Policy Tests
        [Test]
        public async Task CreateClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createQueueResponse = await CreateQueueAsync(nameof(CreateClassificationPolicyTest));

            var classificationPolicyId = ReduceToFiftyCharacters($"{IdPrefix}{nameof(CreateClassificationPolicyTest)}");
            var queueSelector = new QueueIdSelector(new StaticRule(createQueueResponse.Value.Id));
            var workerSelectors = new List<LabelSelectorAttachment>()
            {
                new StaticLabelSelector(new LabelSelector("key", LabelOperator.Equal, "value"))
            };
            var prioritizationRule = new StaticRule(1);

            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(
                classificationPolicyId,
                queueSelector: queueSelector,
                workerSelectors: workerSelectors,
                prioritizationRule: prioritizationRule);

            Assert.NotNull(createClassificationPolicyResponse.Value);

            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelector = (QueueIdSelector)createClassificationPolicy.QueueSelector;
                Assert.IsTrue(queueSelector.Rule.GetType() == typeof(StaticRule));
                var staticValue = queueSelector.Rule as StaticRule;
                Assert.AreEqual(createQueueResponse.Value.Id, (string)staticValue!.Value);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectors.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = (StaticLabelSelector)createClassificationPolicy.WorkerSelectors.First();
                Assert.AreEqual("key", workerSelectors.LabelSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, workerSelectors.LabelSelector.Operator);
                Assert.AreEqual("value", workerSelectors.LabelSelector.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId));
            Assert.IsTrue(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            var classificationPolicyName = $"{classificationPolicyId}-Name";

            createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(
                classificationPolicyId,
                fallbackQueueId: createQueueResponse.Value.Id,
                queueSelector: queueSelector,
                workerSelectors: workerSelectors,
                prioritizationRule: prioritizationRule,
                name: classificationPolicyName);

            Assert.NotNull(createClassificationPolicyResponse.Value);

            createClassificationPolicy = createClassificationPolicyResponse.Value;
            Assert.DoesNotThrow(() =>
            {
                var queueSelector = (QueueIdSelector)createClassificationPolicy.QueueSelector;
                Assert.IsTrue(queueSelector.Rule.GetType() == typeof(StaticRule));
                var staticValue = queueSelector.Rule as StaticRule;
                Assert.AreEqual(createQueueResponse.Value.Id, (string)staticValue!.Value);
            });
            Assert.AreEqual(1, createClassificationPolicy.WorkerSelectors.Count);
            Assert.DoesNotThrow(() =>
            {
                var workerSelectors = (StaticLabelSelector)createClassificationPolicy.WorkerSelectors.First();
                Assert.AreEqual("key", workerSelectors.LabelSelector.Key);
                Assert.AreEqual(LabelOperator.Equal, workerSelectors.LabelSelector.Operator);
                Assert.AreEqual("value", workerSelectors.LabelSelector.Value);
            });
            Assert.IsTrue(createClassificationPolicy.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(createClassificationPolicy.FallbackQueueId) && createClassificationPolicy.FallbackQueueId == createQueueResponse.Value.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createClassificationPolicy.Name));

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateEmptyClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var queue = CreateQueueAsync(nameof(CreateEmptyClassificationPolicyTest));

            var classificationPolicyId = $"{IdPrefix}-CPEmpty";
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId);
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.Null(getClassificationPolicyResponse.Value.Name);
            Assert.Null(getClassificationPolicyResponse.Value.QueueSelector);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreatePrioritizationClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPPri";
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var priorityRule = new StaticRule(10);
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, null, null, priorityRule);
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.Null(getClassificationPolicyResponse.Value.QueueSelector);
            Assert.IsTrue(getClassificationPolicyResponse.Value.PrioritizationRule.GetType() == typeof(StaticRule));
            Assert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateQueueSelectionClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPQS";
            var classificationPolicyName = $"QueueSelection-ClassificationPolicy";
            var createQueueResponse = await CreateQueueAsync(nameof(CreateQueueSelectionClassificationPolicyTest));
            var queueIdStaticRule = new StaticRule(createQueueResponse.Value.Id);
            var queueSelectionRule = new QueueIdSelector(queueIdStaticRule);
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, queueSelectionRule);
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.IsTrue(getClassificationPolicyResponse.Value.QueueSelector.GetType() == typeof(QueueIdSelector));
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.AreEqual(0, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        [Test]
        public async Task CreateWorkerRequirementsClassificationPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = $"{IdPrefix}-CPWR";
            var classificationPolicyName = $"Priority-ClassificationPolicy";
            var workerSelectors = new List<LabelSelectorAttachment>();
            var labelSelectorAttachment = new StaticLabelSelector(new LabelSelector("department", LabelOperator.Equal, "sales"));
            workerSelectors.Add(labelSelectorAttachment);
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, null, workerSelectors);
            var getClassificationPolicyResponse =
                await routerClient.GetClassificationPolicyAsync(classificationPolicyId);

            Assert.Null(getClassificationPolicyResponse.Value.FallbackQueueId);
            Assert.AreEqual(classificationPolicyName, getClassificationPolicyResponse.Value.Name);
            Assert.Null(getClassificationPolicyResponse.Value.PrioritizationRule);
            Assert.Null(getClassificationPolicyResponse.Value.QueueSelector);
            Assert.AreEqual(1, getClassificationPolicyResponse.Value.WorkerSelectors.Count);

            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
        }

        #endregion Classification Policy Tests

        #region Exception Policy Tests

        [Test]
        public async Task CreateExceptionPolicyTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var exceptionPolicyId = ReduceToFiftyCharacters($"{IdPrefix}{nameof(CreateExceptionPolicyTest)}");

            var createExceptionPolicyResponse = await routerClient.SetExceptionPolicyAsync(exceptionPolicyId);

            Assert.NotNull(createExceptionPolicyResponse.Value);

            var exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);

            // with name
            var exceptionPolicyName = $"{exceptionPolicyId}-ExceptionPolicyName";
            createExceptionPolicyResponse = await routerClient.SetExceptionPolicyAsync(exceptionPolicyId, exceptionPolicyName);

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.AreEqual(exceptionPolicyName, exceptionPolicy.Name);

            var exceptionRuleId = ReduceToFiftyCharacters($"{IdPrefix}-ExceptionRule");
            var cancelActionId = ReduceToFiftyCharacters($"{IdPrefix}-CancellationExceptionAction");

            // with rules
            var rules = new List<ExceptionRule>()
            {
                new ExceptionRule(exceptionRuleId,
                    new QueueLengthExceptionTrigger(1),
                    new List<ExceptionAction>()
                    {
                        new CancelExceptionAction(cancelActionId)
                        {
                            DispositionCode = "CancelledDueToMaxQueueLengthReached"
                        }
                    }
                )
            };
            createExceptionPolicyResponse = await routerClient.SetExceptionPolicyAsync(exceptionPolicyId, rules: rules);

            Assert.NotNull(createExceptionPolicyResponse.Value);

            exceptionPolicy = createExceptionPolicyResponse.Value;

            Assert.AreEqual(exceptionPolicyId, exceptionPolicy.Id);
            Assert.DoesNotThrow(() =>
            {
                var exceptionRule = exceptionPolicy.ExceptionRules.First();

                Assert.AreEqual(exceptionRuleId, exceptionRule.Id);
                Assert.IsTrue(exceptionRule.Trigger.GetType() == typeof(QueueLengthExceptionTrigger));
                var trigger = exceptionRule.Trigger as QueueLengthExceptionTrigger;
                Assert.NotNull(trigger);
                Assert.AreEqual(1, trigger!.Threshold);

                var actions = exceptionRule.Actions;
                Assert.AreEqual(1, actions.Count);
                var cancelAction = actions.FirstOrDefault() as CancelExceptionAction;
                Assert.NotNull(cancelAction);
                Assert.AreEqual(cancelActionId, cancelAction!.Id);
                Assert.AreEqual($"CancelledDueToMaxQueueLengthReached", cancelAction!.DispositionCode);
            });

            AddForCleanup(new Task(async () => await routerClient.DeleteExceptionPolicyAsync(exceptionPolicyId)));
        }

        #endregion Exception Policy Tests

        #region Queue Tests
        [Test]
        public async Task CreateQueueTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(nameof(CreateQueueTest));
            var queue = await CreateQueueAsync(nameof(CreateQueueTest));
            var queueName = "DefaultQueue" + queue.Value.Id;
            var createQueueResponse = await routerClient.SetQueueAsync(queue.Value.Id,
                createDistributionPolicyResponse.Value.Id);
            AssertQueueResponseIsEqual(createQueueResponse, queue.Value.Id, createDistributionPolicyResponse.Value.Id);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));

            var queueId = queue.Value.Id + "2";
            queueName = "DefaultQueueWithLabels" + queueId;
            var queueLabels = new LabelCollection() { ["Label_1"] = "Value_1" };
            createQueueResponse = await routerClient.SetQueueAsync(queueId,
                createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
        }

        #endregion Queue Tests

        #region Worker Tests
        [Test]
        public async Task CreateWorkerTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateWorkerTest));

            // Register worker
            var workerId = $"{IdPrefix}{nameof(CreateWorkerTest)}";
            var totalCapacity = 100;

            var channelConfig1 = new ChannelConfiguration("ACS_Chat_Channel", 20);

            var channelConfigList = new List<ChannelConfiguration>(){channelConfig1};
            var workerLabels = new LabelCollection()
            {
                ["test_label_1"] = "testLabel",
                ["test_label_2"] = 12,
            };

            var queueAssignmentList = new string[]{ createQueueResponse.Value.Id };

            var routerWorkerResponse = await routerClient.RegisterWorkerAsync(workerId, totalCapacity, queueAssignmentList, workerLabels, channelConfigList);

            Assert.NotNull(routerWorkerResponse.Value);
            AssertRegisteredWorkerIsValid(routerWorkerResponse, workerId, queueAssignmentList,
                totalCapacity, workerLabels, channelConfigList);

            AddForCleanup(new Task(async () => await routerClient.DeregisterWorkerAsync(routerWorkerResponse.Value.Id)));
        }

        [Test]
        public async Task RegisterWorkerShouldNotThrowArgumentNullExceptionTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            // Register worker with only id and total capacity
            var workerId = $"{IdPrefix}-WorkerIDRegisterWorker";

            var totalCapacity = 100;
            var routerWorkerResponse = await routerClient.RegisterWorkerAsync(workerId, totalCapacity);

            Assert.NotNull(routerWorkerResponse.Value);

            AddForCleanup(new Task(async () => await routerClient.DeregisterWorkerAsync(routerWorkerResponse.Value.Id)));
        }

        [Test]
        public async Task GetWorkersTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup channel 1 - given per job cost of 1
            var createChannel1Response = await CreateChannel($"Ch1{nameof(GetWorkersTest)}");
            var createChannel1 = createChannel1Response.Value;

            // Setup channel 2 - given per job cost of 10
            var createChannel2Response = await CreateChannel($"Ch2{nameof(GetWorkersTest)}");
            var createChannel2 = createChannel2Response.Value;

            // Setup queue 1
            var createQueue1Response = await CreateQueueAsync($"Q1{nameof(GetWorkersTest)}");
            var createQueue1 = createQueue1Response.Value;

            // Setup queue 2
            var createQueue2Response = await CreateQueueAsync($"Q2{nameof(GetWorkersTest)}");
            var createQueue2 = createQueue2Response.Value;

            // Setup workers
            var workerId1 = ReduceToFiftyCharacters($"{IdPrefix}GetWorkersTest_1");
            var workerId2 = ReduceToFiftyCharacters($"{IdPrefix}GetWorkersTest_2");
            var workerId3 = ReduceToFiftyCharacters($"{IdPrefix}GetWorkersTest_3");
            var workerId4 = ReduceToFiftyCharacters($"{IdPrefix}GetWorkersTest_4");

            var expectedWorkerIds = new List<string>() {workerId1, workerId2, workerId3, workerId4};

            var registerWorker1Response = await routerClient.RegisterWorkerAsync(
                workerId1,
                10,
                queueIds: new List<string>()
                {
                    createQueue1.Id
                },
                channelConfigurations: new List<ChannelConfiguration>()
                {
                    new ChannelConfiguration(createChannel1.Id, 1),
                    new ChannelConfiguration(createChannel2.Id, 10)
                });
            var registerWorker1 = registerWorker1Response.Value;

            var registerWorker2Response = await routerClient.RegisterWorkerAsync(
                workerId2,
                10,
                queueIds: new List<string>()
                {
                    createQueue2.Id
                },
                channelConfigurations: new List<ChannelConfiguration>()
                {
                    new ChannelConfiguration(createChannel1.Id, 1),
                    new ChannelConfiguration(createChannel2.Id, 10)
                });
            var registerWorker2 = registerWorker2Response.Value;

            var registerWorker3Response = await routerClient.RegisterWorkerAsync(
                workerId3,
                10,
                queueIds: new List<string>()
                {
                    createQueue1.Id, createQueue2.Id
                },
                channelConfigurations: new List<ChannelConfiguration>()
                {
                    new ChannelConfiguration(createChannel1.Id, 1),
                    new ChannelConfiguration(createChannel2.Id, 10)
                });
            var registerWorker3 = registerWorker3Response.Value;

            var registerWorker4Response = await routerClient.RegisterWorkerAsync(
                workerId4,
                10,
                queueIds: new List<string>()
                {
                    createQueue1.Id
                },
                channelConfigurations: new List<ChannelConfiguration>()
                {
                    new ChannelConfiguration(createChannel1.Id, 1)
                });
            var registerWorker4 = registerWorker4Response.Value;

            // Query all workers with channel filter
            var channel2Workers = new HashSet<string>() {workerId1, workerId2, workerId3};
            var getWorkersResponse = routerClient.GetWorkersAsync(channelId: createChannel2.Id);
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    Assert.IsTrue(channel2Workers.Contains(worker.Id));
                }
            }

            // Query all workers with queue filter
            var queue2Workers = new HashSet<string>() { workerId2, workerId3 };
            getWorkersResponse = routerClient.GetWorkersAsync(queueId: createQueue2.Id);
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    Assert.IsTrue(queue2Workers.Contains(worker.Id));
                }
            }

            // Query all workers with channel + hasCapacity filter
            var channel1Workers = new HashSet<string>() { workerId1, workerId2, workerId3, workerId4 }; // no worker is expected to get any job
            getWorkersResponse = routerClient.GetWorkersAsync(channelId: createChannel1.Id, hasCapacity:true);
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    Assert.IsTrue(channel1Workers.Contains(worker.Id));
                }
            }

            // Deregister worker1
            await routerClient.DeregisterWorkerAsync(workerId1);

            var checkWorker1Status = await Poll(async () => await routerClient.GetWorkerAsync(workerId1),
                w => w.Value.State == WorkerState.Inactive, TimeSpan.FromSeconds(10));

            Assert.AreEqual(WorkerState.Inactive, checkWorker1Status.Value.State);

            // Query all workers with status: active
            var activeWorkers = new HashSet<string>();
            getWorkersResponse = routerClient.GetWorkersAsync(status: WorkerStateSelector.Active, channelId: createChannel1.Id);
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    activeWorkers.Add(worker.Id);
                }
            }

            Assert.IsTrue(activeWorkers.Contains(workerId2));
            Assert.IsTrue(activeWorkers.Contains(workerId3));
            Assert.IsTrue(activeWorkers.Contains(workerId4));

            // Query all workers with status: inactive
            var inactiveWorkers = new HashSet<string>();
            getWorkersResponse = routerClient.GetWorkersAsync(status: WorkerStateSelector.Inactive, channelId: createChannel1.Id);
            await foreach (var workerPage in getWorkersResponse.AsPages(pageSizeHint: 1))
            {
                Assert.AreEqual(1, workerPage.Values.Count);
                foreach (var worker in workerPage.Values)
                {
                    inactiveWorkers.Add(worker.Id);
                }
            }
            Assert.IsTrue(inactiveWorkers.Contains(workerId1));

            // in-test cleanup workers before deleting queue and channel
            await routerClient.DeregisterWorkerAsync(expectedWorkerIds[0]);
            await routerClient.DeregisterWorkerAsync(expectedWorkerIds[1]);
            await routerClient.DeregisterWorkerAsync(expectedWorkerIds[2]);
            await routerClient.DeregisterWorkerAsync(expectedWorkerIds[3]);
        }
        #endregion Worker Tests

        #region Job Tests

        [Test]
        public async Task GetJobsTest()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            // Setup channel
            var createChannelResponse = await CreateChannel(nameof(GetJobsTest));
            var createChannel = createChannelResponse.Value;

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(GetJobsTest));
            var createQueue = createQueueResponse.Value;

            // Create 2 jobs - Both should be in Queued state
            var createJob1Response = await routerClient.CreateJobAsync(createChannel.Id, createQueue.Id, 1);
            var createJob1 = createJob1Response.Value;

            // wait for job1 to be in queued state
            var job1Result = await Poll(async () => await routerClient.GetJobAsync(createJob1.Id),
                job => job.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, job1Result.Value.JobStatus);

            // cancel job 1
            var cancelJob1Response = await routerClient.CancelJobAsync(createJob1.Id);

            // Create job 2
            var createJob2Response = await routerClient.CreateJobAsync(createChannel.Id, createQueue.Id, 1);
            var createJob2 = createJob2Response.Value;

            var job2Result = await Poll(async () => await routerClient.GetJobAsync(createJob2.Id),
                job => job.Value.JobStatus == JobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, job2Result.Value.JobStatus);

            // test get all jobs
            var getJobsResponse = routerClient.GetJobsAsync();
            var allJobs = new List<string>();
            // TODO: it is not sustainable to get all jobs everytime, we need to bulkhead them.
            await foreach (var jobPage in getJobsResponse.AsPages(pageSizeHint: 100))
            {
                foreach (var job in jobPage.Values)
                {
                    allJobs.Add(job.Id);
                }
            }

            Assert.IsTrue(allJobs.Contains(createJob1.Id));
            Assert.IsTrue(allJobs.Contains(createJob2.Id));

            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(createJob1.Id)));
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(createJob2.Id)));
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_StaticPriority()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // Setup channel
            var createChannelResponse = await CreateChannel($"CP_StaticPriority");
            var createChannel = createChannelResponse.Value;

            // Setup queue - to specify on job
            var createQueueResponse = await CreateQueueAsync($"Q1_CP_StaticPriority");
            var createQueue = createQueueResponse.Value;

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_StaticPriority");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policies
            var classificationPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-CP_StaticPriority");
            var classificationPolicyName = $"StaticPriority-ClassificationPolicy";
            var priorityRule = new StaticRule(10);
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, prioritizationRule: priorityRule, fallbackQueueId: createQueue2.Id);
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(createChannel.Id, createClassificationPolicy.Id, channelReference: "123", queueId: createQueue.Id);
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(10, queuedJob.Value.Priority); // from classification policy
            Assert.AreEqual(createQueue.Id, queuedJob.Value.QueueId); // from direct queue assignment

            // in-test cleanup
            await routerClient.CancelJobAsync(createJob.Id); // other wise queue deletion will throw error
            await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_StaticQueueSelector()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // Setup channel
            var createChannelResponse = await CreateChannel($"CP_StaticQueue");
            var createChannel = createChannelResponse.Value;

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_StaticQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-CP_StaticQueue");
            var classificationPolicyName = $"StaticQueueSelector-ClassificationPolicy";
            var staticQueueSelector = new QueueIdSelector(new StaticRule(createQueue2.Id));
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, queueSelector: staticQueueSelector);
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(createChannel.Id, createClassificationPolicy.Id, channelReference: "123");
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(createJob.Id); // other wise queue deletion will throw error
            await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_FallbackQueue()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // Setup channel
            var createChannelResponse = await CreateChannel($"CP_FallbackQueue");
            var createChannel = createChannelResponse.Value;

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_FallbackQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-CP_FallbackQueue");
            var classificationPolicyName = $"FallbackQueue-ClassificationPolicy";
            var staticQueueSelector = new QueueIdSelector(new StaticRule(createQueue2.Id));
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, fallbackQueueId: createQueue2.Id);
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(createChannel.Id, createClassificationPolicy.Id, channelReference: "123");
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(createJob.Id); // other wise queue deletion will throw error
            await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue()
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            // Setup channel
            var createChannelResponse = await CreateChannel($"CP_JobQVsFallbackQ");
            var createChannel = createChannelResponse.Value;

            // Setup queue - to specify on classification default queue id
            var createQueue1Response = await CreateQueueAsync($"Q1_CP_JobQVsFallbackQ");
            var createQueue1 = createQueue1Response.Value;
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_JobQVsFallbackQ");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = ReduceToFiftyCharacters($"{IdPrefix}-CP_JobQVsFallbackQ");
            var classificationPolicyName = $"JobQVsFallbackQ-ClassificationPolicy";
            var staticQueueSelector = new QueueIdSelector(new StaticRule(createQueue2.Id));
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, fallbackQueueId: createQueue2.Id);
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue1 specified - should override default queue of classification policy
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(createChannel.Id, createClassificationPolicy.Id, channelReference: "123", queueId: createQueue1.Id);
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.JobStatus == JobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(JobStatus.Queued, queuedJob.Value.JobStatus);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue1.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(createJob.Id); // other wise queue deletion will throw error
            await routerClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        #endregion Job Tests

        #region CRUD Helpers

        protected async Task<Response<UpsertClassificationPolicyResponse>> CreateQueueSelectionCPAsync(string? uniqueIdentifier = default)
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();

            var classificationPolicyId = ReduceToFiftyCharacters($"{IdPrefix}{uniqueIdentifier}");
            var classificationPolicyName = $"QueueSelection-ClassificationPolicy";
            var createQueueResponse = await CreateQueueAsync(nameof(CreateQueueSelectionCPAsync));
            var queueIdStaticRule = new StaticRule(createQueueResponse.Value.Id);
            var queueSelectionRule = new QueueIdSelector(queueIdStaticRule);
            var createClassificationPolicyResponse = await routerClient.SetClassificationPolicyAsync(classificationPolicyId, classificationPolicyName, queueSelectionRule, null, null, createQueueResponse.Value.Id);
            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(createClassificationPolicyResponse.Value.Id)));

            return createClassificationPolicyResponse;
        }

        protected async Task<Response<UpsertQueueResponse>> CreateQueueAsync(string? uniqueIdentifier = default)
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(uniqueIdentifier);
            var queueId = ReduceToFiftyCharacters($"{IdPrefix}{uniqueIdentifier}");
            var queueName = "DefaultQueue-Sdk-Test" + queueId;
            var queueLabels = new LabelCollection() { ["Label_1"] = "Value_1" };
            var createQueueResponse = await routerClient.SetQueueAsync(queueId,
                createDistributionPolicyResponse.Value.Id, queueName, queueLabels);

            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
            return createQueueResponse;
        }

        protected async Task<Response<UpsertDistributionPolicyResponse>> CreateDistributionPolicy(string? uniqueIdentifier = default)
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var distributionId = ReduceToFiftyCharacters($"{IdPrefix}{uniqueIdentifier}");
            var distributionPolicyName = "LongestIdleDistributionPolicy" + distributionId;
            var createDistributionPolicyResponse = await routerClient.SetDistributionPolicyAsync(distributionId,
                TimeSpan.FromSeconds(30),
                new LongestIdleMode(1, 1), distributionPolicyName);

            Assert.AreEqual(distributionId, createDistributionPolicyResponse.Value.Id);
            Assert.AreEqual(distributionPolicyName, createDistributionPolicyResponse.Value.Name);
            Assert.IsNotNull(createDistributionPolicyResponse.Value.Mode);
            Assert.IsTrue(createDistributionPolicyResponse.Value.Mode.GetType() == typeof(LongestIdleMode));
            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(createDistributionPolicyResponse.Value.Id)));
            return createDistributionPolicyResponse;
        }

        protected async Task<Response<UpsertChannelResponse>> CreateChannel(string? uniqueIdentifier = default)
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = ReduceToFiftyCharacters($"{IdPrefix}{uniqueIdentifier}");
            var channelName = "TestChannelName-ChannelId";
            var createChannelResponse = await routerClient.SetChannelAsync(channelId, channelName);

            Assert.AreEqual(channelId, createChannelResponse.Value.Id);
            Assert.AreEqual(channelName, createChannelResponse.Value.Name);
            Assert.IsFalse(createChannelResponse.Value.AcsManaged);
            AddForCleanup(new Task(async () => await routerClient.DeleteChannelAsync(createChannelResponse.Value.Id)));

            return createChannelResponse;
        }

        protected async Task<Response<UpsertChannelResponse>> CreateChannelAndValidate(string? uniqueIdentifier = default)
        {
            RouterClient routerClient = CreateRouterClientWithConnectionString();
            var createChannelResponse = await CreateChannel(uniqueIdentifier);
            var getChannelResponse = await routerClient.GetChannelAsync(createChannelResponse.Value.Id);

            Assert.AreEqual(createChannelResponse.Value.Id, getChannelResponse.Value.Id);
            Assert.AreEqual(createChannelResponse.Value.Name, getChannelResponse.Value.Name);
            Assert.AreEqual(createChannelResponse.Value.AcsManaged, getChannelResponse.Value.AcsManaged);

            return createChannelResponse;
        }

        #endregion CRUD Helpers

    }
}
