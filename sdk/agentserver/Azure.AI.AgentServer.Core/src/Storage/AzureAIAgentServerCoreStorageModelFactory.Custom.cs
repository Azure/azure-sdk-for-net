// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>Creates state-store model instances for mocking.</summary>
    // Preserve the existing public factory name; the package-level emitter defaults to AgentServerCoreModelFactory.
    [CodeGenType("AgentServerCoreModelFactory")]
    [CodeGenSuppress("DeletedStateStore", typeof(string), typeof(string), typeof(bool))]
    [CodeGenSuppress("DeletedStateStoreItem", typeof(string), typeof(string), typeof(bool))]
    [CodeGenSuppress(
        "StateStore",
        typeof(string),
        typeof(string),
        typeof(bool),
        typeof(int),
        typeof(string),
        typeof(IDictionary<string, string>),
        typeof(long),
        typeof(long))]
    public static partial class AzureAIAgentServerCoreStorageModelFactory
    {
        /// <summary>Creates a deleted state-store model for mocking.</summary>
        public static DeletedStateStore DeletedStateStore(
            string? id = null,
            string name = default!,
            bool deleted = default)
            => new(id, "state_store", name, deleted, additionalBinaryDataProperties: null);

        /// <summary>Creates a deleted state-store item model for mocking.</summary>
        public static DeletedStateStoreItem DeletedStateStoreItem(
            string? id = null,
            string key = default!,
            bool deleted = default)
            => new(id, "state_store.item", key, deleted, additionalBinaryDataProperties: null);

        /// <summary>Creates a state-store model for mocking.</summary>
        public static StateStore StateStore(
            string id = default!,
            string name = default!,
            bool userIsolation = default,
            int itemTtlSeconds = default,
            string? description = null,
            IDictionary<string, string> tags = null!,
            long createdAt = default,
            long updatedAt = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new StateStore(
                id,
                "state_store",
                name,
                userIsolation,
                itemTtlSeconds,
                description,
                tags,
                createdAt,
                updatedAt,
                additionalBinaryDataProperties: null);
        }

        internal static ListResponseStateStoreItemKey ListResponseStateStoreItemKey(
            IEnumerable<StateStoreItemKey>? data = null,
            string? firstId = null,
            string? lastId = null,
            bool hasMore = default)
        {
            data ??= Array.Empty<StateStoreItemKey>();
            return new ListResponseStateStoreItemKey(data, firstId, lastId, hasMore);
        }
    }
}
