// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication.Models
{
    [Serializable]
    public partial class AzureSubscription
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Environment { get; set; }

        public string Account { get; set; }

        public string State { get; set; }

        public Dictionary<Property, string> Properties { get; set; }

        public enum Property
        {
            /// <summary>
            /// Comma separated registered resource providers, i.e.: websites,compute,hdinsight
            /// </summary>
            RegisteredResourceProviders,

            /// <summary>
            /// Associated tenants
            /// </summary>
            Tenants,

            /// <summary>
            /// If this property existed on the subscription indicates that it's default one.
            /// </summary>
            Default,

            StorageAccount
        }
    }
}
