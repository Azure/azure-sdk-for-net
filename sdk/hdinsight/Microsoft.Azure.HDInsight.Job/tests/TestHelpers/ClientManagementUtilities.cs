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

namespace Microsoft.Azure.HDInsight.Job.Tests
{
    using Microsoft.Azure.HDInsight.Job;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Globalization;

    public static class ClientManagementUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A management client, created from the current context (environment variables)</returns>
        public static TServiceClient GetServiceClient<TServiceClient>(this TestBase testBase, MockContext context) where TServiceClient : class, IDisposable
        {
            return context.GetServiceClient<TServiceClient>();
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testFixture">the test class</param>
        /// <returns>A HDInsight job management client, created from the current context (environment variables)</returns>
        public static HDInsightJobClient GetHDInsightJobClient(this CommonTestsFixture testFixture, MockContext context)
        {
            var credentials = new BasicAuthenticationCredentials
            {
                UserName = testFixture.HttpUserName,
                Password = testFixture.HttpUserPassword
            };

            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var client = context.GetServiceClientWithCredentials<HDInsightJobClient>(currentEnvironment, credentials, true);
            client.Endpoint = testFixture.HDInsightClusterUrl;
            client.Username = CultureInfo.CurrentCulture.TextInfo.ToLower(credentials.UserName);
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testFixture">the test class</param>
        /// <returns>A HDInsight spark job management client, created from the current context (environment variables)</returns>
        public static HDInsightJobClient GetHDInsightSparkJobClient(this SparkJobTestsFixture testFixture, MockContext context)
        {
            var credentials = new BasicAuthenticationCredentials
            {
                UserName = testFixture.HttpUserName,
                Password = testFixture.HttpUserPassword
            };

            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var client = context.GetServiceClientWithCredentials<HDInsightJobClient>(currentEnvironment, credentials, true);
            client.Endpoint = testFixture.HDInsightClusterUrl;
            client.Username = CultureInfo.CurrentCulture.TextInfo.ToLower(credentials.UserName);
            return client;
        }
    }
}
