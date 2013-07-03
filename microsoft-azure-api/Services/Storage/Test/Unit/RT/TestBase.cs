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

using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace Microsoft.WindowsAzure.Storage
{
    public partial class TestBase
    {
        static TestBase()
        {
            StorageFile xmlFile = Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(TestConfigurations.DefaultTestConfigFilePath).AsTask().Result;
            XmlDocument xmlDoc = XmlDocument.LoadFromFileAsync(xmlFile).AsTask().Result;

            XDocument doc = XDocument.Parse(xmlDoc.GetXml());
            TestConfigurations = TestConfigurations.ReadFromXml(doc);

            foreach (TenantConfiguration tenant in TestConfigurations.TenantConfigurations)
            {
                if (tenant.TenantName == TestConfigurations.TargetTenantName)
                {
                    TargetTenantConfig = tenant;
                    break;
                }
            }

            StorageCredentials = new StorageCredentials(TestBase.TargetTenantConfig.AccountName,
                TestBase.TargetTenantConfig.AccountKey);

            CurrentTenantType = TargetTenantConfig.TenantType;
        }
    }
}
