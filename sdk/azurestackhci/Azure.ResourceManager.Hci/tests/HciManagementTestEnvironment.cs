// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class HciManagementTestEnvironment : TestEnvironment
    {
        public string CustomLocationId => GetRecordedVariable("CUSTOM_LOCATION_ID");
        public string MachineName => GetRecordedVariable("HC_MACHINE_NAME");
        public string MachineNameAsync => GetRecordedVariable("HC_MACHINE_NAME_ASYNC");
        public string ImagePath => GetRecordedVariable("IMAGE_PATH");
        public string StoragePath => GetRecordedVariable("STORAGE_PATH");
        public string VmUsername => GetRecordedVariable("VM_USERNAME");
        public string VmPass => GetRecordedVariable("VM_PASS");
    }
}
