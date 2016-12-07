// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Dns.Fluent.Models;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    /// <summary>
    /// An immutable client-side representation of a Soa (start of authority) record set in Azure Dns Zone.
    /// </summary>
    public interface ISoaRecordSet  :
        IDnsRecordSet
    {
        /// <return>The Soa record in this record set.</return>
        SoaRecord Record { get; }
    }
}