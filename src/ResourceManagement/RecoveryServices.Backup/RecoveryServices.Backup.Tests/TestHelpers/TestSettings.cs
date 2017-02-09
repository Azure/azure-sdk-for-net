// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
