// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    internal static class JTokenExtensions
    {
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "We're using the right pattern here. Fxcop static analysis doesn't recognize that we are.")]
        public static string ToJsonString(this JToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            // The following code is different from token.ToString(), which special-cases null to return "" instead of
            // "null".
            StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            try
            {
                using (JsonWriter jsonWriter = JsonSerialization.CreateJsonTextWriter(stringWriter))
                {
                    token.WriteTo(jsonWriter);
                    jsonWriter.Flush();
                    stringWriter.Flush();

                    string result = stringWriter.ToString();
                    stringWriter = null;

                    return result;
                }
            }
            finally
            {
                if (stringWriter != null)
                {
                    stringWriter.Dispose();
                }
            }
        }
    }
}
