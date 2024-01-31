// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Contains the IActionRequest response when the function is called.</summary>
    /// <seealso cref="IValueBinder" />
    public class AuthenticationEventResponseHandler : IValueBinder
    {
        /// <summary>The response property.</summary>
        internal const string EventResponseProperty = "$event$response";

        private AuthenticationEventResponse _response;

        /// <summary>Gets or sets the action result.</summary>
        /// <value>The action result.</value>
        public AuthenticationEventResponse Response
        {
            get => _response;
            private set
            {
                if (value != null)
                {
                    _response = value;

                    // Set metrics on the headers for the response
                    EventTriggerMetrics.Instance.SetMetricHeaders(_response);
                }
            }
        }

        internal AuthenticationEventResponseHandler() { }

        /// <summary>Gets the type.</summary>
        /// <value>The type.</value>
        public Type Type => typeof(AuthenticationEventResponse).MakeByRefType();

        /// <summary>Gets or sets the request.</summary>
        /// <value>The associated request.</value>
        public AuthenticationEventRequestBase Request { get; internal set; }

        /// <summary>Gets the value asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(Response);
        }

        /// <summary>Sets the value asynchronous.</summary>
        /// <param name="result">The result.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   A task flag as completed.
        /// </returns>
        public Task SetValueAsync(object result, CancellationToken cancellationToken)
        {
            try
            {
                if (result == null)
                {
                    throw new AuthenticationEventTriggerResponseValidationException(AuthenticationEventResource.Ex_Invalid_Return);
                }

                if (result is AuthenticationEventResponse action)
                {
                    Response = action;
                }
                else
                {
                    AuthenticationEventResponse response = Request.GetResponseObject();
                    if (response == null)
                    {
                        throw new AuthenticationEventTriggerRequestValidationException(AuthenticationEventResource.Ex_Missing_Request_Response);
                    }

                    Response = GetActionResult(result, response);
                }

                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Response.Validate();
                    Response.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Response = Request.Failed(ex, true).Result;
            }

            return Task.CompletedTask;
        }

        internal AuthenticationEventResponse GetActionResult(object result, AuthenticationEventResponse response)
        {
            AuthenticationEventJsonElement jResult;

            //If the request was unsuccessful we return the IActionResult based on the error and do no further processing.
            if (Request.RequestStatus != RequestStatusType.Successful)
            {
                return Request.Failed(null, true).Result;
            }
            else if (result is string strResult)//A string was returned from the function execution
            {
                jResult = GetJsonObjectFromString(strResult);
            }
            else if (result is HttpResponse httpResponse)//A HttpResponse Object was returned from the function execution
            {
                jResult = GetJsonObjectFromHttpResponse(httpResponse);
            }
            else if (result is HttpResponseMessage responseMessage)//A HttpResponseMessage Object was returned from the function execution
            {
                jResult = GetJsonObjectFromHttpResponseMessage(responseMessage);
            }
            else if (result is Stream stream)//A HttpResponseMessage Object was returned from the function execution
            {
                jResult = GetJsonObjectFromStream(stream);
            }
            //As we do not reference Newstonsoft objects there still is a possibility that Newtonsoft objects can be parsed down from func.exe
            else if (result != null && result.GetType().ToString().ToLower(CultureInfo.CurrentCulture).Contains("newtonsoft"))
            {
                jResult = GetJsonObjectFromString(result.ToString());
            }
            else
            {
                throw new InvalidCastException(AuthenticationEventResource.Ex_Invalid_Return);
            }

            AuthenticationEventResponse convertedResponse = ConvertToEventResponse(jResult, response.GetType());

            if (convertedResponse != null && !string.IsNullOrEmpty(response.Body))
            {
                if (convertedResponse.GetType() != response.GetType())
                {
                    throw new Exception(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Response_Mismatch, Request.GetResponseObject().GetType()));
                }

                if (string.IsNullOrEmpty(convertedResponse.Body))
                {
                    convertedResponse.Body = response.Body;
                }

                return convertedResponse;
            }

            return GetAuthEventFromJObject(jResult, response);
        }

        /// <summary>Tries to convert a JSON response payload to an string type EventResponse.</summary>
        /// <param name="response">The response payload.</param>
        /// <param name="responseType">Type of the response to generate.</param>
        /// <returns>If the EventResponse is generated then the Typed EventResponse else null.</returns>
        internal static AuthenticationEventResponse ConvertToEventResponse(AuthenticationEventJsonElement response, Type responseType)
        {
            if (response.Properties.ContainsKey("data") && response.Properties["data"] is AuthenticationEventJsonElement jsonElement)
            {
                response = jsonElement;
            }

            return responseType.BaseType.GetGenericTypeDefinition() == typeof(ActionableResponse<>) ||
                   responseType.BaseType.GetGenericTypeDefinition() == typeof(ActionableCloudEventResponse<>) ?
                     (AuthenticationEventResponse)JsonSerializer.Deserialize(response.ToString(), responseType, GetSerializerOptions()) :
                     null;
        }

        private static JsonSerializerOptions GetSerializerOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new ActionConverterFactoryOfT());
            return options;
        }

        internal static AuthenticationEventJsonElement GetJsonObjectFromHttpResponseMessage(HttpResponseMessage httpResponseMessage)
        {
            return GetJsonObjectFromString(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        internal static AuthenticationEventJsonElement GetJsonObjectFromHttpResponse(HttpResponse result)
        {
            return GetJsonObjectFromStream(result.Body);
        }

        internal static AuthenticationEventJsonElement GetJsonObjectFromStream(Stream stream)
        {
            // Build up the request body in a string builder.
            StringBuilder builder = new StringBuilder();

            // Rent a shared buffer to write the request body into.
            byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);

            while (true)
            {
                var bytesRemaining = stream.Read(buffer, offset: 0, buffer.Length);
                if (bytesRemaining == 0)
                {
                    break;
                }

                // Append the encoded string into the string builder.
                var encodedString = Encoding.UTF8.GetString(buffer, 0, bytesRemaining);
                builder.Append(encodedString);
            }

            ArrayPool<byte>.Shared.Return(buffer);

            return GetJsonObjectFromString(builder.ToString());
        }

        internal static AuthenticationEventJsonElement GetJsonObjectFromString(string result)
        {
            try
            {
                Helpers.ValidateJson(result);
            }
            catch (JsonException ex)
            {
                throw new AuthenticationEventTriggerResponseValidationException($"{AuthenticationEventResource.Ex_Invalid_Return}: {ex.Message}", ex.InnerException);
            }

            return new AuthenticationEventJsonElement(result);
        }

        internal static AuthenticationEventResponse GetAuthEventFromJObject(AuthenticationEventJsonElement result, AuthenticationEventResponse response)
        {
            //see if the jObject contains an error
            if (result.Properties.ContainsKey("error"))
            {
                throw new Exception(result.GetPropertyValue("error"));
            }

            if (result.Properties.ContainsKey("schema"))
            {
                result.Properties.Remove("schema");
            }

            var jBody = new AuthenticationEventJsonElement(response.Body);
            jBody.Merge(result);

            response.Body = jBody.ToString();

            return response;
        }

        /// <summary>Converts to invokestring.</summary>
        /// <returns>
        ///   The string "response".
        /// </returns>
        public string ToInvokeString()
        {
            return "response";
        }
    }
}
