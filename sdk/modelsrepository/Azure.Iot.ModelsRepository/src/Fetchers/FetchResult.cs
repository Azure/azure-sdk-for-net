// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Iot.ModelsRepository.Fetchers
{
    /// <summary>
    /// The FetchResult class has the purpose of containing key elements of
    /// an IModelFetcher Fetch() operation including model definition, path and whether
    /// it was from an expanded (pre-calculated) fetch.
    /// </summary>
    internal class FetchResult
    {
        public string Definition { get; set; }

        public string Path { get; set; }

        public bool FromExpanded => Path.EndsWith(
            ModelsRepositoryConstants.ExpandedJsonFileExtension,
            StringComparison.InvariantCultureIgnoreCase);
    }
}
