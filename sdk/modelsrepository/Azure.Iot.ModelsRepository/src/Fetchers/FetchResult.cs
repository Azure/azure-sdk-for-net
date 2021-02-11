// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.ModelsRepository.Fetchers
{
    internal class FetchResult
    {
        public string Definition { get; set; }
        public string Path { get; set; }
        public bool FromExpanded => Path.EndsWith("expanded.json", System.StringComparison.InvariantCultureIgnoreCase);
    }
}
