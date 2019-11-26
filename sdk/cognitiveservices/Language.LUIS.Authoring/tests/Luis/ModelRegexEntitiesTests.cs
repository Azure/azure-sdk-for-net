﻿namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class ModelRegexEntitiesTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void GetRegexEntities()
        {
            UseClientFor(async client =>
            {
                var regexEntityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, versionId, GetRegexEntitySample());
                var regexEntities = await client.Model.ListRegexEntityInfosAsync(GlobalAppId, versionId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, versionId, regexEntityId);

                Assert.NotEmpty(regexEntities);
            });
        }

        [Fact]
        public void CreateRegexEntity()
        {
            UseClientFor(async client =>
            {
                var regexEntityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, versionId, GetRegexEntitySample());
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, versionId, regexEntityId);

                Assert.True(regexEntityId != Guid.Empty);
            });
        }

        [Fact]
        public void GetRegexEntity()
        {
            UseClientFor(async client =>
            {
                var regexEntityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, versionId, GetRegexEntitySample());
                var regexEntity = await client.Model.GetRegexEntityEntityInfoAsync(GlobalAppId, versionId, regexEntityId);
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, versionId, regexEntityId);

                // Assert
                Assert.Equal("regex entity 1", regexEntity.Name);
                Assert.Equal("regex pattern 1", regexEntity.RegexPattern);
            });
        }

        [Fact]
        public void UpdateRegexEntity()
        {
            UseClientFor(async client =>
            {
                var regexEntityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, versionId, GetRegexEntitySample());
                var regexEntityUpdateObj = new RegexModelUpdateObject()
                {
                    Name = "regex entity 2",
                    RegexPattern = "regex pattern 2"
                };

                await client.Model.UpdateRegexEntityModelAsync(GlobalAppId, versionId, regexEntityId, regexEntityUpdateObj);
                var updatedRegexEntity = await client.Model.GetRegexEntityEntityInfoAsync(GlobalAppId, versionId, regexEntityId);

                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, versionId, regexEntityId);

                Assert.Equal("regex entity 2", updatedRegexEntity.Name);
                Assert.Equal("regex pattern 2", updatedRegexEntity.RegexPattern);
            });
        }

        [Fact]
        public void DeleteRegexEntity()
        {
            UseClientFor(async client =>
            {
                var regexEntityId = await client.Model.CreateRegexEntityModelAsync(GlobalAppId, versionId, GetRegexEntitySample());
                await client.Model.DeleteRegexEntityModelAsync(GlobalAppId, versionId, regexEntityId);

                var regexEntities = await client.Model.ListRegexEntityInfosAsync(GlobalAppId, versionId);

                Assert.DoesNotContain(regexEntities, o => o.Id == regexEntityId);
            });
        }

        private static RegexModelCreateObject GetRegexEntitySample()
        {
            return new RegexModelCreateObject
            {
                Name = "regex entity 1",
                RegexPattern = "regex pattern 1"
            };
        }
    }
}
