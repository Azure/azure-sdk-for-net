// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> CVE analysis result resource. </summary>
    public partial class CveResult
    {
        /// <summary> Name of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NamePropertiesName
        {
            get => CveName;
            set => CveName = value;
        }
    }
}
