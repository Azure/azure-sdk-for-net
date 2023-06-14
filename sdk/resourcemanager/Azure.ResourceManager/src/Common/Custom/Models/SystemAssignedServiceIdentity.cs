// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Models
{
    /// <summary> Managed service identity (either system assigned, or none). </summary>
    // this class is consolidated into the ManagedServiceIdentity class.
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SystemAssignedServiceIdentity
    {
        /// <summary> Initializes a new instance of SystemAssignedServiceIdentity. </summary>
        /// <param name="systemAssignedServiceIdentityType"> Type of managed service identity (either system assigned, or none). </param>
        [InitializationConstructor]
        public SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType systemAssignedServiceIdentityType)
        {
            Identity = new ManagedServiceIdentity(systemAssignedServiceIdentityType.ToString());
        }

        /// <summary> Initializes a new instance of SystemAssignedServiceIdentity. </summary>
        /// <param name="principalId"> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="tenantId"> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="systemAssignedServiceIdentityType"> Type of managed service identity (either system assigned, or none). </param>
        [SerializationConstructor]
        internal SystemAssignedServiceIdentity(Guid? principalId, Guid? tenantId, SystemAssignedServiceIdentityType systemAssignedServiceIdentityType)
        {
            Identity = new ManagedServiceIdentity(principalId, tenantId, systemAssignedServiceIdentityType.ToString(), null);
        }

        /// <summary> Initializes a new instance of SystemAssignedServiceIdentity by given ManagedServiceIdentity. </summary>
        internal SystemAssignedServiceIdentity(ManagedServiceIdentity managedServiceIdentity)
        {
            if (managedServiceIdentity == null)
            {
                throw new ArgumentNullException();
            }
            Identity = managedServiceIdentity;
        }

        internal ManagedServiceIdentity Identity { get; set; }

        /// <summary> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        public Guid? PrincipalId
        {
            get => Identity.PrincipalId;
        }
        /// <summary> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        public Guid? TenantId
        {
            get => Identity.TenantId;
        }
        /// <summary> Type of managed service identity (either system assigned, or none). </summary>
        public SystemAssignedServiceIdentityType SystemAssignedServiceIdentityType
        {
            get => Identity.ManagedServiceIdentityType.ToString();
            set => Identity.ManagedServiceIdentityType = value.ToString();
        }
    }
}
