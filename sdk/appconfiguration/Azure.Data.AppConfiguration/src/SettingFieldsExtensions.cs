// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Data.AppConfiguration 
{
    internal static class SettingFieldsExtensions
    {
        public static string ToLowerCaseString(this SettingFields settingFields) => ((ulong)settingFields).FlagsToString(Names, Values);

        private static IReadOnlyList<string> Names { get; } = new List<string>
            {
                "key",
                "label",
                "value",
                "contenttype",
                "etag",
                "lastmodified",
                "locked",
                "tags",
                "all",
            };

        private static IReadOnlyList<ulong> Values { get; } = new List<ulong>
            {
                (ulong)SettingFields.Key,
                (ulong)SettingFields.Label,
                (ulong)SettingFields.Value,
                (ulong)SettingFields.ContentType,
                (ulong)SettingFields.ETag,
                (ulong)SettingFields.LastModified,
                (ulong)SettingFields.ReadOnly,
                (ulong)SettingFields.Tags,
                (ulong)SettingFields.All,
            };
    }
}
