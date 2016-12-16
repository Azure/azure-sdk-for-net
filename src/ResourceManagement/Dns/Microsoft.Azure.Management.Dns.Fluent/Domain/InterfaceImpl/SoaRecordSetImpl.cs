// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Dns.Fluent.Models;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    internal partial class SoaRecordSetImpl 
    {
        /// <summary>
        /// Gets the Soa record in this record set.
        /// </summary>
        SoaRecord Microsoft.Azure.Management.Dns.Fluent.ISoaRecordSet.Record
        {
            get
            {
                return this.Record() as SoaRecord;
            }
        }
    }
}