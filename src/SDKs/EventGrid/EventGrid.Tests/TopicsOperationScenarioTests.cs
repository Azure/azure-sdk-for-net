using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;
using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;

namespace EventGrid.Tests
{
	public class TopicsOperationScenarioTests
	{
		private const string EventGridLocation = "westus2";

		[Fact]
		public void TopicsCRUD()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-topicstest-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// Create topic
				string topicName = context.GenerateName("testtopic");
				Topic createTopic = client.Topics.CreateOrUpdate(resourceGroup.Name, topicName, new Topic
				{
					Location = resourceGroup.Location,
				});
				Assert.NotNull(createTopic);
				string topicId = createTopic.Id;

				// Get topic
				Topic getTopic = client.Topics.Get(resourceGroup.Name, topicName);
				Assert.NotNull(getTopic);

				// List topics by resource group
				IEnumerable<Topic> listRgTopics = client.Topics.ListByResourceGroup(resourceGroup.Name);
				Assert.NotNull(listRgTopics);
				Assert.Equal(1, listRgTopics.Count());
				Topic listRgTopicSingle = listRgTopics.First();
				Assert.Equal(topicName, listRgTopicSingle.Name);
				Assert.Equal(topicId, listRgTopicSingle.Id);

				// List topics by resource group
				IEnumerable<Topic> listSubTopics = client.Topics.ListBySubscription();
				Assert.NotNull(listSubTopics);
				Assert.True(listSubTopics.Any());
				Topic listSubTopicSingle = listSubTopics.First(x=> topicId.Equals(x?.Id));
				Assert.Equal(topicName, listSubTopicSingle.Name);

				// Update topic with same name and location, aka, create if not exists
				Topic updateTopic = client.Topics.CreateOrUpdate(resourceGroup.Name, topicName, new Topic
				{
					Location = resourceGroup.Location,
				});
				Assert.NotNull(updateTopic);

				// Delete topic
				client.Topics.Delete(resourceGroup.Name, topicName);

				// Confirm that if it doesn't exist, delete doesn't throw
				client.Topics.Delete(resourceGroup.Name, topicName);
			}
		}

		[Fact(Skip = "Doesn't seem fully implemented on Azure's side")]
		public void TopicsEventTypes()
		{
			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-topicseventtest-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// List event types
				string provider = "provider";
				string resourceType = "type";
				string resourceName = "name";
				IEnumerable<EventType> listEventTypes = client.Topics.ListEventTypes(resourceGroup.Name, provider, resourceType, resourceName);
				Assert.NotNull(listEventTypes);
				Assert.True(listEventTypes.Any());
				foreach(EventType eventType in listEventTypes)
				{
					Assert.NotNull(eventType.Name);
					Assert.NotNull(eventType.SchemaUrl);
					Assert.NotNull(eventType.DisplayName);
					Assert.NotNull(eventType.Description);
					Assert.NotNull(eventType.Type);
				}
			}
		}

		[Fact]
		public void TopicsSharedAccessKeys()
		{
			const string Key1Name = "Key1";
			const string Key2Name = "Key2";

			using (TestContext context = new TestContext(this))
			{
				ResourceGroup resourceGroup = context.CreateResourceGroup("eg-topicseventtest-", EventGridLocation);
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// Create topic
				string topicName = context.GenerateName("testtopic");
				Topic createTopic = client.Topics.CreateOrUpdate(resourceGroup.Name, topicName, new Topic
				{
					Location = resourceGroup.Location,
				});
				Assert.NotNull(createTopic);

				// List access keys
				TopicSharedAccessKeys sharedAccessKeys = client.Topics.ListSharedAccessKeys(resourceGroup.Name, topicName);
				Assert.NotNull(sharedAccessKeys);
				Assert.NotNull(sharedAccessKeys.Key1);
				Assert.NotNull(sharedAccessKeys.Key2);

				string originalKey1 = sharedAccessKeys.Key1;
				string originalKey2 = sharedAccessKeys.Key2;

				// Regenerate key 1
				TopicSharedAccessKeys regenKey1AccessKeys = client.Topics.RegenerateKey(resourceGroup.Name, topicName, Key1Name);
				Assert.NotNull(regenKey1AccessKeys);
				Assert.NotNull(regenKey1AccessKeys.Key1);
				Assert.NotNull(regenKey1AccessKeys.Key2);
				Assert.NotEqual(originalKey1, regenKey1AccessKeys.Key1);
				Assert.Equal(originalKey2, regenKey1AccessKeys.Key2);
				string newKey1 = regenKey1AccessKeys.Key1;

				// List post regen key 1
				TopicSharedAccessKeys afterRegenKey1AccessKeys = client.Topics.ListSharedAccessKeys(resourceGroup.Name, topicName);
				Assert.NotNull(afterRegenKey1AccessKeys);
				Assert.NotNull(afterRegenKey1AccessKeys.Key1);
				Assert.NotNull(afterRegenKey1AccessKeys.Key2);
				Assert.Equal(newKey1, afterRegenKey1AccessKeys.Key1);
				Assert.Equal(originalKey2, afterRegenKey1AccessKeys.Key2);

				// Regenerate key 2
				TopicSharedAccessKeys regenKey2AccessKeys = client.Topics.RegenerateKey(resourceGroup.Name, topicName, Key2Name);
				Assert.NotNull(regenKey2AccessKeys);
				Assert.NotNull(regenKey2AccessKeys.Key1);
				Assert.NotNull(regenKey2AccessKeys.Key2);
				Assert.Equal(newKey1, regenKey2AccessKeys.Key1);
				Assert.NotEqual(originalKey2, regenKey2AccessKeys.Key2);
				string newKey2 = regenKey2AccessKeys.Key2;

				// List post regen key 2
				TopicSharedAccessKeys afterRegenKey2AccessKeys = client.Topics.ListSharedAccessKeys(resourceGroup.Name, topicName);
				Assert.NotNull(afterRegenKey2AccessKeys);
				Assert.NotNull(afterRegenKey2AccessKeys.Key1);
				Assert.NotNull(afterRegenKey2AccessKeys.Key2);
				Assert.NotEqual(originalKey1, afterRegenKey2AccessKeys.Key1);
				Assert.NotEqual(originalKey2, afterRegenKey2AccessKeys.Key2);
				Assert.Equal(newKey1, afterRegenKey2AccessKeys.Key1);
				Assert.Equal(newKey2, afterRegenKey2AccessKeys.Key2);
			}
		}
	}
}
