// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Moq;
using Rl.Net;

namespace Azure.AI.Personalizer.Tests
{
    public abstract class PersonalizerTestBase : RecordedTestBase<PersonalizerTestEnvironment>
    {
        public static bool IsTestTenant = false;

        internal class ActionProbabilityWrapperForTest : ActionProbabilityWrapper
        {
            private readonly long index;
            private readonly float prob;

            public override long ActionIndex { get { return this.index; } }

            public override float Probability { get { return this.prob; } }

            internal ActionProbabilityWrapperForTest(long index, float prob) : base()
            {
                this.index = index;
                this.prob = prob;
            }
        }
        internal class SlotRankingWrapperForTest : SlotRankingWrapper
        {
            private IEnumerable<ActionProbabilityWrapper> ranking;
            private readonly long actionIndex;
            private readonly string slotId;

            public override long ChosenAction { get { return this.actionIndex; } }

            public override string SlotId { get { return this.slotId; } }

            internal SlotRankingWrapperForTest(long actionIndex, string slotId, IEnumerable<ActionProbabilityWrapper> ranked) : base()
            {
                this.actionIndex = actionIndex;
                this.slotId = slotId;
                this.ranking = ranked;
            }

            public override IEnumerator<ActionProbabilityWrapper> GetEnumerator()
            {
                return ranking.GetEnumerator();
            }
        }

        internal class RankingResponseWrapperForTest : RankingResponseWrapper
        {
            private IEnumerable<ActionProbabilityWrapper> rank;

            public RankingResponseWrapperForTest(IEnumerable<ActionProbabilityWrapper> ranked) : base()
            {
                rank = ranked;
            }

            public override IEnumerator<ActionProbabilityWrapper> GetEnumerator()
            {
                return rank.GetEnumerator();
            }
        }

        internal class MultiSlotResponseWrapperForTest : MultiSlotResponseDetailedWrapper
        {
            private IEnumerable<SlotRankingWrapper> slotRank;

            public MultiSlotResponseWrapperForTest(IEnumerable<SlotRankingWrapper> rankedSlot) : base()
            {
                slotRank = rankedSlot;
            }

            public override IEnumerator<SlotRankingWrapper> GetEnumerator()
            {
                return slotRank.GetEnumerator();
            }
        }

        public PersonalizerTestBase(bool isAsync) : base(isAsync)
        {
            // TODO: Compare bodies again when https://github.com/Azure/azure-sdk-for-net/issues/22219 is resolved.
            Matcher = new RecordMatcher(compareBodies: false);
            Sanitizer = new PersonalizerRecordedTestSanitizer();
        }

        protected async Task<PersonalizerClient> GetPersonalizerClientAsync(bool isSingleSlot = false, bool useLocalInference = false, float subsampleRate = 1.0f)
        {
            string endpoint = isSingleSlot ? TestEnvironment.SingleSlotEndpoint : TestEnvironment.MultiSlotEndpoint;
            string apiKey = isSingleSlot ? TestEnvironment.SingleSlotApiKey : TestEnvironment.MultiSlotApiKey;
            PersonalizerAdministrationClient adminClient = GetAdministrationClient(isSingleSlot);
            if (!isSingleSlot)
            {
                await EnableMultiSlot(adminClient);
            }
            var credential = new AzureKeyCredential(apiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions(useLocalInference: useLocalInference, subsampleRate: subsampleRate));
            PersonalizerClient personalizerClient = null;
            if (useLocalInference)
            {
                if (Mode == RecordedTestMode.Playback)
                {
                    RlNetProcessor rlNetProcessor = SetupRlNetProcessor();

                    personalizerClient = new PersonalizerClientForTest(new Uri(endpoint), credential, true, rlNetProcessor, options: options, subsampleRate: subsampleRate);
                }
                else
                {
                    personalizerClient = new PersonalizerClient(new Uri(endpoint), credential, options: options);
                }
            }
            else
            {
                personalizerClient = new PersonalizerClient(new Uri(endpoint), credential, options);
            }

            personalizerClient = InstrumentClient(personalizerClient);
            return personalizerClient;
        }

