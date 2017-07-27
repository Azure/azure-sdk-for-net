// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;

    internal partial class ARecordSetImpl 
    {
        /// <summary>
        /// Gets the IP v4 addresses of A records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Dns.Fluent.IARecordSet.IPv4Addresses
        {
            get
            {
                return this.IPv4Addresses() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }
    }
}