// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a A (IPv4) record set in Azure DNS Zone.
    /// </summary>
    public interface IARecordSet  :
        Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet
    {
        /// <summary>
        /// Gets the IP v4 addresses of A records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> IPv4Addresses { get; }
    }
}