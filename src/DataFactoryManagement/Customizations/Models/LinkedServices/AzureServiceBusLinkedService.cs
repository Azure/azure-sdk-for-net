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
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;
using Hyak.Common;

namespace Microsoft.Azure.Management.DataFactories.Models
{
#if ADF_INTERNAL
    /// <summary>
    /// Proxy linked service to custom compute.
    /// </summary>
    public class AzureServiceBusLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. Azure ServiceBus queue where ADF will submit activity
        /// slice execution jobs.
        /// </summary>
        [AdfRequired]
        public string ActivityQueueName { get; set; }

        /// <summary>
        /// Required. Azure ServiceBus endpoint.
        /// </summary>
        [AdfRequired]
        public string Endpoint { get; set; }

        /// <summary>
        /// Optional. User defined property bag. There is no restriction on the
        /// keys or values that can be used. The user service has the full
        /// responsibility to consume and interpret the content defined.
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; set; }

        /// <summary>
        /// Required. Azure ServiceBus shared access key.
        /// </summary>
        [AdfRequired]
        public string SharedAccessKey { get; set; }

        /// <summary>
        /// Required. Azure ServiceBus shared access key name.
        /// </summary>
        [AdfRequired]
        public string SharedAccessKeyName { get; set; }

        /// <summary>
        /// Required. Azure ServiceBus session queue where activity executor
        /// should report slice status.
        /// </summary>
        [AdfRequired]
        public string StatusQueueName { get; set; }

        /// <summary>
        /// The transport protocol version adhered to by the compute 
        /// (and service proxy) connecting through Azure ServiceBus.
        /// </summary>
        public string TransportProtocolVersion { get; set; }

        /// <summary>
        /// Initializes a new instance of the AzureServiceBusLinkedService
        /// class.
        /// </summary>
        public AzureServiceBusLinkedService()
        {
            this.ExtendedProperties = new LazyDictionary<string, string>();
        }
    }
#endif
}
