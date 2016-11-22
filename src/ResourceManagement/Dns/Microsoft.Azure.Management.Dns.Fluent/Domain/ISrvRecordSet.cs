// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a Srv (service) record set in Azure Dns Zone.
    /// </summary>
    public interface ISrvRecordSet  :
        IDnsRecordSet
    {
        /// <return>The Srv records in this record set.</return>
        System.Collections.Generic.IList<SrvRecord> Records { get; }
    }
}