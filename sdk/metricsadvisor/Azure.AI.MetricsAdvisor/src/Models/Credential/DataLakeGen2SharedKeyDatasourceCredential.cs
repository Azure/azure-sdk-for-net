// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("DataLakeGen2SharedKeyCredential")]
    [CodeGenSuppress(nameof(DataLakeGen2SharedKeyDatasourceCredential), typeof(string), typeof(DataLakeGen2SharedKeyParam))]
    public partial class DataLakeGen2SharedKeyDatasourceCredential
    {
        private string _accountKey;

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accountKey"></param>
        public DataLakeGen2SharedKeyDatasourceCredential(string name, string accountKey) : base(name)
        {
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));

            DataSourceCredentialType = DataSourceCredentialType.DataLakeGen2SharedKey;
            AccountKey = accountKey;
        }

        internal DataLakeGen2SharedKeyDatasourceCredential(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, DataLakeGen2SharedKeyParam parameters) : base(dataSourceCredentialType, id, name, description)
        {
            DataSourceCredentialType = dataSourceCredentialType;
            AccountKey = parameters.AccountKey;
        }

        /// <summary>
        /// </summary>
        /// <param name="accountKey"></param>
        public void UpdateAccountKey(string accountKey)
        {
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));
            AccountKey = accountKey;
        }

        /// <summary>
        /// The client Secret of the service principal used for authentication.
        /// </summary>
        internal string AccountKey
        {
            get => Volatile.Read(ref _accountKey);
            set => Volatile.Write(ref _accountKey, value);
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal DataLakeGen2SharedKeyParam Parameters => new DataLakeGen2SharedKeyParam() { AccountKey = AccountKey };
    }
}
