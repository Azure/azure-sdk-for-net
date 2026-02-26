// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The new generated code removed the parameterless constructor
// (the model now requires parameters). This restores the public parameterless constructor
// so existing callers that create MsixPackageData via `new MsixPackageData()` are not broken.

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class MsixPackageData
    {
        /// <summary> Initializes a new instance of <see cref="MsixPackageData"/>. </summary>
        public MsixPackageData()
        {
        }
    }
}