        protected PersonalizerAdministrationClient GetAdministrationClient(bool isSingleSlot = false)
        {
            string endpoint = isSingleSlot ? TestEnvironment.SingleSlotEndpoint : TestEnvironment.MultiSlotEndpoint;
            string apiKey = isSingleSlot ? TestEnvironment.SingleSlotApiKey : TestEnvironment.MultiSlotApiKey;
            var credential = new AzureKeyCredential(apiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerAdministrationClient personalizerAdministrationClient = new PersonalizerAdministrationClient(new Uri(endpoint), credential, options);
            personalizerAdministrationClient = InstrumentClient(personalizerAdministrationClient);
            return personalizerAdministrationClient;
        }

        private async Task EnableMultiSlot(PersonalizerAdministrationClient adminClient)
        {
            PersonalizerServiceProperties properties = await adminClient.GetPersonalizerPropertiesAsync();
            properties.IsAutoOptimizationEnabled = false;
            await adminClient.UpdatePersonalizerPropertiesAsync(properties);
            await Delay(30000);
            await adminClient.UpdatePersonalizerPolicyAsync(new PersonalizerPolicy("multiSlot", "--ccb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::"));
            //sleep 30 seconds to allow settings to propagate
            await Delay(30000);
        }

        private RlNetProcessor SetupRlNetProcessor()
        {
            Mock<LiveModelBase> mockLiveModel = new Mock<LiveModelBase>();

            List<ActionProbabilityWrapper> actionProbability = new List<ActionProbabilityWrapper>
                    {
                        new ActionProbabilityWrapperForTest(0, 1f)
                    };

            RankingResponseWrapper responseWrapper = new RankingResponseWrapperForTest(actionProbability);
            mockLiveModel.Setup(m => m.ChooseRank(It.IsAny<string>(), It.IsAny<string>(), ActionFlags.Default)).Returns(responseWrapper);

            Dictionary<string, List<ActionProbabilityWrapper>> slotRankedActions = GetSlotActionProbabilityList();
            List<SlotRankingWrapper> rankedSlots = new List<SlotRankingWrapper>();

            foreach (var item in slotRankedActions)
            {
                var slotRankingWrapperForTest = new SlotRankingWrapperForTest(item.Value.FirstOrDefault().ActionIndex, item.Key, item.Value);
                rankedSlots.Add(slotRankingWrapperForTest);
            }

            MultiSlotResponseDetailedWrapper multiSlotResponseWrapper = new MultiSlotResponseWrapperForTest(rankedSlots);

            mockLiveModel.Setup(m => m.RequestMultiSlotDecisionDetailed(It.IsAny<string>(), It.IsAny<string>(), ActionFlags.Default, It.IsAny<int[]>())).Returns(multiSlotResponseWrapper);
            mockLiveModel.Setup(m => m.QueueOutcomeEvent(It.IsAny<string>(), It.IsAny<float>())).Verifiable();
            mockLiveModel.Setup(m => m.QueueOutcomeEvent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<float>())).Verifiable();
            mockLiveModel.Setup(m => m.QueueActionTakenEvent(It.IsAny<string>())).Verifiable();

            return new RlNetProcessor(mockLiveModel.Object);
        }

        private Dictionary<string, List<ActionProbabilityWrapper>> GetSlotActionProbabilityList()
        {
            Dictionary<string, List<ActionProbabilityWrapper>> dict = new Dictionary<string, List<ActionProbabilityWrapper>>();

            List<ActionProbabilityWrapper> slot1list = new List<ActionProbabilityWrapper>
            {
                new ActionProbabilityWrapperForTest(0, 1f)
            };
            dict.Add("Main Article", slot1list);

            List<ActionProbabilityWrapper> slot2list = new List<ActionProbabilityWrapper>
            {
                new ActionProbabilityWrapperForTest(1, 1f)
            };
            dict.Add("Side Bar", slot2list);

            return dict;
        }
    }
}
