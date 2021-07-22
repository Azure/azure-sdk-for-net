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
            PersonalizerSlotReward slotReward = new PersonalizerSlotReward("testSlot", 1);
            PersonalizerMultiSlotRewardOptions rewardRequest = new PersonalizerMultiSlotRewardOptions(new List<PersonalizerSlotReward> { slotReward });
            await client.MultiSlotRewardAsync("123456789", rewardRequest);
        }

        [Test]
        public async Task Activate()
        {
            PersonalizerClient client = GetPersonalizerClient();
            await client.MultiSlotActivateAsync("123456789");
        }
    }
}
