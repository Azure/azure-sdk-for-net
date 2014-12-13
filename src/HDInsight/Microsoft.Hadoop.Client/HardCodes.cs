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

namespace Microsoft.Hadoop.Client
{
    using System;

    /// <summary>
    ///     Provides Hard codes for key values.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        ///     The protocol string to use when using a HDFS.
        /// </summary>
        public const string HdfsProtocol = "hdfs";

        /// <summary>
        ///     The protocol scheme name to use when using a HDFS.
        /// </summary>
        public const string HdfsProtocolSchemeName = "hdfs://";

        /// <summary>
        ///     The interval to use when polling a Hadoop cluster.
        /// </summary>
        public const int PollingInterval = 30000;

        /// <summary>
        ///     The number of times to retry when communicating with a Hadoop cluster.
        /// </summary>
        public const int RetryCount = 5;

        /// <summary>
        ///     The protocol string to use when using a Windows Azure Blob Storage account.
        /// </summary>
        public const string WabsProtocol = "wasb";

        /// <summary>
        ///     The protocol scheme name to use when using a Windows Azure Blob Storage account.
        /// </summary>
        public const string WabsProtocolSchemeName = "wasb://";

        /// <summary>
        ///     Represents Unix Epoch.
        /// </summary>
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
