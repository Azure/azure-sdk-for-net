// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
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
            PersonalizerClient client = GetPersonalizerClient();
            await client.Events.RewardAsync("123456789", new RewardRequest((float)0.5));
        }

        [Test]
        public async Task Activate()
        {
            PersonalizerClient client = GetPersonalizerClient();
            await client.Events.ActivateAsync("123456789");
        }
    }
}
