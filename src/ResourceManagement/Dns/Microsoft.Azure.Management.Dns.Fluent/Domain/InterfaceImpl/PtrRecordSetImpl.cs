// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class PtrRecordSetImpl 
    {
        /// <return>The target domain names of Ptr records in this record set.</return>
        System.Collections.Generic.IList<string> IPtrRecordSet.TargetDomainNames
        {
            get
            {
                return this.TargetDomainNames() as System.Collections.Generic.IList<string>;
            }
        }
    }
}