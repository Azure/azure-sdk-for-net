// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;

    internal partial class SoaRecordSetImpl 
    {
        /// <summary>
        /// Gets the SOA record in this record set.
        /// </summary>
        Models.SoaRecord Microsoft.Azure.Management.Dns.Fluent.ISoaRecordSet.Record
        {
            get
            {
                return this.Record() as Models.SoaRecord;
            }
        }
    }
}