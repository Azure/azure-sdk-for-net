namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Newtonsoft.Json;
    using System.IO;
    using Xunit;

    public class FeaturesTests : BaseTest
    {
        [Fact]
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

                Assert.True(features.PatternFeatures.Count > 0);
                Assert.True(features.PhraselistFeatures.Count > 0);
            });
        }
    }
}
