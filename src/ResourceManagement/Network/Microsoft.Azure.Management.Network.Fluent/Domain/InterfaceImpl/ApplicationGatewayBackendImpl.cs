// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayBackend.Definition;
    using ApplicationGatewayBackend.Update;
    using ApplicationGatewayBackend.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayBackendImpl 
    {
        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// This call can be made in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackend.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackend.Definition.IWithAddress<ApplicationGateway.Definition.IWithCreate>.WithFqdn(string fqdn)
        {
            return this.WithFqdn(fqdn) as ApplicationGatewayBackend.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// This call can be made in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackend.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackend.Definition.IWithAddress<ApplicationGateway.Definition.IWithCreate>.WithIpAddress(string ipAddress)
        {
            return this.WithIpAddress(ipAddress) as ApplicationGatewayBackend.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackend.UpdateDefinition.IWithAddress<ApplicationGateway.Update.IUpdate>.WithFqdn(string fqdn)
        {
            return this.WithFqdn(fqdn) as ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackend.UpdateDefinition.IWithAddress<ApplicationGateway.Update.IUpdate>.WithIpAddress(string ipAddress)
        {
            return this.WithIpAddress(ipAddress) as ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Ensures the specified fully qualified domain name (FQDN) is not associated with this backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackend.Update.IUpdate ApplicationGatewayBackend.Update.IWithAddress.WithoutFqdn(string fqdn)
        {
            return this.WithoutFqdn(fqdn) as ApplicationGatewayBackend.Update.IUpdate;
        }

        /// <summary>
        /// Ensures the specified IP address is not associated with this backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackend.Update.IUpdate ApplicationGatewayBackend.Update.IWithAddress.WithoutIpAddress(string ipAddress)
        {
            return this.WithoutIpAddress(ipAddress) as ApplicationGatewayBackend.Update.IUpdate;
        }

        /// <summary>
        /// Ensure the specified address is not associated with this backend.
        /// </summary>
        /// <param name="address">An existing address currently associated with the backend.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackend.Update.IUpdate ApplicationGatewayBackend.Update.IWithAddress.WithoutAddress(ApplicationGatewayBackendAddress address)
        {
            return this.WithoutAddress(address) as ApplicationGatewayBackend.Update.IUpdate;
        }

        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackend.Update.IUpdate ApplicationGatewayBackend.Update.IWithAddress.WithFqdn(string fqdn)
        {
            return this.WithFqdn(fqdn) as ApplicationGatewayBackend.Update.IUpdate;
        }

        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackend.Update.IUpdate ApplicationGatewayBackend.Update.IWithAddress.WithIpAddress(string ipAddress)
        {
            return this.WithIpAddress(ipAddress) as ApplicationGatewayBackend.Update.IUpdate;
        }

        /// <summary>
        /// Gets a map of names of the IP configurations of network interfaces assigned to this backend,
        /// indexed by their NIC's resource id.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Network.Fluent.IHasBackendNics.BackendNicIpConfigurationNames
        {
            get
            {
                return this.BackendNicIpConfigurationNames() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Checks whether the specified FQDN is referenced by this backend address pool.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>True if the specified FQDN is referenced by this backend, else false.</return>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend.ContainsFqdn(string fqdn)
        {
            return this.ContainsFqdn(fqdn);
        }

        /// <summary>
        /// Gets addresses on the backend of the application gateway, indexed by their FQDN.
        /// </summary>
        System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend.Addresses
        {
            get
            {
                return this.Addresses() as System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress>;
            }
        }

        /// <summary>
        /// Checks whether the specified IP address is referenced by this backend address pool.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>True if the specified IP address is referenced by this backend, else false.</return>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend.ContainsIpAddress(string ipAddress)
        {
            return this.ContainsIpAddress(ipAddress);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithCreate;
        }
    }
}