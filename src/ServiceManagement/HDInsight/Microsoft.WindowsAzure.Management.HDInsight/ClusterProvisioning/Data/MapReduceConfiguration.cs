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
    /// Configuration for the MapReduce Hadoop service.
    /// </summary>
    public sealed class MapReduceConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the MapReduceConfiguration class.
        /// </summary>
        public MapReduceConfiguration()
        {
            this.ConfigurationCollection = new ConfigValuesCollection();
            this.CapacitySchedulerConfigurationCollection = new ConfigValuesCollection();
        }

        /// <summary>
        /// Gets the configuration collection for Map reduce.
        /// </summary>
        public ConfigValuesCollection ConfigurationCollection { get; private set; }

        /// <summary>
        /// Gets the capacity scheduler configuration collection for Map reduce.
        /// </summary>
        public ConfigValuesCollection CapacitySchedulerConfigurationCollection { get; private set; }
    }
}
