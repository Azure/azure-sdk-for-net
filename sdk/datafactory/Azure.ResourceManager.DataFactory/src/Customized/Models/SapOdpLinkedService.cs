// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> SAP ODP Linked Service. </summary>
    public partial class SapOdpLinkedService : DataFactoryLinkedServiceProperties
    {
        /// <summary> SNC activation indicator to access the SAP server where the table is located. Must be either 0 (off) or 1 (on). Type: string (or Expression with resultType string). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataFactoryElement<string> SncMode
        {
            get { return SncFlag.ToString(); }
            set { SncFlag = Boolean.Parse(value.ToString()); }
        }
    }
}
