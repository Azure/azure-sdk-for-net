namespace LUIS.Authoring.Tests.Luis
{
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    public class ModelSimpleEntitiesTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void ListEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Existing Entity Test"
                });

                var results = await client.Model.ListEntitiesAsync(appId, versionId);

                Assert.NotEqual(0, results.Count);
                Assert.Contains(results, o => o.Name == "Existing Entity Test");

                await client.Model.DeleteEntityAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void GetEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "New Entity Test"
                });

                var result = await client.Model.GetEntityAsync(appId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Entity Extractor", result.ReadableType);

                await client.Model.DeleteEntityAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void AddEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "New Entity Test"
                });

                var result = await client.Model.GetEntityAsync(appId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Entity Extractor", result.ReadableType);

                await client.Model.DeleteEntityAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void UpdateEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Rename Entity Test"
                });

                await client.Model.UpdateEntityAsync(appId, versionId, entityId, new ModelUpdateObject
                {
                    Name = "Entity Test Renamed"
                });

                var result = await client.Model.GetEntityAsync(appId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("Entity Test Renamed", result.Name);

                await client.Model.DeleteEntityAsync(appId, versionId, entityId);
            });
        }

        [Fact]
        public void DeleteEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Delete Entity Test"
                });

                await client.Model.DeleteEntityAsync(appId, versionId, entityId);

                var results = await client.Model.ListEntitiesAsync(appId, versionId);

                Assert.DoesNotContain(results, o => o.Id == entityId);
            });
        }

        [Fact]
        public void GetEntitySuggestions_ReturnsEmpty()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, versionId, new ModelCreateObject
                {
                    Name = "Suggestions Entity Test"
                });

                var results = await client.Model.GetEntitySuggestionsAsync(appId, versionId, entityId);
                var count = results.SelectMany(o => o.EntityPredictions).Count(o => o.EntityName == "Suggestions Entity Test");

                await client.Model.DeleteEntityAsync(appId, versionId, entityId);

                Assert.Equal(0, count);
            });
        }

        [Fact]
        public void GetEntitySuggestions_ReturnsResults()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.ListEntitiesAsync(appId, versionId)).Single(o => o.Name == "RoomType").Id;

                var results = await client.Model.GetEntitySuggestionsAsync(appId, versionId, entityId);
                var count = results.SelectMany(o => o.EntityPredictions).Count(o => o.EntityName == "RoomType");

                Assert.NotEqual(0, count);
            });
        }
    }
}
