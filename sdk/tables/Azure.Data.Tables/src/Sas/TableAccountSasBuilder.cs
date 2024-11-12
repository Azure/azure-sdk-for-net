// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// <see cref="TableAccountSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage table.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas"/>.
    /// </summary>
    public class TableAccountSasBuilder
    {
        /// <summary>
        /// Initializes an instance of a <see cref="TableAccountSasBuilder"/>.
        /// </summary>
        /// <param name="permissions">The permissions associated with the shared access signature.</param>
        /// <param name="resourceTypes"><see cref="TableAccountSasResourceTypes"/> containing the accessible resource types.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        public TableAccountSasBuilder(TableAccountSasPermissions permissions, TableAccountSasResourceTypes resourceTypes, DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
            ResourceTypes = resourceTypes;
        }

        /// <summary>
        /// Initializes an instance of a <see cref="TableAccountSasBuilder"/>.
        /// </summary>
        /// <param name="rawPermissions">The permissions associated with the shared access signature. This string should contain one or more of the following permission characters in this order: "racwdl".</param>
        /// <param name="resourceTypes"><see cref="TableAccountSasResourceTypes"/> containing the accessible resource types.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        public TableAccountSasBuilder(string rawPermissions, TableAccountSasResourceTypes resourceTypes, DateTimeOffset expiresOn)
        {
            Argument.AssertNotNullOrEmpty(rawPermissions, nameof(rawPermissions));

            ExpiresOn = expiresOn;
            Permissions = rawPermissions;
            ResourceTypes = resourceTypes;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TableAccountSasBuilder"/> based on an existing Uri containing a shared acccess signature.
        /// </summary>
        /// <param name="sasUri">The Uri containing a SAS token to parse.</param>
        /// <returns></returns>
        public TableAccountSasBuilder(Uri sasUri)
        {
            Argument.AssertNotNull(sasUri, nameof(sasUri));

            var uriBuilder = new TableUriBuilder(sasUri);

            if (!uriBuilder.Sas.ResourceTypes.HasValue)
            {
                throw new ArgumentException("Uri must contain a ResourceType value", nameof(sasUri));
            }

            ExpiresOn = uriBuilder.Sas.ExpiresOn;
            Identifier = uriBuilder.Sas.Identifier;
            IPRange = uriBuilder.Sas.IPRange;
            Protocol = uriBuilder.Sas.Protocol;
            StartsOn = uriBuilder.Sas.StartsOn;
            Version = uriBuilder.Sas.Version;
            ResourceTypes = uriBuilder.Sas.ResourceTypes.Value;
            SetPermissions(uriBuilder.Sas.Permissions);
        }

        /// <summary>
        /// The optional signed protocol field specifies the protocol
        /// permitted for a request made with the SAS.  Possible values are
        /// <see cref="TableSasProtocol.HttpsAndHttp"/>,
        /// <see cref="TableSasProtocol.Https"/>, and
        /// <see cref="TableSasProtocol.None"/>.
        /// </summary>
        public TableSasProtocol Protocol { get; set; }

        /// <summary>
        /// Optionally specify the time at which the shared access signature
        /// becomes valid.  If omitted when DateTimeOffset.MinValue is used,
        /// start time for this call is assumed to be the time when the
        /// storage service receives the request.
        /// </summary>
        public DateTimeOffset StartsOn { get; set; }

        /// <summary>
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// The permissions associated with the shared access signature. The
        /// user is restricted to operations allowed by the permissions. This
        /// field must be omitted if it has been specified in an associated
        /// stored access policy.  <see cref="TableAccountSasPermissions"/> can be used to create the
        /// permissions string.
        /// </summary>
        public string Permissions { get; private set; }

        /// <summary>
        /// Specifies an IP address or a range of IP addresses from which to
        /// accept requests. If the IP address from which the request
        /// originates does not match the IP address or address range
        /// specified on the SAS token, the request is not authenticated.
        /// When specifying a range of IP addresses, note that the range is
        /// inclusive.
        /// </summary>
        public TableSasIPRange IPRange { get; set; }

        /// <summary>
        /// An optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The resource types associated with the shared access signature. The
        /// user is restricted to operations on the specified resources.
        /// </summary>
        public TableAccountSasResourceTypes ResourceTypes { get; set; }

        /// <summary>
        /// The storage service version to use to authenticate requests made
        /// with this shared access signature, and the service version to use
        /// when handling requests made with this shared access signature.
        /// </summary>
        internal string Version { get; set; }

        /// <summary>
        /// Sets the permissions for a table SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="TableAccountSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(TableAccountSasPermissions permissions)
        {
            Permissions = permissions.ToPermissionsString();
        }

        /// <summary>
        /// Sets the permissions for the SAS using a raw permissions string.
        /// </summary>
        /// <param name="rawPermissions">Raw permissions string for the SAS.</param>
        public void SetPermissions(string rawPermissions)
        {
            Permissions = rawPermissions;
        }

        /// <summary>
        /// Use an account's <see cref="TableSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="TableSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// An instance of <see cref="TableAccountSasQueryParameters"/>.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/data-tables")]
        public TableAccountSasQueryParameters ToSasQueryParameters(TableSharedKeyCredential sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            EnsureState();

            var startTime = TableSasExtensions.FormatTimesForSasSigning(StartsOn);
            var expiryTime = TableSasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas#constructing-the-signature-string
            var stringToSign = string.Join("\n",
                sharedKeyCredential.AccountName,
                Permissions,
                TableConstants.Sas.TableAccountServices.Table,
                ResourceTypes.ToPermissionsString(),
                startTime,
                expiryTime,
                IPRange.ToString(),
                Protocol.ToProtocolString(),
                Version,
                "");
            var signature = TableSharedKeyCredential.ComputeSasSignature(sharedKeyCredential, stringToSign);
            var p = new TableAccountSasQueryParameters(
                version: Version,
                resourceTypes: ResourceTypes,
                protocol: Protocol,
                startsOn: StartsOn,
                expiresOn: ExpiresOn,
                ipRange: IPRange,
                identifier: Identifier,
                resource: null,
                permissions: Permissions,
                signature: signature);
            return p;
        }

        /// <summary>
        /// Use an account's <see cref="TableSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="TableSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/data-tables")]
        public string Sign(TableSharedKeyCredential sharedKeyCredential) =>
            ToSasQueryParameters(sharedKeyCredential).ToString();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two TablesSasBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the TablesSasBuilder.
        /// </summary>
        /// <returns>Hash code for the TablesSasBuilder.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Ensure the <see cref="TableAccountSasBuilder"/>'s properties are in a
        /// consistent state.
        /// </summary>
        private void EnsureState()
        {
            if (ResourceTypes == default)
            {
                throw Errors.SasMissingData(nameof(ResourceTypes));
            }
            if (ExpiresOn == default)
            {
                throw Errors.SasMissingData(nameof(ExpiresOn));
            }
            if (string.IsNullOrEmpty(Permissions))
            {
                throw Errors.SasMissingData(nameof(Permissions));
            }
            if (string.IsNullOrEmpty(Version))
            {
                Version = TableAccountSasQueryParameters.DefaultSasVersion;
            }
        }
    }
}
