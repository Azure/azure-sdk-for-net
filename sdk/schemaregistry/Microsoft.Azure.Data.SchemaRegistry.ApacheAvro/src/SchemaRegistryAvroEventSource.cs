// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Avro;
using Azure.Core.Diagnostics;
using Azure.Core;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Entity's client.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Complete tasks, it is highly recommended that the
    ///   the CompleteEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal class SchemaRegistryAvroEventSource : AzureEventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Microsoft-Azure-Data-SchemaRegistry-ApacheAvro";

        internal const int CacheUpdatedEvent = 1;

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        public static SchemaRegistryAvroEventSource Log { get; } = new SchemaRegistryAvroEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="SchemaRegistryAvroEventSource"/> class from being
        ///   created outside the scope of the <see cref="Log" /> instance, as well as setting up the
        ///   integration with AzureEventSourceListener.
        /// </summary>
        protected SchemaRegistryAvroEventSource() : base(EventSourceName)
        {
        }

        [NonEvent]
        public virtual void CacheUpdated(LruCache<string, Schema> idToSchemaCache, LruCache<Schema, string> schemaToIdCache)
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