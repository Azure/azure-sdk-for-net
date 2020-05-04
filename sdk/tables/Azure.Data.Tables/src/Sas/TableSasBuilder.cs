// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// <see cref="TableSasBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage table.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas" />.
    /// </summary>
    public class TableSasBuilder
    {

        public TableSasBuilder(string tableName)
        {
            Argument.AssertNotNullOrEmpty(tableName, nameof(tableName));

            TableName = tableName;
        }
        /// <summary>
        /// The storage service version to use to authenticate requests made
        /// with this shared access signature, and the service version to use
        /// when handling requests made with this shared access signature.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The optional signed protocol field specifies the protocol
        /// permitted for a request made with the SAS.  Possible values are
        /// <see cref="SasProtocol.HttpsAndHttp"/>,
        /// <see cref="SasProtocol.Https"/>, and
        /// <see cref="SasProtocol.None"/>.
        /// </summary>
        public SasProtocol Protocol { get; set; }

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
        /// stored access policy.  <see cref="TableSasPermissions"/> can be used to create the
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
        public SasIPRange IPRange { get; set; }

        /// <summary>
        /// An optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the table being made accessible.
        /// </summary>
        public string TableName { get; }

        /// <summary>
        /// The optional start of the partition key values range being made available.
        /// </summary>
        public string PartitionKeyStart { get; set; }

        /// <summary>
        /// The optional start of the row key values range being made available.
        /// </summary>
        public string RowKeyStart { get; set; }

        /// <summary>
        /// The optional end of the partition key values range being made available.
        /// <see cref="PartitionKeyStart"/> must be specified if this value is set.
        /// </summary>
        public string PartitionKeyEnd { get; set; }

        /// <summary>
        /// The optional end of the partition key values range being made available.
        /// <see cref="RowKeyStart"/> must be specified if this value is set.
        /// </summary>
        public string RowKeyEnd { get; set; }



        /// <summary>
        /// Sets the permissions for a table SAS.
        /// </summary>
        /// <param name="permissions">
        /// <see cref="TableSasPermissions"/> containing the allowed permissions.
        /// </param>
        public void SetPermissions(TableSasPermissions permissions)
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
        /// Use an account's <see cref="TablesSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="TablesSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// The <see cref="SasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        public TableSasQueryParameters ToSasQueryParameters(TablesSharedKeyCredential sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            EnsureState();

            var startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            var expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = string.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, TableName),
                Identifier,
                IPRange.ToString(),
                SasExtensions.ToProtocolString(Protocol),
                Version,
                PartitionKeyStart,
                RowKeyStart,
                PartitionKeyEnd,
                RowKeyEnd);
            var signature = TablesSharedKeyCredentialInternals.ComputeSasSignature(sharedKeyCredential, stringToSign);
            var p = new TableSasQueryParameters(
                version: Version,
                tableName: TableName,
                services: default,
                resourceTypes: default,
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
        /// Computes the canonical name for a table resource for SAS signing.
        /// </summary>
        /// <param name="account">
        /// Account.
        /// </param>
        /// <param name="tableName">
        /// Name of table.
        /// </param>
        /// <returns>
        /// Canonical name as a string.
        /// </returns>
        private static string GetCanonicalName(string account, string tableName) =>
            // Table: "/table/account/tablename"
            string.Join("", new[] { "/table/", account, "/", tableName });

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
        /// Ensure the <see cref="TableSasBuilder"/>'s properties are in a
        /// consistent state.
        /// </summary>
        private void EnsureState()
        {
            if (Identifier == default)
            {
                if (ExpiresOn == default)
                {
                    throw Errors.SasMissingData(nameof(ExpiresOn));
                }
                if (string.IsNullOrEmpty(Permissions))
                {
                    throw Errors.SasMissingData(nameof(Permissions));
                }
            }

            if (string.IsNullOrEmpty(Version))
            {
                Version = SasQueryParameters.DefaultSasVersion;
            }
        }
    }
}
