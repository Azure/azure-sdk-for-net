// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition
{
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.StandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of a CDN profile definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IBlank,
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithGroup,
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithSku,
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate,
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithPremiumVerizonCreate,
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithStandardCreate  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithCreate
    {
        /// <summary>
        /// Adds new endpoint to the CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">An endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate WithNewEndpoint(string endpointOriginHostname);

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>The first stage of a new CDN endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate> DefineNewEndpoint();

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">A new endpoint name.</param>
        /// <return>The first stage of a new CDN endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate> DefineNewEndpoint(string name);

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">An endpoint origin hostname.</param>
        /// <return>The first stage of a new CDN endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate> DefineNewEndpoint(string name, string endpointOriginHostname);
    }

    /// <summary>
    /// The first stage of a CDN profile definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// A CDN profile definition allowing the SKU to be specified.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Selects the Standard Akamai SKU.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate WithStandardAkamaiSku();

        /// <summary>
        /// Selects the Standard Verizon SKU.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithStandardCreate WithStandardVerizonSku();

        /// <summary>
        /// Selects the Premium Verizon SKU.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithPremiumVerizonCreate WithPremiumVerizonSku();
    }

    /// <summary>
    /// The stage of a CDN profile definition allowing the resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithSku>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithPremiumVerizonCreate  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithCreate
    {
        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>The first stage of a new CDN endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithPremiumVerizonCreate> DefineNewPremiumEndpoint();

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">A name for the endpoint.</param>
        /// <return>The first stage of a new CDN endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithPremiumVerizonCreate> DefineNewPremiumEndpoint(string name);

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithPremiumVerizonCreate> DefineNewPremiumEndpoint(string name, string endpointOriginHostname);

        /// <summary>
        /// Adds a new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">An endpoint origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithPremiumVerizonCreate WithNewPremiumEndpoint(string endpointOriginHostname);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition.IWithCreate>
    {
    }
}