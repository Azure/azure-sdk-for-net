// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Core;

namespace Azure.Data.SchemaRegistry.Serialization
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Entity's client.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Complete tasks, it is highly recommended that the CompleteEvent.Id be exactly StartEvent.Id + 1.
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal class SchemaRegistrySerializationEventSource : AzureEventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Microsoft-Azure-Data-SchemaRegistry-JsonSchema";

        internal const int CacheUpdatedEvent = 1;

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        public static SchemaRegistrySerializationEventSource Log { get; } = new SchemaRegistrySerializationEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="SchemaRegistrySerializationEventSource"/> class from being
        ///   created outside the scope of the <see cref="Log" /> instance, as well as setting up the
        ///   integration with AzureEventSourceListener.
        /// </summary>
        protected SchemaRegistrySerializationEventSource() : base(EventSourceName)
        {
        }

        [NonEvent]
        public virtual void CacheUpdated(LruCache<string, string> idToSchemaCache, LruCache<string, string> schemaToIdCache)
        {
            if (IsEnabled())
            {
                CacheUpdatedCore(idToSchemaCache.Count + schemaToIdCache.Count, idToSchemaCache.TotalLength + schemaToIdCache.TotalLength);
            }
        }

        [Event(CacheUpdatedEvent, Level = EventLevel.Verbose, Message = "Cache entry added or updated. Total number of entries: {0}; Total schema length: {1}")]
        public virtual void CacheUpdatedCore(int entryCount, int totalSchemaLength)
        {
            if (IsEnabled())
            {
                WriteEvent(CacheUpdatedEvent, entryCount, totalSchemaLength);
            }
        }
    }
}
