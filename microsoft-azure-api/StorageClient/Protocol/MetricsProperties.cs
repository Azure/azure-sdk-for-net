//-----------------------------------------------------------------------
// <copyright file="MetricsProperties.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the MetricsProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class representing the service properties pertaining to metrics.
    /// </summary>
    public class MetricsProperties
    {
        /// <summary>
        /// Gets or sets the version of the analytics service.
        /// </summary>
        /// <value>A string identifying the version of the service.</value>
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the state of metrics collection.
        /// </summary>
        /// <value>A <see cref="MetricsLevel"/> value indicating which metrics to collect, if any.</value>
        public MetricsLevel MetricsLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logging retention policy.
        /// </summary>
        /// <value>The number of days to retain the logs.</value>
        public int? RetentionDays
        {
            get;
            set;
        }
    }
}
