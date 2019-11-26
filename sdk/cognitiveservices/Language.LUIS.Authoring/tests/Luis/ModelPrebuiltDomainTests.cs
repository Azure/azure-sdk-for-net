namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System;
    using System.Linq;
    using Xunit;

    [Collection("TestCollection")]
    public class ModelPrebuiltDomainTests: BaseTest
    {
        [Fact]
        public void AddCustomPrebuiltDomain()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });
                var versionsApp = await client.Versions.ListAsync(testAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomainToAdd = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Communication"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(testAppId, version, prebuiltDomainToAdd);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(testAppId, version);
                await client.Model.DeleteCustomPrebuiltDomainAsync(testAppId, version, "Communication");
                await client.Apps.DeleteAsync(testAppId);

                foreach (var result in prebuiltModels)
                {
                    Assert.Contains(results, m => m == result.Id);
                }
            });
        }

        [Fact]
        public void DeleteCustomPrebuiltDomain()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });
                var versionsApp = await client.Versions.ListAsync(testAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Communication"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(testAppId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(testAppId, version);

                Assert.Contains(prebuiltModels, o => o.CustomPrebuiltDomainName == "Communication");

                await client.Model.DeleteCustomPrebuiltDomainAsync(testAppId, version, prebuiltDomain.DomainName);

                prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(testAppId, version);
                await client.Apps.DeleteAsync(testAppId);


                Assert.DoesNotContain(prebuiltModels, o => o.CustomPrebuiltDomainName == "Communication");
            });
        }

        [Fact]
        public void ListCustomPrebuiltEntities()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });
                var versionsApp = await client.Versions.ListAsync(testAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Communication"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(testAppId, version, prebuiltDomain);
                var prebuiltEntities = await client.Model.ListCustomPrebuiltEntitiesAsync(testAppId, version);
                await client.Model.DeleteCustomPrebuiltDomainAsync(testAppId, version, "Communication");
                await client.Apps.DeleteAsync(testAppId);

                Assert.Contains(prebuiltEntities, entity => entity.CustomPrebuiltDomainName == prebuiltDomain.DomainName);
            });
        }

        [Fact]
        public void AddCustomPrebuiltEntity()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltModel = new PrebuiltDomainModelCreateObject
                {
                    DomainName = "Communication",
                    ModelName = "Category"
                };

                var guidModel = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, version, prebuiltModel);
                var prebuiltEntities = await client.Model.ListCustomPrebuiltEntitiesAsync(GlobalAppId, version);
                await client.Model.DeleteEntityAsync(GlobalAppId, version, guidModel);

                Assert.Contains(prebuiltEntities, entity => entity.Id == guidModel);
            });
        }

        [Fact]
        public void ListCustomPrebuiltIntents()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });
                var versionsApp = await client.Versions.ListAsync(testAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Communication"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(testAppId, version, prebuiltDomain);
                var prebuiltIntents = await client.Model.ListCustomPrebuiltIntentsAsync(testAppId, version);
                await client.Model.DeleteCustomPrebuiltDomainAsync(testAppId, version, "Communication");
                await client.Apps.DeleteAsync(testAppId);

                Assert.Contains(prebuiltIntents, entity => entity.CustomPrebuiltDomainName == prebuiltDomain.DomainName);
            });
        }

        [Fact]
        public void AddCustomPrebuiltIntent()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltModel = new PrebuiltDomainModelCreateObject
                {
                    DomainName = "Calendar",
                    ModelName = "Cancel"
                };

                var guidModel = await client.Model.AddCustomPrebuiltIntentAsync(GlobalAppId, version, prebuiltModel);
                var prebuiltIntents = await client.Model.ListCustomPrebuiltIntentsAsync(GlobalAppId, version);
                await client.Model.DeleteIntentAsync(GlobalAppId, version, guidModel);

                Assert.Contains(prebuiltIntents, entity => entity.Id == guidModel);
            });
        }

        [Fact]
        public void ListCustomPrebuiltModels()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });
                var versionsApp = await client.Versions.ListAsync(testAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Calendar"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(testAppId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(testAppId, version);
                await client.Model.DeleteCustomPrebuiltDomainAsync(testAppId, version, "Communication");
                await client.Apps.DeleteAsync(testAppId);

                var validTypes = new string[] { "Intent Classifier", "Closed List Entity Extractor", "Entity Extractor" };

                Assert.True(prebuiltModels.All(m => validTypes.Contains(m.ReadableType)));
            });
        }
    }
}
