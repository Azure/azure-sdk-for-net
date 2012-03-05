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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Syndication;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Rule description.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "RuleDescription")]
    public sealed class RuleInfo
    {
        /// <summary>
        /// Name of the rule.
        /// </summary>
        [IgnoreDataMember]
        public string Name { get; private set; }

        /// <summary>
        /// URI of the rule.
        /// </summary>
        [IgnoreDataMember]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets rule's filter.
        /// </summary>
        [DataMember(Order = 0)]
        public IRuleFilter Filter { get; internal set; }

        /// <summary>
        /// Gets rule's action.
        /// </summary>
        [DataMember(Order = 1)]
        public IRuleAction Action { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public RuleInfo()
        {
            //TODO: make the constructor internal once the issue with JavaScript
            // serialization has been fixed.
        }

        /// <summary>
        /// Initializes deserialized item with the data from the atom feed item.
        /// </summary>
        /// <param name="item">Atom item</param>
        internal void Initialize(SyndicationItem item)
        {
            Name = item.Title.Text;
            Uri = new Uri(item.Id);
        }
    }
}
