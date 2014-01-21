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
        private HttpResponseMessage serverErrorResponse;
        private HttpResponseMessage serverErrorResponseWithCamelCase;
        private string genericMessageString = "{'key'='value'}";
        private string jsonErrorMessageString = @"{
                                    'code': 'BadRequest',
                                    'message': 'The provided database ‘foo’ has an invalid username.',
                                    'target': 'query',
                                    'details': [
                                      {
                                       'code': '301',
                                       'target': '$search',
                                       'message': '$search query option not supported.',
                                      }
                                    ]
                                }";
        private string jsonErrorMessageStringWithCamelCase = @"{
                                    'Code': 'BadRequest',
                                    'Message': 'The provided database ‘foo’ has an invalid username.',
                                    'Target': 'query',
                                    'Details': [
                                      {
                                       'Code': '301',
                                       'Target': '$search',
                                       'Message': '$search query option not supported.',
                                      }
                                    ]
                                }";
        private HttpRequestMessage genericMessage;

        public CloudExceptionTest()
        {
            genericMessage = new HttpRequestMessage(HttpMethod.Get, "http//test/url");
            genericMessage.Content = new StringContent(genericMessageString);
            notFoundResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            notFoundResponse.Content = new StreamContent(new MemoryStream());
            serverErrorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            serverErrorResponse.Content = new StringContent(jsonErrorMessageString);
            serverErrorResponseWithCamelCase = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            serverErrorResponseWithCamelCase.Content = new StringContent(jsonErrorMessageStringWithCamelCase);
        }

        [Fact]
        public void ExceptionIsCreatedFromHeaderlessResponse()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse,
                                           "", CloudExceptionType.Json);

            Assert.Null(notFoundResponse.Content.Headers.ContentType);
            Assert.NotNull(ex);
        }

        [Fact]
        public void ExceptionContainsHttpStatusCodeIfBodyIsEmpty()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse,
                                           "", CloudExceptionType.Json);

            Assert.Equal("Not Found", ex.Message);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithLowerCase()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponse,
                                           jsonErrorMessageString, CloudExceptionType.Json);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.ErrorMessage);
            Assert.Equal("BadRequest", ex.ErrorCode);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithCamelCase()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponseWithCamelCase,
                                           jsonErrorMessageStringWithCamelCase, CloudExceptionType.Json);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.ErrorMessage);
            Assert.Equal("BadRequest", ex.ErrorCode);
        }
    }
}
