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
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas" />.
    /// </summary>
    public class TableSasBuilder
    {
        /// <summary>
        /// Initializes an instance of a <see cref="TableSasBuilder"/>.
        /// </summary>
        /// <param name="tableName">The name of the table being made accessible with the shared access signature.</param>
        /// <param name="permissions">The permissions associated with the shared access signature.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        public TableSasBuilder(string tableName, TableSasPermissions permissions, DateTimeOffset expiresOn)
        {
            Argument.AssertNotNullOrEmpty(tableName, nameof(tableName));

            TableName = tableName;
            ExpiresOn = expiresOn;
            SetPermissions(permissions);
        }

        /// <summary>
        /// Initializes an instance of a <see cref="TableSasBuilder"/>.
        /// </summary>
        /// <param name="tableName">The name of the table being made accessible with the shared access signature.</param>
        /// <param name="rawPermissions">The permissions associated with the shared access signature. This string should contain one or more of the following permission characters in this order: "raud".</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        public TableSasBuilder(string tableName, string rawPermissions, DateTimeOffset expiresOn)
        {
            Argument.AssertNotNullOrEmpty(tableName, nameof(tableName));
            Argument.AssertNotNullOrEmpty(rawPermissions, nameof(tableName));

            TableName = tableName;
            ExpiresOn = expiresOn;
            Permissions = rawPermissions;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TableSasBuilder"/> based on an existing Uri containing a shared acccess signature.
        /// </summary>
        /// <param name="uri">The Uri to parse.</param>
        /// <returns></returns>
        public TableSasBuilder(Uri uri)
        {
            Argument.AssertNotNull(uri, nameof(uri));

            var uriBuilder = new TableUriBuilder(uri);

            TableName = uriBuilder.Tablename;
            ExpiresOn = uriBuilder.Sas.ExpiresOn;
            Identifier = uriBuilder.Sas.Identifier;
            IPRange = uriBuilder.Sas.IPRange;
            PartitionKeyEnd = uriBuilder.Sas.EndPartitionKey;
            PartitionKeyStart = uriBuilder.Sas.StartPartitionKey;
            Protocol = uriBuilder.Sas.Protocol;
            RowKeyEnd = uriBuilder.Sas.EndRowKey;
            RowKeyStart = uriBuilder.Sas.StartRowKey;
            StartsOn = uriBuilder.Sas.StartsOn;
            Version = uriBuilder.Sas.Version;
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
        public TableSasIPRange IPRange { get; set; }

        /// <summary>
        /// An optional unique value up to 64 characters in length that
        /// correlates to an access policy specified for the container.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the table being made accessible.
        /// </summary>
        public string TableName { get; set; }

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
        /// The storage service version to use to authenticate requests made
        /// with this shared access signature, and the service version to use
        /// when handling requests made with this shared access signature.
        /// </summary>
        internal string Version { get; set; }

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
        /// Use an account's <see cref="TableSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="TableSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// An instance of <see cref="TableSasQueryParameters"/>.
        /// </returns>
        public TableSasQueryParameters ToSasQueryParameters(TableSharedKeyCredential sharedKeyCredential)
        {
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            EnsureState();

            var startTime = TableSasExtensions.FormatTimesForSasSigning(StartsOn);
            var expiryTime = TableSasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = string.Join("\n",
                Permissions,
                startTime,
                expiryTime,
                GetCanonicalName(sharedKeyCredential.AccountName, TableName),
                Identifier,
                IPRange.ToString(),
                TableSasExtensions.ToProtocolString(Protocol),
                Version,
                PartitionKeyStart,
                RowKeyStart,
                PartitionKeyEnd,
                RowKeyEnd);
            var signature = TableSharedKeyCredential.ComputeSasSignature(sharedKeyCredential, stringToSign);
            var p = new TableSasQueryParameters(
                version: Version,
                resourceTypes: default,
                tableName: TableName,
                partitionKeyStart: PartitionKeyStart,
                partitionKeyEnd: PartitionKeyEnd,
                rowKeyStart: RowKeyStart,
                rowKeyEnd: RowKeyEnd,
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
        public string Sign(TableSharedKeyCredential sharedKeyCredential) =>
            ToSasQueryParameters(sharedKeyCredential).ToString();

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
                Version = TableSasQueryParameters.DefaultSasVersion;
            }
        }
    }
}
