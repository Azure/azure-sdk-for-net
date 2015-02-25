// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;
using Xunit.Extensions;
using Microsoft.Azure;

namespace Microsoft.Azure.Test
{
    public class CloudExceptionTests
    {
        private readonly HttpResponseMessage notFoundResponse;
        private readonly HttpResponseMessage serverErrorResponse;
        private readonly HttpResponseMessage serverErrorResponseWithCamelCase;
        private readonly HttpResponseMessage serverErrorResponseWithParent;
        private readonly HttpResponseMessage serverErrorResponseWithParent2;
        private const string genericMessageString = "{'key'='value'}";
        private const string jsonErrorMessageString = @"{
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
        private const string jsonErrorMessageStringWithCamelCase = @"{
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
        private const string jsonErrorMessageWithParent = @"{
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
        private const string jsonErrorMessageWithParent2 = @"{'error':{'code':'ResourceGroupNotFound','message':
                'Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.'}}";
        
        private const string malformedJsonErrorMessageString = @"{
                    'code': 'BadRequest',
                    'dsadsadsadsadsajkfdhgsjkfrdhgsajkfdh";
        private const string malformedXmlErrorMessageString = @"<xml rsewdsadsardhsajhedrsajhedjsad";

        private const string jsonErrorCodeOnly = @"{'error':{'code':'ResourceGroupNotFound'}}";

        private const string jsonErrorMessageOnly = @"{'error':{'message':
                'Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.'}}";
        private const string xmlErrorCodeOnly = @"<error>
                                        <code>BadRequest</code>
                                    </error>";
        private const string xmlErrorMessageOnly = @"<error>
                                        <message>The provided database ‘foo’ has an invalid username.</message>
                                    </error>";

        private readonly HttpRequestMessage genericMessage;

        public CloudExceptionTests()
        {
            genericMessage = new HttpRequestMessage(HttpMethod.Get, "http//test/url");
            genericMessage.Content = new StringContent(genericMessageString);
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
        public void JsonExceptionIsParsedCorrectlyWithLowerCase()
        {
            var ex = new CloudError(jsonErrorMessageString);

            Assert.Equal("BadRequest", ex.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithCamelCase()
        {
            var ex = new CloudError(jsonErrorMessageStringWithCamelCase);

            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("BadRequest", ex.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithParent()
        {
            var ex = new CloudError(jsonErrorMessageWithParent);

            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("BadRequest", ex.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithoutMessageBody()
        {
            var ex = new CloudError(jsonErrorMessageWithParent2);

            Assert.Equal("Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.", ex.Message);
            Assert.Equal("ResourceGroupNotFound", ex.Code);
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

            var error = new CloudError(message);

            Assert.Equal("BadRequest", error.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
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

            var error = new CloudError(message);

            Assert.Equal("BadRequest", error.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
        }

        [Theory]
        [InlineData(@"{'some error' : {'some message': 'The provided database ‘foo’ has an invalid username.',}}")]
        [InlineData(@"{'error' : {'some message': 'The provided database ‘foo’ has an invalid username.',}}")]
        [InlineData(@"{'error' : {'some message': 'The provided database ‘foo’ has an invalid username.'")]
        public void ParseJsonErrorSupportsIncorrectlyFormattedJsonErrors(string message)
        {
            var error = new CloudError(message);

            Assert.Equal(message, error.Message);
            Assert.Null(error.Code);
        }

        [Fact]
        public void ParseXmlErrorSupportsErrorsWithCamelCase()
        {
            string message = @"<Error>
                                        <Code>BadRequest</Code>
                                        <Message>The provided database ‘foo’ has an invalid username.</Message>
                                    </Error>";

            var error = new CloudError(message);
            Assert.Equal("BadRequest", error.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
        }

        [Fact]
        public void ParseXmlErrorSupportsErrorsWithLowerCase()
        {
            string message = @"<error>
                                        <code>BadRequest</code>
                                        <message>The provided database ‘foo’ has an invalid username.</message>
                                    </error>";

            var error = new CloudError(message);
            Assert.Equal("BadRequest", error.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
        }

        [Fact]
        public void ParseXmlErrorSupportsEmptyErrors()
        {
            Assert.Null(new CloudError(null).Message);
            Assert.Equal("", new CloudError(string.Empty).Message);
        }

        [Fact]
        public void ParseXmlErrorIgnoresParentElement()
        {
            string xmlErrorMessageWithBadParent = @"<SomeError>
                                        <Code>BadRequest</Code>
                                        <Message>The provided database ‘foo’ has an invalid username.</Message>
                                    </SomeError>";

            var error = new CloudError();
            error.Deserialize(xmlErrorMessageWithBadParent);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Code);
        }

        [Theory]
        [InlineData("<error><some-message>The provided database ‘foo’ has an invalid username.</some-message></error>")]
        [InlineData("<some-error><some-message>The provided database ‘foo’ has an invalid username.</some-message></some-error>")]
        [InlineData("<some-error><some-message>The provided database ‘foo’ has an invalid username.")]
        [InlineData(@"<Error><SomeCode>BadRequest</SomeCode><SomeMessage>The provided database ‘foo’ has an invalid username.</SomeMode></Error>}")]
        public void ParseXmlErrorSupportsIncorrectlyFormattedXmlErrors(string message)
        {
            var error = new CloudError();
            error.Deserialize(message);
            Assert.Equal(message, error.Message);
        }

        [Fact]
        public void MalformedXmlErrorMessageIsParsedCorrectly()
        {
            var ex = new CloudError();
            ex.Deserialize(malformedXmlErrorMessageString);
            Assert.NotNull(ex);
            Assert.Equal(malformedXmlErrorMessageString, ex.Message);
        }

        [Fact]
        public void MalformedJsonErrorMessageIsParsedCorrectly()
        {
            var ex = new CloudError();
            ex.Deserialize(malformedJsonErrorMessageString);
            Assert.NotNull(ex);
            Assert.Equal(malformedJsonErrorMessageString, ex.Message);
            
        }

        [Fact]
        public void CodeOnlyJsonErrorMessageIsParsedCorrectly()
        {
            var ex = new CloudError();
            ex.Deserialize(jsonErrorCodeOnly);
            Assert.NotNull(ex);
            Assert.Equal("ResourceGroupNotFound", ex.Code);
            
        }

        [Fact]
        public void MessageOnlyJsonErrorMessageIsParsedCorrectly()
        {
            var ex = new CloudError();
            ex.Deserialize(jsonErrorMessageOnly);
            Assert.NotNull(ex);
            Assert.Equal("Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.", ex.Message);
            
        }

        [Fact]
        public void CodeOnlyXmlErrorMessageIsParsedCorrectly()
        {
            var ex = new CloudError();
            ex.Deserialize(xmlErrorCodeOnly);
            Assert.NotNull(ex);
            Assert.Equal(ex.Code, ex.Message);
            
        }

        [Fact]
        public void MessageOnlyXmlErrorMessageIsParsedCorrectly()
        {
            var ex = new CloudError();
            ex.Deserialize(xmlErrorMessageOnly);
            Assert.NotNull(ex);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
        }
    }
}