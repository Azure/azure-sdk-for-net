// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Container interface for all the definitions related to an availability set.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithGroup,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify the fault domain count.
    /// </summary>
    public interface IWithFaultDomainCount 
    {
        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">The fault domain count.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithFaultDomainCount(int faultDomainCount);
    }

    /// <summary>
    /// The first stage of an availability set definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the availability set definition allowing enable or disable for managed disk.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku type for the availability set.
        /// </summary>
        /// <param name="skuType">The sku type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithSku(AvailabilitySetSkuTypes skuType);
    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify the update domain count.
    /// </summary>
    public interface IWithUpdateDomainCount 
    {
        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">Update domain count.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate WithUpdateDomainCount(int updateDomainCount);
    }

    /// <summary>
    /// The stage of an availability set definition which contains all the minimum required inputs for
    /// the resource to be created (via WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Definition.IWithCreate>,
        IWithUpdateDomainCount,
        IWithFaultDomainCount,
        IWithSku
    {
    }
}