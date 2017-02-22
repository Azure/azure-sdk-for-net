// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class ARecordSetImpl 
    {
        /// <summary>
        /// Gets the Ipv4 addresses of A records in this record set.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Dns.Fluent.IARecordSet.IPv4Addresses
        {
            get
            {
                return this.Ipv4Addresses() as System.Collections.Generic.IList<string>;
            }
        }
    }
}