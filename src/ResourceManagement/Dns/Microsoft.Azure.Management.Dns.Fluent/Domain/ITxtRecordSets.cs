// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Resource.Fluent.Core;

    /// <summary>
    /// Entry point to TXT record sets in a DNS zone.
    /// </summary>
    public interface ITxtRecordSets  :
        ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSet>,
        ISupportsGettingByName<Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSet>,
        IHasParent<IDnsZone>
    {
    }
}