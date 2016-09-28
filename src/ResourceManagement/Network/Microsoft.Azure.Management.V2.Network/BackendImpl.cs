// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.Backend.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.Backend.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Network.Backend.Definition;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link Backend}.
    /// </summary>
    public partial class BackendImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.BackendAddressPoolInner,Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        IBackend,
        IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithBackendOrProbe>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.Backend.Update.IUpdate
    {
        protected  BackendImpl (BackendAddressPoolInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {

            //$ super(inner, parent);
            //$ }

        }

        public IDictionary<string,string> BackendNicIpConfigurationNames
        {
            get
            {
            //$ // This assumes a NIC can only have one IP config associated with the backend of an LB,
            //$ // which is correct at the time of this implementation and seems unlikely to ever change
            //$ final Map<String, String> ipConfigNames = new TreeMap<>();
            //$ if (this.inner().backendIPConfigurations() != null) {
            //$ for (NetworkInterfaceIPConfigurationInner inner : this.inner().backendIPConfigurations()) {
            //$ String nicId = ResourceUtils.parentResourcePathFromResourceId(inner.id());
            //$ String ipConfigName = ResourceUtils.nameFromResourceId(inner.id());
            //$ ipConfigNames.put(nicId, ipConfigName);
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableMap(ipConfigNames);


                return null;
            }
        }
        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ILoadBalancingRule> LoadBalancingRules ()
        {

            //$ final Map<String, LoadBalancingRule> rules = new TreeMap<>();
            //$ if (this.inner().loadBalancingRules() != null) {
            //$ for (SubResource inner : this.inner().loadBalancingRules()) {
            //$ String name = ResourceUtils.nameFromResourceId(inner.id());
            //$ LoadBalancingRule rule = this.parent().loadBalancingRules().get(name);
            //$ if (rule != null) {
            //$ rules.put(name, rule);
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableMap(rules);

            return null;
        }

        override public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public ISet<string> GetVirtualMachineIds ()
        {

            //$ Set<String> vmIds = new HashSet<>();
            //$ Map<String, String> nicConfigs = this.backendNicIpConfigurationNames();
            //$ if (nicConfigs != null) {
            //$ for (String nicId : nicConfigs.keySet()) {
            //$ try {
            //$ NetworkInterface nic = this.parent().manager().networkInterfaces().getById(nicId);
            //$ if (nic == null || nic.virtualMachineId() == null) {
            //$ continue;
            //$ } else {
            //$ vmIds.add(nic.virtualMachineId());
            //$ }
            //$ } catch (CloudException | IllegalArgumentException e) {
            //$ continue;
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return vmIds;

            return null;
        }

        public LoadBalancerImpl Attach ()
        {

            //$ this.parent().withBackend(this);
            //$ return this.parent();

            return null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}