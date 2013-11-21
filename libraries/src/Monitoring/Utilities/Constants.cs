// 
// Copyright (c) Microsoft.  All rights reserved.
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

namespace Microsoft.WindowsAzure.Management.Monitoring.Utilities
{
    public static class Constants
    {
        /// <summary>
        /// Service bus resource types
        /// </summary>
        public static class ServiceBusResourceType
        {
            /// <summary>
            /// Topics resource type
            /// </summary>
            public const string Topics = "topics";

            /// <summary>
            /// Queues resource type
            /// </summary>
            public const string Queues = "queues";

            /// <summary>
            /// Notification Hub resource type
            /// </summary>
            public const string NotificationHubs = "notificationhubs";
        }

        /// <summary>
        /// Storage service types
        /// </summary>
        public static class StorageServiceType
        {
            /// <summary>
            /// Blob service type
            /// </summary>
            public const string Blob = "blob";

            /// <summary>
            /// Table service type
            /// </summary>
            public const string Table = "table";

            /// <summary>
            /// Queue service type
            /// </summary>
            public const string Queue = "queue";
        }
    }
}
