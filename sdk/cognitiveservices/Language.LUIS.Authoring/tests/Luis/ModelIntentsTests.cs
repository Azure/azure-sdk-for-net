namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    public class ModelIntentsTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void ListIntents()
        {
            UseClientFor(async client =>
            {
                var intents = await client.Model.ListIntentsAsync(GlobalAppId, versionId);

                Assert.True(intents.All(i => i.ReadableType.Equals("Intent Classifier")));
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddIntent()
        {
            UseClientFor(async client =>
            {
                var newIntent = new ModelCreateObject
                {
                    Name = "TestIntent"
                };

                var newIntentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, newIntent);
                var intents = await client.Model.ListIntentsAsync(GlobalAppId, versionId);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, newIntentId);

                Assert.True(newIntentId != Guid.Empty);
                Assert.Contains(intents, i => i.Id.Equals(newIntentId) && i.Name.Equals(newIntent.Name));
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetIntent()
        {
            UseClientFor(async client =>
            {
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "TestIntent"
                });

                var intent = await client.Model.GetIntentAsync(GlobalAppId, versionId, intentId);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);

                Assert.Equal(intentId, intent.Id);
                Assert.Equal("TestIntent", intent.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateIntent()
        {
            UseClientFor(async client =>
            {
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "TestIntent"
                });

                var newName = new ModelUpdateObject
                {
                    Name = "UpdateTest"
                };

                var intent = await client.Model.GetIntentAsync(GlobalAppId, versionId, intentId);
                await client.Model.UpdateIntentAsync(GlobalAppId, versionId, intentId, newName);
                var newIntent = await client.Model.GetIntentAsync(GlobalAppId, versionId, intentId);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);

                Assert.Equal(intent.Id, newIntent.Id);
                Assert.NotEqual(intent.Name, newIntent.Name);
                Assert.Equal(newName.Name, newIntent.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteIntent()
        {
            UseClientFor(async client =>
            {
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "TestIntent"
                });

                var intents = await client.Model.ListIntentsAsync(GlobalAppId, versionId);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);
                var intentsWithoutDeleted = await client.Model.ListIntentsAsync(GlobalAppId, versionId);

                Assert.Contains(intents, i => i.Id.Equals(intentId));
                Assert.DoesNotContain(intentsWithoutDeleted, i => i.Id.Equals(intentId));
            });
        }
    }
}
