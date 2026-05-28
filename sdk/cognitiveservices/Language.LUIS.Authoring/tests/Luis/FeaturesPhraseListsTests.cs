namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class FeaturesPhraseListsTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void AddPhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrases = await client.Features.GetPhraseListAsync(GlobalAppId, versionId, id.Value);
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, id.Value);

                Assert.NotNull(phrases);
                Assert.Equal("DayOfWeek", phrases.Name);
                Assert.Equal("monday,tuesday,wednesday,thursday,friday,saturday,sunday", phrases.Phrases);
            });
        }

        [Fact]
        public void ListPhraseLists()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrases = await client.Features.ListPhraseListsAsync(GlobalAppId, versionId);
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, id.Value);

                Assert.True(phrases.Count > 0);
            });
        }

        [Fact]
        public void GetPhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrase = await client.Features.GetPhraseListAsync(GlobalAppId, versionId, id.Value);
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, id.Value);

                Assert.Equal("DayOfWeek", phrase.Name);
                Assert.True(phrase.IsActive);
                Assert.True(phrase.IsExchangeable);
            });
        }

        [Fact (Skip = "Problem from API")]
        public void UpdatePhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                await client.Features.UpdatePhraseListAsync(GlobalAppId, versionId, id.Value, new PhraselistUpdateObject
                {
                    IsActive = false,
                    Name = "Month",
                    Phrases = "january,february,march,april,may,june,july,august,september,october,november,december"
                });

                var updated = await client.Features.GetPhraseListAsync(GlobalAppId, versionId, id.Value);
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, id.Value);

                Assert.Equal("Month", updated.Name);
                Assert.Equal("january,february,march,april,may,june,july,august,september,october,november,december", updated.Phrases);
                Assert.False(updated.IsActive);
            });
        }

        [Fact]
        public void AddPhraseListWithEnabledForAllModels()
        {
            UseClientFor(async client =>
            {
                var entityId = await client.Model.AddEntityAsync(GlobalAppId, versionId, new EntityModelCreateObject
                {
                    Name = "entity added"
                });

                var id = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true,
                    EnabledForAllModels = true
                });

                var features = await client.Model.GetEntityFeaturesAsync(GlobalAppId, versionId, entityId);

                Assert.Equal("DayOfWeek", features[0].FeatureName);
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, id.Value);
                await client.Model.DeleteEntityAsync(GlobalAppId, versionId, entityId);
            });
        }

        [Fact]
        public void DeletePhraseList()
        {
            UseClientFor(async client =>
            {
                var id = await client.Features.AddPhraseListAsync(GlobalAppId, versionId, new PhraselistCreateObject
                {
                    Name = "DayOfWeek",
                    Phrases = "monday,tuesday,wednesday,thursday,friday,saturday,sunday",
                    IsExchangeable = true
                });

                var phrase = await client.Features.GetPhraseListAsync(GlobalAppId, versionId, id.Value);
                await client.Features.DeletePhraseListAsync(GlobalAppId, versionId, id.Value);

                var phrases = await client.Features.ListPhraseListsAsync(GlobalAppId, versionId);

                Assert.DoesNotContain(phrases, o => o.Id == id);
            });
        }
    }
}
