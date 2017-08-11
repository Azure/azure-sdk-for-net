// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;

    internal partial class ApplicationGatewaysImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        ApplicationGateway.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ApplicationGateway.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as ApplicationGateway.Definition.IBlank;
        }

        /// <summary>
        /// Starts the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An emitter of the resource ID for each successfully started application gateway.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.StartAsync(string[] ids, CancellationToken cancellationToken)
        {
            return await this.StartAsync(ids, cancellationToken) as System.Collections.Generic.IEnumerable<string>;
        }

        /// <summary>
        /// Starts the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An emitter of the resource ID for each successfully started application gateway.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.StartAsync(ICollection<string> ids, CancellationToken cancellationToken)
        {
            return await this.StartAsync(ids, cancellationToken) as System.Collections.Generic.IEnumerable<string>;
        }

        /// <summary>
        /// Stops the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.Stop(params string[] ids)
        {
 
            this.Stop(ids);
        }

        /// <summary>
        /// Stops the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.Stop(ICollection<string> ids)
        {
 
            this.Stop(ids);
        }

        /// <summary>
        /// Stops the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        /// <return>An emitter of the resource ID for each successfully stopped application gateway.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.StopAsync(string[] ids, CancellationToken cancellationToken)
        {
            return await this.StopAsync(ids, cancellationToken) as System.Collections.Generic.IEnumerable<string>;
        }

        /// <summary>
        /// Stops the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An emitter of the resource ID for each successfully stopped application gateway.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.StopAsync(ICollection<string> ids, CancellationToken cancellationToken)
        {
            return await this.StopAsync(ids, cancellationToken) as System.Collections.Generic.IEnumerable<string>;
        }

        /// <summary>
        /// Starts the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.Start(params string[] ids)
        {
 
            this.Start(ids);
        }

        /// <summary>
        /// Starts the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Microsoft.Azure.Management.Network.Fluent.IApplicationGateways.Start(ICollection<string> ids)
        {
 
            this.Start(ids);
        }
    }
}