// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update;

    /// <summary>
    /// The entirety of an AAAA record set update as a part of parent DNS zone update.
    /// </summary>
    public interface IUpdateAaaaRecordSet  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithAaaaRecordIPv6Address,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate
    {
    }
}