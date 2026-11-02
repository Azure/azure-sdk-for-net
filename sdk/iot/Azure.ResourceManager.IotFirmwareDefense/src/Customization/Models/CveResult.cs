// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> CVE analysis result resource. </summary>
    [CodeGenSuppress("Component")]
    public partial class CveResult
    {
        /// <summary> The SBOM component for the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CveComponent Component
        {
            get
            {
                var component = new CveComponent();
                component.ComponentId = ComponentId;
                component.Name = ComponentName;
                component.Version = ComponentVersion;
                return component;
            }
            set
            {
                ComponentId = value.ComponentId;
                ComponentName = value.Name;
                ComponentVersion = value.Version;
            }
        }

        /// <summary> Name of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NamePropertiesName
        {
            get => CveName;
            set => CveName = value;
        }
    }
}
