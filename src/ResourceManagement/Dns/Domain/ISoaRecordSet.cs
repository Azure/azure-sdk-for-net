// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of a SOA (start of authority) record set in Azure DNS Zone.
    /// </summary>
    public interface ISoaRecordSet  :
        Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet
    {
        /// <summary>
        /// Gets the SOA record in this record set.
        /// </summary>
        Models.SoaRecord Record { get; }
    }
}