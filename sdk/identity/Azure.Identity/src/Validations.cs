// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    internal static class Validations
    {
        internal const string InvalidTenantIdErrorMessage = "Invalid tenant id provided. You can locate your tenant id by following the instructions listed here: https://learn.microsoft.com/partner-center/find-ids-and-domain-names";

        private const string NullTenantIdErrorMessage = "Tenant id cannot be null. You can locate your tenant id by following the instructions listed here: https://learn.microsoft.com/partner-center/find-ids-and-domain-names";

        private const string NonTlsAuthorityHostErrorMessage = "Authority host must be a TLS protected (https) endpoint.";

        internal const string NoWindowsPowerShellLegacyErrorMessage = "PowerShell Legacy is only supported in Windows.";

        /// <summary>
        /// As tenant id is used in constructing authority endpoints and in command line invocation we validate the character set of the tenant id matches allowed characters.
        /// </summary>
        public static string ValidateTenantId(string tenantId, string argumentName = default, bool allowNull = false)
        {
            if (tenantId != null)
            {
                if (tenantId.Length == 0)
                {
                    throw (argumentName != null) ? new ArgumentException(InvalidTenantIdErrorMessage, argumentName) : new ArgumentException(InvalidTenantIdErrorMessage);
                }

                foreach (char c in tenantId)
                {
                    if (!IsValidTenantCharacter(c))
                    {
                        throw (argumentName != null) ? new ArgumentException(InvalidTenantIdErrorMessage, argumentName) : new ArgumentException(InvalidTenantIdErrorMessage);
                    }
                }
            }
            else if (!allowNull)
            {
                throw (argumentName != null) ? new ArgumentNullException(argumentName, NullTenantIdErrorMessage) : new ArgumentNullException(InvalidTenantIdErrorMessage, (Exception)null);
            }

            return tenantId;
        }

        public static Uri ValidateAuthorityHost(Uri authorityHost)
        {
            if (authorityHost != null)
            {
                if (string.Compare(authorityHost.Scheme, "https", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    throw new ArgumentException(NonTlsAuthorityHostErrorMessage);
                }
            }

            return authorityHost;
        }

        /// <summary>
        /// PowerShell Legacy can only be used on Windows OS systems.
        /// </summary>
        /// <param name="useLegacyPowerShell"></param>
        /// <returns></returns>
        public static bool CanUseLegacyPowerShell(bool useLegacyPowerShell)
        {
            //If the OS is not Windows, PowerShell Legacy cannot be used
            if (useLegacyPowerShell && !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new ArgumentException(NoWindowsPowerShellLegacyErrorMessage);
            }

            return useLegacyPowerShell;
        }

        private static bool IsValidTenantCharacter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || (c == '.') || (c == '-');
        }
    }
}
