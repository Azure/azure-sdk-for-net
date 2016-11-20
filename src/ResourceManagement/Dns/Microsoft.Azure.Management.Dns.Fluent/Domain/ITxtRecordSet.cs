// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a Txt (text) record set in Azure Dns Zone.
    /// </summary>
    public interface ITxtRecordSet  :
        IDnsRecordSet
    {
        /// <return>The Txt records in this record set.</return>
        System.Collections.Generic.IList<TxtRecord> Records { get; }
    }
}