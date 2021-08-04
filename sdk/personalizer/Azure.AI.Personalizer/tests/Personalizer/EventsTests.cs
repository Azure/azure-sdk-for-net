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
        public async Task Reward()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: true);
            await client.RewardAsync("123456789", (float)0.5);
        }

        [Test]
        public async Task Activate()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: true);
            await client.ActivateAsync("123456789");
        }
    }
}
