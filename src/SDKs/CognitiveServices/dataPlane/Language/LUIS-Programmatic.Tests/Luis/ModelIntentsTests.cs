namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelIntentsTests : BaseTest
    {
        [Fact]
        public void ListIntents()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intents = await client.Model.ListIntentsAsync(appId, version);

                Assert.True(intents.All(i => i.ReadableType.Equals("Intent Classifier")));
            });
        }

        [Fact]
        public void AddIntent()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";

                var newIntent = new ModelCreateObject
                {
                    Name = "TestIntent"
                };

                var newIntentId = await client.Model.AddIntentAsync(appId, version, newIntent);
                var intents = await client.Model.ListIntentsAsync(appId, version);

                Assert.True(newIntentId != Guid.Empty);
                Assert.Contains(intents, i => i.Id.Equals(newIntentId) && i.Name.Equals(newIntent.Name));
            });
        }

        [Fact]
        public void GetIntent()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = new Guid("d7a08f1a-d276-4364-b2d5-b0235c61e37f");

                var intent = await client.Model.GetIntentAsync(appId, version, intentId);

                Assert.Equal(intentId, intent.Id);
            });
        }

        [Fact]
        public void UpdateIntent()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = new Guid("d7a08f1a-d276-4364-b2d5-b0235c61e37f");
                var newName = new ModelUpdateObject
                {
                    Name = "NewTest"
                };

                var intent = await client.Model.GetIntentAsync(appId, version, intentId);
                await client.Model.UpdateIntentAsync(appId, version, intentId, newName);
                var newIntent = await client.Model.GetIntentAsync(appId, version, intentId);

                Assert.Equal(intent.Id, newIntent.Id);
                Assert.NotEqual(intent.Name, newIntent.Name);
                Assert.Equal(newName.Name, newIntent.Name);
            });
        }

        [Fact]
        public void DeleteIntent()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = new Guid("d7a08f1a-d276-4364-b2d5-b0235c61e37f");

                var intents = await client.Model.ListIntentsAsync(appId, version);
                await client.Model.DeleteIntentAsync(appId, version, intentId);
                var intentsWithoutDeleted = await client.Model.ListIntentsAsync(appId, version);

                Assert.Contains(intents, i => i.Id.Equals(intentId));
                Assert.DoesNotContain(intentsWithoutDeleted, i => i.Id.Equals(intentId));
            });
        }

        [Fact]
        public void GetIntentSuggestions()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var intentId = new Guid("d81d151e-59a1-49d0-bd2d-dce0533c7efe");

                var intent = await client.Model.GetIntentAsync(appId, version, intentId);
                var suggestions = await client.Model.GetIntentSuggestionsAsync(appId, version, intentId);

                Assert.Contains(suggestions, s => s.IntentPredictions.Any(i => i.Name.Equals(intent.Name)));
            });
        }
    }
}
