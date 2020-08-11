namespace LUIS.Authoring.Tests.Luis
{
    using System.IO;
    using System.Text;
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
        public void ExportAppVersionLuFormat()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "LUIS App to be exported in Lu format",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var app = await client.Versions.ExportLuFormatAsync(appId, versionId);

                await client.Apps.DeleteAsync(appId);

                var buffer = new byte[app.Length];

                app.Read(buffer, 0, (int)app.Length);

                var f = Encoding.UTF8.GetString(buffer);
                //LocalEncoding.GetString(stream.ToArray());
                Assert.NotNull(app);
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
        public void ImportAppVersionV2()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportV2App.json"));
            var app = JsonConvert.DeserializeObject<LuisAppV2>(appJson);

            UseClientFor(async client =>
            {
                const string VersionId = "0.2";
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Import Version Test LUIS App V2",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var newImportedVersion = await client.Versions.ImportV2AppAsync(testAppId, app, VersionId);
                var importedVerion = await client.Versions.GetAsync(testAppId, VersionId);
                await client.Apps.DeleteAsync(testAppId);

                Assert.NotNull(importedVerion);
                Assert.Equal(importedVerion.Version, VersionId);
            });
        }

       [Fact]
        public void ImportAppVersionLuFormat()
        {
            const string VersionId = "0.2";
            var appText = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportLuApp.json")).ToString();

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Import Version Test LUIS App V2",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });


                var newVersion = await client.Versions.ImportLuFormatAsync(testAppId, appText, VersionId);
                await client.Apps.DeleteAsync(testAppId);

                Assert.Equal(VersionId, newVersion);
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
        public void ImportAppV2()
        {
            var appJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportV2App.json"));
            var app = JsonConvert.DeserializeObject<LuisAppV2>(appJson);

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.ImportV2AppAsync(app, "Test Import LUIS App V2");
                var testApp = await client.Apps.GetAsync(testAppId);
                await client.Apps.DeleteAsync(testAppId);

                Assert.NotNull(testApp);
            });
        }

        [Fact]
        public void ImportAppLuFormat()
        {
            var appText = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SessionRecords/ImportLuApp.json")).ToString();

            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.ImportLuFormatAsync(appText, "Test Import LUIS App Lu format");
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
