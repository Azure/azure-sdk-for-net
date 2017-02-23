// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    internal partial class CNameRecordSetImpl 
    {
        /// <summary>
        /// Gets the canonical name (without a terminating dot) of CName record in this record set.
        /// </summary>
        string Microsoft.Azure.Management.Dns.Fluent.ICNameRecordSet.CanonicalName
        {
            get
            {
                return this.CanonicalName();
            }
        }
    }
}