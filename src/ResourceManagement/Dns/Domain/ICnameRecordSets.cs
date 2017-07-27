// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    /// <summary>
    /// Entry point to CNAME record sets in a DNS zone.
    /// </summary>
    public interface ICNameRecordSets  :
        Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSets<Microsoft.Azure.Management.Dns.Fluent.ICNameRecordSet>
    {
    }
}