// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class EventsTests : PersonalizerTestBase
    {
        public EventsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SingleSlotEventsTests()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: true);
            await Reward(client);
            await Activate(client);
        }

        private async Task Reward(PersonalizerClient client)
        {
            await client.RewardAsync("123456789", (float)0.5);
        }

        private async Task Activate(PersonalizerClient client)
        {
            await client.ActivateAsync("123456789");
        }
    }
}
