// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Diagnostics;

namespace Management.HDInsight.Tests
{
    public class TestConfigurationManager
    {
        private const string AppSettingSection = "AppSettings";

        /// <summary />
        private static readonly Lazy<TestConfigurationManager> instance = new Lazy<TestConfigurationManager>(() => GetDefaultInstance());

        /// <summary />
        internal static TestConfigurationManager Instance => instance.Value;

        /// <summary />
        internal const string FakeConfigFileName = "fakesettings.json";

        /// <summary>
        /// Some test requires some real Azure resouces to run in record mode.
        /// Those configurations will be stored in this file.
        /// </summary>
        internal const string RealConfigFileName = "realsettings.json";

        /// <summary />
        internal string ConfigFileName { get; set; }

        /// <summary />
        internal AppSettings AppSettings { get; set; }

        private TestConfigurationManager()
        {
        }

        private static TestConfigurationManager GetDefaultInstance()
        {
            var instance = new TestConfigurationManager();
            string configFileName;
            if (HDInsightManagementTestUtilities.IsRecordMode())
            {
                if (File.Exists(RealConfigFileName))
                {
                    configFileName = RealConfigFileName;
                }
                else
                {
                    Debug.WriteLine("Need a " + RealConfigFileName + " file to run all test cases in Record mode.");
                    Debug.WriteLine("Use " + FakeConfigFileName + " file instead. Some test cases will be skipped.");
                    configFileName = FakeConfigFileName;
                }
            }
            else
            {
                configFileName = FakeConfigFileName;
            }

            return new TestConfigurationManager
            {
                ConfigFileName = configFileName,
                AppSettings = GetAppSettings(configFileName)
            };
        }

        private static AppSettings GetAppSettings(string configFile)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile(configFile).Build();
            var appSettings = new AppSettings();
            config.GetSection(AppSettingSection).Bind(appSettings);

            return appSettings;
        }
    }

    public class AppSettings
    {
        public string DataLakeStoreAccountName { get; set; }

        public string DataLakeClientId { get; set; }
    }
}
