//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class TestSettingsSchema
    {
        public string VirtualMachineName { get; set; }

        public string VirtualMachineResourceGroupName { get; set; }

        public string VirtualMachineType { get; set; }

        public string RestoreStorageAccountName { get; set; }

        public string RestoreStorageAccountResourceGroupName { get; set; }
    }

    public class TestSettings
    {
        public const string _VirtualMachineName = "VirtualMachineName";
        public const string _VirtualMachineResourceGroupName = "VirtualMachineResourceGroupName";
        public const string _VirtualMachineType = "VirtualMachineType";
        public const string _RestoreStorageAccountName = "RestoreStorageAccountName";
        public const string _RestoreStorageAccountResourceGroupName = "RestoreStorageAccountResourceGroupName";

        public string VirtualMachineName { get; set; }

        public string VirtualMachineResourceGroupName { get; set; }

        public string VirtualMachineType { get; set; }

        public string RestoreStorageAccountName { get; set; }

        public string RestoreStorageAccountResourceGroupName { get; set; }

        public TestSettings()
        {
            var content = File.ReadAllText(@"TestSettings.json");
            JObject jObject = JObject.Parse(content);
            var testSettings = JsonConvert.DeserializeObject<TestSettingsSchema>(jObject.ToString());

            VirtualMachineName = testSettings.VirtualMachineName;
            VirtualMachineResourceGroupName = testSettings.VirtualMachineResourceGroupName;
            VirtualMachineType = testSettings.VirtualMachineType;
            RestoreStorageAccountName = testSettings.RestoreStorageAccountName;
            RestoreStorageAccountResourceGroupName = testSettings.RestoreStorageAccountResourceGroupName;
        }

        public static TestSettings Instance = new TestSettings();
    }
}
