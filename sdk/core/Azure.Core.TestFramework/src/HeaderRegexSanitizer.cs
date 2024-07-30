// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework.Models
{
    public partial class HeaderRegexSanitizer
    {
        public static HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string sanitizedValue) =>
            new(headerKey)
            {
                // match the value of the query parameter up until the next ampersand or the end of the string
                Regex = $@"([\x0026|&|?]{queryParameter}=)(?<group>[^&]+)",
                GroupForReplace = "group",
                Value = sanitizedValue
            };
    }
}
