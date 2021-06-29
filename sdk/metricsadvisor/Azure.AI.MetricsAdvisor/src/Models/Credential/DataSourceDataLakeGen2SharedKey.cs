// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Authenticates to a Data Lake Storage Gen2 resource via shared key.
    /// </summary>
    [CodeGenModel("DataLakeGen2SharedKeyCredential")]
    [CodeGenSuppress(nameof(DataSourceDataLakeGen2SharedKey), typeof(string), typeof(DataLakeGen2SharedKeyParam))]
    public partial class DataSourceDataLakeGen2SharedKey
    {
        private string _accountKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceDataLakeGen2SharedKey"/> class.
        /// </summary>
        /// <param name="name">A custom unique name for this <see cref="DataSourceDataLakeGen2SharedKey"/> to be displayed on the web portal.</param>
        /// <param name="accountKey">The account key to be used for authentication.</param>
        public DataSourceDataLakeGen2SharedKey(string name, string accountKey)
            : base(name)
        {
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));

            DataSourceCredentialType = DataSourceCredentialType.DataLakeGen2SharedKey;
            AccountKey = accountKey;
        }

        internal DataSourceDataLakeGen2SharedKey(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, DataLakeGen2SharedKeyParam parameters)
            : base(dataSourceCredentialType, id, name, description)
        {
            DataSourceCredentialType = dataSourceCredentialType;
            AccountKey = parameters.AccountKey;
        }

        internal string AccountKey
        {
            get => Volatile.Read(ref _accountKey);
            set => Volatile.Write(ref _accountKey, value);
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal DataLakeGen2SharedKeyParam Parameters => new DataLakeGen2SharedKeyParam() { AccountKey = AccountKey };

        /// <summary>
        /// Updates the account key.
        /// </summary>
        /// <param name="accountKey">The new account key to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="accountKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="accountKey"/> is empty.</exception>
        public void UpdateAccountKey(string accountKey)
        {
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));
            AccountKey = accountKey;
        }
    }
}
