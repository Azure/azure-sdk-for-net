// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>EventMetadata enum attribute that controls the related request object, schemas and json payloads</summary>
    /// <seealso cref="WebJobsAuthenticationEventRequest{T, K}" />
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class WebJobsAuthenticationEventMetadataAttribute : Attribute
    {
        /// <summary>Gets or sets the type of the request.</summary>
        /// <value>The type of the request.
        /// Which is must inherit EventRequest</value>
        /// <seealso cref="WebJobsAuthenticationEventRequest{T, K}" />
        internal Type RequestType { get; set; }
        /// <summary>Gets or sets the request schema.
        /// The name of the schema file in the event folder.</summary>
        /// <value>The request schema.</value>

        /// <summary>Gets or sets the event namespace.</summary>
        /// <value>The event namespace.</value>
        public string EventNamespace { get; set; }

        /// <summary>Gets or sets the response template.
        /// This with be the base response Json template file located in the event folder</summary>
        /// <value>The response template.</value>
        internal string ResponseTemplate { get; set; }
        /// <summary>Gets or sets the EventIdentifier.</summary>
        /// <value>The Event Identifier.</value>
        internal string EventIdentifier { get; set; }

        /// <summary>Initializes a new instance of the <see cref="WebJobsAuthenticationEventMetadataAttribute" /> class.</summary>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="eventIdentifier">The event identifier.</param>
        /// <param name="eventNamespace">The name space related to the event</param>
        /// <param name="responseTemplate">The response template.
        /// Defaulted to ResponseTemplate.json</param>
        /// <exception cref="Exception">If the requestType in not of type EventRequest</exception>
        internal WebJobsAuthenticationEventMetadataAttribute(Type requestType, string eventIdentifier, string eventNamespace, string responseTemplate = "ResponseTemplate.json")
        {
            if (!typeof(WebJobsAuthenticationEventRequestBase).IsAssignableFrom(requestType))
            {
                throw new Exception(AuthenticationEventResource.Ex_Invalid_EventType);
            }

            RequestType = requestType;
            EventNamespace = eventNamespace;
            ResponseTemplate = responseTemplate;
            EventIdentifier = eventIdentifier;
        }
    }
}
