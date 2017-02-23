// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class NSRecordSetImpl 
    {
        /// <summary>
        /// Gets the name server names of NS (name server) records in this record set.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Dns.Fluent.INSRecordSet.NameServers
        {
            get
            {
                return this.NameServers() as System.Collections.Generic.IList<string>;
            }
        }
    }
}