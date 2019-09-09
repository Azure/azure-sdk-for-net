using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Data.ApplicationInsights.Tests
{
    public class QueryTests : DataPlaneTestBase
    {
        delegate Task<Microsoft.Rest.HttpOperationResponse<QueryResults>> ExecuteQuery(ApplicationInsightsDataClient client);

        private const int TakeCount = 25;
        private readonly string SimpleQuery = $"union * | take {TakeCount}";
        private readonly string PastHourTimespan = "PT1H";

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task CanExecuteSimplePostQuery_DemoWorkspace()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                await ExecuteAndVerify(async (client) => await client.Query.ExecuteWithHttpMessagesAsync(DefaultAppId, SimpleQuery), ctx: ctx);
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task CanExecutePostQueryWithTimespan_DemoWorkspace()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                await ExecuteAndVerify(async (client) => await client.Query.ExecuteWithHttpMessagesAsync(DefaultAppId, SimpleQuery, PastHourTimespan), ctx: ctx);
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetsExceptionWithSyntaxError()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var client = GetClient(ctx: ctx);
                var badQuery = "union * | foobar";

                try
                {
                    await client.Query.ExecuteWithHttpMessagesAsync(DefaultAppId, badQuery, PastHourTimespan);
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

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetsExceptionWithShortWait()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var client = GetClient(ctx);
                client.Preferences.Wait = 1;

                var longQuery = "union * | order by operation_Id | order by timestamp | order by operation_Id | order by timestamp | order by operation_Id | order by timestamp | order by operation_Id | order by timestamp";

                try
                {
                    var result = await client.Query.ExecuteWithHttpMessagesAsync(DefaultAppId, longQuery, customHeaders: new Dictionary<string, List<string>> { { "Cache-Control", new List<string> { "no-cache" } } });
                    Assert.True(false, "An exception should have been thrown.");
                }
                catch (ErrorResponseException e)
                {
                    Assert.Equal(System.Net.HttpStatusCode.GatewayTimeout, e.Response.StatusCode);
                    Assert.Equal("GatewayTimeout", e.Body.Error.Code);
                    Assert.Equal("GatewayTimeout", e.Body.Error.Innererror.Code);
                }
                catch (Exception e)
                {
                    Assert.True(false, $"Expected an {nameof(ErrorResponseException)} but got a {e.GetType().Name}: {e.Message}");
                }
            }
        }

        private async Task ExecuteAndVerify(ExecuteQuery runQuery, MockContext ctx, string appId = DefaultAppId, string apiKey = DefaultApiKey)
        {
            var client = GetClient(ctx, appId, apiKey);
            client.Preferences.IncludeStatistics = true;
            client.Preferences.IncludeRender = true;

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
