namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class VersionsTests: BaseTest
    {
        [Fact]
        public void ListVersions()
        {
            UseClientFor(async client =>
            {
                var results = await client.Versions.ListAsync(appId);

                Assert.True(results.Count > 0);
                foreach (var version in results)
                {
                    Assert.NotNull(version.Version);
                }
            });
        }

        [Fact]
        public void GetVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                foreach (var version in versions)
                {
                    var result = await client.Versions.GetAsync(appId, version.Version);
                    Assert.Equal(version.Version, result.Version);
                    Assert.Equal(version.TrainingStatus, result.TrainingStatus);
                }
            });
        }

        [Fact]
        public void UpdateVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var versionToUpdate = new TaskUpdateObject
                {
                    Version = "test"
                };

                await client.Versions.UpdateAsync(appId, first.Version, versionToUpdate);
                var versionsWithUpdate = await client.Versions.ListAsync(appId);

                Assert.Contains(versionsWithUpdate, v => v.Version.Equals(versionToUpdate.Version));
                Assert.DoesNotContain(versionsWithUpdate, v => v.Version.Equals(first.Version));

                await client.Versions.UpdateAsync(appId, versionToUpdate.Version, new TaskUpdateObject
                {
                    Version = first.Version
                });
            });
        }

        [Fact]
        public void DeleteVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                var newVersion = await client.Versions.CloneAsync(appId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.ListAsync(appId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(newVersion));

                await client.Versions.DeleteAsync(appId, newVersion);

                var versionsWithoutTest = await client.Versions.ListAsync(appId);

                Assert.DoesNotContain(versionsWithoutTest, v => v.Version.Equals(newVersion));
            });
        }

        [Fact]
        public void CloneVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                Assert.DoesNotContain(versions, v => v.Version.Equals(testVersion.Version));

                var newVersion = await client.Versions.CloneAsync(appId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.ListAsync(appId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(newVersion));

                await client.Versions.DeleteAsync(appId, newVersion);
            });
        }

        [Fact]
        public void DeleteUnlabelledUtterance()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var versionId = versions.FirstOrDefault().Version;
                var intents = await client.Model.ListIntentsAsync(appId, versionId);
                var intentId = intents.FirstOrDefault().Id;

                var suggestions = await client.Model.GetIntentSuggestionsAsync(appId, versionId, intentId);

                var utteranceToDelete = suggestions.FirstOrDefault().Text;

                await client.Versions.DeleteUnlabelledUtteranceAsync(appId, versionId, utteranceToDelete);

                var suggestionsWithoutDeleted = await client.Model.GetIntentSuggestionsAsync(appId, versionId, intentId);

                Assert.DoesNotContain(suggestionsWithoutDeleted, v => v.Text.Equals(utteranceToDelete));
            });
        }

        [Fact]
        public void ListVersions_ErrorSubscriptionKey()
        {
            var headers = new Dictionary<string, List<string>>
            {
                { "Ocp-Apim-Subscription-Key", new List<string> { "3eff76bb229942899255402725b72933" } }
            };
            var errorCode = "401";
            UseClientFor(async client =>
            {
                var exception = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.ListWithHttpMessagesAsync(appId, customHeaders: headers));
                var error = exception.Body;

                Assert.Equal(errorCode, error.Code);
                Assert.Contains("subscription key", error.Message);
            });
        }

        [Fact]
        public void ListVersions_ErrorAppId()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var exception = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.ListAsync(appId_error));
                var error = exception.Body;

                Assert.Equal(errorCode, error.Code);
                Assert.Contains("application", error.Message);
            });
        }

        [Fact]
        public void GetVersion_ErrorVersion()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var errorVersion = versions.FirstOrDefault().Version + "_";
                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.GetAsync(appId, errorVersion));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
                Assert.Contains("task", error.Message);
            });
        }

        [Fact]
        public void UpdateVersion_ErrorModel()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var versionToUpdate = new TaskUpdateObject
                {
                    Version = ""
                };

                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.UpdateAsync(appId, first.Version, versionToUpdate));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
                Assert.Contains("Version Id", error.Message);
            });
        }

        [Fact]
        public void DeleteVersion_ErrorModel()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();

                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.DeleteAsync(appId, first.Version + "0"));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
                Assert.Contains("task", error.Message);
            });
        }

        [Fact]
        public void CloneVersion_ErrorModel()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(appId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = ""
                };

                Assert.DoesNotContain(versions, v => v.Version.Equals(testVersion.Version));

                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.CloneAsync(appId, first.Version, testVersion));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
                Assert.Contains("Version Id", error.Message);
            });
        }
    }
}
