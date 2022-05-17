// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Configuration;
using Xunit;
namespace Microsoft.Azure.ConfigurationManager.Test
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
