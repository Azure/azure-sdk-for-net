// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class AaaaRecordSetImpl 
    {
        /// <summary>
        /// Gets the IPv6 addresses of Aaaa records in this record set.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet.Ipv6Addresses
        {
            get
            {
                return this.Ipv6Addresses() as System.Collections.Generic.IList<string>;
            }
        }
    }
}