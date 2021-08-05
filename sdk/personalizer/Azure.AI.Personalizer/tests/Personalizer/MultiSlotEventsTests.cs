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
        public async Task MultiSlotEventTest()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: false);
            await Reward(client);
            await RewardForOneSlot(client);
            await Activate(client);
        }

        private async Task Reward(PersonalizerClient client)
        {
            PersonalizerSlotReward slotReward = new PersonalizerSlotReward("testSlot", 1);
            PersonalizerRewardMultiSlotOptions rewardRequest = new PersonalizerRewardMultiSlotOptions(new List<PersonalizerSlotReward> { slotReward });
            await client.RewardMultiSlotAsync("123456789", rewardRequest);
        }

        private async Task RewardForOneSlot(PersonalizerClient client)
        {
            await client.RewardMultiSlotAsync("123456789", "testSlot", 1);
        }

        private async Task Activate(PersonalizerClient client)
        {
            await client.ActivateMultiSlotAsync("123456789");
        }
    }
}
