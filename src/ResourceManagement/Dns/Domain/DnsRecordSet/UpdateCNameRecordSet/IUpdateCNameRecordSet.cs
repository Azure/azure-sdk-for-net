// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateCNameRecordSet
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update;

    /// <summary>
    /// The entirety of CNAME record set update as part of parent DNS zone update.
    /// </summary>
    public interface IUpdateCNameRecordSet  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithCNameRecordAlias,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate
    {
    }
}