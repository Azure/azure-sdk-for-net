// -----------------------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
#if WINDOWS_PHONE
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
    using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

    using Microsoft.WindowsAzure.Storage.Auth;
    using System.Xml.Linq;

    [TestClass]
    public partial class TestBase
    {
#if !WINDOWS_PHONE
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            OperationContext.DefaultLogLevel = LogLevel.Off;
        }
#endif

        static TestBase()
        {
            XElement element = XElement.Load(TestConfigurations.DefaultTestConfigFilePath);
            TestConfigurations = TestConfigurations.ReadFromXml(element);

            foreach (TenantConfiguration tenant in TestConfigurations.TenantConfigurations)
            {
                if (tenant.TenantName == TestConfigurations.TargetTenantName)
                {
                    TargetTenantConfig = tenant;
                    break;
                }
            }

            StorageCredentials = new StorageCredentials(TargetTenantConfig.AccountName,
                TargetTenantConfig.AccountKey);

            CurrentTenantType = TargetTenantConfig.TenantType;
        }
    }
}
