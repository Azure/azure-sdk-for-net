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
    using System;
    using System.Globalization;
    using System.Net.Http;
    using Xunit;

    public class CustomizationTests
    {
        [Fact]
        public void CheckEmptySdkVersion()
        {
            var client = GetHDInsightUnitTestingJobClient();
            Assert.NotEmpty(client.UserAgent);
        }

        [Fact]
        public void CheckValidJobUserName()
        {
            var credentials = new BasicAuthenticationCredentials
            {
                UserName = "Admin",
                Password = ""
            };

            var client = new HDInsightJobClient("TestCluster", credentials);
            Assert.Equal(credentials.UserName.ToLower(CultureInfo.CurrentCulture), client.Username);

            client = new HDInsightJobClient("TestCluster", credentials, new HttpClient());
            Assert.Equal(credentials.UserName.ToLower(CultureInfo.CurrentCulture), client.Username);
        }

        [Fact]
        public void ValidateJobClientHttpTimeOut()
        {
            var client = GetHDInsightUnitTestingJobClient();

            // The default Http client time out would be MaxBackOff (8min) + 2 mins for HDinsight gateway
            // time out and having 1 min extra buffer.
            Assert.True(TimeSpan.Compare(client.HttpClient.Timeout, TimeSpan.FromMinutes(11)) == 0);
        }

        [Fact]
        public void KillEmptyNameJob()
        {
            var client = GetHDInsightUnitTestingJobClient();
            var exceptionMessage = string.Empty;

            try
            {
                var job = client.Job.Kill(string.Empty);
            }
            catch (ValidationException ex)
            {
                exceptionMessage = ex.Message;
            }

            Assert.Equal("'jobId' is less than minimum length of '1'.", exceptionMessage);
        }

        private static HDInsightJobClient GetHDInsightUnitTestingJobClient()
        {
            var cred = new BasicAuthenticationCredentials()
            {
                UserName = "mockUser",
                Password = "mockPassword"
            };

            return new HDInsightJobClient("TestCluster", cred);
        }
    }
}
