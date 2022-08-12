// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>The base class for all typed event requests and its related response and data model.</summary>
    /// <typeparam name="TResponse">The EventResponse related to the request.</typeparam>
    /// <typeparam name="TData">The EventData model related to the request.</typeparam>
    /// <seealso cref="AuthEventResponse" />
    /// <seealso cref="AuthEventData" />
    public abstract class AuthEventRequest<TResponse, TData> : AuthEventRequestBase where TResponse : AuthEventResponse where TData : AuthEventData
    {
        /// <summary>Initializes a new instance of the <see cref="AuthEventRequest{T, K}" /> class.</summary>
        /// <param name="request">The request.</param>
        internal AuthEventRequest(HttpRequestMessage request) : base(request) { }
        /// <summary>Gets or sets the related EventResponse object.</summary>
        /// <value>The response.</value>
        ///
        [JsonPropertyName("response")]
        [Required]
        public TResponse Response { get; set; }

        /// <summary>Gets or sets the related EventData model.</summary>
        /// <value>The Json payload.</value>
        ///
        [JsonPropertyName("payload")]
        [Required]
        public TData Payload { get; set; }

        /// <summary>Validates the response and creates the IActionResult with the json payload based on the status of the request.</summary>
        /// <returns>IActionResult based on the EventStatus (UnauthorizedResult, BadRequestObjectResult or JsonResult).</returns>
        public async override Task<AuthEventResponse> Completed()
        {
            try
            {
                if (RequestStatus == AuthEventConvertStatusType.Failed)
                    Response.MarkAsFailed(new Exception(String.IsNullOrEmpty(StatusMessage) ? AuthEventResource.Ex_Gen_Failure : StatusMessage));

                if (RequestStatus == AuthEventConvertStatusType.TokenInvalid)
                    Response.MarkAsUnauthorised();
            }
            catch (Exception ex)
            {
                return await Failed(ex).ConfigureAwait(false);
            }

            return Response;
        }

        /// <summary>Set the response to Failed mode.</summary>
        /// <param name="exception">The exception to return in the response.</param>
        /// <returns>The Underlying AuthEventResponse.</returns>
        public override Task<AuthEventResponse> Failed(Exception exception)
        {
            Response.MarkAsFailed(exception);
            return Task.FromResult<AuthEventResponse>((TResponse)Response);
        }
    }
}