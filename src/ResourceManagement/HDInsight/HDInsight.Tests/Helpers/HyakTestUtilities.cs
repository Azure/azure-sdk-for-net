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

using Microsoft.Azure;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Xunit;

namespace HDInsight.Tests.Helpers
{
    public class HyakTestUtilities
    {
        /// <summary>
        /// Validate the fields of an operation response
        /// </summary>
        /// <param name="opResponse"> The operation response to validate</param>
        /// <param name="expectedStatus">The expected status code </param>
        public static void ValidateOperationResponse(AzureOperationResponse opResponse, HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            Assert.Equal(expectedStatus, opResponse.StatusCode);
            Assert.True(opResponse.RequestId != null);
        }

        public static void SetHttpMockServerMatcher()
        {
            // If a test customizes the record matcher, use the cutomized version otherwise use the default
            // permissive record matcher.
            if (HttpMockServer.Matcher == null || HttpMockServer.Matcher.GetType() == typeof(SimpleRecordMatcher))
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("Microsoft.Resources", null);
                d.Add("Microsoft.Features", null);
                d.Add("Microsoft.Authorization", null);
                d.Add("Microsoft.Compute", null);
                var providersToIgnore = new Dictionary<string, string>();
                providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
                HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            }
        }
    }
}
