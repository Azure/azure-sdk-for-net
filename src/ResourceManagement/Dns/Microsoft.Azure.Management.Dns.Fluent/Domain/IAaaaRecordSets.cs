// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to Aaaa record sets in a Dns zone.
    /// </summary>
    public interface IAaaaRecordSets  :
        ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet>,
        ISupportsGettingByName<Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet>
    {
    }
}