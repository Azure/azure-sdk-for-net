namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class ModelTests : BaseTest
    {
        [Fact]
        public void ListCompositeEntities()
        {
            UseClientFor(async client =>
            {
                var childEntity = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "datetimeV2" });
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, new CompositeEntityModel(new List<string>() { "datetimeV2" }, name: "CompositeTest"));
                var result = await client.Model.ListCompositeEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity.Single().Id);

                Assert.NotEmpty(result);
            });
        }

        [Fact]
        public void AddCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var childEntity = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "datetimeV2" });
                var compositeEntity = new CompositeEntityModel(new List<string>() { "datetimeV2" }, name: "CompositeTest");
                var result = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, compositeEntity);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, result);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity.Single().Id);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void GetCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var childEntity = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "datetimeV2" });
                var entity = new CompositeEntityModel(new List<string>() { "datetimeV2" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, entity);
                var result = await client.Model.GetCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity.Single().Id);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void UpdateCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var childEntity = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "datetimeV2" });
                var entity = new CompositeEntityModel(new List<string>() { "datetimeV2" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, entity);
                await client.Model.UpdateCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId, new CompositeEntityModel(new List<string>() { "datetimeV2" }, name: "CompositeTestUpdate"));

                var entities = await client.Model.ListCompositeEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity.Single().Id);
            

                Assert.Equal("CompositeTestUpdate", entities.Single(e => e.Id == entityId).Name);
            });
        }

        [Fact]
        public void DeleteCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var childEntity = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "datetimeV2" });
                var entity = new CompositeEntityModel(new List<string>() { childEntity.Single().Name }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, entity);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity.Single().Id);

                var entities = await client.Model.ListCompositeEntitiesAsync(GlobalAppId, GlobalVersionId);
                Assert.DoesNotContain(entities, e => e.Id == entityId);
            });
        }

        [Fact]
        public void AddCompositeEntityChild()
        {
            UseClientFor(async client =>
            {
                var childEntityId = await client.Model.AddEntityAsync(GlobalAppId, GlobalVersionId, new ModelCreateObject("ChildTest"));
                var childEntityId2 = await client.Model.AddEntityAsync(GlobalAppId, GlobalVersionId, new ModelCreateObject("ChildTest2"));
                var entity = new CompositeEntityModel(new List<string>() { "ChildTest" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, entity);

                var child = new CompositeChildModelCreateObject("ChildTest2");
                var result = await client.Model.AddCompositeEntityChildAsync(GlobalAppId, GlobalVersionId, entityId, child);

                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, GlobalVersionId, childEntityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, GlobalVersionId, childEntityId2);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void DeleteCompositeEntityChild()
        {
            UseClientFor(async client =>
            {
                var childEntity = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "datetimeV2" });
                var childEntity2 = await client.Model.AddPrebuiltAsync(GlobalAppId, GlobalVersionId, new List<string> { "number" });
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, GlobalVersionId, new CompositeEntityModel(new List<string>() { childEntity.Single().Name, childEntity2.Single().Name }, name: "CompositeTest"));
                var childEntityId = childEntity2.Single().Id;

                await client.Model.DeleteCompositeEntityChildAsync(GlobalAppId, GlobalVersionId, entityId, childEntityId);

                var entities = await client.Model.ListCompositeEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity.Single().Id);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, GlobalVersionId, childEntity2.Single().Id);

                Assert.DoesNotContain(entities, e => e.Id == entityId && e.Children.Any(c => c.Id == childEntityId));
            });
        }

        [Fact]
        public void ListHierarchicalEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var result = await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.NotEmpty(result);
                Assert.NotEmpty(result);
            });
        }

        [Fact]
        public void AddHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.True(entityId != Guid.Empty);
            });
        }

        [Fact]
        public void GetHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var result = await client.Model.GetHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void UpdateHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                await client.Model.UpdateHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTestUpdate"));
                var entities = await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.Equal("HierarchicalTestUpdate", entities.Single(e => e.Id == entityId).Name);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var entities = await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                entities = await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId);
                Assert.DoesNotContain(entities, e => e.Id == entityId);
            });
        }

        [Fact]
        public void GetHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var entity = await client.Model.GetHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                var result = await client.Model.GetHierarchicalEntityChildAsync(GlobalAppId, GlobalVersionId, entityId, entity.Children.First().Id);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest", "AnotherChildTest" }, name: "HierarchicalTest"));
                var entity = (await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId)).SingleOrDefault(o => o.Id == entityId);
                var childEntityId = entity.Children.First().Id;

                await client.Model.DeleteHierarchicalEntityChildAsync(GlobalAppId, GlobalVersionId, entityId, childEntityId);
                var entities = await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.DoesNotContain(entities, e => e.Id == entityId && e.Children.Any(c => c.Id == childEntityId));
            });
        }

        [Fact]
        public void UpdateHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var entity = await client.Model.GetHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);
                var childEntity = entity.Children.Last();
                var updateEntity = new HierarchicalChildModelUpdateObject("RenamedChildEntity");

                await client.Model.UpdateHierarchicalEntityChildAsync(GlobalAppId, GlobalVersionId, entity.Id, childEntity.Id, updateEntity);

                var entities = await client.Model.ListHierarchicalEntitiesAsync(GlobalAppId, GlobalVersionId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                entity = entities.Last(e => e.Id == entity.Id);
                childEntity = entity.Children.Last(c => c.Id == childEntity.Id);
                Assert.Equal("RenamedChildEntity", childEntity.Name);
            });
        }

        [Fact]
        public void AddHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var childEntity = new HierarchicalChildModelCreateObject
                {
                    Name = "NewChildEntity"
                };

                var result = await client.Model.AddHierarchicalEntityChildAsync(GlobalAppId, GlobalVersionId, entityId, childEntity);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, GlobalVersionId, entityId);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void ListModels()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entities = await client.Model.ListModelsAsync(GlobalAppId, versionId);

                foreach (var entity in entities)
                {
                    var entityInfo = await client.Model.GetEntityAsync(GlobalAppId, versionId, entity.Id);
                    Assert.Equal(entity.Name, entityInfo.Name);
                }
            });
        }
    }
}
