namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
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
                var addedId = (await client.Model.AddPrebuiltAsync(appId, version, new string[]
                {
                    "number"
                })).First().Id;

                var prebuiltEntities = await client.Model.ListPrebuiltsAsync(appId, version);
                await client.Model.DeletePrebuiltAsync(appId, version, addedId);

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
                foreach (var added in prebuiltEntitiesAdded)
                {
                    await client.Model.DeletePrebuiltAsync(appId, version, added.Id);
                }

                Assert.All(prebuiltEntitiesAdded, e => prebuiltEntitiesToAdd.Contains(e.Name));
            });
        }

        [Fact]
        public void GetPrebuilt()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var addedId = (await client.Model.AddPrebuiltAsync(appId, version, new string[]
                {
                    "number"
                })).First().Id;

                var prebuiltEntity = await client.Model.GetPrebuiltAsync(appId, version, addedId);
                await client.Model.DeletePrebuiltAsync(appId, version, addedId);

                Assert.Equal(addedId, prebuiltEntity.Id);
            });
        }

        [Fact]
        public void DeletePrebuilt()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var addedId = (await client.Model.AddPrebuiltAsync(appId, version, new string[]
                {
                    "number"
                })).First().Id;

                await client.Model.DeletePrebuiltAsync(appId, version, addedId);
                var prebuiltEntitiesWithoutDeleted = await client.Model.ListPrebuiltsAsync(appId, version);

                Assert.DoesNotContain(prebuiltEntitiesWithoutDeleted, e => e.Id.Equals(addedId));
            });
        }
    }
}
