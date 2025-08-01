﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework.TestProxy;

public partial class UriRegexSanitizer
{
    /// <summary>
    /// Creates a new <see cref="UriRegexSanitizer"/> instance configured to sanitize
    /// a specific query parameter in URIs during test recording.
    /// </summary>
    /// <param name="queryParameter">
    /// The name of the query parameter to sanitize. This should be the exact parameter
    /// name without the '=' sign (e.g., "api-version", "subscription-id").
    /// </param>
    /// <param name="sanitizedValue">
    /// The replacement value to use when sanitizing the query parameter. This value
    /// will replace the actual parameter value in recorded test sessions.
    /// </param>
    /// <returns>
    /// A configured <see cref="UriRegexSanitizer"/> that will match and sanitize
    /// the specified query parameter in URI strings.
    /// </returns>
    public static UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string sanitizedValue) =>
        new($@"([\x0026|&|?]{queryParameter}=)(?<group>[^&]+)", sanitizedValue, "group", null);
}
