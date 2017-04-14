// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a TXT (text) record set in Azure DNS Zone.
    /// </summary>
    public interface ITxtRecordSet  :
        Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet
    {
        /// <summary>
        /// Gets the TXT records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.TxtRecord> Records { get; }
    }
}