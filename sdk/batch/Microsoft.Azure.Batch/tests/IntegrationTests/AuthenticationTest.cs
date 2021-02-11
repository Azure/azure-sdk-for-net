
namespace BatchClientIntegrationTests
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using BatchClientIntegrationTests.IntegrationTestUtilities;
    using BatchTestCommon;
    using IntegrationTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using Xunit;

    public class AuthenticationTest
    {
        private string invalidUrl = "https://fakeurl.batchintegrationtesting.com";

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task CanAuthenticateToServiceWithAADToken()
        {
            static Task<string> tokenProvider() => IntegrationTestCommon.GetAuthenticationTokenAsync("https://batch.core.windows.net/");

            using var client = BatchClient.Open(new BatchTokenCredentials(TestCommon.Configuration.BatchAccountUrl, tokenProvider));
            await client.JobOperations.ListJobs().ToListAsync();
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task CanAuthenticateToServiceWithSharedKeyCredentials()
        {
            BatchSharedKeyCredentials credentials = TestUtilities.GetCredentialsFromEnvironment();

            using var client = BatchClient.Open(credentials);
            await client.JobOperations.ListJobs().ToListAsync();
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BadAccountUrlThrows()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                $"{TestCommon.Configuration.BatchAccountUrl}/badendpoint",
                TestCommon.Configuration.BatchAccountName,
                TestCommon.Configuration.BatchAccountKey);

            using var client = BatchClient.Open(credentials);
            await TestUtilities.AssertThrowsAsync<BatchException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task InvalidAccountUrlThrows()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                invalidUrl,
                TestCommon.Configuration.BatchAccountName,
                TestCommon.Configuration.BatchAccountKey);

            using var client = BatchClient.Open(credentials);
            await TestUtilities.AssertThrowsAsync<HttpRequestException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BadAccountNameThrows()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                TestCommon.Configuration.BatchAccountUrl,
                "BadAccountName",
                TestCommon.Configuration.BatchAccountKey);

            using var client = BatchClient.Open(credentials);
            await TestUtilities.AssertThrowsAsync<BatchException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task InvalidAccountKeyThrows()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                TestCommon.Configuration.BatchAccountUrl,
                TestCommon.Configuration.BatchAccountName,
                Convert.ToBase64String(Encoding.UTF8.GetBytes("InvalidAccountKey")));

            using var client = BatchClient.Open(credentials);
            await TestUtilities.AssertThrowsAsync<BatchException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task BadAccountKeyThrows()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                TestCommon.Configuration.BatchAccountUrl,
                TestCommon.Configuration.BatchAccountName,
                "BadAccountKey");

            using var client = BatchClient.Open(credentials);
            await TestUtilities.AssertThrowsAsync<FormatException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task BadTokenHostThrows()
        {
            static Task<string> tokenProvider() => IntegrationTestCommon.GetAuthenticationTokenAsync("https://batch.core.windows.net/");

            using var client = BatchClient.Open(new BatchTokenCredentials(invalidUrl, tokenProvider));
            await TestUtilities.AssertThrowsAsync<HttpRequestException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }

        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BadTokenThrows()
        {
            using var client = BatchClient.Open(new BatchTokenCredentials(TestCommon.Configuration.BatchAccountUrl, "BadToken"));
            await TestUtilities.AssertThrowsAsync<BatchException>(async () => await client.JobOperations.ListJobs().ToListAsync());
        }
    }
}