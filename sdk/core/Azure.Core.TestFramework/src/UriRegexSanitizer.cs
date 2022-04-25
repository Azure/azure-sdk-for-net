// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework.Models
{
    public partial class UriRegexSanitizer
    {
        public static UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string value) =>
            new($@"([\x0026|&|?]{queryParameter}=)(?<group>[\w\d%]+)", value)
            {
                GroupForReplace = "group"
            };
    }
}