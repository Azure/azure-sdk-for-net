using Microsoft.Azure.OperationalInsights;
using Microsoft.Azure.OperationalInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OperationalInsights.Data.Test.ScenarioTests
{
    public class QueryTests : TestBase
    {
        delegate Task<Microsoft.Rest.HttpOperationResponse<QueryResults>> ExecuteQuery(OperationalInsightsDataClient client);

        private const int TakeCount = 25;
        private readonly string SimpleQuery = $"union * | take {TakeCount}";
        private readonly TimeSpan PastHourTimespan = new TimeSpan(1, 0, 0);

        private const string DefaultWorkspaceId = "DEMO_WORKSPACE";
        private const string DefaultApiKey = "DEMO_KEY";

        static QueryTests() {
            //Uncomment this to regenerate the SessionRecords
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
        }

        [Fact]
        public async Task CanExecuteSimplePostQuery_DemoWorkspace()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                await ExecuteAndVerify(async (client) => await client.QueryWithHttpMessagesAsync(SimpleQuery), ctx);
            }
        }

        [Fact]
        public async Task CanExecutePostQueryWithTimespan_DemoWorkspace()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                await ExecuteAndVerify(async (client) => await client.QueryWithHttpMessagesAsync(SimpleQuery, PastHourTimespan), ctx);
            }
        }

        [Fact]
        public async Task GetsExceptionWithSyntaxError()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                var client = GetClient(ctx);
                var badQuery = "union * | foobar";

                try
                {
                    await client.QueryWithHttpMessagesAsync(badQuery, PastHourTimespan);
                    Assert.True(false, "An exception should have been thrown.");
                }
                catch (ErrorResponseException e)
                {
                    Assert.Equal(System.Net.HttpStatusCode.BadRequest, e.Response.StatusCode);
                    Assert.Equal("BadArgumentError", e.Body.Error.Code);
                    Assert.Equal("SyntaxError", e.Body.Error.Innererror.Code);
                }
                catch (Exception e)
                {
                    Assert.True(false, $"Expected an {nameof(ErrorResponseException)} but got a {e.GetType().Name}: {e.Message}");
                }
            }
        }

        [Fact]
        public async Task GetsExceptionWithShortWait()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                var client = GetClient(ctx);
                client.Preferences.Wait = 1;

                var longQuery = "union *";
                var longTimespan = new TimeSpan(24, 0, 0);

                try
                {
                    await client.QueryWithHttpMessagesAsync(longQuery, longTimespan);
                    Assert.True(false, "An exception should have been thrown.");
                }
                catch (ErrorResponseException e)
                {
                    Assert.Equal(System.Net.HttpStatusCode.GatewayTimeout, e.Response.StatusCode);
                    Assert.Equal("GatewayTimeout", e.Body.Error.Code);
                    Assert.Equal("ServiceError", e.Body.Error.Innererror.Code);
                }
                catch (Exception e)
                {
                    Assert.True(false, $"Expected an {nameof(ErrorResponseException)} but got a {e.GetType().Name}: {e.Message}");
                }
            }
        }

        private OperationalInsightsDataClient GetClient(MockContext ctx, string workspaceId = DefaultWorkspaceId, string apiKey = DefaultApiKey)
        {
            var credentials = new ApiKeyClientCredentials(apiKey);
            var client = new OperationalInsightsDataClient(credentials, HttpMockServer.CreateInstance());
            client.WorkspaceId = workspaceId;

            return client;
        }

        private async Task ExecuteAndVerify(ExecuteQuery runQuery, MockContext ctx, string workspaceId = DefaultWorkspaceId, string apiKey = DefaultApiKey)
        {
            var client = GetClient(ctx, workspaceId, apiKey);
            client.Preferences.IncludeStatistics = true;
            client.Preferences.IncludeRender = true;

            client.WorkspaceId = workspaceId;

            var response = await runQuery.Invoke(client);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.Response.StatusCode);
            Assert.Equal("OK", response.Response.ReasonPhrase);
            Assert.True(response.Body.Tables.Count > 0, "Table count isn't greater than 0");
            Assert.False(String.IsNullOrWhiteSpace(response.Body.Tables[0].Name), "Table name was null/empty");
            Assert.True(response.Body.Tables[0].Columns.Count > 1, "Column count isn't greater than 1");
            Assert.True(response.Body.Tables[0].Rows.Count > 1, "Row count isn't greater than 1");

            var resultArray = response.Body.Tables[0].Rows;
            Assert.NotNull(resultArray);
            Assert.Equal(TakeCount, resultArray.Count);

            Assert.NotNull(response.Body.Statistics);
            Assert.NotNull(response.Body.Render);
        }
    }
}
