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
        private readonly HttpRequestMessage genericMessageWithoutBody;

        public CloudExceptionTests()
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
            Assert.Equal("BadRequest", ex.Body.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Body.Message);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithCamelCase()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponseWithCamelCase,
                                           jsonErrorMessageStringWithCamelCase);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("BadRequest", ex.Body.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithParent()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, serverErrorResponseWithParent,
                                           jsonErrorMessageWithParent);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", ex.Message);
            Assert.Equal("BadRequest", ex.Body.Code);
        }

        [Fact]
        public void JsonExceptionIsParsedCorrectlyWithoutMessageBody()
        {
            var ex = CloudException.Create(genericMessageWithoutBody, null, serverErrorResponseWithParent2, jsonErrorMessageWithParent2);

            Assert.Equal("ResourceGroupNotFound: Resource group `ResourceGroup_crosoftAwillAofferAmoreAWebAservicemnopqrstuvwxyz1` could not be found.", ex.Message);
            Assert.Equal("ResourceGroupNotFound", ex.Body.Code);
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

            CloudException error = CloudException.Create(null, null, null, message);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Body.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Body.Message);
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

            var error = CloudException.Create(null, null, null, message);

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Body.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Body.Message);
        }

        [Fact]
        public void ParseJsonErrorSupportsEmptyErrors()
        {
            Assert.Null(CloudException.Create(null, null, null, null).Body);
            Assert.Equal("Operation is not valid due to the current state of the object.", CloudException.Create(null, null, null, string.Empty).Message);
        }

        [Theory]
        [InlineData(@"{'some error' : {'some message': 'The provided database ‘foo’ has an invalid username.',}}")]
        [InlineData(@"{'error' : {'some message': 'The provided database ‘foo’ has an invalid username.',}}")]
        [InlineData(@"{'error' : {'some message': 'The provided database ‘foo’ has an invalid username.'")]
        public void ParseJsonErrorSupportsIncorrectlyFormattedJsonErrors(string message)
        {
            var error = CloudException.Create(null, null, null, message);

            Assert.Equal(message, error.Message);
            Assert.Null(error.Body);
        }

        [Fact]
        public void ParseXmlErrorSupportsErrorsWithCamelCase()
        {
            string message = @"<Error>
                                        <Code>BadRequest</Code>
                                        <Message>The provided database ‘foo’ has an invalid username.</Message>
                                    </Error>";

            var error = CloudException.Create(null, null, null, message);
            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Body.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Body.Message);
        }

        [Fact]
        public void ParseXmlErrorSupportsErrorsWithLowerCase()
        {
            string message = @"<error>
                                        <code>BadRequest</code>
                                        <message>The provided database ‘foo’ has an invalid username.</message>
                                    </error>";

            var error = CloudException.Create(null, null, null, message);
            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", error.Message);
            Assert.Equal("BadRequest", error.Body.Code);
            Assert.Equal("The provided database ‘foo’ has an invalid username.", error.Body.Message);
        }

        [Fact]
        public void ParseXmlErrorSupportsEmptyErrors()
        {
            Assert.Null(CloudException.Create(null, null, null, null).Body);
            Assert.Equal("Operation is not valid due to the current state of the object.",
                CloudException.Create(null, null, null, null).Message);
            Assert.Null(CloudException.Create(null, null, null, null).Response);
            Assert.Null(CloudException.Create(null, null, null, string.Empty).Body);
            Assert.Equal("Operation is not valid due to the current state of the object.",
                CloudException.Create(null, null, null, string.Empty).Message);
            Assert.Null(CloudException.Create(null, null, null, string.Empty).Response);
        }

        [Fact]
        public void ParseXmlErrorIgnoresParentElement()
        {
            string xmlErrorMessageWithBadParent = @"<SomeError>
                                        <Code>BadRequest</Code>
                                        <Message>The provided database ‘foo’ has an invalid username.</Message>
                                    </SomeError>";

            Assert.Equal("BadRequest: The provided database ‘foo’ has an invalid username.", CloudException.Create(null, null, null, xmlErrorMessageWithBadParent).Message);
            Assert.Equal("BadRequest", CloudException.Create(null, null, null, xmlErrorMessageWithBadParent).Body.Code);
        }

        [Theory]
        [InlineData("<error><some-message>The provided database ‘foo’ has an invalid username.</some-message></error>")]
        [InlineData("<some-error><some-message>The provided database ‘foo’ has an invalid username.</some-message></some-error>")]
        [InlineData("<some-error><some-message>The provided database ‘foo’ has an invalid username.")]
        [InlineData(@"<Error><SomeCode>BadRequest</SomeCode><SomeMessage>The provided database ‘foo’ has an invalid username.</SomeMode></Error>}")]
        public void ParseXmlErrorSupportsIncorrectlyFormattedXmlErrors(string message)
        {
            var error = CloudException.Create(null, null, null, message);
            Assert.Equal(message, error.Message);
            Assert.Null(error.Body);
        }

        [Fact]
        public void MalformedXmlErrorMessageIsParsedCorrectly()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, malformedXmlErrorMessageString);

            Assert.NotNull(ex);
            Assert.Null(ex.Body);
            Assert.Equal(malformedXmlErrorMessageString, ex.Message);
            
        }

        [Fact]
        public void MalformedJsonErrorMessageIsParsedCorrectly()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, malformedJsonErrorMessageString);

            Assert.NotNull(ex);
            Assert.Null(ex.Body);
            Assert.Equal(malformedJsonErrorMessageString, ex.Message);
            
        }

        [Fact]
        public void CodeOnlyJsonErrorMessageIsParsedCorrectly()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, jsonErrorCodeOnly);

            Assert.NotNull(ex);
            Assert.Null(ex.Body);
            Assert.Equal(jsonErrorCodeOnly, ex.Message);
            
        }

        [Fact]
        public void MessageOnlyJsonErrorMessageIsParsedCorrectly()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, jsonErrorMessageOnly);

            Assert.NotNull(ex);
            Assert.Null(ex.Body);
            Assert.Equal(jsonErrorMessageOnly, ex.Message);
            
        }

        [Fact]
        public void CodeOnlyXmlErrorMessageIsParsedCorrectly()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, xmlErrorCodeOnly);

            Assert.NotNull(ex);
            Assert.NotNull(ex.Body);
            Assert.Equal(ex.Body.Code, ex.Message);
            
        }

        [Fact]
        public void MessageOnlyXmlErrorMessageIsParsedCorrectly()
        {
            var ex = CloudException.Create(genericMessage, genericMessageString, notFoundResponse, xmlErrorMessageOnly);

            Assert.NotNull(ex);
            Assert.NotNull(ex.Body);
            Assert.Equal(ex.Body.Message, ex.Message);
            
        }
    }
}