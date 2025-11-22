// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("SearchIndexerDataSource")]
    [CodeGenSuppress(nameof(SearchIndexerDataSourceConnection), typeof(string), typeof(SearchIndexerDataSourceType), typeof(DataSourceCredentials), typeof(SearchIndexerDataContainer))]
    public partial class SearchIndexerDataSourceConnection
    {
        [CodeGenMember("ETag")]
        private string _etag;

        /// <summary>
        /// Creates a new instance of the <see cref="SearchIndexerDataSourceConnection"/> class.
        /// </summary>
        /// <param name="name">The name of the data source.</param>
        /// <param name="type">The type of the data source.</param>
        /// <param name="connectionString">The connection string to the data source.</param>
        /// <param name="container">The data container for the data source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="connectionString"/>, or <paramref name="container"/> is null.</exception>
        public SearchIndexerDataSourceConnection(string name, SearchIndexerDataSourceType type, string connectionString, SearchIndexerDataContainer container)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            Container = container ?? throw new ArgumentNullException(nameof(container));
            Type = type;
            IndexerPermissionOptions = new ChangeTrackingList<IndexerPermissionOption>();
        }

        /// <summary> Initializes a new instance of <see cref="SearchIndexerDataSourceConnection"/>. </summary>
        /// <param name="name"> The name of the datasource. </param>
        /// <param name="description"> The description of the datasource. </param>
        /// <param name="type"> The type of the datasource. </param>
        /// <param name="connectionString"> Credentials for the datasource. </param>
        /// <param name="container"> The data container for the datasource. </param>
        /// <param name="dataChangeDetectionPolicy">
        /// The data change detection policy for the datasource.
        /// Please note <see cref="Models.DataChangeDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="HighWaterMarkChangeDetectionPolicy"/> and <see cref="SqlIntegratedChangeTrackingPolicy"/>.
        /// </param>
        /// <param name="dataDeletionDetectionPolicy">
        /// The data deletion detection policy for the datasource.
        /// Please note <see cref="Models.DataDeletionDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SoftDeleteColumnDeletionDetectionPolicy"/>.
        /// </param>
        /// <param name="etag"> The ETag of the data source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your datasource definition when you want full assurance that no one, not even Microsoft, can decrypt your data source definition. Once you have encrypted your data source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your datasource definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SearchIndexerDataSourceConnection(string name, string description, SearchIndexerDataSourceType type, string connectionString, SearchIndexerDataContainer container, DataChangeDetectionPolicy dataChangeDetectionPolicy, DataDeletionDetectionPolicy dataDeletionDetectionPolicy, string etag, SearchResourceEncryptionKey encryptionKey, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Description = description;
            Type = type;
            ConnectionString = connectionString;
            Container = container;
            DataChangeDetectionPolicy = dataChangeDetectionPolicy;
            DataDeletionDetectionPolicy = dataDeletionDetectionPolicy;
            _etag = etag;
            EncryptionKey = encryptionKey;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchIndexerDataSourceConnection"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }

        /// <summary>
        /// Gets or sets a connection string to the <see cref="Container"/>.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="DataSourceCredentials"/> for de/serialization purposes only.
        /// </summary>
        [CodeGenMember("Credentials")]
        private DataSourceCredentials CredentialsInternal
        {
            get
            {
                return new DataSourceCredentials(ConnectionString ?? DataSourceCredentials.UnchangedValue, serializedAdditionalRawData: null);
            }

            set
            {
                ConnectionString = value?.ConnectionString;
            }
        }
    }
}
