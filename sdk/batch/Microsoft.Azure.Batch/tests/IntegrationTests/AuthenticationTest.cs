
namespace BatchClientIntegrationTests
{
    using System.Threading.Tasks;
    using BatchTestCommon;
    using IntegrationTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using Xunit;
    using Xunit.Abstractions;

    public class AuthenticationTest
    {
        [LiveTest]
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task CanAuthenticateToServiceWithAADToken()
        {
            static Task<string> tokenProvider() => IntegrationTestCommon.GetAuthenticationTokenAsync("https://batch.core.windows.net/");

            using var client = BatchClient.Open(new BatchTokenCredentials(TestCommon.Configuration.BatchAccountUrl, tokenProvider));
            await client.JobOperations.ListJobs().ToListAsync();
        }
    }
}