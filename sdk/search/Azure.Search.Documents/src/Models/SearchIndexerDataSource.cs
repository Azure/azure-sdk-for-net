﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("DataSource")]
    [CodeGenSuppress(nameof(SearchIndexerDataSource), typeof(string), typeof(SearchIndexerDataSourceType), typeof(DataSourceCredentials), typeof(SearchIndexerDataContainer))]
    public partial class SearchIndexerDataSource
    {
        [CodeGenMember("etag")]
        private string _etag;

        /// <summary>
        /// Creates a new instance of the <see cref="SearchIndexerDataSource"/> class.
        /// </summary>
        /// <param name="name">The name of the data source.</param>
        /// <param name="type">The type of the data source.</param>
        /// <param name="connectionString">The connection string to the data source.</param>
        /// <param name="container">The data container for the data source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="connectionString"/>, or <paramref name="container"/> is null.</exception>
        public SearchIndexerDataSource(string name, SearchIndexerDataSourceType type, string connectionString, SearchIndexerDataContainer container)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            Container = container ?? throw new ArgumentNullException(nameof(container));
            Type = type;
        }

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchIndexerDataSource"/>.
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
        [CodeGenMember("credentials")]
        private DataSourceCredentials CredentialsInternal
        {
            get
            {
                if (ConnectionString != null)
                {
                    return new DataSourceCredentials(ConnectionString);
                }

                return null;
            }

            set
            {
                ConnectionString = value?.ConnectionString;
            }
        }
    }
}
