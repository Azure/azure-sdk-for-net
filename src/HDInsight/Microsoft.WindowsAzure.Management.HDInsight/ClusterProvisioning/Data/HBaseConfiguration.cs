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
    /// <summary>
    /// Configuration for the HBase Hadoop service.
    /// </summary>
    public sealed class HBaseConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the HBaseConfiguration class.
        /// </summary>
        public HBaseConfiguration()
        {
            this.ConfigurationCollection = new ConfigValuesCollection();
        }

        /// <summary>
        /// Gets the configuration collection for HBase.
        /// </summary>
        public ConfigValuesCollection ConfigurationCollection { get; private set; }

        /// <summary>
        /// Gets or sets the location to find additional HBase libraries.
        /// </summary>
        public WabStorageAccountConfiguration AdditionalLibraries { get; set; }
    }
}
