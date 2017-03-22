// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update;
    using System;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for AccessPolicy and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLkFjY2Vzc1BvbGljeUltcGw=
    internal partial class AccessPolicyImpl :
        ChildResource<AccessPolicyEntry, VaultImpl, IVault>,
        IAccessPolicy,
        IDefinition<IWithCreate>,
        IUpdateDefinition<Vault.Update.IUpdate>,
        AccessPolicy.Update.IUpdate
    {
        private string userPrincipalName;
        private string servicePrincipalName;
        ///GENMHASH:DB1CD9648996DA10B58423DFABD976E4:BC7BE29DA61C7F6594944FD23512AD2F
        internal AccessPolicyImpl (AccessPolicyEntry innerObject, VaultImpl parent) : base(innerObject, parent)
        {
            Inner.TenantId = Guid.Parse(parent.TenantId);
        }

        ///GENMHASH:EFC2DDE75F20FD4EAFECA334A50B3D22:B383D7B422F0E34653A55B7CA778970F
        internal string UserPrincipalName
        {
            get
            {
                return this.userPrincipalName;
            }
        }

        ///GENMHASH:F7CF19ADF2E05F1D39D6A50FA0A5AB79:EB069810FBC10E1827D16F395FF3A078
        internal string ServicePrincipalName
        {
            get
            {
                return this.servicePrincipalName;
            }
        }

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:8CE5F00FA8F3A032BD5A0628F8ACA3DB
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

        ///GENMHASH:17540EB75C744FB87D329C55BE359E09:398DB6C274F97FC8B13DE18ED8C1BA0B
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

        ///GENMHASH:359D1EADA427782D05CA5CF20BD6D91A:FDF832AECB3EF51F25367680A7510FAB
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

        ///GENMHASH:5FECF7CEB96EFF8A50AB4CA3950B5843:833D7CA0001EC62E67CD177E707E39B5
        public Permissions Permissions
        {
            get
            {
                return Inner.Permissions;
            }
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:ECE58FC8B41B858AA434697B6028BD23
        public override string Name()
        {
            return ObjectId;
        }

        ///GENMHASH:2548489FEC6DEDA375BB14337408C32F:F98681659352BAAE0C36842A9939C2C0
        private void InitializeKeyPermissions ()
        {
            if (Inner.Permissions == null) {
                Inner.Permissions = new Permissions();
            }
            if (Inner.Permissions.Keys == null) {
                Inner.Permissions.Keys = new List<string>();
            }
        }

        ///GENMHASH:E016D80945C42D59D0AEF2D38ECB30DB:5F47B75D080175C69CF7CF370856DC63
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

        ///GENMHASH:CAED6C15F9B42B76A5AC64F370A3FD5B:53E624BA383B922224605FF351DC75E1
        public AccessPolicyImpl AllowKeyPermissions (params KeyPermissions[] permissions)
        {
            return AllowKeyPermissions(new List<KeyPermissions>(permissions));
        }

        ///GENMHASH:4285C26105D2CACA3EB31944C49CADB1:4EA7EF6F19835FEDF776325D20842BA6
        public AccessPolicyImpl AllowKeyPermissions (IList<KeyPermissions> permissions)
        {
            InitializeKeyPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Keys.Add(permission.ToString());
            }
            return this;
        }

        ///GENMHASH:3B24D44CFE59D6F67A1E749291E41B8F:A4770BCE1DF8EF5C1DC58FB5ECE21BC9
        public AccessPolicyImpl AllowSecretPermissions (params SecretPermissions[] permissions)
        {
            return AllowSecretPermissions(new List<SecretPermissions>(permissions));
        }

        ///GENMHASH:78BA35A3DD13CB1E4732F1F2B4B3F36A:9C923B42AB4F3547C2D5E115CC1EE332
        public AccessPolicyImpl AllowSecretPermissions(IList<SecretPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Secrets.Add(permission.ToString());
            }
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:B7963E82870A365FD51B673F0B0274AC
        public VaultImpl Attach ()
        {
            Parent.WithAccessPolicy(this);
            return Parent;
        }

        ///GENMHASH:458BF8ACE4D00DD896B7979D96F7C2EB:225E1D92A92E81E1982C4A483BC88058
        public AccessPolicyImpl ForObjectId (Guid objectId)
        {
            Inner.ObjectId = objectId;
            return this;
        }

        ///GENMHASH:9D8D39171FFFFE2517D8100304C11862:6A48AA5D0D2710F0A8787D34676538E1
        public AccessPolicyImpl ForUser (IUser user)
        {
            Inner.ObjectId = Guid.Parse(user.ObjectId);
            return this;
        }

        ///GENMHASH:8E6D48BCE723A76A602CE321050BFECB:57A825FB9FC082E89AA8F17B8DEB7486
        public AccessPolicyImpl ForUser (string userPrincipalName)
        {
            this.userPrincipalName = userPrincipalName;
            return this;
        }

        ///GENMHASH:498DF2FE8CE61E58CF671C4DCDF1A6D1:B99DEC951B47738BA49B5FC2B737021E
        public AccessPolicyImpl ForGroup (IActiveDirectoryGroup group)
        {
            Inner.ObjectId = Guid.Parse(group.ObjectId);
            return this;
        }

        ///GENMHASH:7B10596856964977EC5E018A031EE6E9:AA2717CDA7300E14A15599831EE2375F
        public AccessPolicyImpl ForServicePrincipal (IServicePrincipal servicePrincipal)
        {
            Inner.ObjectId = Guid.Parse(servicePrincipal.ObjectId);
            return this;
        }

        ///GENMHASH:A5A82E0B3718195704CB5A3CC0F635D9:7F5AA729AD0F3F93063692EA32AF9FD8
        public AccessPolicyImpl ForServicePrincipal (string servicePrincipalName)
        {
            this.servicePrincipalName = servicePrincipalName;
            return this;
        }

        ///GENMHASH:01ABB2A8A169AF9132F24847F24D56E9:6BD265DE8D6EB0AF71D7E13104A95DB5
        public AccessPolicyImpl AllowKeyAllPermissions ()
        {
            return AllowKeyPermissions(KeyPermissions.All);
        }

        ///GENMHASH:A03FAAD8A56A117F1C5B4D0165E18038:2886FCB58861FDE2A5A0722CF95F02F8
        public AccessPolicyImpl DisallowKeyAllPermissions ()
        {
            InitializeKeyPermissions();
            Inner.Permissions.Keys.Clear();
            return this;
        }

        ///GENMHASH:0379078579ABB5B0C7747DE0FCD150CE:32E7054731C3AF1FE28D7D4F657764E5
        public AccessPolicyImpl DisallowKeyPermissions (params KeyPermissions[] permissions)
        {
            return DisallowKeyPermissions(new List<KeyPermissions>(permissions));
        }

        ///GENMHASH:BFC40A8274C194ADA54B97FFF26C792F:B6357A7A6591914A7D868EDF465B9C79
        public AccessPolicyImpl DisallowKeyPermissions(IList<KeyPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Keys.Remove(permission.ToString());
            }
            return this;
        }

        ///GENMHASH:23EFE82E8A7FB33D4BEAF74B70CE1367:3E60726A1B82A5D46BD83ECBDA666DAC
        public AccessPolicyImpl AllowSecretAllPermissions ()
        {
            return AllowSecretPermissions(SecretPermissions.All);
        }

        ///GENMHASH:034BD24F1EDCEF94C2B612E26745EC84:3DEB6E41E02F3F5DD756AAD51E9D5A41
        public AccessPolicyImpl DisallowSecretAllPermissions ()
        {
            InitializeKeyPermissions();
            Inner.Permissions.Keys.Clear();
            return this;
        }

        ///GENMHASH:0BE789A9F7F46772A48AE4DEF539ED9B:C45089A07841C467C39B8B11526C860C
        public AccessPolicyImpl DisallowSecretPermissions (params SecretPermissions[] permissions)
        {
            return DisallowSecretPermissions(new List<SecretPermissions>(permissions));
        }

        ///GENMHASH:044EB3BD07FE92ADABF599BDE9722E03:08024B552C1C45974AC88973802166CA
        public AccessPolicyImpl DisallowSecretPermissions(IList<SecretPermissions> permissions)
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
