// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using EventGrid.Tests.TestHelper;
using Xunit;
using System.Threading.Tasks;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        const string StorageTopicType = "Microsoft.Storage.StorageAccounts";
        const string EventHubsTopicType = "Microsoft.EventHub.Namespaces";

        [Fact]
        public async Task TopicTypeTestsAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                IEnumerable<TopicTypeInfo> topicTypesList = this.EventGridManagementClient.TopicTypes.ListAsync().Result;
                Assert.NotNull(topicTypesList);
                Assert.Contains(topicTypesList, tt => string.Equals(tt.Name, StorageTopicType, StringComparison.OrdinalIgnoreCase));
                Assert.Contains(topicTypesList, tt => string.Equals(tt.Name, EventHubsTopicType, StringComparison.OrdinalIgnoreCase));

                await ValidateStorageEventTypesAsync();
            }
        }

        async Task ValidateStorageEventTypesAsync()
        {
            TopicTypeInfo storageTopicType = this.EventGridManagementClient.TopicTypes.GetAsync(StorageTopicType).Result;
            Assert.Equal(storageTopicType.Name, StorageTopicType);

            IEnumerable<EventType> eventTypesList = await this.EventGridManagementClient.TopicTypes.ListEventTypesAsync(StorageTopicType);
            Assert.NotNull(eventTypesList);
            Assert.Contains(eventTypesList, et => string.Equals(et.Name, "Microsoft.Storage.BlobCreated", StringComparison.OrdinalIgnoreCase));
        }
    }
}