namespace LUIS.Authoring.Tests.Luis
{
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class ModelSimpleEntitiesTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void ListEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "Existing Entity Test"
                });

                var results = await client.Model.ListEntitiesAsync(GlobalAppId, versionId);

                Assert.NotEqual(0, results.Count);
                Assert.Contains(results, o => o.Name == "Existing Entity Test");

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void GetEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "New Entity Test"
                });

                var result = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Entity Extractor", result.ReadableType);
            });
        }

        [Fact]
        public void AddEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "New Entity Test"
                });

                var result = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Entity Extractor", result.ReadableType);
            });
        }

        [Fact]
        public void DeleteEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "Delete Entity Test"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);

                var results = await client.Model.ListEntitiesAsync(GlobalAppId, versionId);

                Assert.DoesNotContain(results, o => o.Id == entityId);
            });
        }

        [Fact]
        public void GetEntitySuggestions_ReturnsEmpty()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "Suggestions Entity Test"
                });

                var results = await client.Model.ListEntitySuggestionsAsync(GlobalAppId, versionId, entityId);
                var count = results.SelectMany(o => o.EntityPredictions).Count(o => o.EntityName == "Suggestions Entity Test");

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);

                Assert.Equal(0, count);
            });
        }
    }
}
