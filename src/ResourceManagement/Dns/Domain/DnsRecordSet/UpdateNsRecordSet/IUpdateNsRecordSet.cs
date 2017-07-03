// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update;

    /// <summary>
    /// The entirety of a NS record set update as a part of parent DNS zone update.
    /// </summary>
    public interface IUpdateNSRecordSet  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithNSRecordNameServer,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate
    {
    }
}