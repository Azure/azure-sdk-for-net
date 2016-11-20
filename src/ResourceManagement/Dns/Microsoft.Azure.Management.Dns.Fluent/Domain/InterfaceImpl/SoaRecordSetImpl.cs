// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    internal partial class SoaRecordSetImpl 
    {
        /// <return>The Soa record in this record set.</return>
        SoaRecord ISoaRecordSet.Record
        {
            get
            {
                return this.Record() as SoaRecord;
            }
        }
    }
}