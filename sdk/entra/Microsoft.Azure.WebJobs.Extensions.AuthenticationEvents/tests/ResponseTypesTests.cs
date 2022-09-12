﻿
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart.Legacy;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using Xunit;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;
using payloads = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    /// <summary>Class for housing all tests pertaining to Response Type Casting</summary>
    public class ResponseTypesTests
    {
        /// <summary>Available Types to test</summary>
        public enum ResponseTypes
        {
            /// <summary>Function response is of type string</summary>
            String,
            /// <summary>Function response is of type HttpResponse</summary>
            HttpResponse,
            /// <summary>Function response is of type HttpResponseMessage</summary>
            HttpResponseMessage,
            /// <summary>An unknown type that raises failure</summary>
            Unknown,
            /// <summary>Function response is of type AuthEventResponse</summary>
            AuthEventResponse
        }

        /// <summary>Test the response value setting based on the response type expected.</summary>
        /// <param name="responseType">The response type to test as a function return value.</param>
        [Theory]
        [InlineData(ResponseTypes.String)]
        [InlineData(ResponseTypes.HttpResponse)]
        [InlineData(ResponseTypes.HttpResponseMessage)]
        [InlineData(ResponseTypes.Unknown)]
        [InlineData(ResponseTypes.AuthEventResponse)]
        [Obsolete]
        public async void Tests(ResponseTypes responseType)
        {
            var (code, payload) = GetExpected(responseType);

            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(eventsResponseHandler =>
            {
                MemoryStream memoryStream = null;
                StreamWriter streamWriter = null;
                try
                {
                    memoryStream = new MemoryStream();
                    streamWriter = new StreamWriter(memoryStream);
                    eventsResponseHandler.SetValueAsync(GetResponseTypeObject(responseType, streamWriter), CancellationToken.None);
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Close();
                        streamWriter = null;
                    }
                    if (memoryStream != null)
                    {
                        memoryStream.Close();
                        memoryStream = null;
                    }
                }
            });

            Assert.Equal(httpResponseMessage.StatusCode, code);
            Assert.True(DoesPayloadMatch(payload, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }

        private object GetResponseTypeObject(ResponseTypes responseType, StreamWriter streamWriter)
        {
            switch (responseType)
            {
                case ResponseTypes.String: return TokenIssuanceStartLegacy.ActionResponse;
                case ResponseTypes.HttpResponse: return CreateHttpResponse(streamWriter);
                case ResponseTypes.HttpResponseMessage: return CreateHttpResponseMessage();
                case ResponseTypes.AuthEventResponse: return new TestAuthResponse(HttpStatusCode.OK, payloads.TokenIssuanceStart.ActionResponse);
                case ResponseTypes.Unknown: return new object();
                default: return null;
            }
        }

        /// <summary>Get the expected HTTP status and payload.</summary>
        /// <param name="responseType">Expected results for comparison based on Response Type</param>
        /// <returns>Returns the HttpStatusCode, if the expected HTTP response is json and if what the expected body of the response is.</returns>
        private (HttpStatusCode code, string payload) GetExpected(ResponseTypes responseType)
        {
            switch (responseType)
            {
                case ResponseTypes.String:
                case ResponseTypes.HttpResponse:
                case ResponseTypes.HttpResponseMessage:
                    return (code: HttpStatusCode.OK, TokenIssuanceStartLegacy.ExpectedPayload);
                case ResponseTypes.AuthEventResponse:
                    return (code: HttpStatusCode.OK, payloads.TokenIssuanceStart.ActionResponse);
                case ResponseTypes.Unknown:
                    return (code: HttpStatusCode.BadRequest, @"{'errors':['Return type is invalid, please return either an AuthEventResponse, HttpResponse, HttpResponseMessage or string in your function return.']}");
                default:
                    return (code: HttpStatusCode.BadRequest, string.Empty);
            };
        }

        /// <summary>Creates a HttpResponse object based on default HTTP context.</summary>
        /// <param name="sw">The stream writer to use to right the HTTP response body.</param>
        /// <returns>A newly created HttpResponse with the a payload set.</returns>
        private HttpResponse CreateHttpResponse(StreamWriter sw)
        {
            var response = new DefaultHttpContext().Response;

            sw.Write(TokenIssuanceStartLegacy.ActionResponse);
            sw.Flush();

            response.Body = sw.BaseStream;
            response.Body.Position = 0;
            return response;
        }

        /// <summary>Creates the HTTP response message.</summary>
        /// <returns>A newly created HttpResponseMessage with the payload set.</returns>
        private HttpResponseMessage CreateHttpResponseMessage()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(TokenIssuanceStartLegacy.ActionResponse)
            };
        }

    }
}

