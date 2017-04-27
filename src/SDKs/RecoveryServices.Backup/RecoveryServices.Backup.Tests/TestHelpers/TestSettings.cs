// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class TestSettings
    {
        public string ResourceGroupName { get; set; }

        public string VirtualMachineName { get; set; }

        public string VirtualMachineResourceGroupName { get; set; }

        public string VirtualMachineType { get; set; }

        public string RestoreStorageAccountName { get; set; }

        public string RestoreStorageAccountResourceGroupName { get; set; }

        public TestSettings Initialize()
        {
            string content = File.ReadAllText(@"TestSettings.json");
            JObject jObject = JObject.Parse(content);
            var testSettings = JsonConvert.DeserializeObject<TestSettings>(jObject.ToString());

            ResourceGroupName = testSettings.ResourceGroupName;
            VirtualMachineName = testSettings.VirtualMachineName;
            VirtualMachineResourceGroupName = testSettings.VirtualMachineResourceGroupName;
            VirtualMachineType = testSettings.VirtualMachineType;
            RestoreStorageAccountName = testSettings.RestoreStorageAccountName;
            RestoreStorageAccountResourceGroupName = testSettings.RestoreStorageAccountResourceGroupName;
            return this;
        }

        public static TestSettings Instance = new TestSettings().Initialize();

        public void Commit()
        {
            string testSettingsJson = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(@"TestSettings.json", testSettingsJson);
        }
    }
}
