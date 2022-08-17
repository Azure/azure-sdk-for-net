// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net.Http;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Represents event meta-data.</summary>
    internal class AuthEventMetadata
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
        /// <seealso cref="AuthEventRequestBase" />
        /// <seealso cref="AuthEventData" />
        internal AuthEventRequestBase CreateEventRequestValidate(HttpRequestMessage request, string payload, params object[] args)
        {
            return CreateEventRequest(request, payload, true, args);
        }

        /// <summary>Creates the event request,response and data model instances for the related event.</summary>
        /// <param name="request">The incoming HTTP request message.</param>
        /// <param name="payload">The Json payload.</param>
        /// <param name="validate">Validate the generated object.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>A newly create EventRequest with related EventResponse and EventData based on event type.</returns>
        /// <seealso cref="AuthEventRequestBase" />
        /// <seealso cref="AuthEventData" />
        internal AuthEventRequestBase CreateEventRequest(HttpRequestMessage request, string payload, bool validate, params object[] args)
        {
            AuthEventRequestBase eventRequest = (AuthEventRequestBase)Activator.CreateInstance(RequestType, new object[] { request });
            PropertyInfo responseInfo = eventRequest.GetType().GetProperty("Response");
            PropertyInfo dataInfo = eventRequest.GetType().GetProperty("Payload");

            AuthEventResponse eventResponse = AuthEventResponse.CreateInstance(
                responseInfo.PropertyType,
                // ResponseSchema ?? string.Empty,
                ResponseTemplate ?? string.Empty);

            responseInfo.SetValue(eventRequest, eventResponse);

            if (args != null && args.Length != 0)
            {
                eventRequest.InstanceCreated(args);
            }

            if (!string.IsNullOrEmpty(payload))
            {
                AuthEventJsonElement jsonPayload = new(payload);
                eventResponse.InstanceCreated(jsonPayload);
                dataInfo.SetValue(eventRequest, AuthEventData.CreateInstance(dataInfo.PropertyType, jsonPayload));
                eventRequest.ParseInbound(jsonPayload);
            }

            eventRequest.StatusMessage = AuthEventResource.Status_Good;

            if (validate)
            {
                Helpers.ValidateGraph(eventRequest);
            }

            return eventRequest;
        }

        internal static AuthEventRequestBase CreateEventRequest(HttpRequestMessage request, Type type, params object[] args)
        {
            foreach (EventDefinition eventDefinition in Enum.GetValues(typeof(EventDefinition)))
            {
                AuthEventMetadataAttribute eventMetadata = eventDefinition.GetAttribute<AuthEventMetadataAttribute>();
                if (eventMetadata.RequestType == type)
                {
                    AuthEventMetadata metadata = AuthEventMetadataLoader.GetEventMetadata(eventDefinition);
                    return metadata.CreateEventRequest(request, null, false, args);
                }
            }

            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_Missing_Def, type));
        }
    }
}