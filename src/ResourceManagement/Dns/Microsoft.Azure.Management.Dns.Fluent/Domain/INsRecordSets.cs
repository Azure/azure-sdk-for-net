// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to NS record sets in a DNS zone.
    /// </summary>
    public interface INSRecordSets  :
        ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.INSRecordSet>,
        ISupportsGettingByName<Microsoft.Azure.Management.Dns.Fluent.INSRecordSet>
    {
    }
}