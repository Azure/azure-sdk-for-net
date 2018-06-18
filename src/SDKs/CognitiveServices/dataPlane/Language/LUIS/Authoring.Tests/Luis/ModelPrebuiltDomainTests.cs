namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class ModelPrebuiltDomainTests: BaseTest
    {
        [Fact]
        public void AddCustomPrebuiltDomain()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomainToAdd = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(appId, version, prebuiltDomainToAdd);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(appId, version);

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
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(appId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(appId, version);

                Assert.Contains(prebuiltModels, o => o.CustomPrebuiltDomainName == "Gaming");

                await client.Model.DeleteCustomPrebuiltDomainAsync(appId, version, prebuiltDomain.DomainName);

                prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(appId, version);

                Assert.DoesNotContain(prebuiltModels, o => o.CustomPrebuiltDomainName == "Gaming");
            });
        }

        [Fact]
        public void ListCustomPrebuiltEntities()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(appId, version, prebuiltDomain);
                var prebuiltEntities = await client.Model.ListCustomPrebuiltEntitiesAsync(appId, version);

                Assert.Contains(prebuiltEntities, entity => entity.CustomPrebuiltDomainName == prebuiltDomain.DomainName);
            });
        }

        [Fact]
        public void AddCustomPrebuiltEntity()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltModel = new PrebuiltDomainModelCreateObject
                {
                    DomainName = "Camera",
                    ModelName = "AppName"
                };

                var guidModel = await client.Model.AddCustomPrebuiltEntityAsync(appId, version, prebuiltModel);
                var prebuiltEntities = await client.Model.ListCustomPrebuiltEntitiesAsync(appId, version);

                Assert.Contains(prebuiltEntities, entity => entity.Id == guidModel);
            });
        }

        [Fact]
        public void ListCustomPrebuiltIntents()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Gaming"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(appId, version, prebuiltDomain);
                var prebuiltIntents = await client.Model.ListCustomPrebuiltIntentsAsync(appId, version);

                Assert.Contains(prebuiltIntents, entity => entity.CustomPrebuiltDomainName == prebuiltDomain.DomainName);
            });
        }

        [Fact]
        public void AddCustomPrebuiltIntent()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltModel = new PrebuiltDomainModelCreateObject
                {
                    DomainName = "Calendar",
                    ModelName = "Add"
                };

                var guidModel = await client.Model.AddCustomPrebuiltIntentAsync(appId, version, prebuiltModel);
                var prebuiltIntents = await client.Model.ListCustomPrebuiltIntentsAsync(appId, version);

                await client.Model.DeleteIntentAsync(appId, version, guidModel);

                Assert.Contains(prebuiltIntents, entity => entity.Id == guidModel);
            });
        }

        [Fact]
        public void ListCustomPrebuiltModels()
        {
            UseClientFor(async client =>
            {
                var versionsApp = await client.Versions.ListAsync(appId);
                var version = versionsApp.FirstOrDefault().Version;
                var prebuiltDomain = new PrebuiltDomainCreateBaseObject
                {
                    DomainName = "Calendar"
                };

                var results = await client.Model.AddCustomPrebuiltDomainAsync(appId, version, prebuiltDomain);
                var prebuiltModels = await client.Model.ListCustomPrebuiltModelsAsync(appId, version);
                
                var validTypes = new string[] { "Intent Classifier", "Entity Extractor" };

                Assert.True(prebuiltModels.All(m => validTypes.Contains(m.ReadableType)));
            });
        }
    }
}
