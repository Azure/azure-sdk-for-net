// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class ARecordSetImpl 
    {
        /// <return>The Ipv4 addresses of A records in this record set.</return>
        System.Collections.Generic.IList<string> IARecordSet.Ipv4Addresses
        {
            get
            {
                return this.Ipv4Addresses() as System.Collections.Generic.IList<string>;
            }
        }
    }
}