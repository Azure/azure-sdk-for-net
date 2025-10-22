// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Encapsulates the shared properties used by both
    /// BlobSasQueryParameters and DataLakeSasQueryParameters.
    /// </summary>
    internal class UserDelegationKeyProperties
    {
        // skoid
        internal string ObjectId { get; set; }

        // sktid
        internal string TenantId { get; set; }

        // skt
        internal DateTimeOffset StartsOn { get; set; }

        // ske
        internal DateTimeOffset ExpiresOn { get; set; }

        // sks
        internal string Service { get; set; }

        // skv
        internal string Version { get; set; }

        // skdutid
        public string SignedDelegatedUserTenantId { get; set; }

        /// <summary>
        /// Builds up the UserDelegationKey portion of the SAS query parameter string.
        /// </summary>
        public void AppendProperties(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(ObjectId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyObjectId, ObjectId);
            }

            if (!string.IsNullOrWhiteSpace(TenantId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyTenantId, TenantId);
            }

            if (StartsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(StartsOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture)));
            }

            if (ExpiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(ExpiresOn.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrWhiteSpace(Service))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyService, Service);
            }

            if (!string.IsNullOrWhiteSpace(Version))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyVersion, Version);
            }

            if (!string.IsNullOrWhiteSpace(SignedDelegatedUserTenantId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.DelegatedUserTenantId, SignedDelegatedUserTenantId);
            }
        }
    }
}
