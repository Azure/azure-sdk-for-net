// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a record set in Azure DNS Zone.
    /// </summary>
    public interface IDnsRecordSet  :
        IExternalChildResource<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet,Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        IHasInner<RecordSetInner>
    {
        /// <summary>
        /// Gets TTL of the records in this record set.
        /// </summary>
        long TimeToLive { get; }

        /// <summary>
        /// Gets the metadata associated with this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Metadata { get; }

        /// <summary>
        /// Gets the type of records in this record set.
        /// </summary>
        RecordType RecordType { get; }
    }
}