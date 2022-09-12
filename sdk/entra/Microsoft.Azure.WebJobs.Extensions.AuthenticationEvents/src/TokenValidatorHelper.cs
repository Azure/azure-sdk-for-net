// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Helper functions for token validations.</summary>
    internal static class TokenValidatorHelper
    {
        public static SupportedTokenSchemaVersions ParseSupportedTokenVersion(string version)
        {
            string[] v1 = { "1.0", "1", "ver1" };
            string[] v2 = { "2.0", "2", "ver2" };
            if (v1.Contains(version))
            {
                return SupportedTokenSchemaVersions.V1_0;
            }
            else if (v2.Contains(version))
            {
                return SupportedTokenSchemaVersions.V2_0;
            }
            else
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Token_Version, version, String.Join(",", Enum.GetNames(typeof(SupportedTokenSchemaVersions)))));
            }
        }
    }
}
