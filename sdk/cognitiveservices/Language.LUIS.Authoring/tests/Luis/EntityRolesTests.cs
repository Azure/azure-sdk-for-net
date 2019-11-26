
namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;

    [Collection("TestCollection")]
    public class EntityRolesTests : BaseTest
    {
        [Fact]
        public void AddSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new EntityModelCreateObject
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void GetSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new EntityModelCreateObject
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void GetSimpleEntityRoles()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new EntityModelCreateObject
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void UpdateSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new EntityModelCreateObject
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void DeleteSimpleEntityRole()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, "0.1", new EntityModelCreateObject
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
