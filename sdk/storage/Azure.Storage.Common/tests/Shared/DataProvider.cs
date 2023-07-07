// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Test
{
    public static class DataProvider
    {
        public static Dictionary<string, string> BuildTags()
            => new()
            {
                { "tagKey0", "tagValue0" },
                { "tagKey1", "tagValue1" }
            };

        public static Dictionary<string, string> BuildMetadata()
            => new(StringComparer.OrdinalIgnoreCase)
                {
                    { "foo", "bar" },
                    { "meta", "data" },
                    { "Capital", "letter" },
                    { "UPPER", "case" }
                };
    }
}
