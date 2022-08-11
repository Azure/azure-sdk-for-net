// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Lazy loader and caching for events and the event's related event.</summary>
    internal class AuthEventMetadataLoader
    {
        private static AuthEventMetadataLoader _instance;
        private static readonly object _lock = new();
        private readonly Dictionary<string, AuthEventMetadata> _events = new();

        /// <summary>Prevents a default instance of the <see cref="AuthEventMetadataLoader" /> class from being created.</summary>
        private AuthEventMetadataLoader() { }

        /// <summary>Gets the instance.</summary>
        /// <value>The instance.</value>
        internal static AuthEventMetadataLoader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthEventMetadataLoader();

                return _instance;
            }
        }

        /// <summary>Gets the event based on the event type.</summary>
        /// <param name="payload">The incoming payload to determine the correct event metadata to use.</param>
        /// <returns>The related event meta-data.</returns>
        /// <exception cref="MissingFieldException">Is thrown when the event metadata attribute is not found on the event definition enum.</exception>
        /// <exception cref="Exception">If not lock is achieved on the thread.</exception>
        /// <seealso cref="AuthEventMetadata" />
        internal static AuthEventMetadata GetEventMetadata(string payload)
        {
            //As we read from files we lock this thread to only one execution at a time.
            bool lockTaken = false;
            Monitor.TryEnter(_lock, 5000, ref lockTaken);
            try
            {
                if (lockTaken)
                {
                    return GetEventMetadata(Helpers.GetEventDefintionFromPayload(payload));
                }
                else
                    throw new Exception(AuthEventResource.Ex_No_Lock);
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }

        internal static AuthEventMetadata GetEventMetadata(EventDefinition eventDef)
        {
            var eventMetadataAttr = eventDef.GetAttribute<AuthEventMetadataAttribute>();
            if (eventMetadataAttr == null)
                throw new MissingFieldException(AuthEventResource.Ex_No_Attr);

            AuthEventMetadata eventMetadata = Instance._events.ContainsKey(eventMetadataAttr.EventIdentifier) ? Instance._events[eventMetadataAttr.EventIdentifier] : null;

            //If the current event meta-data is not associated to the event we load it from file, associated it and store it in memory
            return eventMetadata ?? LoadFromResource(eventMetadataAttr);
        }

        /// <summary>Loads from schema and payload resource files that are stored as an embedded resource.</summary>
        /// <param name="eventMetadataAttr">The event metadata attribute with reference the schema files and template payloads.</param>
        /// <returns>EventMetadata with the contents of the embedded resources.</returns>
        /// <seealso cref="AuthEventMetadata" />
        private static AuthEventMetadata LoadFromResource(AuthEventMetadataAttribute eventMetadataAttr)
        {
            AuthEventMetadata eventMetadata = Instance._events.ContainsKey(eventMetadataAttr.EventIdentifier) ? Instance._events[eventMetadataAttr.EventIdentifier] : null;
            if (eventMetadata == null)
            {
                eventMetadata = CreateEventMetadata(eventMetadataAttr);
                Instance._events.Add(eventMetadataAttr.EventIdentifier, eventMetadata);
            }

            return eventMetadata;
        }

        internal static AuthEventMetadata CreateEventMetadata(AuthEventMetadataAttribute eventMetadataAttr)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var defaultNS = typeof(AuthenticationEventsTriggerAttribute).Namespace;
            return new AuthEventMetadata()
            {
                RequestType = eventMetadataAttr.RequestType,
                RequestSchema = ReadResource(assembly, string.Join(".", defaultNS, "Schema", eventMetadataAttr.EventNamespace, eventMetadataAttr.RequestSchema)),
                ResponseSchema = ReadResource(assembly, string.Join(".", defaultNS, "Schema", eventMetadataAttr.EventNamespace, eventMetadataAttr.ResponseSchema)),
                OpenApiDocument = ReadResource(assembly, string.Join(".", defaultNS, "Schema", eventMetadataAttr.EventNamespace, eventMetadataAttr.OpenApiDocument), string.Empty),
                ResponseTemplate = GetResponseTemplate(assembly, defaultNS ?? string.Empty, eventMetadataAttr)
            };
        }

        private static string GetResponseTemplate(Assembly assembly, string defaultNS, AuthEventMetadataAttribute verAttr)
        {
            string resource = string.Join(".", defaultNS, "Templates", verAttr.ResponseTemplate);

            if (!assembly.GetManifestResourceNames().Any(x => x == resource))
                resource = string.Join(".", defaultNS, "Templates", "ActionableTemplate.json");

            return ReadResource(assembly, resource);
        }

        /// <summary>Reads the embedded resource.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="defaultBody">If no resource is found, what default value should be used, if null an error is thrown.</param>
        /// <returns>The content of the embedded resource.</returns>
        /// <exception cref="Exception"></exception>
        private static string ReadResource(Assembly assembly, string resource, string defaultBody = null)
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                if (!assembly.GetManifestResourceNames().Any(x => x == resource))
                {
                    if (defaultBody != null)
                        return defaultBody;

                    throw new Exception(AuthEventResource.Ex_Invalid_EventSchema);
                }
                stream = assembly.GetManifestResourceStream(resource);

                reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
            }
        }
    }
}
