// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Globalization;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    /// <summary>
    /// Represents a Windows Azure Table.
    /// </summary>
    public sealed partial class CloudTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTable"/> class.
        /// </summary>
        /// <param name="address">The Table address.</param>
        /// <param name="client">The client.</param>
#if RT
        internal
#else
        public 
#endif
            CloudTable(Uri address, CloudTableClient client)
        {
            CommonUtils.AssertNotNull("address", address);
            CommonUtils.AssertNotNull("client", client);

            this.Uri = address;
            this.ServiceClient = client;

            this.Name = NavigationHelper.GetTableNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);

            CommonUtils.AssertNotNullOrEmpty("Table Name", this.Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTable"/> class.
        /// </summary>
        /// <param name="tableAbsoluteUri">The absolute URI to the table.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudTable(Uri tableAbsoluteUri, StorageCredentials credentials)
            : this(null, tableAbsoluteUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTable"/> class.
        /// </summary>
        /// <param name="tableAbsoluteUri">The absolute URI to the table.</param>
        /// <param name="credentials">The storage account credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c>, use path style Uris.</param>
        internal CloudTable(Uri tableAbsoluteUri, StorageCredentials credentials, bool usePathStyleUris)
            : this(usePathStyleUris, tableAbsoluteUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTable"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="tableAbsoluteUri">The absolute URI to the table.</param>
        /// <param name="credentials">The credentials.</param>
        internal CloudTable(bool? usePathStyleUris, Uri tableAbsoluteUri, StorageCredentials credentials)
        {
            CommonUtils.AssertNotNull("tableAbsoluteUri", tableAbsoluteUri);
            CommonUtils.AssertNotNull("credentials", credentials);

            this.Uri = tableAbsoluteUri;

            Uri baseAddress = NavigationHelper.GetServiceClientBaseAddress(this.Uri, usePathStyleUris);

            this.ServiceClient = new CloudTableClient(baseAddress, credentials);
            this.Name = NavigationHelper.GetTableNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Gets the <see cref="CloudTableClient"/> object that represents the Table service.
        /// </summary>
        /// <value>A client object that specifies the Table service endpoint.</value>
        public CloudTableClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the table name.
        /// </summary>
        /// <value>The table name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the URI that identifies the table.
        /// </summary>
        /// <value>The address of the table.</value>
        public Uri Uri { get; private set; }

#if !COMMON
        /// <summary>
        /// Returns a shared access signature for the table.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="accessPolicyIdentifier">An access policy identifier.</param>
        /// <param name="startPartitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPartitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <returns>A shared access signature.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the current credentials don't support creating a shared access signature.</exception>
        public string GetSharedAccessSignature(
            SharedAccessTablePolicy policy,
            string accessPolicyIdentifier,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
            string endRowKey)
        {
            if (!this.ServiceClient.Credentials.IsSharedKey)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            string resourceName = this.GetCanonicalName();

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(
                policy,
                accessPolicyIdentifier,
                startPartitionKey,
                startRowKey,
                endPartitionKey,
                endRowKey,
                resourceName,
                this.ServiceClient.Credentials);

            string accountKeyName = this.ServiceClient.Credentials.KeyName;

            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(
                policy,
                this.Name,
                accessPolicyIdentifier,
                startPartitionKey,
                startRowKey,
                endPartitionKey,
                endRowKey,
                signature,
                accountKeyName);

            return builder.ToString();
        }
#endif

        /// <summary>
        /// Returns the name of the table.
        /// </summary>
        /// <returns>The name of the table.</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets the canonical name of the table, formatted as /&lt;account-name&gt;/&lt;table-name&gt;.
        /// </summary>
        /// <returns>The canonical name of the table.</returns>
        private string GetCanonicalName()
        {
            string accountName = this.ServiceClient.Credentials.AccountName;
            string tableNameLowerCase = this.Name.ToLower();

            return string.Format("/{0}/{1}", accountName, tableNameLowerCase);
        }
    }
}
