namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class ModelPatternAnyTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void ListEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any entity",
                    ExplicitList = new[] { "item" }
                });

                var results = await client.Model.ListPatternAnyEntityInfosAsync(GlobalAppId, versionId);

                var model = results.FirstOrDefault(r => r.Name == "Pattern.Any entity");
                Assert.NotNull(model);
                Assert.Equal("Pattern.Any entity", model.Name);
                Assert.Equal("item", model.ExplicitList.Single().ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void GetEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new[] { "item" }
                });

                var result = await client.Model.GetPatternAnyEntityInfoAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Pattern.Any Entity Extractor", result.ReadableType);
                Assert.Equal("item", result.ExplicitList.Single().ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void AddEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new[] { "item" }
                });

                var result = await client.Model.GetPatternAnyEntityInfoAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("New Entity Test", result.Name);
                Assert.Equal("Pattern.Any Entity Extractor", result.ReadableType);
                Assert.Equal("item", result.ExplicitList.Single().ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void UpdateEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new[] { "item" }
                });

                await client.Model.UpdatePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId, new PatternAnyModelUpdateObject
                {
                    Name = "Entity Test Renamed",
                    ExplicitList = new[] { "item1" }
                });

                var result = await client.Model.GetPatternAnyEntityInfoAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Equal("Entity Test Renamed", result.Name);
                Assert.Equal("Pattern.Any Entity Extractor", result.ReadableType);
                Assert.Equal("item1", result.ExplicitList.Single().ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void DeleteEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new[] { "item" }
                });

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);

                var results = await client.Model.ListPatternAnyEntityInfosAsync(GlobalAppId, versionId);

                Assert.DoesNotContain(results, o => o.Id == entityId);
            });
        }

        [Fact]
        public void GetExplicitList()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new[] { "item1", "item2" }
                });

                var result = await client.Model.GetExplicitListAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(result);
                Assert.Contains(result, r => r.ExplicitListItemProperty == "item1");
                Assert.Contains(result, r => r.ExplicitListItemProperty == "item2");

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void AddExplicitListItem()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new[] { "item1" }
                });

                var result = await client.Model.AddExplicitListItemAsync(GlobalAppId, versionId, entityId, new ExplicitListItemCreateObject
                {
                    ExplicitListItem = "item2"
                });

                var item = await client.Model.GetExplicitListItemAsync(GlobalAppId, versionId, entityId, result.Value);

                Assert.NotNull(item);
                Assert.Equal("item2", item.ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void GetExplicitListItem()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new List<string>()
                });

                var result = await client.Model.AddExplicitListItemAsync(GlobalAppId, versionId, entityId, new ExplicitListItemCreateObject
                {
                    ExplicitListItem = "item"
                });

                var item = await client.Model.GetExplicitListItemAsync(GlobalAppId, versionId, entityId, result.Value);

                Assert.NotNull(item);
                Assert.Equal("item", item.ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void UpdateExplicitListItem()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new List<string>()
                });

                var result = await client.Model.AddExplicitListItemAsync(GlobalAppId, versionId, entityId, new ExplicitListItemCreateObject
                {
                    ExplicitListItem = "item"
                });

                await client.Model.UpdateExplicitListItemAsync(GlobalAppId, versionId, entityId, result.Value, new ExplicitListItemUpdateObject
                {
                    ExplicitListItem = "item1"
                });

                var item = await client.Model.GetExplicitListItemAsync(GlobalAppId, versionId, entityId, result.Value);

                Assert.NotNull(item);
                Assert.Equal("item1", item.ExplicitListItemProperty);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void DeleteExplicitListItem()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, versionId, new PatternAnyModelCreateObject
                {
                    Name = "New Entity Test",
                    ExplicitList = new List<string>()
                });

                var result = await client.Model.AddExplicitListItemAsync(GlobalAppId, versionId, entityId, new ExplicitListItemCreateObject
                {
                    ExplicitListItem = "item"
                });

                await client.Model.DeleteExplicitListItemAsync(GlobalAppId, versionId, entityId, result.Value);
                var list = await client.Model.GetExplicitListAsync(GlobalAppId, versionId, entityId);

                Assert.NotNull(list);
                Assert.Empty(list);

                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, versionId, entityId);
            });
        }
    }
}
