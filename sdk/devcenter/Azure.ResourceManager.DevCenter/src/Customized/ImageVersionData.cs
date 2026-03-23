// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.DevCenter
{
    /// <summary>
    /// Backward compatibility: the baseline SDK had a public parameterless constructor.
    /// The new generator seals it or removes it, causing CannotSealType and MembersMustExist
    /// ApiCompat errors. This partial class restores the public parameterless constructor.
    /// </summary>
    public partial class ImageVersionData
    {
        /// <summary> Initializes a new instance of <see cref="ImageVersionData"/>. </summary>
        public ImageVersionData()
        {
        }
    }
}
