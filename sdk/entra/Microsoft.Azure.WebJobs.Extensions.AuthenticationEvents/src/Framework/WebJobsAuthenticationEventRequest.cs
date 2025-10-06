// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>The base class for all typed event requests and its related response and data model.</summary>
    /// <typeparam name="TResponse">The EventResponse related to the request.</typeparam>
    /// <typeparam name="TData">The EventData model related to the request.</typeparam>
    /// <seealso cref="WebJobsAuthenticationEventResponse" />
    /// <seealso cref="WebJobsAuthenticationEventData" />
    public abstract class WebJobsAuthenticationEventRequest<TResponse, TData> : WebJobsAuthenticationEventRequestBase
        where TResponse : WebJobsAuthenticationEventResponse, new()
        where TData : WebJobsAuthenticationEventData
    {
        /// <summary>Initializes a new instance of the <see cref="WebJobsAuthenticationEventRequest{T, K}" /> class.</summary>
        /// <param name="request">The request.</param>
        internal WebJobsAuthenticationEventRequest(HttpRequestMessage request) : base(request) { }
        /// <summary>Gets or sets the related EventResponse object.</summary>
        /// <value>The response.</value>
        ///
        [JsonPropertyName("response")]
        public TResponse Response { get; set; }

        /// <summary>Gets or sets the related EventData model.</summary>
        /// <value>The Json payload.</value>
        ///
        [JsonPropertyName("data")]
        [Required]
        public TData Data { get; set; }

        /// <summary>Validates the response and creates the IActionResult with the json payload based on the status of the request.</summary>
        /// <returns>IActionResult based on the EventStatus (UnauthorizedResult, BadRequestObjectResult or JsonResult).</returns>
        public override WebJobsAuthenticationEventResponse Completed()
        {
            try
            {
                if (RequestStatus == WebJobsAuthenticationEventsRequestStatusType.Failed || RequestStatus == WebJobsAuthenticationEventsRequestStatusType.ValidationError)
                {
                    return Failed(new AuthenticationEventTriggerRequestValidationException(string.IsNullOrEmpty(StatusMessage) ? AuthenticationEventResource.Ex_Gen_Failure : StatusMessage));
                }
                else if (RequestStatus == WebJobsAuthenticationEventsRequestStatusType.TokenInvalid)
                {
                    SetResponseUnauthorized();
                }
            }
            catch (Exception ex)
            {
                return Failed(ex);
            }

            return Response;
        }

        /// <summary>
        /// Sets the response statuscode, reason phrase and body when we want to return failed.
        /// </summary>
        /// <param name="exception">The exception that is thrown</param>
        /// <returns>An authenticationeventresponse task</returns>
        public override WebJobsAuthenticationEventResponse Failed(Exception exception)
        {
            if (Response == null)
            {
                Response = new TResponse();
            }

            if (exception is AuthenticationEventTriggerValidationException ex)
            {
                Response.StatusCode = ex.ExceptionStatusCode;
                Response.ReasonPhrase = ex.ReasonPhrase;
            }
            else
            {
                Response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                Response.ReasonPhrase = "Internal Server Error";
            }

            Response.Body = Helpers.GetFailedResponsePayload(exception);

            return Response;
        }

        /// <summary>
        /// Sets the response statuscode and reasonphrase to unauthorized.
        /// </summary>
        private void SetResponseUnauthorized()
        {
            // Set response as unauthorized when token is invalid
            Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            Response.ReasonPhrase = "Unauthorized";
            Response.Body = string.Empty;
        }
    }
}