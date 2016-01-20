using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.Authentication;
using Microsoft.Azure.Test.HttpRecorder;

namespace Helpers
{
    public class CsmSpnFactory : TestEnvironmentFactory
    {
        private const string ClientSecretKey = "ApplicationSecret";
        protected override TestEnvironment GetTestEnvironmentFromContext()
        {
            return this.GetCustomTestEnvironment("TEST_CSM_SPN_AUTHENTICATION");
        }

        protected TestEnvironment GetCustomTestEnvironment(string envVariableName)
        {
            string connectionString = Environment.GetEnvironmentVariable(envVariableName);
            IDictionary<string, string> parsedConnection = TestUtilities.ParseConnectionString(connectionString);
            TestEnvironment testEnv = new TestEnvironment(parsedConnection, ExecutionMode.CSM);
            string token = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                token = TestEnvironment.RawTokenDefault;
                testEnv.UserName = TestEnvironment.UserIdDefault;
                SetEnvironmentSubscriptionId(testEnv, connectionString);
                testEnv.Credentials = new TokenCloudCredentials(testEnv.SubscriptionId, token);
            }
            else //Record or None
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    if (parsedConnection.ContainsKey(TestEnvironment.RawToken))
                    {
                        token = parsedConnection[TestEnvironment.RawToken];
                    }
                    else if (parsedConnection.ContainsKey(ClientSecretKey))
                    {
                        var secret = parsedConnection[ClientSecretKey];
                        TracingAdapter.Information("Using AAD auth with appid and secret combination");
                        token = AuthenticationHelper.GetTokenForSpn(testEnv.Endpoints.AADAuthUri.ToString(), "https://management.core.windows.net/", testEnv.Tenant, testEnv.ClientId, secret );
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("{0} Must Contain {1} to use SPN Credentials in tests", envVariableName, ClientSecretKey));
                    }
                }
                else
                {
                        throw new InvalidOperationException(string.Format("{0} Must Contain {1} to use SPN Credentials in tests", envVariableName, ClientSecretKey));
                }

                SetEnvironmentSubscriptionId(testEnv, connectionString);

                if (testEnv.SubscriptionId == null)
                {
                    throw new Exception("Subscription Id was not provided in environment variable. " + "Please set " + 
                                        "the envt. variable - TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=<subscription-id>");
                }

                testEnv.Credentials = new TokenCloudCredentials(testEnv.SubscriptionId, token);
            }

            return testEnv;
        }

    }
}
