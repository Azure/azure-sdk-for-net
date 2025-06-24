// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

public partial class UriRegexSanitizer
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="queryParameter"></param>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    public static UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string sanitizedValue) =>
        new($@"([\x0026|&|?]{queryParameter}=)(?<group>[^&]+)", sanitizedValue, "group");
}
