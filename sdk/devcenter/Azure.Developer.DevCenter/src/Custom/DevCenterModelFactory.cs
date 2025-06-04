// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.DevCenter.Models
{
    [CodeGenClient("DeveloperDevCenterModelFactory")]
    public static partial class DevCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DevBoxStorageProfile"/>. </summary>
        /// <param name="osDisk"> Settings for the operating system disk. </param>
        /// <returns> A new <see cref="Models.DevBoxStorageProfile"/> instance for mocking. </returns>
        public static DevBoxStorageProfile DevBoxStorageProfile(OSDisk osDisk = null)
        {
            return new DevBoxStorageProfile(osDisk, serializedAdditionalRawData: null);
        }
    }
}
