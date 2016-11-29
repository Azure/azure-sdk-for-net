// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMxRecordSet
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update;

    /// <summary>
    /// The entirety of a Mx record set update as a part of parent Dns zone update.
    /// </summary>
    public interface IUpdateMxRecordSet  :
        IWithMxRecordMailExchange,
        IUpdate
    {
    }
}