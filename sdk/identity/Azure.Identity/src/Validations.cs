// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal static class Validations
    {



        private const string InvalidTenantIdErrorMessage = "Invalid tenant id provided. You can locate your tenant id by following the instructions listed here: https://docs.microsoft.com/partner-center/find-ids-and-domain-names";

        private const string NullTenantIdErrorMessage = "Tenant id cannot be null. You can locate your tenant id by following the instructions listed here: https://docs.microsoft.com/partner-center/find-ids-and-domain-names";

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

        private static bool IsValidTenantCharacter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || (c == '.') || (c == '-');
        }
    }
}
