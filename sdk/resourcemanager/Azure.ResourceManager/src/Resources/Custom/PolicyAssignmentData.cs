// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing the PolicyAssignment data model. </summary>
    public partial class PolicyAssignmentData : ResourceData
    {
#pragma warning disable CS0618 // This type is obsolete and will be removed in a future release.
        private SystemAssignedServiceIdentity _identity;
        /// <summary> The managed identity associated with the policy assignment. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use ManagedIdentity.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SystemAssignedServiceIdentity Identity
        {
            get
            {
                if (ManagedIdentity != null)
                {
                    if (_identity == null || _identity.Identity != ManagedIdentity)
                    {
                        _identity = new SystemAssignedServiceIdentity(ManagedIdentity);
                    }
                }
                else
                {
                    _identity = null;
                }
                return _identity;
            }
            set
            {
                _identity = value;
                ManagedIdentity = value == null ? null : _identity.Identity;
            }
        }
#pragma warning restore CS0618 // This type is obsolete and will be removed in a future release.
    }
}
