// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    internal partial class AuthorizationKeysImpl 
    {
        /// <summary>
        /// Gets secondary connection string.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys.SecondaryConnectionString
        {
            get
            {
                return this.SecondaryConnectionString();
            }
        }

        /// <summary>
        /// Gets secondary key associated with the rule.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys.SecondaryKey
        {
            get
            {
                return this.SecondaryKey();
            }
        }

        /// <summary>
        /// Gets primary connection string.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys.PrimaryConnectionString
        {
            get
            {
                return this.PrimaryConnectionString();
            }
        }

        /// <summary>
        /// Gets primary key associated with the rule.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys.PrimaryKey
        {
            get
            {
                return this.PrimaryKey();
            }
        }
    }
}