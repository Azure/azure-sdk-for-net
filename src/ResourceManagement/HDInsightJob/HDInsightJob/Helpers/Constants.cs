// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace Microsoft.Azure.Management.HDInsight.Job
{
    internal class Constants
    {
        /// <summary>
        /// The protocol string to use when using a Windows Azure Blob Storage account.
        /// </summary>
        public const string WabsProtocol = "wasb";

        /// <summary>
        /// The protocol scheme name to use when using a Windows Azure Blob Storage account.
        /// </summary>
        public const string WabsProtocolSchemeName = "wasb://";

        /// <summary>
        /// The directory in which task logs are placed.
        /// </summary>
        public const string TaskLogsDirectoryName = "logs";

        /// <summary>
        /// The directory path for the root.
        /// </summary>
        public const string RootDirectoryPath = "/";

        /// <summary>
        /// The public storage endpoint.
        /// </summary>
        public const string ProductionStorageAccountEndpointUriTemplate = "http://{0}.blob.core.windows.net/";
    }
}
