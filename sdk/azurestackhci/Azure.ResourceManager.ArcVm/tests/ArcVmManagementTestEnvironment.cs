// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ArcVm.Tests
{
    public class ArcVmManagementTestEnvironment : TestEnvironment
    {
        public string CustomLocationId => GetRecordedVariable("CUSTOM_LOCATION_ID", options => options.IsSecret());
        public string MachineName => GetRecordedVariable("HC_MACHINE_NAME");
        public string MachineNameAsync => GetRecordedVariable("HC_MACHINE_NAME_ASYNC");
        public string ImagePath => GetRecordedVariable("IMAGE_PATH", options => options.IsSecret());
        public string StoragePath => GetRecordedVariable("STORAGE_PATH", options => options.IsSecret());
        public string VmUsername => GetRecordedVariable("VM_USERNAME", options => options.IsSecret());
        public string VmPass => GetRecordedVariable("VM_PASS", options => options.IsSecret());
    }
}
