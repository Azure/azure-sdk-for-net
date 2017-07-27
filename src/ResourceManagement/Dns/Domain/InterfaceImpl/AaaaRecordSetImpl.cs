// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;

    internal partial class AaaaRecordSetImpl 
    {
        /// <summary>
        /// Gets the IPv6 addresses of AAAA records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet.IPv6Addresses
        {
            get
            {
                return this.IPv6Addresses() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }
    }
}