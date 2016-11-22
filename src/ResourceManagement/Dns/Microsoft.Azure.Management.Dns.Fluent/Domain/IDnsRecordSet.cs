// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a record set in Azure Dns Zone.
    /// </summary>
    public interface IDnsRecordSet  :
        IExternalChildResource<IDnsRecordSet,IDnsZone>,
        IWrapper<RecordSetInner>
    {
        /// <return>TTL of the records in this record set.</return>
        long TimeToLive { get; }

        /// <return>The metadata associated with this record set.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Metadata { get; }

        /// <return>The type of records in this record set.</return>
        RecordType RecordType { get; }
    }
}