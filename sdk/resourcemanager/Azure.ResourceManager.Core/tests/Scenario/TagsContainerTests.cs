// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.s

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class TagsContainerTests : ResourceManagerTestBase
    {
        public TagsContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            var container = GetTagsContainer();
            var result = await container.ListAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(result.Count, 0, "List result less than 0" );
        }

        [Ignore("Not Implemented")]
        [TestCase]
        [RecordedTest]
        public async Task GetOperation()
        {
            var container = GetTagsContainer();
            var result = await container.GetAsync(Client.DefaultSubscription.Id.SubscriptionId);
            Assert.NotNull(result.Value);
        }

        protected TagsContainer GetTagsContainer()
        {
            return new TagsContainer(new ClientContext(Client.DefaultSubscription.ClientOptions, Client.DefaultSubscription.Credential, Client.DefaultSubscription.BaseUri, Client.DefaultSubscription.Pipeline), Client.DefaultSubscription.Id.SubscriptionId);
        }
    }
}
