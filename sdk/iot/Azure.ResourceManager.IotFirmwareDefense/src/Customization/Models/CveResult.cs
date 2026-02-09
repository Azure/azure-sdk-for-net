// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> CVE analysis result resource. </summary>
    public partial class CveResult
    {
        ///// <summary> ID of the CVE result. </summary>
        //public string CveId { get; set; }
        /// <summary> The SBOM component for the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CveComponent Component {
            get
            {
                var r = new CveComponent();
                r.ComponentId = ComponentId;
                r.Name = ComponentName;
                r.Version = ComponentVersion;
                return r;
            }
            set
            {
                ComponentId = value.ComponentId;
                ComponentName = value.Name;
                ComponentVersion = value.Version;
            }
        }
        ///// <summary> Severity of the CVE. </summary>
        //public string Severity { get; set; }
        /// <summary> Name of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NamePropertiesName
        {
            get => CveName;
            set => CveName = value;
        }
    }
}
