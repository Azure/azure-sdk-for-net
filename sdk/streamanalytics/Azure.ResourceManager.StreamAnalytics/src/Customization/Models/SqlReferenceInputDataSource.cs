// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary> Describes an Azure SQL database reference input data source. </summary>
    public partial class SqlReferenceInputDataSource : ReferenceInputDataSource
    {
        /// <summary> This element is associated with the datasource element. This indicates how frequently the data will be fetched from the database. It is of DateTime format. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use RefreshInterval instead.", false)]
        public DateTimeOffset? RefreshRate { get; set; }
    }
}
