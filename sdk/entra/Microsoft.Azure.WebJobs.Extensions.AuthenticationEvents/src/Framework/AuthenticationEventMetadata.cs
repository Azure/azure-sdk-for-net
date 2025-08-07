// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Http;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Represents event meta-data.</summary>
    internal class AuthenticationEventMetadata
    {
        /// <summary>Gets or sets the type of the request.</summary>
        /// <value>The type of the request.</value>
        internal Type RequestType { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        internal WebJobsAuthenticationEventDefinition Id { get; set; }

        /// <summary>Gets or sets the response template content.</summary>
        /// <value>The response template content.</value>
        internal string ResponseTemplate { get; set; }

        /// <summary>Creates the event request,response and data model instances for the related event.</summary>
        /// <param name="request">The incoming HTTP request message.</param>
        /// <param name="payload">The Json payload.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>A newly create EventRequest with related EventResponse and EventData based on event type.</returns>
        /// <seealso cref="WebJobsAuthenticationEventRequestBase" />
        /// <seealso cref="WebJobsAuthenticationEventData" />
        internal WebJobsAuthenticationEventRequestBase CreateEventRequestValidate(HttpRequestMessage request, string payload, params object[] args)
        {
            return CreateEventRequest(request, payload, true, args);
        }

        /// <summary>Creates the event request,response and data model instances for the related event.</summary>
        /// <param name="request">The incoming HTTP request message.</param>
        /// <param name="payload">The Json payload.</param>
        /// <param name="validate">Validate the generated object.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>A newly create EventRequest with related EventResponse and EventData based on event type.</returns>
        /// <seealso cref="WebJobsAuthenticationEventRequestBase" />
        /// <seealso cref="WebJobsAuthenticationEventData" />
        internal WebJobsAuthenticationEventRequestBase CreateEventRequest(HttpRequestMessage request, string payload, bool validate, params object[] args)
        {
            WebJobsAuthenticationEventRequestBase eventRequest = (WebJobsAuthenticationEventRequestBase)Activator.CreateInstance(RequestType, new object[] { request });
            PropertyInfo responseInfo = eventRequest.GetType().GetProperty("Response");
            PropertyInfo dataInfo = eventRequest.GetType().GetProperty("Data");

            WebJobsAuthenticationEventResponse eventResponse = WebJobsAuthenticationEventResponse.CreateInstance(
                responseInfo.PropertyType,
                // ResponseSchema ?? string.Empty,
                ResponseTemplate ?? string.Empty);

            if (args != null && args.Length != 0)
            {
                eventRequest.InstanceCreated(args);
            }

            if (!string.IsNullOrEmpty(payload))
            {
                AuthenticationEventJsonElement jsonPayload = new AuthenticationEventJsonElement(payload);
                eventResponse.InstanceCreated(jsonPayload);
                dataInfo.SetValue(eventRequest, WebJobsAuthenticationEventData.CreateInstance(dataInfo.PropertyType, jsonPayload));
                eventRequest.ParseInbound(jsonPayload);
            }

            eventRequest.StatusMessage = AuthenticationEventResource.Status_Good;

            if (validate)
            {
                // Validate the request body. If the validation fails, throw a request validation
                // exception that will return a 500 error back to eSTS.
                try
                {
                    Helpers.ValidateGraph(eventRequest);
                }
                catch (ValidationException exception)
                {
                    throw new AuthenticationEventTriggerRequestValidationException(exception.Message, exception.InnerException);
                }
            }

            responseInfo.SetValue(eventRequest, eventResponse);

            return eventRequest;
        }

        internal static WebJobsAuthenticationEventRequestBase CreateEventRequest(HttpRequestMessage request, Type type, params object[] args)
        {
            foreach (WebJobsAuthenticationEventDefinition eventDefinition in Enum.GetValues(typeof(WebJobsAuthenticationEventDefinition)))
            {
                WebJobsAuthenticationEventMetadataAttribute eventMetadata = eventDefinition.GetAttribute<WebJobsAuthenticationEventMetadataAttribute>();
                if (eventMetadata.RequestType == type)
                {
                    AuthenticationEventMetadata metadata = AuthenticationEventMetadataLoader.GetEventMetadata(eventDefinition);
                    return metadata.CreateEventRequest(request, null, false, args);
                }
            }

            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    AuthenticationEventResource.Ex_Missing_Def,
                    type));
        }
    }
}