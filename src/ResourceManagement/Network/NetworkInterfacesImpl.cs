// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for NetworkInterfaces.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya0ludGVyZmFjZXNJbXBs
    internal partial class NetworkInterfacesImpl :
        TopLevelModifiableResources<
            INetworkInterface,
            NetworkInterfaceImpl,
            NetworkInterfaceInner,
            INetworkInterfacesOperations,
            INetworkManager>,
        INetworkInterfaces
    {
        
        ///GENMHASH:541D9CA48625DA59F5ACD5C51CAC928B:B9076B1FF51903FE27B3E5E401CEEBB3
        internal NetworkInterfacesImpl(INetworkManager networkManager)
            : base(networkManager.Inner.NetworkInterfaces, networkManager)
        {
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:7EDE301E56E52EA4AE4C695EA758FCE4
        override protected NetworkInterfaceImpl WrapModel(string name)
        {
            NetworkInterfaceInner inner = new NetworkInterfaceInner()
            {
                IpConfigurations = new List<NetworkInterfaceIPConfigurationInner>(),
                DnsSettings = new NetworkInterfaceDnsSettings()
            };
            return new NetworkInterfaceImpl(name, inner, Manager);
        }

        //$TODO: this should return NetworkInterfaceImpl

        
        ///GENMHASH:0FC0465591EF4D86100A2FF1DC557738:5FA06784E91172B242B7124B96DE6A6F
        override protected INetworkInterface WrapModel(NetworkInterfaceInner inner)
        {
            return new NetworkInterfaceImpl(inner.Name, inner, Manager);
        }

        
        protected async override Task<IPage<NetworkInterfaceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<NetworkInterfaceInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        
        protected async override Task<IPage<NetworkInterfaceInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<NetworkInterfaceInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal NetworkInterfaceImpl Define(string name)
        {
            return WrapModel(name);
        }

        
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        
        protected async override Task<NetworkInterfaceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        
        ///GENMHASH:CF1C887C1688AB525BA63FD7B4469714:8F00A537375AA728C645AA4A09E83CD4
        public IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId, string name)
        {
            VirtualMachineScaleSetNetworkInterfacesImpl scaleSetNetworkInterfaces = new VirtualMachineScaleSetNetworkInterfacesImpl(
                resourceGroupName,
                scaleSetName,
                Manager);
            return scaleSetNetworkInterfaces.GetByVirtualMachineInstanceId(instanceId, name);
        }

        
        ///GENMHASH:FB8BAF1D7A241BC666A03354AD1A59B1:8539C97B7B4BC22A0A20D9B20F29FA78
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSet(string resourceGroupName, string scaleSetName)
        {
            VirtualMachineScaleSetNetworkInterfacesImpl scaleSetNetworkInterfaces = new VirtualMachineScaleSetNetworkInterfacesImpl(
                resourceGroupName,
                scaleSetName,
                Manager);
            return scaleSetNetworkInterfaces.List();
        }

        
        ///GENMHASH:BA50DA09E1FC76012780D58EFCE9A237:FCFAC84F49E66F1F4CEB39A2A782719B
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetId(string id)
        {
            return this.ListByVirtualMachineScaleSet(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        
        ///GENMHASH:DD375F4600A4F5AA88A87C271E21CBDB:EF1D4DAC0F1240EECDA12517F1751620
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId)
        {
            VirtualMachineScaleSetNetworkInterfacesImpl scaleSetNetworkInterfaces = new VirtualMachineScaleSetNetworkInterfacesImpl(
                resourceGroupName,
                scaleSetName,
                Manager);
            return scaleSetNetworkInterfaces.ListByVirtualMachineInstanceId(instanceId);
        }
    }
}
