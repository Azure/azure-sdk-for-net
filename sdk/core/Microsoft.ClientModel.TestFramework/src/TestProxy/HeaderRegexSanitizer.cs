using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

public partial class HeaderRegexSanitizer
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="headerKey"></param>
    /// <param name="queryParameter"></param>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    public static HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string sanitizedValue) =>
        new(headerKey, sanitizedValue, $@"([\x0026|&|?]{queryParameter}=)(?<group>[^&]+)", "group");
}
