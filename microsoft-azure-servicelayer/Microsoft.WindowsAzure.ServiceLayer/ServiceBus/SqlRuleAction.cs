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
    /// Rule's SQL filter action.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name="SqlRuleAction")]
    public sealed class SqlRuleAction : IRuleAction
    {
        /// <summary>
        /// Action string,
        /// </summary>
        [DataMember(Order = 0, Name="SqlExpression")]
        public string Action { get; private set; }

        [DataMember(Order = 1)]
        public int CompatibilityLevel { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="action">Rule's SQL action string.</param>
        public SqlRuleAction(string action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            Action = action;
            CompatibilityLevel = Constants.CompatibilityLevel;
        }
    }
}
