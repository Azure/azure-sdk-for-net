
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
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddPrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(GlobalAppId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListPrebuiltEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(GlobalAppId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListClosedListEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteClosedListAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListRegexEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListCompositeEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddPatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListPatternAnyEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListHierarchicalEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void AddCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListCustomPrebuiltEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Contains(roles, r => r.Name == "simple role");
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetPrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(GlobalAppId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(GlobalAppId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteClosedListAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetPatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetPatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var role = await client.Model.GetCustomEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetSimpleEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetPrebuiltEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(GlobalAppId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListPrebuiltEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetClosedListEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(GlobalAppId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListClosedListEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteClosedListAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetRegexEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListRegexEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetCompositeEntityRoles()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListCompositeEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetPatternAnyEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListPatternAnyEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetHierarchicalEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListHierarchicalEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetCustomPrebuiltDomainEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                var roles = await client.Model.ListCustomPrebuiltEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role", Assert.Single(roles).Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdatePrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(GlobalAppId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdatePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(GlobalAppId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteClosedListAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdatePatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdatePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetPatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.UpdateCustomPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId, new EntityRoleUpdateObject
                {
                    Name = "simple role 2"
                });
                var role = await client.Model.GetCustomEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Equal("simple role 2", role.Name);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new ModelCreateObject
                {
                    Name = "simple entity"
                });
                var roleId = await client.Model.CreateEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeletePrebuiltEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = (await client.Model.AddPrebuiltAsync(GlobalAppId, "0.1", new[] { "money" })).First().Id;
                var roleId = await client.Model.CreatePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeletePrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListPrebuiltEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeletePrebuiltAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteClosedListEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddClosedListAsync(GlobalAppId, "0.1", new ClosedListModelCreateObject
                {
                    Name = "closed list model",
                    SubLists = new[]
                    {
                        new WordListObject { CanonicalForm = "test", List = new List<string>() }
                    }
                });
                var roleId = await client.Model.CreateClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteClosedListEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListClosedListEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteClosedListAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteRegexEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, "0.1", new RegexModelCreateObject
                {
                    Name = "regex model",
                    RegexPattern = "a+"
                });
                var roleId = await client.Model.CreateRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteRegexEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListRegexEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteCompositeEntityRole()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var entityId = await client.Model.AddCompositeEntityAsync(GlobalAppId, "0.1", new CompositeEntityModel
                {
                    Name = "composite model",
                    Children = new[] { "datetimeV2" }
                });
                var roleId = await client.Model.CreateCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteCompositeEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListCompositeEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteCompositeEntityAsync(GlobalAppId, "0.1", entityId);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeletePatternAnyEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.CreatePatternAnyEntityModelAsync(GlobalAppId, "0.1", new PatternAnyModelCreateObject
                {
                    Name = "Pattern.Any model",
                    ExplicitList = new List<string>()
                });
                var roleId = await client.Model.CreatePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeletePatternAnyEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListPatternAnyEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeletePatternAnyEntityModelAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteHierarchicalEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddHierarchicalEntityAsync(GlobalAppId, "0.1", new HierarchicalEntityModel
                {
                    Name = "Pattern.Any model",
                    Children = new[] { "child1" }
                });

                var roleId = await client.Model.CreateHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteHierarchicalEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListHierarchicalEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteHierarchicalEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteCustomPrebuiltDomainEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, "0.1", new PrebuiltDomainModelCreateObject
                {
                    ModelName = "ContactName",
                    DomainName = "Communication"
                });

                var roleId = await client.Model.CreateCustomPrebuiltEntityRoleAsync(GlobalAppId, "0.1", entityId, new EntityRoleCreateObject
                {
                    Name = "simple role"
                });
                await client.Model.DeleteCustomEntityRoleAsync(GlobalAppId, "0.1", entityId, roleId);
                var roles = await client.Model.ListCustomPrebuiltEntityRolesAsync(GlobalAppId, "0.1", entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, "0.1", entityId);

                Assert.Empty(roles);
            });
        }
    }
}
