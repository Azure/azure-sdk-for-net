// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Cdn.Fluent;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint;

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        IWithEndpoint,
        IUpdateWithTags<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the CDN profile update allowing to specify the endpoints
    /// for the profile.
    /// </summary>
    public interface IWithEndpoint 
    {
        /// <summary>
        /// Specifies definition of an endpoint to be attached to the current Premium Verizon CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<IUpdate> DefineNewPremiumEndpoint();

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<IUpdate> DefineNewPremiumEndpoint(string name);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<IUpdate> DefineNewPremiumEndpoint(string name, string endpointOriginHostname);

        /// <summary>
        /// Removes an endpoint in the profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The next stage of the CDN profile update.</return>
        IUpdate WithoutEndpoint(string name);

        /// <summary>
        /// Adds new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile update.</return>
        IUpdate WithNewEndpoint(string endpointOriginHostname);

        /// <summary>
        /// Adds new endpoint to current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile update.</return>
        IUpdate WithNewPremiumEndpoint(string endpointOriginHostname);

        /// <summary>
        /// Begins the description of an update of an existing endpoint in current profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The stage representing updating configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint UpdateEndpoint(string name);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<IUpdate> DefineNewEndpoint();

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<IUpdate> DefineNewEndpoint(string name);

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<IUpdate> DefineNewEndpoint(string name, string endpointOriginHostname);

        /// <summary>
        /// Begins the description of an update of an existing endpoint in current Premium Verizon profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The stage representing updating configuration for the endpoint.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint UpdatePremiumEndpoint(string name);
    }
}