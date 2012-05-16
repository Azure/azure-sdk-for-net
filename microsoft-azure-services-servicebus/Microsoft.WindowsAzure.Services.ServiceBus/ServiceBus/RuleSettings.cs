﻿//
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

namespace Microsoft.WindowsAzure.Services.ServiceBus
{
    /// <summary>
    /// Settings for creating subscription rules.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "RuleDescription")]
    public sealed class RuleSettings
    {
        /// <summary>
        /// Gets rule's filter.
        /// </summary>
        [DataMember(Order = 0)]
        public IRuleFilter Filter { get; private set; }

        /// <summary>
        /// Gets rule's action.
        /// </summary>
        [DataMember(Order = 1)]
        public IRuleAction Action { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="filter">Rule's filter.</param>
        /// <param name="action">Rule's action.</param>
        public RuleSettings(IRuleFilter filter, IRuleAction action)
        {
            if (filter == null && action == null)
            {
                throw new ArgumentException(
                    Resources.ErrorNullFilterAndAction);
            }

            Filter = filter;
            Action = action;
        }
    }
}
