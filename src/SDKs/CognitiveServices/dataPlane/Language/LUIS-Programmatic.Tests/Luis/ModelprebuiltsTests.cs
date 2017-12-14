namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelPrebuiltsTests : BaseTest
    {
        [Fact]
        public void ListPrebuiltEntities()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntities = await client.Model.ListPrebuiltEntitiesAsync(appId, version);

                Assert.True(prebuiltEntities.Count > 0);
            });
        }

        [Fact]
        public void ListPrebuilts()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntities = await client.Model.ListPrebuiltsAsync(appId, version);

                Assert.True(prebuiltEntities.Count > 0);
                Assert.All(prebuiltEntities, e => e.ReadableType.Equals("Prebuilt Entity Extractor"));
            });
        }

        [Fact]
        public void AddPrebuilt()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltEntitiesToAdd = new string[]
                {
                    "number",
                    "ordinal"
                };
                var prebuiltEntitiesAdded = await client.Model.AddPrebuiltAsync(appId, version, prebuiltEntitiesToAdd);

                Assert.All(prebuiltEntitiesAdded, e => prebuiltEntitiesToAdd.Contains(e.Name));
            });
        }

        [Fact]
        public void GetPrebuilt()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltId = new Guid("a065c863-918e-4c56-a267-9aaae3c7dced");

                var prebuiltEntity = await client.Model.GetPrebuiltAsync(appId, version, prebuiltId);

                Assert.Equal(prebuiltId, prebuiltEntity.Id);
            });
        }

        [Fact]
        public void DeletePrebuilt()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var prebuiltId = new Guid("1e14dc89-be04-46ef-ab26-2a9768fad89b");

                await client.Model.DeletePrebuiltAsync(appId, version, prebuiltId);
                var prebuiltEntitiesWithoutDeleted = await client.Model.ListPrebuiltsAsync(appId, version);

                Assert.DoesNotContain(prebuiltEntitiesWithoutDeleted, e => e.Id.Equals(prebuiltId));
            });
        }
    }
}
