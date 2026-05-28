
namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class PatternsTests : BaseTest
    {
        [Fact]
        public void AddPattern()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var pattern = new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {datetimeV2}" };
                var result = await client.Pattern.AddPatternAsync(GlobalAppId, "0.1", pattern);
                await client.Pattern.DeletePatternAsync(GlobalAppId, "0.1", result.Id.Value);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.NotNull(result);
                Assert.NotNull(result.Id);
                Assert.Equal("None", result.Intent);
                Assert.NotEqual(Guid.Empty, result.Id);
                Assert.Equal("this is a {datetimeV2}", result.Pattern);
            });
        }

        [Fact]
        public void AddPatterns()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2",
                    "number"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var patterns = new[]
                {
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {number}" },
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {datetimeV2}" },
                };

                var result = await client.Pattern.BatchAddPatternsAsync(GlobalAppId, "0.1", patterns);
                await client.Pattern.DeletePatternsAsync(GlobalAppId, "0.1", result.Select(p => p.Id).ToList());
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.NotNull(result);
                foreach (var pattern in result)
                {
                    Assert.NotNull(pattern.Id);
                    Assert.Equal("None", pattern.Intent);
                    Assert.NotEqual(Guid.Empty, pattern.Id);
                }
            });
        }

        [Fact]
        public void UpdatePattern()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "email"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var pattern = new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {email}" };
                var updatedPattern = new PatternRuleUpdateObject { Intent = "None", Pattern = "This [is] a {email}" };

                var addResult = await client.Pattern.AddPatternAsync(GlobalAppId, "0.1", pattern);
                var updateResult = await client.Pattern.UpdatePatternAsync(GlobalAppId, "0.1", addResult.Id.Value, updatedPattern);
                await client.Pattern.DeletePatternAsync(GlobalAppId, "0.1", addResult.Id.Value);
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.NotNull(updateResult);
                Assert.NotNull(updateResult.Id);
                Assert.Equal("None", updateResult.Intent);
                Assert.Equal(addResult.Id, updateResult.Id);
                Assert.NotEqual(Guid.Empty, updateResult.Id);
                Assert.Equal("this [is] a {email}", updateResult.Pattern);
            });
        }

        [Fact]
        public void UpdatePatterns()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "email",
                    "geographyV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var patterns = new[] { new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {email}" } };
                var addResult = await client.Pattern.BatchAddPatternsAsync(GlobalAppId, "0.1", patterns);

                var updatedPatterns = new[] { new PatternRuleUpdateObject { Intent = "None", Pattern = "This [is] a {geographyV2}", Id = addResult.First().Id } };
                var updateResult = await client.Pattern.UpdatePatternsAsync(GlobalAppId, "0.1", updatedPatterns);
                await client.Pattern.DeletePatternsAsync(GlobalAppId, "0.1", updateResult.Select(p => p.Id).ToList());
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.NotNull(updateResult);
                Assert.NotNull(updateResult.Single().Id);
                Assert.Equal("None", updateResult.Single().Intent);
                Assert.NotEqual(Guid.Empty, updateResult.Single().Id);
                Assert.Equal(addResult.Single().Id, updateResult.Single().Id);
                Assert.Equal("this [is] a {geographyV2}", updateResult.Single().Pattern);
            });
        }

        [Fact]
        public void GetPatterns()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "ordinalV2",
                    "money"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var patternsToAdd = new[]
                {
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {money}" },
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {ordinalV2}" },
                };

                var result = await client.Pattern.BatchAddPatternsAsync(GlobalAppId, "0.1", patternsToAdd);
                var patterns = await client.Pattern.ListPatternsAsync(GlobalAppId, "0.1");

                await client.Pattern.DeletePatternsAsync(GlobalAppId, "0.1", result.Select(p => p.Id).ToList());
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.NotNull(patterns);
                Assert.NotEmpty(patterns);
                foreach (var pattern in patterns)
                {
                    Assert.NotNull(pattern.Id);
                    Assert.NotNull(pattern.Intent);
                    Assert.NotNull(pattern.Pattern);
                }
            });
        }

        [Fact]
        public void GetIntentPatterns()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "money",
                    "ordinalV2"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var patternsToAdd = new[]
                {
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {money}" },
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {ordinalV2}" },
                };

                var result = await client.Pattern.BatchAddPatternsAsync(GlobalAppId, "0.1", patternsToAdd);
                var patterns = await client.Pattern.ListIntentPatternsAsync(GlobalAppId, "0.1", GlobalNoneId);

                await client.Pattern.DeletePatternsAsync(GlobalAppId, "0.1", result.Select(p => p.Id).ToList());
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.NotNull(patterns);
                Assert.NotEmpty(patterns);
                foreach (var pattern in patterns)
                {
                    Assert.NotNull(pattern.Id);
                    Assert.NotNull(pattern.Intent);
                    Assert.NotNull(pattern.Pattern);
                    Assert.Equal("None", pattern.Intent);
                }
            });
        }

        [Fact]
        public void DeletePattern()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "email"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var pattern = new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {email}" };
                var result = await client.Pattern.AddPatternAsync(GlobalAppId, "0.1", pattern);
                await client.Pattern.DeletePatternAsync(GlobalAppId, "0.1", result.Id.Value);
                var existingPatterns = await client.Pattern.ListPatternsAsync(GlobalAppId, "0.1");
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Null(existingPatterns.FirstOrDefault(p => p.Id == result.Id));
            });
        }

        [Fact]
        public void DeletePatterns()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "datetimeV2",
                    "number"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(GlobalAppId, version, prebuiltEntitiesToAdd);
                var patterns = new[]
                {
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {number}" },
                    new PatternRuleCreateObject { Intent = "None", Pattern = "This is a {datetimeV2}" },
                };

                var result = await client.Pattern.BatchAddPatternsAsync(GlobalAppId, "0.1", patterns);
                await client.Pattern.DeletePatternsAsync(GlobalAppId, "0.1", result.Select(p => p.Id).ToList());
                var existingPatterns = await client.Pattern.ListPatternsAsync(GlobalAppId, "0.1");
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(GlobalAppId, version, added.Id);
                }

                Assert.Null(existingPatterns.FirstOrDefault(p => result.Any(r => r.Id == p.Id)));
            });
        }
    }
}
