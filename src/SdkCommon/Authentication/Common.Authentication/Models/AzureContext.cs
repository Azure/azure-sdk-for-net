// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
