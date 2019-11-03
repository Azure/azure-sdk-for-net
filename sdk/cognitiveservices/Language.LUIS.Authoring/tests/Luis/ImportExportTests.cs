namespace LUIS.Authoring.Tests.Luis
{
    using System.IO;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Newtonsoft.Json;
    using Xunit;

    [Collection("TestCollection")]
    public class ImportExportTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void ExportVersion()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "LUIS App to be exported",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var app = await client.Versions.ExportAsync(appId, versionId);

                await client.Apps.DeleteAsync(appId);

                Assert.NotNull(app);
                Assert.Equal("LUIS App to be exported", app.Name);
            });
        }

        [Fact]
        public void ImportVersion()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportApp.json"));
            var app = JsonConvert.DeserializeObject<LuisApp>(appJson);

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Import Version Test LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var newVersion = await client.Versions.ImportAsync(testAppId, app, "0.2");

                await client.Apps.DeleteAsync(testAppId);

                Assert.Equal("0.2", newVersion);
            });
        }

        [Fact]
        public void ImportApp()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportApp.json"));
            var app = JsonConvert.DeserializeObject<LuisApp>(appJson);

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.ImportAsync(app, "Test Import LUIS App");
                var testApp = await client.Apps.GetAsync(testAppId);
                await client.Apps.DeleteAsync(testAppId);

                Assert.NotNull(testApp);
            });
        }

        [Fact]
        public void ImportAppWithEnabledForAllModels()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportAppWithEnabledForAllModels.json"));
            var app = JsonConvert.DeserializeObject<LuisApp>(appJson);

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.ImportAsync(app, "Test Import LUIS App With Enabled For All Models");
                var testApp = await client.Apps.GetAsync(testAppId);
                await client.Apps.DeleteAsync(testAppId);

                Assert.NotNull(testApp);
            });
        }
    }
}
