// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework.Models
{
    public partial class HeaderRegexSanitizer
    {
        public static HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string value) =>
            new(headerKey, value)
            {
                Regex = $@"([\x0026|&|?]{queryParameter}=)(?<group>[\w\d%]+)",
                GroupForReplace = "group"
            };
    }
}