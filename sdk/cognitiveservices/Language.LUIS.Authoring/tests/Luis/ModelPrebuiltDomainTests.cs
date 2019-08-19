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
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomainToAdd = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(GlobalAppId, version, prebuiltDomainToAdd);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(GlobalAppId, version);

                foreach (var result in results)
                {
                    Assert.True(result != Guid.Empty);
                    Assert.Contains(prebuiltModels, m => m.Id.Equals(result));
                }
            });
        }

        [Fact]
        public void DeleteCustomPrebuiltDomain()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(GlobalAppId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(GlobalAppId, version);

                Assert.Contains(prebuiltModels, o => o.CustomPrebuiltDomainName == "Gaming");

                await client.Model.DeleteCustomPrebuiltDomainAsync(GlobalAppId, version, prebuiltDomain.DomainName);

                prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(GlobalAppId, version);

                Assert.DoesNotContain(prebuiltModels, o => o.CustomPrebuiltDomainName == "Gaming");
            });
        }

        [Fact]
        public void ListCustomPrebuiltEntities()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(GlobalAppId, version, prebuiltDomain);
                var prebuiltEntities = await client.Model.ListCustomPrebuiltEntitiesAsync(GlobalAppId, version);

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
                    DomainName = "Camera",
                    ModelName = "AppName"
                };

                var guidModel = await client.Model.AddCustomPrebuiltEntityAsync(GlobalAppId, version, prebuiltModel);
                var prebuiltEntities = await client.Model.ListCustomPrebuiltEntitiesAsync(GlobalAppId, version);

                Assert.Contains(prebuiltEntities, entity => entity.Id == guidModel);
            });
        }

        [Fact]
        public void ListCustomPrebuiltIntents()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(GlobalAppId, version, prebuiltDomain);
                var prebuiltIntents = await client.Model.ListCustomPrebuiltIntentsAsync(GlobalAppId, version);

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
                    ModelName = "Add"
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
                var versionsApp = await client.Versions.ListAsync(GlobalAppId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Calendar"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(GlobalAppId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(GlobalAppId, version);
                
                var validTypes = new string[] { "Intent Classifier", "Entity Extractor" };

                Assert.True(prebuiltModels.All(m => validTypes.Contains(m.ReadableType)));
            });
        }
    }
}
