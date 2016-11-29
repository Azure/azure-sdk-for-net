// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to Soa record sets in a Dns zone.
    /// </summary>
    public interface ISoaRecordSets  :
        ISupportsListing<ISoaRecordSet>,
        ISupportsGettingById<ISoaRecordSet>
    {
    }
}