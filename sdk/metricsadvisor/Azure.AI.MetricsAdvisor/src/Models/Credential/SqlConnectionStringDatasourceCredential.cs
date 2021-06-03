// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("AzureSQLConnectionStringCredential")]
    [CodeGenSuppress(nameof(SqlConnectionStringDatasourceCredential), typeof(string), typeof(AzureSQLConnectionStringParam))]
    public partial class SqlConnectionStringDatasourceCredential
    {
        private string _connectionString;

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connectionString"></param>
        public SqlConnectionStringDatasourceCredential(string name, string connectionString) : base(name)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            DataSourceCredentialType = DataSourceCredentialType.AzureSQLConnectionString;
            ConnectionString = connectionString;
        }

        internal SqlConnectionStringDatasourceCredential(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, AzureSQLConnectionStringParam parameters) : base(dataSourceCredentialType, id, name, description)
        {
            DataSourceCredentialType = dataSourceCredentialType;
            ConnectionString = parameters.ConnectionString;
        }

        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        public void UpdateConnectionString(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }

        internal string ConnectionString
        {
            get => Volatile.Read(ref _connectionString);
            set => Volatile.Write(ref _connectionString, value);
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal AzureSQLConnectionStringParam Parameters => new AzureSQLConnectionStringParam() { ConnectionString = ConnectionString };
    }
}
