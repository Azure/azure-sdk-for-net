// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// ApiCompat: restore public parameterless constructor (CannotSealType + MembersMustExist)
namespace Azure.ResourceManager.DevCenter
{
    public partial class DevCenterImageData
    {
        /// <summary> Initializes a new instance of <see cref="DevCenterImageData"/>. </summary>
        public DevCenterImageData()
        {
        }
    }
}
