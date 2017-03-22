// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to AAAA record sets in a DNS zone.
    /// </summary>
    public interface IAaaaRecordSets  :
        ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet>,
        ISupportsGettingByName<Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet>,
        IHasParent<IDnsZone>
    {
    }
}