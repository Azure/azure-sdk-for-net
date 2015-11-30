// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Azure Storage Account Configuration for addition ASV HDInsight drives.
    /// </summary>
    public sealed class WabStorageAccountConfiguration
    {
        /// <summary>
        /// Gets the Name of the Storage Account.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Key for the Storage Account.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the Container for the Storage Account.
        /// </summary>
        public string Container { get; private set; }

        /// <summary>
        /// Initializes a new instance of the WabStorageAccountConfiguration class.
        /// </summary>
        /// <param name="accountName">Account name of the Storage Account.</param>
        /// <param name="key">Key for the Storage Account.</param>
        public WabStorageAccountConfiguration(string accountName, string key)
        {
            this.Name = accountName;
            this.Key = key;
        }

        /// <summary>
        /// Initializes a new instance of the WabStorageAccountConfiguration class.
        /// </summary>
        /// <param name="accountName">Account name of the Storage Account.</param>
        /// <param name="key">Key for the Storage Account.</param>
        /// <param name="container">Container name of the Storage Account.</param>
        public WabStorageAccountConfiguration(string accountName, string key, string container)
        {
            this.Name = accountName;
            this.Key = key;
            this.Container = container;
        }
    }
}
