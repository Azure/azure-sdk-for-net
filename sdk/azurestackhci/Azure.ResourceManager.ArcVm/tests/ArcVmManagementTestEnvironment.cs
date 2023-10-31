// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ArcVm.Tests
{
    public class ArcVmManagementTestEnvironment : TestEnvironment
    {
        public string CustomLocationId => GetVariable("CUSTOM_LOCATION_ID");
        public string ImagePath => GetVariable("IMAGE_PATH");
        public string StoragePath => GetVariable("STORAGE_PATH");
    }
}
