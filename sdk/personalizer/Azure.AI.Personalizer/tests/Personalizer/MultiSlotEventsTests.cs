// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
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
            SlotReward slotReward = new SlotReward("testSlot", 1);
            MultiSlotRewardRequest rewardRequest = new MultiSlotRewardRequest(new List<SlotReward> { slotReward });
            await client.MultiSlotEvents.RewardAsync("123456789", rewardRequest);
        }

        [Test]
        public async Task Activate()
        {
            PersonalizerClient client = GetPersonalizerClient();
            await client.MultiSlotEvents.ActivateAsync("123456789");
        }
    }
}
