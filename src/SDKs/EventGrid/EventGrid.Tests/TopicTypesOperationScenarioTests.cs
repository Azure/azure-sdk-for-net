using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;

namespace EventGrid.Tests
{
	public class TopicTypesOperationScenarioTests
	{
		[Fact]
		public void ListTopicTypes()
		{
			using (TestContext context = new TestContext(this))
			{
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// List all topic types
				IEnumerable<TopicTypeInfo> listTopicTypes = client.TopicTypes.List();
				Assert.NotNull(listTopicTypes);
				Assert.True(listTopicTypes.Any());
				foreach(TopicTypeInfo topicType in listTopicTypes)
				{
					Assert.NotNull(topicType.Name);
					Assert.NotNull(topicType.Type);
					Assert.NotNull(topicType.Provider);
				}
			}
		}

		[Theory]
		[InlineData("Microsoft.Resources.Subscriptions")]
		[InlineData("Microsoft.Resources.ResourceGroups")]
		[InlineData("Microsoft.Eventhub.Namespaces")]
		[InlineData("Microsoft.Storage.StorageAccounts")]
		public void GetTopicTypes(string topicTypeName)
		{
			using (TestContext context = new TestContext(this, nameof(GetTopicTypes) + topicTypeName))
			{
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();
				
				// Get specific topic type
				TopicTypeInfo getTopicType = client.TopicTypes.Get(topicTypeName);
				Assert.NotNull(getTopicType);
				Assert.NotNull(getTopicType.Name);
				Assert.NotNull(getTopicType.Type);
				Assert.NotNull(getTopicType.Provider);
			}
		}

		[Theory]
		[InlineData("Microsoft.Resources.Subscriptions")]
		[InlineData("Microsoft.Resources.ResourceGroups")]
		[InlineData("Microsoft.Eventhub.Namespaces")]
		[InlineData("Microsoft.Storage.StorageAccounts")]
		public void ListTopicTypeEventTypes(string topicTypeName)
		{
			using (TestContext context = new TestContext(this, nameof(ListTopicTypeEventTypes) + topicTypeName))
			{
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// Get specific topic type
				IEnumerable<EventType> eventTypes = client.TopicTypes.ListEventTypes(topicTypeName);
				Assert.NotNull(eventTypes);
				foreach(EventType et in eventTypes)
				{
					Assert.NotNull(et);
					Assert.NotNull(et.Name);
					Assert.NotNull(et.Type);
					Assert.NotNull(et.Description);
					Assert.NotNull(et.DisplayName);
					Assert.NotNull(et.SchemaUrl);
				}
			}
		}
	}
}
