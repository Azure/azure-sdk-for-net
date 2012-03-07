//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Brokered message obtained from the service.
    /// </summary>
    public sealed class BrokeredMessageInfo
    {
        /// <summary>
        /// Gets the message text.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets message's broker properties.
        /// </summary>
        public BrokerProperties BrokerProperties { get; private set; }

        /// <summary>
        /// Constructor. Initializes the object from the HTTP response.
        /// </summary>
        /// <param name="response">HTTP reponse with the data.</param>
        internal BrokeredMessageInfo(HttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            Text = response.Content.ReadAsStringAsync().Result;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, object>));
            string propertiesString = null;
            IEnumerable<string> values;


            if (response.Headers.TryGetValues("BrokerProperties", out values))
            {
                foreach (string value in values)
                {
                    propertiesString = value;
                    break;
                }
            }

            if (string.IsNullOrEmpty(propertiesString))
            {
                BrokerProperties = new ServiceBus.BrokerProperties();
            }
            else
            {
                BrokerProperties = BrokerProperties.Deserialize(propertiesString);
            }
        }
    }
}
