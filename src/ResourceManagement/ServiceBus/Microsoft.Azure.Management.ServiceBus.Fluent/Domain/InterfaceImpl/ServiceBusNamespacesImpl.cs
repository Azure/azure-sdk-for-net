// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition;
    using Microsoft.Rest;

    internal partial class ServiceBusNamespacesImpl 
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
        ServiceBusNamespace.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ServiceBusNamespace.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as ServiceBusNamespace.Definition.IBlank;
        }

        /// <summary>
        /// Checks if namespace name is valid and is not in use.
        /// </summary>
        /// <param name="name">The account name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespaces.CheckNameAvailability(string name)
        {
            return this.CheckNameAvailability(name) as Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult;
        }

        /// <summary>
        /// Checks if namespace name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The namespace name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        async Task<Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult> Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespaces.CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken)
        {
            return await this.CheckNameAvailabilityAsync(name, cancellationToken) as Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult;
        }
    }
}