// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.ResourceManager.Authorization
{
#pragma warning disable CS0618 // This partial class intentionally exposes the obsolete GA property.
    public partial class RoleManagementPolicyAssignmentData
    {
        private PolicyAssignmentProperties _policyAssignmentProperties;

        // TypeSpec now generates RoleManagementPolicyAssignmentProperties. Preserve the GA property
        // as a cached wrapper so both names observe the same generated backing model.
        /// <summary> Additional properties of scope, role definition and policy. </summary>
        [WirePath("properties.policyAssignmentProperties")]
        [Obsolete("Use RoleManagementPolicyAssignmentProperties instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PolicyAssignmentProperties PolicyAssignmentProperties
        {
            get
            {
                RoleManagementPolicyAssignmentProperties value = RoleManagementPolicyAssignmentProperties;
                if (value is null)
                {
                    return null;
                }

                if (_policyAssignmentProperties is null || !ReferenceEquals(_policyAssignmentProperties.Value, value))
                {
                    _policyAssignmentProperties = new PolicyAssignmentProperties(value);
                }

                return _policyAssignmentProperties;
            }
        }

        internal void SetPolicyAssignmentPropertiesCompatibility(PolicyAssignmentProperties value)
            => _policyAssignmentProperties = value;
    }
#pragma warning restore CS0618
}
