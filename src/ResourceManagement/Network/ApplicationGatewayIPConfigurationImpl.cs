// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayIPConfiguration.Definition;
    using ApplicationGatewayIPConfiguration.UpdateDefinition;
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayIPConfiguration.
    /// </summary>
    
    internal partial class ApplicationGatewayIPConfigurationImpl :
        ChildResource<ApplicationGatewayIPConfigurationInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayIPConfiguration,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayIPConfiguration.Update.IUpdate
    {
        
        internal ApplicationGatewayIPConfigurationImpl(ApplicationGatewayIPConfigurationInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Actions

        
        public ISubnet GetSubnet()
        {
            return Parent.Manager.GetAssociatedSubnet(Inner.Subnet);
        }

        
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithConfig(this);
        }

        #endregion

        #region Accessors

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        public string SubnetName()
        {
            var subnetRef = Inner.Subnet;
            if (subnetRef != null)
            {
                return ResourceUtils.NameFromResourceId(subnetRef.Id);
            }
            else
            {
                return null;
            }
        }

        
        public override string Name()
        {
            return Inner.Name;
        }

        
        public string NetworkId()
        {
            var subnetRef = Inner.Subnet;
            if (subnetRef != null)
            {
                return ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Withers

        
        public ApplicationGatewayIPConfigurationImpl WithExistingSubnet(ISubnet subnet)
        {
            return WithExistingSubnet(subnet.Parent.Id, subnet.Name);
        }

        
        public ApplicationGatewayIPConfigurationImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            return WithExistingSubnet(network.Id, subnetName);
        }

        
        public ApplicationGatewayIPConfigurationImpl WithExistingSubnet(string networkId, string subnetName)
        {
            var subnetRef = new SubResource()
            {
                Id = networkId + "/subnets/" + subnetName
            };

            Inner.Subnet = subnetRef;
            return this;
        }

        #endregion
    }
}
