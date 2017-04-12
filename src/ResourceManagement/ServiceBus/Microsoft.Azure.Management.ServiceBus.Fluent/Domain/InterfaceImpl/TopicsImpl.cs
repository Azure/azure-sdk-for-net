// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using ServiceBus.Fluent;

    internal partial class TopicsImpl 
    {
        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName.DeleteByNameAsync(string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByNameAsync(name, cancellationToken);
        }

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
        Topic.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Topic.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Topic.Definition.IBlank;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        IServiceBusManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<IServiceBusManager>.Manager
        {
            get
            {
                return this.Manager as IServiceBusManager;
            }
        }
    }
}