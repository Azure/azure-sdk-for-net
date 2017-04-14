// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update
{
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of a CDN profile update allowing to modify the endpoints for the profile.
    /// </summary>
    public interface IWithEndpoint 
    {
        /// <summary>
        /// Adds a new endpoint.
        /// </summary>
        /// <param name="endpointOriginHostname">An endpoint origin hostname.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate WithNewEndpoint(string endpointOriginHostname);

        /// <summary>
        /// Removes an endpoint from the profile.
        /// </summary>
        /// <param name="name">The name of an existing endpoint.</param>
        /// <return>The next stage of the CDN profile update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate WithoutEndpoint(string name);

        /// <summary>
        /// Begins the description of an update of an existing endpoint in current Premium Verizon profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The first stage of the update of the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint UpdatePremiumEndpoint(string name);

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to this Premium Verizon CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>The first stage of an endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate> DefineNewPremiumEndpoint();

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to this Premium Verizon CDN profile.
        /// </summary>
        /// <param name="name">A name for the new endpoint.</param>
        /// <return>The first stage of an endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate> DefineNewPremiumEndpoint(string name);

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to this Premium Verizon CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">A name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The first stage of an endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate> DefineNewPremiumEndpoint(string name, string endpointOriginHostname);

        /// <summary>
        /// Begins the description of an update of an existing endpoint in current profile.
        /// </summary>
        /// <param name="name">The name of an existing endpoint.</param>
        /// <return>The first stage of the update of the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint UpdateEndpoint(string name);

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>The first stage of an endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate> DefineNewEndpoint();

        /// <summary>
        /// Starts the definition of a new endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The first stage of an endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate> DefineNewEndpoint(string name);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The first stage of an endpoint definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate> DefineNewEndpoint(string name, string endpointOriginHostname);

        /// <summary>
        /// Adds new endpoint to current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate WithNewPremiumEndpoint(string endpointOriginHostname);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IWithEndpoint,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update.IUpdate>
    {
    }
}