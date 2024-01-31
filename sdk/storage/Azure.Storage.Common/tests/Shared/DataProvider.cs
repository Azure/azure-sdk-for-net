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

        public static string GetNewString(int length = 20, Random random = null)
        {
            random ??= new Random();
            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                buffer[i] = (char)('a' + random.Next(0, 25));
            }
            return new string(buffer);
        }
    }
}
