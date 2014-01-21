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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.WindowsAzure.Common.Test
{
    public class CloudExceptionTest
    {
        private HttpResponseMessage notFoundResponse;
        private string genericMessageString = "{'key'='value'}";
        private HttpRequestMessage genericMessage;

        public CloudExceptionTest()
        {
            genericMessage = new HttpRequestMessage(HttpMethod.Get, "http//test/url");
            genericMessage.Content = new StringContent(genericMessageString);
            notFoundResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            notFoundResponse.Content = new StreamContent(new MemoryStream());
        }

        [Fact]
        public void ExceptionIsCreatedFromEmptyResponse()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse,
                                           "", CloudExceptionType.Json);
            Assert.NotNull(ex);
            Assert.Equal("", ex.Message);
        }
    }
}
