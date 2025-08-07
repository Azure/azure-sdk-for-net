// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework.Models
{
    public partial class UriRegexSanitizer
    {
        public static UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string sanitizedValue) =>
            new($@"([\x0026|&|?]{queryParameter}=)(?<group>[^&]+)")
            {
                GroupForReplace = "group",
                Value = sanitizedValue
            };
    }
}
