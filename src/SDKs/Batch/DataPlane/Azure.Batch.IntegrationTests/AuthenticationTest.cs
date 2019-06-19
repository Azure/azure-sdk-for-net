
namespace BatchClientIntegrationTests
{
    using System;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using IntegrationTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Xunit;
    using Xunit.Abstractions;

    public class AuthenticationTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        public AuthenticationTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task CanAuthenticateToServiceWithAADToken()
        {
            Func<Task<string>> tokenProvider = () => IntegrationTestCommon.GetAuthenticationTokenAsync("https://batch.core.windows.net/");

            using (var client = BatchClient.Open(new BatchTokenCredentials(TestCommon.Configuration.BatchAccountUrl, tokenProvider)))
            {
                await client.JobOperations.ListJobs().ToListAsync();
            }
        }
    }
}