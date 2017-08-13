// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Models;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using LoadBalancerBackend.Definition;
    using LoadBalancerBackend.UpdateDefinition;
    using LoadBalancerBackend.Update;

    /// <summary>
    /// Implementation for Backend.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VyQmFja2VuZEltcGw=
    internal partial class LoadBalancerBackendImpl :
        ChildResource<BackendAddressPoolInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerBackend,
        IDefinition<LoadBalancer.Definition.IWithCreate>,
        IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        IUpdate
    {
        
        ///GENMHASH:EE2A508C800EC05294CBB5EAA90384AB:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal LoadBalancerBackendImpl (BackendAddressPoolInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        
        ///GENMHASH:660646CB1AAA13CCBA50483108FFFCBF:1DE7E24B5141F230DDAD34D53E6C0E04
        internal IReadOnlyDictionary<string, string> BackendNicIPConfigurationNames()
        {
            // This assumes a NIC can only have one IP config associated with the backend of an LB,
            // which is correct at the time of this implementation and seems unlikely to ever change
            var ipConfigNames = new Dictionary<string, string>();
            if (Inner.BackendIPConfigurations != null)
            {
                foreach (var inner in Inner.BackendIPConfigurations)
                {
                    string nicId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id);
                    string ipConfigName = ResourceUtils.NameFromResourceId(inner.Id);
                    ipConfigNames[nicId] = ipConfigName;
                }
            }

            return ipConfigNames;
        }
   
        
        ///GENMHASH:4EDB057B59A7F7BB0C722F8A1399C004:A2F94AF9792429D630DA94FCC75CFD8B
        internal IDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            IDictionary<string, ILoadBalancingRule> rules = new SortedDictionary<string, ILoadBalancingRule>();
            if (Inner.LoadBalancingRules != null)
            {
                foreach (var inner in Inner.LoadBalancingRules)
                {
                    string name = ResourceUtils.NameFromResourceId(inner.Id);
                    ILoadBalancingRule rule;
                    if (Parent.LoadBalancingRules().TryGetValue(name, out rule))
                    {
                        rules[name] = rule;
                    }
                }
            }

            return rules;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:A2968EC81873609D937762599BD3CAF6:6FF87412F1B970C11ADDF4400C94B874
        internal ISet<string> GetVirtualMachineIds ()
        {
            ISet<string> vmIds = new HashSet<string>();
            var nicConfigs = BackendNicIPConfigurationNames();
            if (nicConfigs != null)
            {
                foreach (string nicId in nicConfigs.Keys)
                {
                    try
                    {
                        var nic = Parent.Manager.NetworkInterfaces.GetById(nicId);
                        if (nic != null && nic.VirtualMachineId != null)
                        {
                            vmIds.Add(nic.VirtualMachineId);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return vmIds;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:321924EA2E0782F0638FD1917D19DF54
        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithBackend(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent as LoadBalancer.Update.IUpdate;
        }

        ///GENMHASH:51B0C77EEF192BB5D98474B3557C874E:12D7DD62D5476B4902FDCE9A39A0D717
        internal LoadBalancerBackendImpl WithExistingVirtualMachines(ICollection<IHasNetworkInterfaces> vms)
        {
            if (vms != null)
            {
                foreach(var vm in vms)
                {
                    Parent.WithExistingVirtualMachine(vm, Name());
                }
            }
            return this;
        }

        
        ///GENMHASH:DFE9D388863B0ACFAC02ED04C33B6964:32CC04CBC7A0600E8B42E01CB9CE142B
        internal LoadBalancerBackendImpl WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return (vms != null) ? this.WithExistingVirtualMachines(new List<IHasNetworkInterfaces>(vms)) : this;
        }
    }
}
