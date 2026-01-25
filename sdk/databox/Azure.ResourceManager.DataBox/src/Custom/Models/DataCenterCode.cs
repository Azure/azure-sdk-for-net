// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> DataCenter code. </summary>
    public readonly partial struct DataCenterCode : IEquatable<DataCenterCode>
    {
        /// <summary> IDC5. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataCenterCode IdC5 { get; } = new DataCenterCode(IDC5Value);
    }
}
