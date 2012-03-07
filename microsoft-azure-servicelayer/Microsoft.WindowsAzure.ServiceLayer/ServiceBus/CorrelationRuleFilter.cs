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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Correlation rule filter.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name="CorrelationFilter")]
    public sealed class CorrelationRuleFilter : IRuleFilter
    {
        /// <summary>
        /// Correlation ID.
        /// </summary>
        [DataMember(Order = 0)]
        public string CorrelationId { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="correlationId">Correlation ID.</param>
        public CorrelationRuleFilter(string correlationId)
        {
            if (correlationId == null)
            {
                throw new ArgumentNullException("correlationId");
            }
            CorrelationId = correlationId;
        }
    }
}
