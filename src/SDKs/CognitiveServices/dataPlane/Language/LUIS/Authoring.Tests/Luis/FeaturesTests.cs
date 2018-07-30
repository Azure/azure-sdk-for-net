namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Xunit;

    public class FeaturesTests : BaseTest
    {
        [Fact]
        public void ListFeatures()
        {
            UseClientFor(async client =>
            {
                var version = "0.1";
                var features = await client.Features.ListAsync(appId, version);

                Assert.True(features.PatternFeatures.Count > 0);
                Assert.True(features.PhraselistFeatures.Count > 0);
            });
        }
    }
}
