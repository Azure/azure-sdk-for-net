// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class AaaaRecordSetImpl 
    {
        /// <return>The IPv6 addresses of Aaaa records in this record set.</return>
        System.Collections.Generic.IList<string> IAaaaRecordSet.Ipv6Addresses
        {
            get
            {
                return this.Ipv6Addresses() as System.Collections.Generic.IList<string>;
            }
        }
    }
}