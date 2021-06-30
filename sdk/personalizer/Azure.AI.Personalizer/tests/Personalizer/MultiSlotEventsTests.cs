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
            System.Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
            System.Environment.SetEnvironmentVariable("PERSONALIZER_ENDPOINT", "https://sdktestrecorder.cognitiveservices.azure.com/");
            System.Environment.SetEnvironmentVariable("PERSONALIZER_API_KEY", "c35296bcca76406893b9674f23912052");
            PersonalizerClient client = GetPersonalizerClient();
            await client.MultiSlotEvents.ActivateAsync("123456789");
        }
    }
}
