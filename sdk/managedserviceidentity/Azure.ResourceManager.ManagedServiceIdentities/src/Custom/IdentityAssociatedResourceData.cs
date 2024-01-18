// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using System.ClientModel.Primitives;

namespace Azure.ResourceManager.ManagedServiceIdentities.Models
{
    /// <summary> IdentityAssociatedResourceData </summary>
    public partial class IdentityAssociatedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal IdentityAssociatedResourceData() { }
        /// <summary>
        /// ResourceGroupInstance
        /// </summary>
        public string ResourceGroup { get { throw null; } }
        /// <summary>
        /// SubscriptionDisplayName
        /// </summary>
        public string SubscriptionDisplayName { get { throw null; } }
        /// <summary>
        /// SubscriptionDisplayName
        /// </summary>
        public string SubscriptionId { get { throw null; } }
    }
}
