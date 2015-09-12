//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Modified from the following source by Mark Cowlishaw <Mark.Cowlishaw@microsoft.com>
// https://github.com/Azure/azure-sdk-for-net/pull/1379/files

using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;

namespace Compute.Tests
{
    public class ServicePrincipalNameFactory : TestEnvironmentFactory
    {
        private const string ClientSecretKey = "ApplicationSecret";
        private const string CsmSpnAuthEnvVariableName = "TEST_CSM_SPN_AUTHENTICATION";
        private const string CsmSpnAudienceUri = "https://management.core.windows.net/";

        protected override TestEnvironment GetTestEnvironmentFromContext()
        {
            return this.GetCustomTestEnvironment(CsmSpnAuthEnvVariableName);
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
                        token = AuthenticationHelper.GetTokenForSpn(testEnv.Endpoints.AADAuthUri.ToString(), CsmSpnAudienceUri, testEnv.Tenant, testEnv.ClientId, secret);
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
