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
        public void ListModels()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entities = await client.Model.ListEntitiesAsync(GlobalAppId, versionId);

                foreach (var entity in entities)
                {
                    var entityInfo = await client.Model.GetEntityAsync(GlobalAppId, versionId, entity.Id);
                    Assert.Equal(entity.Name, entityInfo.Name);
                }
            });
        }

        [Fact]
        public void CreateModelWithNoChildren()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> { },
                    Name = "Entity To Be Added"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void CreateModelWithChildren()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> {
                        new ChildEntityModelCreateObject {
                            Name = "child1",
                            Children = new List<ChildEntityModelCreateObject>{ }
                        }
                    },
                    Name = "Entity To Be Added"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void CreateModelWithChildrenAndInstanceOf()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var prebuiltEntitiesToAdd = new string[]
                {
                    "email"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, versionId, prebuiltEntitiesToAdd);

                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> {
                        new ChildEntityModelCreateObject {
                            Name = "child1",
                            Children = new List<ChildEntityModelCreateObject>{
                                new ChildEntityModelCreateObject {
                                    Name = "instanceOf",
                                    InstanceOf = "email"
                                }
                            }
                        }
                    },
                    Name = "Entity To Be Added"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, versionId, added.Id);
                }
            });
        }

        [Fact]
        public void DeleteModel()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> { },
                    Name = "Entity To Be Added"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void AddModelChild()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> { },
                    Name = "Entity To Be Added"
                });

                await client.Model.AddEntityChildAsync(GlobalAppId, versionId, entityId, new ChildEntityModelCreateObject
                {
                    Name = "child1",
                    Children = new List<ChildEntityModelCreateObject> { }
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void GetModel()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> {
                        new ChildEntityModelCreateObject{
                            Name = "child1"
                        }
                    },
                    Name = "Entity To Be Added"
                });

                var model = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);
                Assert.Equal("child1", model.Children[0].Name);
                Assert.Equal(entityId, model.Id);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void GetModelChild()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "Entity To Be Added"
                });

                var childId  = await client.Model.AddEntityChildAsync(GlobalAppId, versionId, entityId, new ChildEntityModelCreateObject
                {
                    Name = "child1",
                    Children = new List<ChildEntityModelCreateObject> { }
                });

                var model = await client.Model.GetEntityAsync(GlobalAppId, versionId, childId);
                Assert.Equal("child1", model.Name);
                Assert.Equal(childId, model.Id);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void UpdateModel()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Children = new List<ChildEntityModelCreateObject> {
                        new ChildEntityModelCreateObject{
                            Name = "child1"
                        }
                    },
                    Name = "Entity To Be Added"
                });

                await client.Model.UpdateEntityChildAsync(GlobalAppId, versionId, entityId, new EntityModelUpdateObject {
                    Name = "Updated  Model"
                });

                var model = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);
                Assert.Equal("Updated  Model", model.Name);
                Assert.Equal("child1", model.Children[0].Name);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void UpdateModelChildName()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "Entity To Be Added"
                });

                var childId = await client.Model.AddEntityChildAsync(GlobalAppId, versionId, entityId, new ChildEntityModelCreateObject
                {
                    Name = "child1",
                    Children = new List<ChildEntityModelCreateObject> { }
                });

                await client.Model.UpdateEntityChildAsync(GlobalAppId, versionId, childId, new EntityModelUpdateObject {
                    Name = "child2"
                });

                var model = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);

                Assert.Equal("child2", model.Children[0].Name);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void UpdateModelChildInstanceOf()
        {
            UseClientFor(async client =>
            {
                var versionId = GlobalVersionId;
                var prebuiltEntitiesToAdd = new string[]
                {
                    "email",
                    "number"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, versionId, prebuiltEntitiesToAdd);

                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "Entity To Be Added",
                    Children = new List<ChildEntityModelCreateObject> {
                        new ChildEntityModelCreateObject {
                            Name = "child1",
                            InstanceOf = "email"
                            }
                        }
                });

                var model = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);

                await client.Model.UpdateEntityChildAsync(GlobalAppId, versionId, model.Children[0].Id, new EntityModelUpdateObject {
                    InstanceOf = "number",
                    Name = "changed Instance Of"
                });

                model = await client.Model.GetEntityAsync(GlobalAppId, versionId, entityId);

                Assert.Equal("changed Instance Of", model.Children[0].Name);

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, versionId, added.Id);
                }
            });
        }
    }
}
