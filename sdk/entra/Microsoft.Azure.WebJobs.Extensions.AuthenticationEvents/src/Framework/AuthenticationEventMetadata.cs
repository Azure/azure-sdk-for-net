// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Http;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Represents event meta-data.</summary>
    internal class AuthenticationEventMetadata
    {
        /// <summary>Gets or sets the type of the request.</summary>
        /// <value>The type of the request.</value>
        internal Type RequestType { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        internal EventDefinition Id { get; set; }

        /// <summary>Gets or sets the response template content.</summary>
        /// <value>The response template content.</value>
        internal string ResponseTemplate { get; set; }

        /// <summary>Creates the event request,response and data model instances for the related event.</summary>
        /// <param name="request">The incoming HTTP request message.</param>
        /// <param name="payload">The Json payload.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>A newly create EventRequest with related EventResponse and EventData based on event type.</returns>
        /// <seealso cref="AuthenticationEventRequestBase" />
        /// <seealso cref="AuthenticationEventData" />
        internal AuthenticationEventRequestBase CreateEventRequestValidate(HttpRequestMessage request, string payload, params object[] args)
        {
            return CreateEventRequest(request, payload, true, args);
        }

        /// <summary>Creates the event request,response and data model instances for the related event.</summary>
        /// <param name="request">The incoming HTTP request message.</param>
        /// <param name="payload">The Json payload.</param>
        /// <param name="validate">Validate the generated object.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>A newly create EventRequest with related EventResponse and EventData based on event type.</returns>
        /// <seealso cref="AuthenticationEventRequestBase" />
        /// <seealso cref="AuthenticationEventData" />
        internal AuthenticationEventRequestBase CreateEventRequest(HttpRequestMessage request, string payload, bool validate, params object[] args)
        {
            AuthenticationEventRequestBase eventRequest = (AuthenticationEventRequestBase)Activator.CreateInstance(RequestType, new object[] { request });
            PropertyInfo responseInfo = eventRequest.GetType().GetProperty("Response");
            PropertyInfo dataInfo = eventRequest.GetType().GetProperty("Data");

            AuthenticationEventResponse eventResponse = AuthenticationEventResponse.CreateInstance(
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
                dataInfo.SetValue(eventRequest, AuthenticationEventData.CreateInstance(dataInfo.PropertyType, jsonPayload));
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

        internal static AuthenticationEventRequestBase CreateEventRequest(HttpRequestMessage request, Type type, params object[] args)
        {
            foreach (EventDefinition eventDefinition in Enum.GetValues(typeof(EventDefinition)))
            {
                AuthenticationEventMetadataAttribute eventMetadata = eventDefinition.GetAttribute<AuthenticationEventMetadataAttribute>();
                if (eventMetadata.RequestType == type)
                {
                    AuthenticationEventMetadata metadata = AuthenticationEventMetadataLoader.GetEventMetadata(eventDefinition);
                    return metadata.CreateEventRequest(request, null, false, args);
                }
            }

            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Missing_Def, type));
        }
    }
}