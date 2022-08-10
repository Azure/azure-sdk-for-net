
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using WebJobs.Extensions.CustomAuthenticationExtension.Tests.Payloads.TokenIssuanceStart.Preview10012021;
using Xunit;
using static WebJobs.Extensions.CustomAuthenticationExtension.Tests.TestHelper;

namespace WebJobs.Extensions.CustomAuthenticationExtension.Tests
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
            Unknown
        }

        /// <summary>Test the response value setting based on the response type expected.</summary>
        /// <param name="responseType">The response type to test as a function return value.</param>
        [Theory]
        [InlineData(ResponseTypes.String)]
        [InlineData(ResponseTypes.HttpResponse)]
        [InlineData(ResponseTypes.HttpResponseMessage)]
        [InlineData(ResponseTypes.Unknown)]
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
                case ResponseTypes.String: return TokenIssuanceStartPreview10012021.ActionResponse;
                case ResponseTypes.HttpResponse: return CreateHttpResponse(streamWriter);
                case ResponseTypes.HttpResponseMessage: return CreateHttpResponseMessage();
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
                    return (code: HttpStatusCode.OK, TokenIssuanceStartPreview10012021.ExpectedPayload);
                case ResponseTypes.Unknown:
                    return (code: HttpStatusCode.BadRequest, "Return type is invalid, please return either an IActionResult, HttpResponse, HttpResponseMessage or string in your function return.");
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

            sw.Write(TokenIssuanceStartPreview10012021.ActionResponse);
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
                Content = new StringContent(TokenIssuanceStartPreview10012021.ActionResponse)
            };
        }
    }
}

