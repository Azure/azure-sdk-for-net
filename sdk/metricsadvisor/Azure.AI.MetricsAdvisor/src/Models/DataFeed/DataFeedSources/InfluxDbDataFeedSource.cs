// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an InfluxDB data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class InfluxDbDataFeedSource : DataFeedSource
    {
        private string _connectionString;

        private string _password;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfluxDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="database">The name of the database.</param>
        /// <param name="username">The access username.</param>
        /// <param name="password">The access password.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="database"/>, <paramref name="username"/>, <paramref name="password"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="database"/>, <paramref name="username"/>, <paramref name="password"/>, or <paramref name="query"/> is empty.</exception>
        public InfluxDbDataFeedSource(string connectionString, string database, string username, string password, string query)
            : base(DataFeedSourceKind.InfluxDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(username, nameof(username));
            Argument.AssertNotNullOrEmpty(password, nameof(password));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            ConnectionString = connectionString;
            Database = database;
            Username = username;
            Password = password;
            Query = query;
        }

        internal InfluxDbDataFeedSource(InfluxDBParameter parameter)
            : base(DataFeedSourceKind.InfluxDb)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            Database = parameter.Database;
            Username = parameter.UserName;
            Password = parameter.Password;
            Query = parameter.Query;
        }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// The access username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The connection string.
        /// </summary>
        internal string ConnectionString
        {
            get => Volatile.Read(ref _connectionString);
            private set => Volatile.Write(ref _connectionString, value);
        }

        /// <summary>
        /// The access password.
        /// </summary>
        internal string Password
        {
            get => Volatile.Read(ref _password);
            private set => Volatile.Write(ref _password, value);
        }

        /// <summary>
        /// Updates the connection string.
        /// </summary>
        /// <param name="connectionString">The new connection string to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> is empty.</exception>
        public void UpdateConnectionString(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="password">The new password to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="password"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="password"/> is empty.</exception>
        public void UpdatePassword(string password)
        {
            Argument.AssertNotNullOrEmpty(password, nameof(password));
            Password = password;
        }
    }
}
