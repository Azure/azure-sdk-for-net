// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to SRV record sets in a DNS zone.
    /// </summary>
    public interface ISrvRecordSets  :
        ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.ISrvRecordSet>,
        ISupportsGettingByName<Microsoft.Azure.Management.Dns.Fluent.ISrvRecordSet>
    {
    }
}