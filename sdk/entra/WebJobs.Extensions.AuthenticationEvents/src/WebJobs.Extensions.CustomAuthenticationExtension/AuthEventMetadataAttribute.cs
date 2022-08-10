// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>EventMetadata enum attribute that controls the related request object, schemas and json payloads</summary>
    /// <seealso cref="AuthEventRequest{T, K}" />
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AuthEventMetadataAttribute : Attribute
    {
        /// <summary>Gets or sets the type of the request.</summary>
        /// <value>The type of the request.
        /// Which is must inherit EventRequest</value>
        /// <seealso cref="AuthEventRequest{T, K}" />
        internal Type RequestType { get; set; }
        /// <summary>Gets or sets the request schema.
        /// The name of the schema file in the event folder.</summary>
        /// <value>The request schema.</value>
        public string RequestSchema { get; set; }
        /// <summary>Gets or sets the open API document.</summary>
        /// <value>The open API document.</value>
        internal string OpenApiDocument { get; set; }
        /// <summary>Gets or sets the event namespace.</summary>
        /// <value>The event namespace.</value>
        public string EventNamespace { get; set; }
        /// <summary>Gets or sets the response schema.
        /// The name of the schema file in the event folder.</summary>
        /// <value>The response schema.</value>
        public string ResponseSchema { get; set; }
        /// <summary>Gets or sets the response template.
        /// This with be the base response Json template file located in the event folder</summary>
        /// <value>The response template.</value>
        internal string ResponseTemplate { get; set; }
        /// <summary>Gets or sets the EventIdentifer.</summary>
        /// <value>The Event Identifier.</value>
        internal string EventIdentifier { get; set; }

        /// <summary>Initializes a new instance of the <see cref="AuthEventMetadataAttribute" /> class.</summary>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="eventIdentifier">The event identifier.</param>
        /// <param name="eventNamespace">The name space related to the event</param>
        /// <param name="requestSchema">The request schema.
        /// Defaulted to RequestSchema.json</param>
        /// <param name="responseSchema">The response schema.
        /// Defaulted to ResponseSchema.json</param>
        /// <param name="responseTemplate">The response template.
        /// Defaulted to ResponseTemplate.json</param>
        /// <param name="openApiDocument"></param>
        /// <exception cref="Exception">If the requestType in not of type EventRequest</exception>
        internal AuthEventMetadataAttribute(Type requestType, string eventIdentifier, string eventNamespace, string requestSchema = "requestSchema.json", string responseSchema = "responseSchema.json", string responseTemplate = "ResponseTemplate.json", string openApiDocument = "openapi.json")
        {
            if (!typeof(AuthEventRequestBase).IsAssignableFrom(requestType))
                throw new Exception(AuthEventResource.Ex_Invalid_EventType);

            RequestType = requestType;
            RequestSchema = requestSchema;
            EventNamespace = eventNamespace;
            ResponseSchema = responseSchema;
            ResponseTemplate = responseTemplate;
            EventIdentifier = eventIdentifier;
            OpenApiDocument = openApiDocument;
        }
    }
}
