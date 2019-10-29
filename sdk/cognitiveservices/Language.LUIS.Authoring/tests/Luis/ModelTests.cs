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
    }
}
