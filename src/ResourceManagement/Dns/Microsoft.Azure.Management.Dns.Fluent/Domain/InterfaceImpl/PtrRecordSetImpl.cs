// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    internal partial class PtrRecordSetImpl 
    {
        /// <summary>
        /// Gets the target domain names of PTR records in this record set.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Dns.Fluent.IPtrRecordSet.TargetDomainNames
        {
            get
            {
                return this.TargetDomainNames() as System.Collections.Generic.IList<string>;
            }
        }
    }
}