namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    public class ModelTests : BaseTest
    {
        [Fact]
        public void ListCompositeEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel(new List<string>() { "datetime" }, name: "CompositeTest"));
                var result = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);

                Assert.NotEmpty(result);
            });
        }

        [Fact]
        public void AddCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var entity = new CompositeEntityModel(new List<string>() { "datetime" }, name: "CompositeTest");
                var result = await client.Model.AddCompositeEntityAsync(appId, "0.1", entity);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", result);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void GetCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var entity = new CompositeEntityModel(new List<string>() { "datetime" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", entity);
                var result = await client.Model.GetCompositeEntityAsync(appId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void UpdateCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var entity = new CompositeEntityModel(new List<string>() { "datetime" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", entity);
                await client.Model.UpdateCompositeEntityAsync(appId, "0.1", entityId, new CompositeEntityModel(new List<string>() { "datetime" }, name: "HierarchicalTestUpdate"));

                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);

                Assert.Equal("HierarchicalTestUpdate", entities.Single(e => e.Id == entityId).Name);
            });
        }

        [Fact]
        public void DeleteCompositeEntity()
        {
            UseClientFor(async client =>
            {
                var entity = new CompositeEntityModel(new List<string>() { "datetime" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", entity);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);

                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                Assert.DoesNotContain(entities, e => e.Id == entityId);
            });
        }

        [Fact]
        public void AddCompositeEntityChild()
        {
            UseClientFor(async client =>
            {
                var childEntityId = await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject("ChildTest"));
                var entity = new CompositeEntityModel(new List<string>() { "datetime" }, name: "CompositeTest");
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", entity);

                var child = new CompositeChildModelCreateObject("ChildTest");
                var result = await client.Model.AddCompositeEntityChildAsync(appId, "0.1", entityId, child);

                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", childEntityId);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void DeleteCompositeEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel(new List<string>() { "datetime", "email" }, name: "CompositeTest"));
                var entity = await client.Model.GetCompositeEntityAsync(appId, "0.1", entityId);
                var childEntityId = entity.Children.Last().Id;

                await client.Model.DeleteCompositeEntityChildAsync(appId, "0.1", entity.Id, childEntityId);

                var entities = await client.Model.ListCompositeEntitiesAsync(appId, "0.1");
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);

                Assert.DoesNotContain(entities, e => e.Id == entity.Id && e.Children.Any(c => c.Id == childEntityId));
            });
        }

        [Fact]
        public void ListHierarchicalEntities()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var result = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.NotEmpty(result);
            });
        }

        [Fact]
        public void AddHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.True(entityId != Guid.Empty);
            });
        }

        [Fact]
        public void GetHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var result = await client.Model.GetHierarchicalEntityAsync(appId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void UpdateHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                await client.Model.UpdateHierarchicalEntityAsync(appId, "0.1", entityId, new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTestUpdate"));
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.Equal("HierarchicalTestUpdate", entities.Single(e => e.Id == entityId).Name);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntity()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                Assert.DoesNotContain(entities, e => e.Id == entityId);
            });
        }

        [Fact]
        public void GetHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var entity = await client.Model.GetHierarchicalEntityAsync(appId, "0.1", entityId);
                var result = await client.Model.GetHierarchicalEntityChildAsync(appId, "0.1", entityId, entity.Children.First().Id);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.True(result.Id != Guid.Empty);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest", "AnotherChildTest" }, name: "HierarchicalTest"));
                var entity = (await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1")).SingleOrDefault(o => o.Id == entityId);
                var childEntityId = entity.Children.First().Id;

                await client.Model.DeleteHierarchicalEntityChildAsync(appId, "0.1", entityId, childEntityId);
                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.DoesNotContain(entities, e => e.Id == entityId && e.Children.Any(c => c.Id == childEntityId));
            });
        }

        [Fact]
        public void UpdateHierarchicalEntityChild()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var entity = await client.Model.GetHierarchicalEntityAsync(appId, "0.1", entityId);
                var childEntity = entity.Children.Last();
                var updateEntity = new HierarchicalChildModelUpdateObject("RenamedChildEntity");

                await client.Model.UpdateHierarchicalEntityChildAsync(appId, "0.1", entity.Id, childEntity.Id, updateEntity);

                var entities = await client.Model.ListHierarchicalEntitiesAsync(appId, "0.1");
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

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
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel(new List<string>() { "ChildTest" }, name: "HierarchicalTest"));
                var childEntity = new HierarchicalChildModelCreateObject
                {
                    Name = "NewChildEntity"
                };

                var result = await client.Model.AddHierarchicalEntityChildAsync(appId, "0.1", entityId, childEntity);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.True(result != Guid.Empty);
            });
        }

        [Fact]
        public void ListModels()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var entitys = await client.Model.ListModelsAsync(appId, versionId);

                foreach (var entity in entitys)
                {
                    var entityInfo = await client.Model.GetEntityAsync(appId, versionId, entity.Id);
                    Assert.Equal(entity.Name, entityInfo.Name);
                }
            });
        }
    }
}
