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

using Newtonsoft.Json;
using System;
namespace Microsoft.Azure.Common.Authentication.Models
{
    /// <summary>
    /// Represents current Azure session context.
    /// </summary>
    [Serializable]
    public class AzureContext
    {
        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="subscription">The azure subscription object</param>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        public AzureContext(AzureSubscription subscription, AzureAccount account, AzureEnvironment environment) 
            : this(subscription, account, environment, null)
        {
            
        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        public AzureContext(AzureAccount account, AzureEnvironment environment, AzureTenant tenant)
            : this(null, account, environment, tenant)
        {

        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="subscription">The azure subscription object</param>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        [JsonConstructor]
        public AzureContext(AzureSubscription subscription, AzureAccount account, AzureEnvironment environment, AzureTenant tenant)
        {
            Subscription = subscription;
            Account = account;
            Environment = environment;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets the azure account.
        /// </summary>
        public AzureAccount Account { get; private set; }

        /// <summary>
        /// Gets the azure subscription.
        /// </summary>
        public AzureSubscription Subscription { get; private set; }

        /// <summary>
        /// Gets the azure environment.
        /// </summary>
        public AzureEnvironment Environment { get; private set; }
        
        /// <summary>
        /// Gets the azure tenant.
        /// </summary>
        public AzureTenant Tenant { get; private set; }

        /// <summary>
        /// Gets or sets the token cache contents.
        /// </summary>
        public byte[] TokenCache { get; set; }
    }
}
