// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class TxtRecordSetImpl 
    {
        /// <return>The Txt records in this record set.</return>
        System.Collections.Generic.IList<TxtRecord> ITxtRecordSet.Records
        {
            get
            {
                return this.Records() as System.Collections.Generic.IList<TxtRecord>;
            }
        }
    }
}