// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using System.Collections.Generic;
    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for Backend.
    /// </summary>
    public partial class BackendImpl  :
        ChildResource<BackendAddressPoolInner, LoadBalancerImpl, ILoadBalancer>,
        IBackend,
        Backend.Definition.IDefinition<LoadBalancer.Definition.IWithBackendOrProbe>,
        Backend.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        Backend.Update.IUpdate
    {
        internal BackendImpl (BackendAddressPoolInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {
        }

        public IDictionary<string,string> BackendNicIpConfigurationNames
        {
            get
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
        }
        public IDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            IDictionary<string, ILoadBalancingRule> rules = new SortedDictionary<string, ILoadBalancingRule>();
            if (this.Inner.LoadBalancingRules != null)
            {
                foreach (var inner in this.Inner.LoadBalancingRules)
                {
                    string name = ResourceUtils.NameFromResourceId(inner.Id);
                    ILoadBalancingRule rule;
                    this.Parent.LoadBalancingRules().TryGetValue(name, out rule);
                    if (rule != null)
                    {
                        rules[name] = rule;
                    }
                }
            }

            return rules;
        }

        override public string Name
        {
            get
            {
                return this.Inner.Name;
            }
        }

        public ISet<string> GetVirtualMachineIds ()
        {
            ISet<string> vmIds = new HashSet<string>();
            IDictionary<string, string> nicConfigs = this.BackendNicIpConfigurationNames;
            if (nicConfigs != null)
            {
                foreach (string nicId in nicConfigs.Keys)
                {
                    try
                    {
                        var nic = this.Parent.Manager.NetworkInterfaces.GetById(nicId);
                        if (nic == null || nic.VirtualMachineId == null)
                        {
                            continue;
                        }
                        else
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

        public LoadBalancerImpl Attach ()
        {
            return Parent.WithBackend(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}