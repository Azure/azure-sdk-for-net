// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using EventGrid.Tests.TestHelper;
using Xunit;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact(Skip = "This is not yet enabled for the new API version, will re-record once it is enabled")]
        public void TopicTypeTests()
        {
            const string StorageTopicType = "Microsoft.Storage.StorageAccounts";
            const string EventHubsTopicType = "Microsoft.EventHub.Namespaces";

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                IEnumerable<TopicTypeInfo> topicTypesList = this.EventGridManagementClient.TopicTypes.ListAsync().Result;

                Assert.NotNull(topicTypesList);

                Assert.Contains(topicTypesList, tt => string.Equals(tt.Name, StorageTopicType, StringComparison.OrdinalIgnoreCase));
                Assert.Contains(topicTypesList, tt => string.Equals(tt.Name, EventHubsTopicType, StringComparison.OrdinalIgnoreCase));

                TopicTypeInfo storageTopicType = this.EventGridManagementClient.TopicTypes.GetAsync(StorageTopicType).Result;
                Assert.Equal(storageTopicType.Name, StorageTopicType);

                IEnumerable<EventType> eventTypesList = this.EventGridManagementClient.TopicTypes.ListEventTypesAsync(StorageTopicType).Result;
                Assert.NotNull(eventTypesList);
                Assert.Contains(eventTypesList, et => string.Equals(et.Name, "Microsoft.Storage.BlobCreated", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
