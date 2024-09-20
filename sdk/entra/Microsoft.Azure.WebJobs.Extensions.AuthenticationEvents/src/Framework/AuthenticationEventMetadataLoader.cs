// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Lazy loader and caching for events and the event's related event.</summary>
    internal class AuthenticationEventMetadataLoader
    {
        private static AuthenticationEventMetadataLoader _instance;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly Dictionary<string, AuthenticationEventMetadata> _events = new Dictionary<string, AuthenticationEventMetadata>();

        /// <summary>Prevents a default instance of the <see cref="AuthenticationEventMetadataLoader" /> class from being created.</summary>
        private AuthenticationEventMetadataLoader() { }

        /// <summary>Gets the instance.</summary>
        /// <value>The instance.</value>
        internal static AuthenticationEventMetadataLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthenticationEventMetadataLoader();
                }

                return _instance;
            }
        }

        /// <summary>Gets the event based on the event type.</summary>
        /// <param name="payload">The incoming payload to determine the correct event metadata to use.</param>
        /// <returns>The related event meta-data.</returns>
        /// <exception cref="MissingFieldException">Is thrown when the event metadata attribute is not found on the event definition enum.</exception>
        /// <exception cref="Exception">If not lock is achieved on the thread.</exception>
        /// <seealso cref="AuthenticationEventMetadata" />
        internal static AuthenticationEventMetadata GetEventMetadata(string payload)
        {
            return GetEventMetadata(Helpers.GetEventDefintionFromPayload(payload));
        }

        internal static AuthenticationEventMetadata GetEventMetadata(WebJobsAuthenticationEventDefinition eventDef)
        {
            var eventMetadataAttr = eventDef.GetAttribute<WebJobsAuthenticationEventMetadataAttribute>();
            if (eventMetadataAttr == null)
            {
                throw new MissingFieldException(AuthenticationEventResource.Ex_No_Attr);
            }

            AuthenticationEventMetadata eventMetadata = Instance._events.ContainsKey(eventMetadataAttr.EventIdentifier) ? Instance._events[eventMetadataAttr.EventIdentifier] : null;

            //If the current event meta-data is not associated to the event we load it from file, associated it and store it in memory
            return eventMetadata ?? LoadFromResource(eventMetadataAttr);
        }

        /// <summary>Loads from schema and payload resource files that are stored as an embedded resource.</summary>
        /// <param name="eventMetadataAttr">The event metadata attribute with reference the schema files and template payloads.</param>
        /// <returns>EventMetadata with the contents of the embedded resources.</returns>
        /// <seealso cref="AuthenticationEventMetadata" />
        private static AuthenticationEventMetadata LoadFromResource(WebJobsAuthenticationEventMetadataAttribute eventMetadataAttr)
        {
            //As we read from files we lock this thread to only one execution at a time.
            _semaphore.Wait();
            try
            {
                AuthenticationEventMetadata eventMetadata = Instance._events.ContainsKey(eventMetadataAttr.EventIdentifier) ? Instance._events[eventMetadataAttr.EventIdentifier] : null;
                if (eventMetadata == null)
                {
                    eventMetadata = CreateEventMetadata(eventMetadataAttr);
                    Instance._events.Add(eventMetadataAttr.EventIdentifier, eventMetadata);
                }

                return eventMetadata;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        internal static AuthenticationEventMetadata CreateEventMetadata(WebJobsAuthenticationEventMetadataAttribute eventMetadataAttr)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var defaultNS = typeof(WebJobsAuthenticationEventsTriggerAttribute).Namespace;
            return new AuthenticationEventMetadata()
            {
                RequestType = eventMetadataAttr.RequestType,
                ResponseTemplate = GetResponseTemplate(assembly, defaultNS ?? string.Empty, eventMetadataAttr)
            };
        }

        private static string GetResponseTemplate(Assembly assembly, string defaultNS, WebJobsAuthenticationEventMetadataAttribute verAttr)
        {
            string resource = string.Join(".", defaultNS, "Templates", verAttr.ResponseTemplate);

            if (!assembly.GetManifestResourceNames().Any(x => x == resource))
            {
                resource = string.Join(".", defaultNS, "Templates", "ActionableTemplate.json");
            }

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
                    return defaultBody != null ? defaultBody : throw new Exception(AuthenticationEventResource.Ex_Invalid_EventSchema);
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
