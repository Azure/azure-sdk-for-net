namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Newtonsoft.Json;
    using System.IO;
    using Xunit;

    [Collection("TestCollection")]
    public class FeaturesTests : BaseTest
    {
        [Fact(Skip = "Problem from API")]
        public void ListFeatures()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportApp.json"));
            var app = JsonConvert.DeserializeObject<LuisApp>(appJson);

            UseClientFor(async client =>
            {
                var appId = await client.Apps.ImportAsync(app, "Test list features of LUIS App");
                var versionId = "0.1";

                var features = await client.Features.ListAsync(appId, versionId);

                await client.Apps.DeleteAsync(appId);

                Assert.True(features.PhraselistFeatures.Count > 0);
            });
        }

        [Fact]
        public void AddEntityFeature()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "parent entity"
                });

                var featureEntity = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "increment phrases",
                    Phrases = "add,increment,plus"
                });

                var featureToAdd = await client.Features.AddEntityFeatureAsync(GlobalAppId, versionId, entityId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                    ModelName = "parent entity"
                });

                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, featureEntity.Value);
                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void AddModelAsRequiredFeatureForEntity()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "flat entity"
                });

                var featureEntityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "feature entity"
                });

                var featureToAdd = await client.Features.AddEntityFeatureAsync(GlobalAppId, versionId, entityId, new ModelFeatureInformation
                {
                    ModelName = "feature entity",
                    IsRequired = true
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, featureEntityId);
            });
        }

        [Fact]
        public void AddModelAsFeatureForEntity()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "parent entity"
                });

                var entityFeatureId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "feature entity"
                });

                var featureToAdd = await client.Features.AddEntityFeatureAsync(GlobalAppId, versionId, entityId, new ModelFeatureInformation
                {
                    ModelName = "feature entity"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityFeatureId);
            });
        }

        [Fact]
        public void AddModelAsFeatureForIntent()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "parent intent"
                });

                var entityFeatureId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "feature entity"
                });

                var featureToAdd = await client.Features.AddIntentFeatureAsync(GlobalAppId, versionId, intentId, new ModelFeatureInformation
                {
                    ModelName = "feature entity"
                });

                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityFeatureId);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);
            });
        }

        [Fact]
        public void DeleteEntityFeature()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "parent entity"
                });

                var featureEntity = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "increment phrases",
                    Phrases = "add,increment,plus"
                });

                var featureToAdd = await client.Features.AddEntityFeatureAsync(GlobalAppId, versionId, entityId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                    ModelName = "parent entity"
                });

                await client.Model.DeleteEntityFeatureAsync(GlobalAppId, versionId, entityId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                    ModelName = "parent entity"
                });
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, featureEntity.Value);
                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void GetEntityFeatures()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "parent entity"
                });

                var featureEntity = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "increment phrases",
                    Phrases = "add,increment,plus"
                });

                var featureToAdd = await client.Features.AddEntityFeatureAsync(GlobalAppId, versionId, entityId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                });

                var features = await client.Model.GetEntityFeaturesAsync(GlobalAppId, versionId, entityId);

                Assert.Equal("increment phrases", features[0].FeatureName);


                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, featureEntity.Value);
                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void AddIntentFeature()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "parent intent"
                });

                var featureIntent = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "increment phrases",
                    Phrases = "add,increment,plus"
                });

                var featureToAdd = await client.Features.AddIntentFeatureAsync(GlobalAppId, versionId, intentId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                    ModelName = "parent intent"
                });

                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, featureIntent.Value);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);
            });
        }

        [Fact]
        public void DeleteIntentFeature()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "parent intent"
                });

                var featureEntity = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "increment phrases",
                    Phrases = "add,increment,plus"
                });

                var featureToAdd = await client.Features.AddIntentFeatureAsync(GlobalAppId, versionId, intentId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                    ModelName = "parent intent"
                });

                await client.Model.DeleteIntentFeatureAsync(GlobalAppId, versionId, intentId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                    ModelName = "parent intent"
                });
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, featureEntity.Value);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);
            });
        }

        [Fact]
        public void GetIntentFeatures()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var intentId = await client.Model.AddIntentAsync(GlobalAppId, versionId, new ModelCreateObject
                {
                    Name = "parent intent"
                });

                var featureIntent = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "increment phrases",
                    Phrases = "add,increment,plus"
                });

                var featureToAdd = await client.Features.AddIntentFeatureAsync(GlobalAppId, versionId, intentId, new ModelFeatureInformation
                {
                    FeatureName = "increment phrases",
                });

                var features = await client.Model.GetIntentFeaturesAsync(GlobalAppId, versionId, intentId);

                Assert.Equal("increment phrases", features[0].FeatureName);

                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, featureIntent.Value);
                await client.Model.DeleteIntentAsync(GlobalAppId, versionId, intentId);
            });
        }
    }
}
