// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayBackend.Definition;
    using ApplicationGatewayBackend.UpdateDefinition;
    using Models;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayBackend.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QmFja2VuZEltcGw=
    internal partial class ApplicationGatewayBackendImpl :
        ChildResource<ApplicationGatewayBackendAddressPoolInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayBackend,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayBackend.Update.IUpdate
    {
        ///GENMHASH:57E12F644F2C3EB367E99CBE582AD951:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayBackendImpl(ApplicationGatewayBackendAddressPoolInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Accessors

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:1FC649C97657147238976F3B54524F58:B74483DFB822D3E7D17AE4E2E8CAE6E0
        public IReadOnlyDictionary<string, string> BackendNicIpConfigurationNames()
        {
            // This assumes a NIC can only have one IP config associated with the backend of an app gateway,
            // which is correct at the time of this implementation and seems unlikely to ever change
            Dictionary<string, string> ipConfigNames = new Dictionary<string, string>();
            if (Inner.BackendIPConfigurations != null)
            {
                foreach (var inner in Inner.BackendIPConfigurations)
                {
                    string nicId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id);
                    string ipConfigName = ResourceUtils.NameFromResourceId(inner.Id);
                    ipConfigNames.Add(nicId, ipConfigName);
                }
            }
            return ipConfigNames;
        }

        ///GENMHASH:BD4433E096C5BD5A3392F44B28BA9083:B81C8A45BECCD7571A580B4729B2CD0C
        public bool ContainsFqdn(string fqdn)
        {
            if (fqdn != null)
            {
                foreach (var address in Inner.BackendAddresses)
                {
                    if (fqdn.ToLower().Equals(address.Fqdn.ToLower()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        ///GENMHASH:DA671E788D7745DDD7A0AEE413BB02F2:436637A06A9B4E6B2B3F2BA7F6A702C2
        public bool ContainsIpAddress(string ipAddress)
        {
            if (ipAddress != null)
            {
                foreach (var address in Inner.BackendAddresses)
                {
                    if (ipAddress.ToLower().Equals(address.IpAddress))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        ///GENMHASH:B9D8E0EB1A218491349631635CDA92D3:5685D5C7D202D29D2E15856A5673C8E7
        public IList<ApplicationGatewayBackendAddress> Addresses()
        {
            var addresses = new List<ApplicationGatewayBackendAddress>();
            if (Inner.BackendAddresses != null) {
                foreach(var address in Inner.BackendAddresses)  {
                    addresses.Add(address);
                }
            }
            return addresses;
        }

        #endregion

        #region Helpers

        ///GENMHASH:CA426728D89DF7B679F3082001CE7DB8:631561FDE1B5174113A31FA550BA7525
        private IList<ApplicationGatewayBackendAddress> EnsureAddresses()
        {
            var addresses = Inner.BackendAddresses;
            if (addresses == null) {
               addresses = new List<ApplicationGatewayBackendAddress>();
                Inner.BackendAddresses = addresses;
            }
            return addresses;
        }

        #endregion

        #region Withers

        ///GENMHASH:DFE562EDA69B9B5779C74F1A7206D23B:524E74936C9A9591669EB81BA006DE87
        public ApplicationGatewayBackendImpl WithoutAddress(ApplicationGatewayBackendAddress address)
        {
            EnsureAddresses().Remove(address);
            return this;
        }

        ///GENMHASH:040FE6797829F09ECF75BDE559FBA5FC:50D6F54EC4B6D5D39C3D750DD28CAF84
        public ApplicationGatewayBackendImpl WithIpAddress(string ipAddress)
        {
            if (ipAddress == null)
            {
                return this;
            }

            ApplicationGatewayBackendAddress address = new ApplicationGatewayBackendAddress()
            {
                IpAddress = ipAddress
            };

            var addresses = EnsureAddresses();
            foreach (var a in addresses)
            {
                if (a.IpAddress == null)
                {
                    continue;
                }
                else if (ipAddress.ToLower().Equals(a.IpAddress.ToLower()))
                {
                    return this;
                }
            }

            addresses.Add(address);
            return this;
        }

        ///GENMHASH:BE71ABDD6202EC63298CCC3687E0D342:D0BAB29C2066E9B0BAB942D4C9C7CE4C
        public ApplicationGatewayBackendImpl WithFqdn(string fqdn)
        {
            if (fqdn == null)
            {
                return this;
            }

            ApplicationGatewayBackendAddress address = new ApplicationGatewayBackendAddress()
            {
                Fqdn = fqdn
            };

            EnsureAddresses().Add(address);
            return this;
        }

        ///GENMHASH:1EEC75E693F98EC473E92A76B0687A98:1F1F5B0E32A38D9A62957DE6F988C355
        public ApplicationGatewayBackendImpl WithoutIpAddress(string ipAddress)
        {
            if (ipAddress == null)
            {
                return this;
            }

            if (Inner.BackendAddresses == null)
            {
                return this;
            }

            var addresses = EnsureAddresses();
            for (int i = 0; i < addresses.Count; i++)
            {
                string curIpAddress = addresses[i].IpAddress;
                if (curIpAddress != null && curIpAddress.ToLower().Equals(ipAddress.ToLower()))
                {
                    addresses.RemoveAt(i);
                    break;
                }
            }

            return this;
        }

        ///GENMHASH:237A061FC122426B3FAE4D0084C2C114:B8170174509CC904E5A9DF22C331E935
        public ApplicationGatewayBackendImpl WithoutFqdn(string fqdn)
        {
            if (fqdn == null)
            {
                return this;
            }

            var addresses = EnsureAddresses();
            for (int i = 0; i < addresses.Count; i++)
            {
                string curFqdn = addresses[i].Fqdn;
                if (curFqdn != null && curFqdn.ToLower().Equals(fqdn.ToLower())) {
                    addresses.RemoveAt(i);
                    break;
                }
            }

            return this;
        }

        #endregion

        #region Actions

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:321924EA2E0782F0638FD1917D19DF54
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithBackend(this);
        }

        #endregion
    }
}