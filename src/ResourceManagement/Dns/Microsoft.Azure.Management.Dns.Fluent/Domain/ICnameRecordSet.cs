// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    /// <summary>
    /// An immutable client-side representation of a CName (canonical name) record set in Azure Dns Zone.
    /// </summary>
    public interface ICnameRecordSet  :
        IDnsRecordSet
    {
        /// <return>The canonical name (without a terminating dot) of CName record in this record set.</return>
        string CanonicalName { get; }
    }
}