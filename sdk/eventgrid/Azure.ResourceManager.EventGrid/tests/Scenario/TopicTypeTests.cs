// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    internal class TopicTypeTests : EventGridManagementTestBase
    {
        private TopicTypeCollection _topicTypeCollection;

        public TopicTypeTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            _topicTypeCollection = tenant.GetTopicTypes();
        }

        [Test]
        [Ignore("System.FormatException : The ResourceIdentifier must start with /subscriptions/ or /providers/")]
        public async Task GetAll()
        {
            // actually: {providers/Microsoft.EventGrid/topicTypes/Microsoft.Eventhub.Namespaces}
            var list = await _topicTypeCollection.GetAllAsync().ToEnumerableAsync();
        }
    }
}
