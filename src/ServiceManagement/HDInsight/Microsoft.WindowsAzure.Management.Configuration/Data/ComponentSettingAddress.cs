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
namespace Microsoft.WindowsAzure.Management.Configuration.Data
{
    using System;

    /// <summary>
    /// Structure to represent a component's address in Ambari response.
    /// </summary>
    public class ComponentSettingAddress
    {
        /// <summary>
        /// Gets or sets the base uri to access the core-site component settings.
        /// </summary>
        public Uri Core { get; set; }

        /// <summary>
        /// Gets or sets the base uri to access the hdfs-site component settings.
        /// </summary>
        public Uri Hdfs { get; set; }

        /// <summary>
        /// Gets or sets the base uri to access the mapred-site component settings.
        /// </summary>
        public Uri MapReduce { get; set; }

        /// <summary>
        /// Gets or sets the base uri to access the hive-site component settings.
        /// </summary>
        public Uri Hive { get; set; }

        /// <summary>
        /// Gets or sets the base uri to access the oozie-site component settings.
        /// </summary>
        public Uri Oozie { get; set; }
    }
}
