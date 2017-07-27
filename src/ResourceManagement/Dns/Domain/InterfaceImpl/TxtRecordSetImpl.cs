// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using System.Collections.Generic;

    internal partial class TxtRecordSetImpl 
    {
        /// <summary>
        /// Gets the TXT records in this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.TxtRecord> Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSet.Records
        {
            get
            {
                return this.Records() as System.Collections.Generic.IReadOnlyList<Models.TxtRecord>;
            }
        }
    }
}