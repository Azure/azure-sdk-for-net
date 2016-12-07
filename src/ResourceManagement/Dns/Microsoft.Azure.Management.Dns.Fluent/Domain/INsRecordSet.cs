// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Ns (name server) record set in Azure Dns Zone.
    /// </summary>
    public interface INsRecordSet  :
        IDnsRecordSet
    {
        /// <return>The name server names of Ns (name server) records in this record set.</return>
        System.Collections.Generic.IList<string> NameServers { get; }
    }
}