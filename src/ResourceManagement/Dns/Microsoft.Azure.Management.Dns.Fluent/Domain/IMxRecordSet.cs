// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a MX (mail exchange) record set in Azure Dns Zone.
    /// </summary>
    public interface IMXRecordSet  :
        IDnsRecordSet
    {
        /// <summary>
        /// Gets the MX records in this record set.
        /// </summary>
        System.Collections.Generic.IList<MxRecord> Records { get; }
    }
}