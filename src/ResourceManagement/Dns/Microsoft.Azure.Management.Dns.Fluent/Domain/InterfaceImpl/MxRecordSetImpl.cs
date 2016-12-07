// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System.Collections.Generic;

    internal partial class MxRecordSetImpl 
    {
        /// <return>The Mx records in this record set.</return>
        System.Collections.Generic.IList<MxRecord> IMxRecordSet.Records
        {
            get
            {
                return this.Records() as System.Collections.Generic.IList<MxRecord>;
            }
        }
    }
}