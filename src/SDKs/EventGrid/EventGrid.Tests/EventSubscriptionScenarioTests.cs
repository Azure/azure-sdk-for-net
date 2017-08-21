using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Rest.Azure;

namespace EventGrid.Tests
{
	public class EventSubscriptionScenarioTests
	{
		private const string EventGridLocation = "westus2";

		[Fact]
		public void EventSubscriptionCRUDSubscriptionScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-sub-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				string eventSubscriptionName = context.GenerateName("essubeventsub");

				string scope = $"/subscriptions/{client.SubscriptionId}";

				EventSubscriptionCRUD(client, resourceGroup, eventSubscriptionName, scope, "Microsoft.Resources.Subscriptions", true, false, false);
			}
		}

		[Fact]
		public void EventSubscriptionCRUDResourceGroupScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-rg-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				string eventSubscriptionName = context.GenerateName("esrgeventsub");

				string scope = $"/subscriptions/{client.SubscriptionId}/resourceGroups/{resourceGroup.Name}";

				EventSubscriptionCRUD(client, resourceGroup, eventSubscriptionName, scope, "Microsoft.Resources.ResourceGroups", true, true, false);
			}
		}

		[Fact(Skip = "Need to be a part of the preview program for Azure Storage events in Event Grid: https://aka.ms/storageevents")]
		public void EventSubscriptionCRUDResourceScope_Storage()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-sto-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();
				StorageManagementClient storageClient = context.GetClient<StorageManagementClient>();

				// Setup our target resource
				string storageAccountName = context.GenerateName("egeventsubsto");
				StorageAccount storageAccount = storageClient.StorageAccounts.Create(resourceGroup.Name, storageAccountName, new StorageAccountCreateParameters
				{
					Sku = new Microsoft.Azure.Management.Storage.Models.Sku {
						Name = Microsoft.Azure.Management.Storage.Models.SkuName.StandardLRS
					},
					AccessTier = AccessTier.Hot,
					Kind = Kind.BlobStorage,
					Location = resourceGroup.Location
				});
				Assert.NotNull(storageAccount);
				Assert.NotNull(storageAccount.Id);

				string eventSubscriptionName = context.GenerateName("eseventsubsto");

				string scope = storageAccount.Id;

				EventSubscriptionCRUD(client, resourceGroup, eventSubscriptionName, scope, "Microsoft.Storage.StorageAccounts", true, true, true);
			}
		}

		[Fact]
		public void EventSubscriptionCRUDResourceScope_EventHub()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-eh-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();
				EventHubManagementClient eventHubClient = context.GetClient<EventHubManagementClient>();

				// Setup our target resource
				string namespaceName = context.GenerateName("egeventsubns");
				EHNamespace eventHubNS = eventHubClient.Namespaces.CreateOrUpdate(resourceGroup.Name, namespaceName, new EHNamespace
				{
					Location = resourceGroup.Location,
					Sku = new Microsoft.Azure.Management.EventHub.Models.Sku
					{
						Name = "Basic"
					}
				});
				Assert.NotNull(eventHubNS);
				Assert.NotNull(eventHubNS.Id);

				string eventSubscriptionName = context.GenerateName("eseventsubeh");
				
				string scope = eventHubNS.Id;

				EventSubscriptionCRUD(client, resourceGroup, eventSubscriptionName, scope, "Microsoft.Eventhub.Namespaces", false, true, true);
			}
		}

		[Fact]
		public void EventSubscriptionCRUDTopicScope()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-eventsub-top-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				string triggerTopicName = context.GenerateName("esresparenttopic");

				Topic triggerTopic = client.Topics.CreateOrUpdate(resourceGroup.Name, triggerTopicName, new Topic
				{
					Location = resourceGroup.Location
				});
				Assert.NotNull(triggerTopic);
				Assert.NotNull(triggerTopic.Id);

				string eventSubscriptionName = context.GenerateName("estopeventsub");

				string scope = triggerTopic.Id;

				EventSubscriptionCRUD(client, resourceGroup, eventSubscriptionName, scope, "Microsoft.EventGrid.Topics", false, true, true);
			}
		}

		private void EventSubscriptionCRUD(EventGridManagementClient client, ResourceGroup resourceGroup, 
			string eventSubscriptionName, 
			string scope,
			string topicType,
			bool globalScoped,
			bool resourceGroupScoped,
			bool locationScoped)
		{
			try
			{
				const string AllIncludedEventType = "All";
				// Create an event subscription with a destination and no filter
				string originalDestinationEndpoint = "https://requestb.in/1a1wyat1";
				string destinationEndpointType = EndpointType.WebHook;
				EventSubscription createEventSub = client.EventSubscriptions.Create(scope, eventSubscriptionName, new EventSubscription
				{
					Destination = new EventSubscriptionDestination
					{
						EndpointType = destinationEndpointType,
						EndpointUrl = originalDestinationEndpoint
					}
				});
				Assert.NotNull(createEventSub);
				Assert.NotNull(createEventSub.Filter); // No filter should be an 'all' filter
				Assert.Equal(AllIncludedEventType, createEventSub.Filter.IncludedEventTypes.Single(), ignoreCase: true);
				Assert.Equal(string.Empty, createEventSub.Filter.SubjectBeginsWith);
				Assert.Equal(string.Empty, createEventSub.Filter.SubjectBeginsWith);
				Assert.NotNull(createEventSub.Destination);
				Assert.Equal(destinationEndpointType, createEventSub.Destination.EndpointType);
				Assert.Equal(originalDestinationEndpoint, createEventSub.Destination.EndpointBaseUrl); // Url maps to base url in response

				// Get the event subscription
				EventSubscription getEventSub = client.EventSubscriptions.Get(scope, eventSubscriptionName);
				Assert.NotNull(getEventSub);
				Assert.NotNull(getEventSub.Filter);
				Assert.Equal(AllIncludedEventType, getEventSub.Filter.IncludedEventTypes.Single(), ignoreCase: true);
				Assert.Equal(string.Empty, getEventSub.Filter.SubjectBeginsWith);
				Assert.Equal(string.Empty, getEventSub.Filter.SubjectBeginsWith);
				Assert.NotNull(getEventSub.Destination);
				Assert.Equal(destinationEndpointType, getEventSub.Destination.EndpointType);
				Assert.Equal(originalDestinationEndpoint, getEventSub.Destination.EndpointBaseUrl);

				string eventSubId = getEventSub.Id;

				// Check if it is in the global list
				IEnumerable<EventSubscription> globalEventSubs = client.EventSubscriptions.ListGlobalBySubscription();
				Assert.True(globalScoped == globalEventSubs.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

				// Check if it is in the resource group list if scoped to the resource group level
				IEnumerable<EventSubscription> globalEventSubsByResourceGroup = client.EventSubscriptions.ListGlobalByResourceGroup(resourceGroup.Name);
				Assert.True((resourceGroupScoped && globalScoped) == globalEventSubsByResourceGroup.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

				// Check if it is in the regional list if scoped to a region
				IEnumerable<EventSubscription> regionalEventSubs = client.EventSubscriptions.ListRegionalBySubscription(resourceGroup.Location);
				Assert.True(locationScoped == regionalEventSubs.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

				// Check if it is in the regional resource group list if scoped to a region and resource group level
				IEnumerable<EventSubscription> regionalEventSubsByResourceGroup = client.EventSubscriptions.ListRegionalByResourceGroup(resourceGroup.Name, resourceGroup.Location);
				Assert.True((resourceGroupScoped && locationScoped) == regionalEventSubsByResourceGroup.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

				// Only check if we know the topicType to test
				if (!string.IsNullOrWhiteSpace(topicType))
				{
					// Check if it is in the global list with the specified type
					IEnumerable<EventSubscription> globalEventSubsByType = client.EventSubscriptions.ListGlobalBySubscriptionForTopicType(topicType);
					Assert.True(globalScoped == globalEventSubsByType.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

					// Check if it is in the resource group list if scoped to the resource group level with the specified type
					IEnumerable<EventSubscription> globalEventSubsByResourceGroupAndType = client.EventSubscriptions.ListGlobalByResourceGroupForTopicType(resourceGroup.Name, topicType);
					Assert.True((globalScoped && resourceGroupScoped) == globalEventSubsByResourceGroupAndType.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

					// Check if it is in the regional list if scoped to a region with the specified type
					IEnumerable<EventSubscription> regionalEventSubsByType = client.EventSubscriptions.ListRegionalBySubscriptionForTopicType(resourceGroup.Location, topicType);
					Assert.True(locationScoped == regionalEventSubsByType.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));

					// Check if it is in the regional resource group list if scoped to a region and resource group level with the specified type
					IEnumerable<EventSubscription> regionalEventSubsByResourceGroupAndType = client.EventSubscriptions.ListRegionalByResourceGroupForTopicType(resourceGroup.Name, resourceGroup.Location, topicType);
					Assert.True((resourceGroupScoped && locationScoped) == regionalEventSubsByResourceGroupAndType.Any(x => eventSubId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)));
				}

				// Update just the destination 
				string newDestinationEndpoint = "https://requestb.in/109n35e1";
				EventSubscription updateEventSub = client.EventSubscriptions.Update(scope, eventSubscriptionName, new EventSubscriptionUpdateParameters
				{
					Destination = new EventSubscriptionDestination
					{
						EndpointType = EndpointType.WebHook,
						EndpointUrl = newDestinationEndpoint
					}
				});
				Assert.NotNull(updateEventSub);
				Assert.NotNull(updateEventSub.Filter);
				Assert.Equal(AllIncludedEventType, updateEventSub.Filter.IncludedEventTypes.Single(), ignoreCase: true);
				Assert.Equal(string.Empty, updateEventSub.Filter.SubjectBeginsWith);
				Assert.Equal(string.Empty, updateEventSub.Filter.SubjectBeginsWith);
				Assert.NotNull(updateEventSub.Destination);
				Assert.Equal(destinationEndpointType, updateEventSub.Destination.EndpointType);
				Assert.Equal(newDestinationEndpoint, updateEventSub.Destination.EndpointBaseUrl);

				// Update the event subscription with a filter
				string subjectEndsWithFilter = "newFilter";
				string singleEventType = AllIncludedEventType;
				EventSubscription updateFilteredEventSub = client.EventSubscriptions.Update(scope, eventSubscriptionName, new EventSubscriptionUpdateParameters
				{
					Filter = new EventSubscriptionFilter
					{
						IncludedEventTypes = new List<string> { singleEventType },
						SubjectEndsWith = subjectEndsWithFilter // Can only update ends with
					}
				});
				Assert.NotNull(updateFilteredEventSub);
				Assert.NotNull(updateFilteredEventSub.Filter);
				Assert.Equal(singleEventType, updateFilteredEventSub.Filter.IncludedEventTypes.Single());
				Assert.Equal(subjectEndsWithFilter, updateFilteredEventSub.Filter.SubjectEndsWith);
				Assert.NotNull(updateFilteredEventSub.Destination);
				Assert.Equal(destinationEndpointType, updateFilteredEventSub.Destination.EndpointType);
				Assert.Equal(newDestinationEndpoint, updateFilteredEventSub.Destination.EndpointBaseUrl);

				// Get event sub to make sure filter and destination exists
				// Get the event subscription
				EventSubscription getFilteredEventSub = client.EventSubscriptions.Get(scope, eventSubscriptionName);
				Assert.NotNull(getFilteredEventSub);
				Assert.NotNull(getFilteredEventSub.Filter);
				Assert.Equal(singleEventType, getFilteredEventSub.Filter.IncludedEventTypes.Single());
				Assert.Equal(subjectEndsWithFilter, getFilteredEventSub.Filter.SubjectEndsWith);
				Assert.NotNull(getFilteredEventSub.Destination);
				Assert.Equal(destinationEndpointType, getFilteredEventSub.Destination.EndpointType);
				Assert.Equal(newDestinationEndpoint, getFilteredEventSub.Destination.EndpointBaseUrl);

				// Do a dummy update with no payload to make sure it throws
				Assert.Throws<CloudException>(() =>
				{
					client.EventSubscriptions.Update(scope, eventSubscriptionName, new EventSubscriptionUpdateParameters());
				});

				// Get the full url
				EventSubscriptionFullUrl fullUrl = client.EventSubscriptions.GetFullUrl(scope, eventSubscriptionName);
				Assert.NotNull(fullUrl);
				Assert.NotNull(fullUrl.EndpointUrl);

			}
			finally
			{
				// Delete the event subscription
				client.EventSubscriptions.Delete(scope, eventSubscriptionName);

				// Confirm that if it doesn't exist, delete doesn't throw
				client.EventSubscriptions.Delete(scope, eventSubscriptionName);
			}
		}
	}
}
 