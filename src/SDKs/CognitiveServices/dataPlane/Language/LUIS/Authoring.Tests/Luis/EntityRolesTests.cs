
namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;

    public class EntityRolesTests : BaseTest
    {
        [Fact]
        public void AddSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddPrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(appId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetPrebuiltEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeletePrebuiltAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(appId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetClosedListEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteClosedListAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(appId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetRegexEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteRegexEntityModelAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(appId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetCompositeEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(appId, version, added.Id);
                }

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddPatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(appId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetPatternAnyEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeletePatternAnyEntityModelAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetHierarchicalEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void AddCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(appId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetCustomPrebuiltEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact]
        public void GetSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetPrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(appId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetPrebuiltEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeletePrebuiltAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(appId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetClosedListEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteClosedListAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(appId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetRegexEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteRegexEntityModelAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(appId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetCompositeEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(appId, version, added.Id);
                }

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetPatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(appId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetPatternAnyEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeletePatternAnyEntityModelAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetHierarchicalEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(appId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetCustomEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact]
        public void GetSimpleEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetPrebuiltEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(appId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetPrebuiltEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeletePrebuiltAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetClosedListEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(appId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetClosedListEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteClosedListAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetRegexEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(appId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetRegexEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteRegexEntityModelAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetCompositeEntityRoles()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(appId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetCompositeEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(appId, version, added.Id);
                }

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetPatternAnyEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(appId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetPatternAnyEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeletePatternAnyEntityModelAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetHierarchicalEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetHierarchicalEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void GetCustomPrebuiltDomainEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(appId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.GetCustomPrebuiltEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact]
        public void UpdateSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdatePrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(appId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdatePrebuiltEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetPrebuiltEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeletePrebuiltAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdateClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(appId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateClosedListEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetClosedListEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteClosedListAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdateRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(appId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateRegexEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetRegexEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteRegexEntityModelAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdateCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(appId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateCompositeEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetCompositeEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(appId, version, added.Id);
                }

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdatePatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(appId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdatePatternAnyEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetPatternAnyEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeletePatternAnyEntityModelAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdateHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateHierarchicalEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetHierarchicalEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void UpdateCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(appId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateCustomPrebuiltEntityRoleAsync(appId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetCustomEntityRoleAsync(appId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact]
        public void DeleteSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeletePrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(appId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeletePrebuiltEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetPrebuiltEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeletePrebuiltAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeleteClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(appId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteClosedListEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetClosedListEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteClosedListAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeleteRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(appId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteRegexEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetRegexEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteRegexEntityModelAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeleteCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(appId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(appId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteCompositeEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetCompositeEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(appId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(appId, version, added.Id);
                }

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeletePatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(appId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeletePatternAnyEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetPatternAnyEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeletePatternAnyEntityModelAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeleteHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(appId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteHierarchicalEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetHierarchicalEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact]
        public void DeleteCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(appId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(appId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteCustomEntityRoleAsync(appId, "0.1", entityId, roleId);
                var roles = await client.Model.GetCustomPrebuiltEntityRolesAsync(appId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(appId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }
    }
}
