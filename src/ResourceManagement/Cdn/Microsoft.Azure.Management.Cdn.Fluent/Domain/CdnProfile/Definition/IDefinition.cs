// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the CDN profile.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithGroup,
        IWithSku,
        IWithStandardCreate,
        IWithPremiumVerizonCreate,
        IWithCreate
    {
    }

    /// <summary>
    /// A Redis Cache definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<IWithSku>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        IDefinitionWithTags<IWithCreate>
    {
    }

    /// <summary>
    /// A CDN profile definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the Standard Verizon sku of the CDN profile.
        /// </summary>
        /// <return>The next stage of CDN profile definition.</return>
        IWithStandardCreate WithStandardVerizonSku();

        /// <summary>
        /// Specifies the Premium Verizon sku of the CDN profile.
        /// </summary>
        /// <return>The next stage of CDN profile definition.</return>
        IWithPremiumVerizonCreate WithPremiumVerizonSku();

        /// <summary>
        /// Specifies the Standard Akamai sku of the CDN profile.
        /// </summary>
        /// <return>The next stage of CDN profile definition.</return>
        IWithStandardCreate WithStandardAkamaiSku();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithStandardCreate  :
        IWithCreate
    {
        /// <summary>
        /// Adds new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile definition.</return>
        IWithStandardCreate WithNewEndpoint(string endpointOriginHostname);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<IWithStandardCreate> DefineNewEndpoint();

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<IWithStandardCreate> DefineNewEndpoint(string name);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<IWithStandardCreate> DefineNewEndpoint(string name, string endpointOriginHostname);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithPremiumVerizonCreate  :
        IWithCreate
    {
        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<IWithPremiumVerizonCreate> DefineNewPremiumEndpoint();

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<IWithPremiumVerizonCreate> DefineNewPremiumEndpoint(string name);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<IWithPremiumVerizonCreate> DefineNewPremiumEndpoint(string name, string endpointOriginHostname);

        /// <summary>
        /// Adds new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile definition.</return>
        IWithPremiumVerizonCreate WithNewPremiumEndpoint(string endpointOriginHostname);
    }

    /// <summary>
    /// The first stage of a CDN profile definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<IWithGroup>
    {
    }
}