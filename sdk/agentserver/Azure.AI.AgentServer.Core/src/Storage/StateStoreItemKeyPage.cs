// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// A page of keys returned by <see cref="FoundryStateStore.ListKeysAsync"/>.
    /// </summary>
    /// <remarks>
    /// A hand-written convenience wrapper (not itself part of the wire contract) over the
    /// generated <c>ListResponseStateStoreItemKey</c> envelope, exposing its <c>data</c> array as
    /// <see cref="Keys"/> to match this client's naming.
    /// </remarks>
    public sealed class StateStoreItemKeyPage
    {
        internal StateStoreItemKeyPage(ListResponseStateStoreItemKey envelope)
        {
            Keys = envelope.Data is null
                ? new List<StateStoreItemKey>()
                : envelope.Data.ToList();
            FirstId = envelope.FirstId;
            LastId = envelope.LastId;
            HasMore = envelope.HasMore;
        }

        /// <summary>The page of keys, ordered by creation time.</summary>
        public IReadOnlyList<StateStoreItemKey> Keys { get; }

        /// <summary>The id of the first key on this page, or <see langword="null"/> when empty.</summary>
        public string? FirstId { get; }

        /// <summary>The id of the last key on this page, or <see langword="null"/> when empty.</summary>
        public string? LastId { get; }

        /// <summary>Whether another page is available after <see cref="LastId"/>.</summary>
        public bool HasMore { get; }
    }
}
