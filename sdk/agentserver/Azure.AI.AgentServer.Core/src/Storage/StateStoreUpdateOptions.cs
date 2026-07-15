// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// Mutable-metadata changes for <see cref="FoundryStateStore.UpdateAsync"/>.
    /// </summary>
    /// <remarks>
    /// A property that is never assigned is left unchanged on the server; assigning
    /// it (including to <see langword="null"/>) sends that value, which clears the
    /// field. Tags are replaced wholesale, not merged.
    /// </remarks>
    public sealed class StateStoreUpdateOptions
    {
        private string? _description;
        private IReadOnlyDictionary<string, string>? _tags;

        /// <summary>Gets or sets the new description. Set to <see langword="null"/> to clear it.</summary>
        public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                IsDescriptionSet = true;
            }
        }

        /// <summary>Gets or sets the new tags (replaces the existing set). Set to <see langword="null"/> to clear them.</summary>
        public IReadOnlyDictionary<string, string>? Tags
        {
            get => _tags;
            set
            {
                _tags = value;
                IsTagsSet = true;
            }
        }

        /// <summary>Gets a value indicating whether <see cref="Description"/> was assigned.</summary>
        internal bool IsDescriptionSet { get; private set; }

        /// <summary>Gets a value indicating whether <see cref="Tags"/> was assigned.</summary>
        internal bool IsTagsSet { get; private set; }
    }
}
