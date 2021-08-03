// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class MultiSlotEventsTests: PersonalizerTestBase
    {
        public MultiSlotEventsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Reward()
        {
            PersonalizerClient client = GetPersonalizerClient();
            PersonalizerSlotReward slotReward = new PersonalizerSlotReward("testSlot", 1);
            PersonalizerRewardMultiSlotOptions rewardRequest = new PersonalizerRewardMultiSlotOptions(new List<PersonalizerSlotReward> { slotReward });
            await client.RewardMultiSlotAsync("123456789", rewardRequest);
        }

        [Test]
        public async Task RewardForOneSlot()
        {
            PersonalizerClient client = GetPersonalizerClient();
            await client.RewardMultiSlotAsync("123456789", "testSlot", 1);
        }

        [Test]
        public async Task Activate()
        {
            PersonalizerClient client = GetPersonalizerClient();
            await client.ActivateMultiSlotAsync("123456789");
        }
    }
}
