namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class VersionsTests: BaseTest
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void ListVersions()
        {
            UseClientFor(async client =>
            {
                var results = await client.Versions.ListAsync(GlobalAppId);

                Assert.True(results.Count > 0);
                foreach (var version in results)
                {
                    Assert.NotNull(version.Version);
                }
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                foreach (var version in versions)
                {
                    var result = await client.Versions.GetAsync(GlobalAppId, version.Version);
                    Assert.Equal(version.Version, result.Version);
                    Assert.Equal(version.TrainingStatus, result.TrainingStatus);
                }
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var first = versions.FirstOrDefault();
                var versionToUpdate = new TaskUpdateObject
                {
                    Version = "test"
                };

                await client.Versions.UpdateAsync(GlobalAppId, first.Version, versionToUpdate);
                var versionsWithUpdate = await client.Versions.ListAsync(GlobalAppId);

                Assert.Contains(versionsWithUpdate, v => v.Version.Equals(versionToUpdate.Version));
                Assert.DoesNotContain(versionsWithUpdate, v => v.Version.Equals(first.Version));

                await client.Versions.UpdateAsync(GlobalAppId, versionToUpdate.Version, new TaskUpdateObject
                {
                    Version = first.Version
                });
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                var newVersion = await client.Versions.CloneAsync(GlobalAppId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.ListAsync(GlobalAppId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(newVersion));

                await client.Versions.DeleteAsync(GlobalAppId, newVersion);

                var versionsWithoutTest = await client.Versions.ListAsync(GlobalAppId);

                Assert.DoesNotContain(versionsWithoutTest, v => v.Version.Equals(newVersion));
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void CloneVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                Assert.DoesNotContain(versions, v => v.Version.Equals(testVersion.Version));

                var newVersion = await client.Versions.CloneAsync(GlobalAppId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.ListAsync(GlobalAppId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(newVersion));

                await client.Versions.DeleteAsync(GlobalAppId, newVersion);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void ListVersions_ErrorSubscriptionKey()
        {
            var headers = new Dictionary<string, List<string>>
            {
                { "Ocp-Apim-Subscription-Key", new List<string> { "3eff76bb229942899255402725b72933" } }
            };
            var errorCode = "401";
            UseClientFor(async client =>
            {
                var exception = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.ListWithHttpMessagesAsync(GlobalAppId, customHeaders: headers));
                var error = exception.Body;

                Assert.Equal(errorCode, error.Code);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void ListVersions_ErrorAppId()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var exception = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.ListAsync(GlobalAppIdError));
                var error = exception.Body;

                Assert.Equal(errorCode, error.Code);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void GetVersion_ErrorVersion()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var errorVersion = versions.FirstOrDefault().Version + "_";
                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.GetAsync(GlobalAppId, errorVersion));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void UpdateVersion_ErrorModel()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var first = versions.FirstOrDefault();
                var versionToUpdate = new TaskUpdateObject
                {
                    Version = ""
                };

                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.UpdateAsync(GlobalAppId, first.Version, versionToUpdate));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void DeleteVersion_ErrorModel()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var first = versions.FirstOrDefault();

                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.DeleteAsync(GlobalAppId, first.Version + "0"));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
            });
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
        public void CloneVersion_ErrorModel()
        {
            var errorCode = "BadArgument";
            UseClientFor(async client =>
            {
                var versions = await client.Versions.ListAsync(GlobalAppId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = ""
                };

                Assert.DoesNotContain(versions, v => v.Version.Equals(testVersion.Version));

                var exeption = await Assert.ThrowsAsync<ErrorResponseException>(async () => await client.Versions.CloneAsync(GlobalAppId, first.Version, testVersion));
                var error = exeption.Body;

                Assert.Equal(errorCode, error.Code);
            });
        }
    }
}
