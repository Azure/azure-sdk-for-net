// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An app service plan definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithPricingTier>
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithOperatingSystem WithPricingTier(PricingTier pricingTier);

        /// <summary>
        /// Specifies shared pricing tier for the app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithSharedPricingTier();

        /// <summary>
        /// Specifies free pricing tier for the app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithFreePricingTier();
    }

    /// <summary>
    /// An app service plan definition with sufficient inputs to create a new
    /// website in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithPerSiteScaling,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCapacity,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// An app service plan definition allowing the operating system to be set.
    /// </summary>
    public interface IWithOperatingSystem 
    {
        /// <summary>
        /// Specifies the operating system of the app service plan.
        /// </summary>
        /// <param name="operatingSystem">The operating system.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithOperatingSystem(OperatingSystem operatingSystem);
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
        /// <return>The next stage of an app service plan definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithCapacity(int capacity);
    }

    /// <summary>
    /// The first stage of the app service plan definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithGroup>
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate WithPerSiteScaling(bool perSiteScaling);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithGroup,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithPricingTier,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithOperatingSystem,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition.IWithCreate
    {
    }
}