// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    public partial class ExpandMsixImage
    {
        /// <summary> List of package dependencies. </summary>
        [WirePath("properties.packageDependencies")]
        public IList<MsixPackageDependencies> PackageDependencies
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new ExpandMsixImageProperties();
                }
                return Properties.PackageDependencies;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ExpandMsixImageProperties();
                }
                Properties.PackageDependencies.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        Properties.PackageDependencies.Add(item);
                    }
                }
            }
        }
    }
}
