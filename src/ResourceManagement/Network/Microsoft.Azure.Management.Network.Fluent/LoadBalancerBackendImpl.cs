// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VyQmFja2VuZEltcGw=
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for Backend.
    /// </summary>
    public partial class LoadBalancerBackendImpl  :
        ChildResource<BackendAddressPoolInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerBackend,
        LoadBalancerBackend.Definition.IDefinition<LoadBalancer.Definition.IWithBackendOrProbe>,
        LoadBalancerBackend.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerBackend.Update.IUpdate
    {
        internal LoadBalancerBackendImpl (BackendAddressPoolInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:1FC649C97657147238976F3B54524F58:41142AC1E2F08572766FDBF43EA00E15
        internal IDictionary<string, string> BackendNicIpConfigurationNames()
        {
            // This assumes a NIC can only have one IP config associated with the backend of an LB,
            // which is correct at the time of this implementation and seems unlikely to ever change
            IDictionary<string, string> ipConfigNames = new SortedDictionary<string, string>();
            if (this.Inner.BackendIPConfigurations != null)
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
            if (this.Inner.LoadBalancingRules != null)
            {
                foreach (var inner in this.Inner.LoadBalancingRules)
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
            return this.Inner.Name;
        }

        ///GENMHASH:A2968EC81873609D937762599BD3CAF6:F9B61BF42E13154C4C28B7365CB04241
        internal ISet<string> GetVirtualMachineIds ()
        {
            ISet<string> vmIds = new HashSet<string>();
            IDictionary<string, string> nicConfigs = BackendNicIpConfigurationNames();
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
            return Parent;
        }
    }
}
