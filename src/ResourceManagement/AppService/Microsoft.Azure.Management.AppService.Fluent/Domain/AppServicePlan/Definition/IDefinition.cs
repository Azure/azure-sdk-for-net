// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An app service plan definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithPricingTier>
    {
    }

    /// <summary>
    /// An app service plan definition allowing pricing tier to be set.
    /// </summary>
    public interface IWithPricingTier 
    {
        /// <summary>
        /// Specifies the pricing tier for the app service plan.
        /// </summary>
        /// <param name="pricingTier">The pricing tier enum.</param>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithPricingTier(AppServicePricingTier pricingTier);
    }

    /// <summary>
    /// An app service plan definition with sufficient inputs to create a new
    /// website in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        IWithPerSiteScaling,
        IWithCapacity,
        ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        IDefinitionWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// An app service plan definition allowing instance capacity to be set.
    /// </summary>
    public interface IWithCapacity 
    {
        /// <summary>
        /// Specifies the maximum number of instances running for this app service plan.
        /// </summary>
        /// <param name="capacity">The maximum number of instances.</param>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithCapacity(int capacity);
    }

    /// <summary>
    /// The first stage of the app service plan definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// An app service plan definition allowing per site scaling configuration to be set.
    /// </summary>
    public interface IWithPerSiteScaling 
    {
        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithPerSiteScaling(bool perSiteScaling);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithGroup,
        IWithPricingTier,
        IWithCreate
    {
    }
}