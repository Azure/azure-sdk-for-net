//
// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Configuration;
using Microsoft.Azure;
using Xunit;
namespace Microsoft.WindowsAzure.Configuration.Test
{
    public class CloudConfigurationManagerTest
    {
        [Fact]
        public void TestGetSettingWithNonExistingSettings()
        {
            string key = "my settings";

            string actual = CloudConfigurationManager.GetSetting(key);

            Assert.Null(actual);
        }

        [Fact]
        public void TestGetSettingWithNullParamThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                string actual = CloudConfigurationManager.GetSetting(null);
            });
        }

        [Fact]
        public void TestGetSettingWithEmptyStringThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string actual = CloudConfigurationManager.GetSetting("");
            });
        }

        [Fact]
        public void TestGetSettingOverloadThatRequiresGettingSettingFromServiceRuntimeWithNonExistingSettingThrowsException()
        {
            Assert.Throws<SettingsPropertyNotFoundException>(() =>
                {
                    string actual = CloudConfigurationManager
                        .GetSetting(
                            name: "notExistingSettingName",
                            outputResultsToTrace: true,
                            throwIfNotFoundInRuntime: true);
                }
            );           
        }
    }
}
