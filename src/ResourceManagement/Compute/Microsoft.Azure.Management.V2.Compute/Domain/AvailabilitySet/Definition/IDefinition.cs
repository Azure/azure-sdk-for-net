// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Compute;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    /// <summary>
    /// The stage of an availability set definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>,
        IDefinitionWithTags<Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate>,
        IWithUpdateDomainCount,
        IWithFaultDomainCount
    {
    }
    /// <summary>
    /// The stage of the availability set definition allowing to specify the update domain count.
    /// </summary>
    public interface IWithUpdateDomainCount 
    {
        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">updateDomainCount update domain count</param>
        /// <returns>the next stage of the definition</returns>
        IWithCreate WithUpdateDomainCount (int updateDomainCount);

    }
    /// <summary>
    /// The first stage of an availability set definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithGroup>
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
        /// <param name="faultDomainCount">faultDomainCount the fault domain count</param>
        /// <returns>the next stage of the definition</returns>
        IWithCreate WithFaultDomainCount (int faultDomainCount);

    }
    /// <summary>
    /// Container interface for all the definitions related to an availability set.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithGroup,
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of the availability set definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate>
    {
    }
}