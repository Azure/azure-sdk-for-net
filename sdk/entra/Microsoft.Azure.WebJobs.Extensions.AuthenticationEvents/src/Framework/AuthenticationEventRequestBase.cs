// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>The base class for all typed event requests.</summary>
    public abstract class AuthenticationEventRequestBase
    {
        private readonly Dictionary<string, string> queryParameters;
        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventRequestBase" /> class.</summary>
        /// <param name="request">The HTTP request message.</param>
        internal AuthenticationEventRequestBase(HttpRequestMessage request)
        {
            HttpRequestMessage = request;
            queryParameters = HttpUtility.ParseQueryString(request.RequestUri.Query).ToDictionary();
        }

        internal HttpRequestMessage HttpRequestMessage { get; set; }

        /// <summary>Gets or sets the type.</summary>
        /// <value>The type.</value>
        [JsonPropertyName("type")]
        [Required]
        [AuthEventIdentifier]
        public string Type { get; set; } = string.Empty;

        /// <summary>Gets or sets the request status.</summary>
        /// <value>The request status.</value>
        [JsonPropertyName("requestStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public RequestStatusType RequestStatus { get; internal set; }

        /// <summary>Gets or sets the status message.</summary>
        /// <value>The status message.</value>
        [JsonPropertyName("statusMessage")]
        [Required]
        public string StatusMessage { get; set; } = string.Empty;

        /// <summary>Gets the query parameters passed from the http request message.</summary>
        /// <value>The query parameters.</value>
        [JsonPropertyName("queryParameters")]
        public Dictionary<string, string> QueryParameters { get { return queryParameters; } }

        /// <summary>Once an instance is created the framework will pass addition arguments to the created sub class for use.</summary>
        /// <param name="args">The arguments.</param>
        internal abstract void InstanceCreated(params object[] args);

        internal virtual void ParseInbound(AuthenticationEventJsonElement payload) { }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            JsonSerializerOptions options = JsonSerializerOptions;
            options.Converters.Add(new AuthenticationEventResponseConverterFactory());
            return JsonSerializer.Serialize((object)this, options);
        }

       internal virtual JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions() { WriteIndented = true, PropertyNameCaseInsensitive = true };

        internal abstract AuthenticationEventResponse GetResponseObject();

        /// <summary>Set the response to Failed mode.</summary>
        /// <param name="exception">The exception to return in the response.</param>
        /// <param name="internalError">Throw 500 internal server error.</param>
        /// <returns>The Underlying AuthEventResponse.</returns>
        internal abstract Task<AuthenticationEventResponse> Failed(Exception exception, bool internalError);

        /// <summary>Set the response to Failed mode.</summary>
        /// <param name="exception">The exception to return in the response.</param>
        /// <returns>The Underlying AuthEventResponse.</returns>
        public Task<AuthenticationEventResponse> Failed(Exception exception)
        {
            return Failed(exception, false);
        }

        /// <summary>Validates the response and creates the IActionResult with the json payload based on the status of the request.</summary>
        /// <returns>IActionResult based on the EventStatus (UnauthorizedResult, BadRequestObjectResult or JsonResult).</returns>
        public abstract Task<AuthenticationEventResponse> Completed();
    }
}