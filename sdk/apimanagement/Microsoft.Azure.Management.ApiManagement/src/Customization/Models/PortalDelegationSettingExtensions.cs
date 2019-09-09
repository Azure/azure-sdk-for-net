// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Portal Delegation Settings.
    /// </summary>
    public partial class PortalDelegationSettings
    {
        const int ValidateKeyLength = 64;

        public static string GenerateValidationKey()
        {
            var bytes = new byte[ValidateKeyLength];
            Random rnd = new Random();
            rnd.NextBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
