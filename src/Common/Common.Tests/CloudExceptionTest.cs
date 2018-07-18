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

using System.IO;
using System.Net;
using System.Net.Http;
using Hyak.Common;
using Microsoft.Azure.Common;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.Azure.Common.Test
{
    public class CloudExceptionTest
    {
        private HttpResponseMessage notFoundResponse;
        private HttpResponseMessage serverErrorResponse;
        private HttpResponseMessage serverErrorResponseWithCamelCase;
        private HttpResponseMessage serverErrorResponseWithParent;
        private HttpResponseMessage serverErrorResponseWithParent2;
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
        private string jsonErrorMessageWithParent = @"{
                    'error' : {
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
                    }
                }";
        private string jsonErrorMessageWithParent2 = @"{'error':{'code':'ResourceGroupNotFound','message':
                'Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.'}}";

        private HttpRequestMessage genericMessage;
        private HttpRequestMessage genericMessageWithoutBody;

        public CloudExceptionTest()
        {
            genericMessage = new HttpRequestMessage(HttpMethod.Get, "http//test/url");
            genericMessage.Content = new StringContent(genericMessageString);
            genericMessageWithoutBody = new HttpRequestMessage(HttpMethod.Get, "http//test/url");
            notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
            notFoundResponse.Headers.Add("x-ms-request-id", "content1");
            notFoundResponse.Headers.Add("x-ms-routing-request-id", "content2");

            notFoundResponse.Content = new StreamContent(new MemoryStream());
            serverErrorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            serverErrorResponse.Content = new StringContent(jsonErrorMessageString);
            serverErrorResponseWithCamelCase = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            serverErrorResponseWithCamelCase.Content = new StringContent(jsonErrorMessageStringWithCamelCase);
            serverErrorResponseWithParent = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            serverErrorResponseWithParent.Content = new StringContent(jsonErrorMessageWithParent);
            serverErrorResponseWithParent2 = new HttpResponseMessage(HttpStatusCode.NotFound);
            serverErrorResponseWithParent2.Content = new StringContent(jsonErrorMessageWithParent2);
        }

        [Fact]
        public void ExceptionIsCreatedFromHeaderlessResponse()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, "");

            Assert.Null(notFoundResponse.Content.Headers.ContentType);
            Assert.NotNull(ex);
        }

        [Fact]
        public void ExceptionIsCreatedFromNullResponseString()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, null);

            Assert.Null(notFoundResponse.Content.Headers.ContentType);
            Assert.NotNull(ex);
        }

        [Fact]
        public void ExceptionContainsHttpStatusCodeIfBodyIsEmpty()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, "");

            Assert.Equal("Not Found", ex.Message);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithLowerCase()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponse, jsonErrorMessageString);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Error.Message);
            Assert.Equal("BadRequest", ex.Error.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithCamelCase()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponseWithCamelCase,
                                           jsonErrorMessageStringWithCamelCase);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Error.Message);
            Assert.Equal("BadRequest", ex.Error.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithParent()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponseWithParent,
                                           jsonErrorMessageWithParent);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Error.Message);
            Assert.Equal("BadRequest", ex.Error.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithoutMessageBody()
        {
            var ex = CloudException.Create(genericMessageWithoutBody, null, serverErrorResponseWithParent2, jsonErrorMessageWithParent2);

            Assert.Equal("ResourceGroupNotFound: Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.", ex.Message);
            Assert.Equal("Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.", ex.Error.Message);
            Assert.Equal("ResourceGroupNotFound", ex.Error.Code);
        }

        [Fact]
        public void ParseJsonErrorSupportsFlatErrors()
        {
            string message = @"{
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

            var error = CloudException.ParseJsonError(message);

            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Code);
            Assert.Equal(message, error.OriginalMessage);
        }

        [Fact]
        public void ParseJsonErrorDeepErrors()
        {
            string message = @"{
                                    'error' : {
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
                                    }
                                }";

            var error = CloudException.ParseJsonError(message);

            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Code);
            Assert.Equal(message, error.OriginalMessage);
        }

        [Fact]
        public void ParseJsonErrorSupportsEmptyErrors()
        {
            Assert.Null(CloudException.ParseJsonError(null).Code);
            Assert.Null(CloudException.ParseJsonError(string.Empty).Message);
        }

        [Theory]
        [InlineData(@"{'some error' : {'some message': 'The provided database ‘foo’ has an invalid username.',}}")]
        [InlineData(@"{'error' : {'some message': 'The provided database ‘foo’ has an invalid username.',}}")]
        [InlineData(@"{'error' : {'some message': 'The provided database ‘foo’ has an invalid username.'")]
        public void ParseJsonErrorSupportsIncorrectlyFormattedJsonErrors(string message)
        {
            var error = CloudException.ParseJsonError(message);

            Assert.Equal(message, error.OriginalMessage);
            Assert.Null(error.Message);
            Assert.Null(error.Code);
        }

        [Fact]
        public void ParseXmlErrorSupportsErrorsWithCamelCase()
        {
            string message = @"<Error>
                                        <Code>BadRequest</Code>
                                        <Message>The provided database ‘foo’ has an invalid username.</Message>
                                    </Error>";

            var error = CloudException.ParseXmlError(message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Code);
            Assert.Equal(message, error.OriginalMessage);
        }

        [Fact]
        public void ParseXmlErrorSupportsErrorsWithLowerCase()
        {
            string message = @"<error>
                                        <code>BadRequest</code>
                                        <message>The provided database ‘foo’ has an invalid username.</message>
                                    </error>";

            var error = CloudException.ParseXmlError(message);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal(message, error.OriginalMessage);
        }

        [Fact]
        public void ParseXmlErrorSupportsEmptyErrors()
        {
            Assert.Null(CloudException.ParseXmlError(null).Code);
            Assert.Null(CloudException.ParseXmlError(null).Message);
            Assert.Null(CloudException.ParseXmlError(null).OriginalMessage);
            Assert.Null(CloudException.ParseXmlError(string.Empty).Code);
            Assert.Null(CloudException.ParseXmlError(string.Empty).Message);
            Assert.Equal(string.Empty, CloudException.ParseXmlError(string.Empty).OriginalMessage);
        }

        [Fact]
        public void ParseXmlErrorIgnoresParentElement()
        {
            string xmlErrorMessageWithBadParent = @"<SomeError>
                                        <Code>BadRequest</Code>
                                        <Message>The provided database ‘foo’ has an invalid username.</Message>
                                    </SomeError>";

            Assert.Equal("The provided database ‘foo’ has an invalid username.", CloudException.ParseXmlError(xmlErrorMessageWithBadParent).Message);
            Assert.Equal("BadRequest", CloudException.ParseXmlError(xmlErrorMessageWithBadParent).Code);
        }

        [Theory]
        [InlineData("<error><some-message>The provided database ‘foo’ has an invalid username.</some-message></error>")]
        [InlineData("<some-error><some-message>The provided database ‘foo’ has an invalid username.</some-message></some-error>")]
        [InlineData("<some-error><some-message>The provided database ‘foo’ has an invalid username.")]
        [InlineData(@"<Error><SomeCode>BadRequest</SomeCode><SomeMessage>The provided database ‘foo’ has an invalid username.</SomeMode></Error>}")]
        public void ParseXmlErrorSupportsIncorrectlyFormattedXmlErrors(string message)
        {
            var error = CloudException.ParseXmlError(message);
            Assert.Equal(message, error.OriginalMessage);
            Assert.Null(error.Message);
            Assert.Null(error.Code);
        }
    }
}
