// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class MxRecordSetsImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<IMxRecordSet> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListing<IMxRecordSet>.List()
        {
            return this.List() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<IMxRecordSet>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        IMxRecordSet Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsGettingByName<IMxRecordSet>.GetByName(string name)
        {
            return this.GetByName(name) as IMxRecordSet;
        }
    }
}