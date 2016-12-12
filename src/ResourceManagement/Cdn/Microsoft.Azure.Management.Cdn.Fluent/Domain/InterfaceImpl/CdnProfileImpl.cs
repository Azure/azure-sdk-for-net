// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using CdnProfile.Update;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading;
    using CdnProfile.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;

    internal partial class CdnProfileImpl 
    {
        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate> CdnProfile.Definition.IWithStandardCreate.DefineNewEndpoint()
        {
            return this.DefineNewEndpoint() as CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate> CdnProfile.Definition.IWithStandardCreate.DefineNewEndpoint(string name)
        {
            return this.DefineNewEndpoint(name) as CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnProfile.Definition.IWithStandardCreate.DefineNewEndpoint(string name, string endpointOriginHostname)
        {
            return this.DefineNewEndpoint(name, endpointOriginHostname) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Adds new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile definition.</return>
        CdnProfile.Definition.IWithStandardCreate CdnProfile.Definition.IWithStandardCreate.WithNewEndpoint(string endpointOriginHostname)
        {
            return this.WithNewEndpoint(endpointOriginHostname) as CdnProfile.Definition.IWithStandardCreate;
        }

        /// <summary>
        /// Adds new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile definition.</return>
        CdnProfile.Definition.IWithPremiumVerizonCreate CdnProfile.Definition.IWithPremiumVerizonCreate.WithNewPremiumEndpoint(string endpointOriginHostname)
        {
            return this.WithNewPremiumEndpoint(endpointOriginHostname) as CdnProfile.Definition.IWithPremiumVerizonCreate;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnProfile.Definition.IWithPremiumVerizonCreate.DefineNewPremiumEndpoint()
        {
            return this.DefineNewPremiumEndpoint() as CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnProfile.Definition.IWithPremiumVerizonCreate.DefineNewPremiumEndpoint(string name)
        {
            return this.DefineNewPremiumEndpoint(name) as CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnProfile.Definition.IWithPremiumVerizonCreate.DefineNewPremiumEndpoint(string name, string endpointOriginHostname)
        {
            return this.DefineNewPremiumEndpoint(name, endpointOriginHostname) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate> CdnProfile.Update.IWithEndpoint.DefineNewEndpoint()
        {
            return this.DefineNewEndpoint() as CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate> CdnProfile.Update.IWithEndpoint.DefineNewEndpoint(string name)
        {
            return this.DefineNewEndpoint(name) as CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnProfile.Update.IWithEndpoint.DefineNewEndpoint(string name, string endpointOriginHostname)
        {
            return this.DefineNewEndpoint(name, endpointOriginHostname) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds new endpoint to current CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile update.</return>
        CdnProfile.Update.IUpdate CdnProfile.Update.IWithEndpoint.WithNewEndpoint(string endpointOriginHostname)
        {
            return this.WithNewEndpoint(endpointOriginHostname) as CdnProfile.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing endpoint in current Premium Verizon profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The stage representing updating configuration for the endpoint.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnProfile.Update.IWithEndpoint.UpdatePremiumEndpoint(string name)
        {
            return this.UpdatePremiumEndpoint(name) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Adds new endpoint to current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The next stage of CDN profile update.</return>
        CdnProfile.Update.IUpdate CdnProfile.Update.IWithEndpoint.WithNewPremiumEndpoint(string endpointOriginHostname)
        {
            return this.WithNewPremiumEndpoint(endpointOriginHostname) as CdnProfile.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing endpoint in current profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The stage representing updating configuration for the endpoint.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnProfile.Update.IWithEndpoint.UpdateEndpoint(string name)
        {
            return this.UpdateEndpoint(name) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Removes an endpoint in the profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The next stage of the CDN profile update.</return>
        CdnProfile.Update.IUpdate CdnProfile.Update.IWithEndpoint.WithoutEndpoint(string name)
        {
            return this.WithoutEndpoint(name) as CdnProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the current Premium Verizon CDN profile.
        /// </summary>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate> CdnProfile.Update.IWithEndpoint.DefineNewPremiumEndpoint()
        {
            return this.DefineNewPremiumEndpoint() as CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate> CdnProfile.Update.IWithEndpoint.DefineNewPremiumEndpoint(string name)
        {
            return this.DefineNewPremiumEndpoint(name) as CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies definition of an endpoint to be attached to the current Premium Verizon CDN profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <param name="endpointOriginHostname">The endpoint origin hostname.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnProfile.Update.IWithEndpoint.DefineNewPremiumEndpoint(string name, string endpointOriginHostname)
        {
            return this.DefineNewPremiumEndpoint(name, endpointOriginHostname) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName;
            }
        }

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.CheckEndpointNameAvailability(string name)
        {
            return this.CheckEndpointNameAvailability(name) as Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult;
        }

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal used for advanced management tasks.
        /// </summary>
        /// <return>URI used to login to third party web portal.</return>
        string ICdnProfile.GenerateSsoUri()
        {
            return this.GenerateSsoUri();
        }

        /// <summary>
        /// Gets endpoints in the CDN manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.Endpoints
        {
            get
            {
                return this.Endpoints() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint>;
            }
        }

        /// <summary>
        /// Forcibly purges CDN endpoint content in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.PurgeEndpointContent(string endpointName, IList<string> contentPaths)
        {
 
            this.PurgeEndpointContent(endpointName, contentPaths);
        }

        /// <summary>
        /// Gets Sku.
        /// </summary>
        Microsoft.Azure.Management.Cdn.Fluent.Models.Sku Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.Sku
        {
            get
            {
                return this.Sku() as Microsoft.Azure.Management.Cdn.Fluent.Models.Sku;
            }
        }

        /// <summary>
        /// Gets CDN profile state.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.ResourceState
        {
            get
            {
                return this.ResourceState();
            }
        }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>CustomDomainValidationResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.ValidateEndpointCustomDomain(string endpointName, string hostName)
        {
            return this.ValidateEndpointCustomDomain(endpointName, hostName) as Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult;
        }

        /// <summary>
        /// Starts stopped CDN endpoint in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.StartEndpoint(string endpointName)
        {
 
            this.StartEndpoint(endpointName);
        }

        /// <summary>
        /// Gets Checks if current instance of CDN profile Sku is Premium Verizon.
        /// </summary>
        /// <summary>
        /// Gets true if current instance of CDN Profile Sku is of Premium Verizon, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.IsPremiumVerizon
        {
            get
            {
                return this.IsPremiumVerizon();
            }
        }

        /// <summary>
        /// Stops running CDN endpoint in the current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.StopEndpoint(string endpointName)
        {
 
            this.StopEndpoint(endpointName);
        }

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content in current profile. Available for Verizon Profiles.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile.LoadEndpointContent(string endpointName, IList<string> contentPaths)
        {
 
            this.LoadEndpointContent(endpointName, contentPaths);
        }

        /// <summary>
        /// Specifies the Standard Verizon sku of the CDN profile.
        /// </summary>
        /// <return>The next stage of CDN profile definition.</return>
        CdnProfile.Definition.IWithStandardCreate CdnProfile.Definition.IWithSku.WithStandardVerizonSku()
        {
            return this.WithStandardVerizonSku() as CdnProfile.Definition.IWithStandardCreate;
        }

        /// <summary>
        /// Specifies the Standard Akamai sku of the CDN profile.
        /// </summary>
        /// <return>The next stage of CDN profile definition.</return>
        CdnProfile.Definition.IWithStandardCreate CdnProfile.Definition.IWithSku.WithStandardAkamaiSku()
        {
            return this.WithStandardAkamaiSku() as CdnProfile.Definition.IWithStandardCreate;
        }

        /// <summary>
        /// Specifies the Premium Verizon sku of the CDN profile.
        /// </summary>
        /// <return>The next stage of CDN profile definition.</return>
        CdnProfile.Definition.IWithPremiumVerizonCreate CdnProfile.Definition.IWithSku.WithPremiumVerizonSku()
        {
            return this.WithPremiumVerizonSku() as CdnProfile.Definition.IWithPremiumVerizonCreate;
        }
    }
}