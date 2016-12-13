// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a Ptr (pointer) record set in Azure Dns Zone.
    /// </summary>
    public interface IPtrRecordSet  :
        IDnsRecordSet
    {
        /// <summary>
        /// Gets the target domain names of Ptr records in this record set.
        /// </summary>
        System.Collections.Generic.IList<string> TargetDomainNames { get; }
    }
}