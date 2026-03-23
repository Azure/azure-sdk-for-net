// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// ApiCompat: restore public constructor with name parameter (CannotSealType + MembersMustExist)
namespace Azure.ResourceManager.DevCenter.Models
{
    public partial class DevCenterSkuDetails
    {
        /// <summary> Initializes a new instance of <see cref="DevCenterSkuDetails"/>. </summary>
        /// <param name="name"> The SKU name. </param>
        public DevCenterSkuDetails(string name)
        {
        }
    }
}
