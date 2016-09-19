/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault
{

    using Microsoft.Azure.Management.Fluent.Graph.RBAC;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update;
    using System;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition;
    using V2.Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for AccessPolicy and its parent interfaces.
    /// </summary>
    public partial class AccessPolicyImpl  :
        ChildResource<AccessPolicyEntry,VaultImpl>,
        IAccessPolicy,
        IDefinition<IWithCreate>,
        IUpdateDefinition<Vault.Update.IUpdate>,
        AccessPolicy.Update.IUpdate
    {
        private string userPrincipalName;
        private string servicePrincipalName;
        internal AccessPolicyImpl (AccessPolicyEntry innerObject, VaultImpl parent)
            : base(null, innerObject, parent)
        {
            Inner.TenantId = Guid.Parse(parent.TenantId);
        }

        internal string UserPrincipalName
        {
            get
            {
                return this.userPrincipalName;
            }
        }
        internal string ServicePrincipalName
        {
            get
            {
                return this.servicePrincipalName;
            }
        }
        public string TenantId
        {
            get
            {
                if (Inner.TenantId == null) {
                    return null;
                }
                return Inner.TenantId.ToString();
            }
        }
        public string ObjectId
        {
            get
            {
                if (Inner.ObjectId == null)
                {
                    return null;
                }
                return Inner.ObjectId.ToString();
            }
        }
        public string ApplicationId
        {
            get
            {
                if (Inner.ApplicationId == null)
                {
                    return null;
                }
                return Inner.ApplicationId.ToString();
            }
        }
        public Permissions Permissions
        {
            get
            {
                return Inner.Permissions;
            }
        }
        public string Name
        {
            get
            {
                return ObjectId;
            }
        }

        private void InitializeKeyPermissions ()
        {
            if (Inner.Permissions == null) {
                Inner.Permissions = new Permissions();
            }
            if (Inner.Permissions.Keys == null) {
                Inner.Permissions.Keys = new List<string>();
            }
        }

        private void InitializeSecretPermissions ()
        {
            if (Inner.Permissions == null)
            {
                Inner.Permissions = new Permissions();
            }
            if (Inner.Permissions.Secrets == null)
            {
                Inner.Permissions.Secrets = new List<string>();
            }
        }

        public AccessPolicyImpl AllowKeyPermission (KeyPermissions permission)
        {
            InitializeKeyPermissions();
            Inner.Permissions.Keys.Add(permission.ToString());
            return this;
        }

        public AccessPolicyImpl AllowKeyPermissions (IList<KeyPermissions> permissions)
        {
            InitializeKeyPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Keys.Add(permissions.ToString());
            }
            return this;
        }

        public AccessPolicyImpl AllowSecretPermission (SecretPermissions permission)
        {
            InitializeSecretPermissions();
            Inner.Permissions.Secrets.Add(permission.ToString());
            return this;
        }

        public AccessPolicyImpl AllowSecretPermissions (IList<SecretPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Secrets.Add(permissions.ToString());
            }
            return this;
        }

        public VaultImpl Attach ()
        {
            Parent.WithAccessPolicy(this);
            return Parent;
        }

        public AccessPolicyImpl ForObjectId (Guid objectId)
        {
            Inner.ObjectId = objectId;
            return this;
        }

        public AccessPolicyImpl ForUser (IUser user)
        {
            Inner.ObjectId = Guid.Parse(user.ObjectId);
            return this;
        }

        public AccessPolicyImpl ForUser (string userPrincipalName)
        {
            this.userPrincipalName = userPrincipalName;
            return this;
        }

        public AccessPolicyImpl ForGroup (IActiveDirectoryGroup group)
        {
            Inner.ObjectId = Guid.Parse(group.ObjectId);
            return this;
        }

        public AccessPolicyImpl ForServicePrincipal (IServicePrincipal servicePrincipal)
        {
            Inner.ObjectId = Guid.Parse(servicePrincipal.ObjectId);
            return this;
        }

        public AccessPolicyImpl ForServicePrincipal (string servicePrincipalName)
        {
            this.servicePrincipalName = servicePrincipalName;
            return this;
        }

        public AccessPolicyImpl AllowKeyAllPermissions ()
        {
            return AllowKeyPermission(KeyPermissions.All);
        }

        public AccessPolicyImpl DisallowKeyAllPermissions ()
        {
            InitializeKeyPermissions();
            Inner.Permissions.Keys.Clear();
            return this;
        }

        public AccessPolicyImpl DisallowKeyPermission (KeyPermissions permission)
        {
            InitializeSecretPermissions();
            Inner.Permissions.Keys.Remove(permission.ToString());
            return this;
        }

        public AccessPolicyImpl DisallowKeyPermissions (IList<KeyPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Keys.Remove(permission.ToString());
            }
            return this;
        }

        public AccessPolicyImpl AllowSecretAllPermissions ()
        {
            return AllowSecretPermission(SecretPermissions.All);
        }

        public AccessPolicyImpl DisallowSecretAllPermissions ()
        {
            InitializeKeyPermissions();
            Inner.Permissions.Keys.Clear();
            return this;
        }

        public AccessPolicyImpl DisallowSecretPermission (SecretPermissions permission)
        {
            InitializeSecretPermissions();
            Inner.Permissions.Secrets.Remove(permission.ToString());
            return this;
        }

        public AccessPolicyImpl DisallowSecretPermissions (IList<SecretPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Secrets.Remove(permission.ToString());
            }
            return this;
        }

        Vault.Update.IUpdate ISettable<Vault.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}