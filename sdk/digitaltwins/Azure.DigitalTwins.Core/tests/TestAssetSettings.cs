// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// These are the settings that will be used by the end-to-end tests tests.
    /// The json files configured in the config will load the settings specific to a user.
    /// </summary>
    public class TestAssetSettings
    {
        public static TestAssetSettings Instance { get; private set; }

        /// <summary>
        /// Default Floor Twin Id prefix.
        /// </summary>
        public const string FloorTwinIdPrefix = "floorTwin";

        /// <summary>
        /// Default Room Twin Id prefix.
        /// </summary>
        public const string RoomTwinIdPrefix = "roomTwin";

        /// <summary>
        /// Default Hvac Twin Id prefix.
        /// </summary>
        public const string HvacTwinIdPrefix = "hvacTwin";

        /// <summary>
        /// Default Room with Wifi Twin Id prefix.
        /// </summary>
        public const string RoomWithWifiTwinIdPrefix = "roomWithWifiTwin";

        /// <summary>
        /// Default Wifi model Id prefix.
        /// </summary>
        public const string WifiModelIdPrefix = "dtmi:example:wifi;1";

        /// <summary>
        /// Default Room model Id prefix.
        /// </summary>
        public const string RoomModelIdPrefix = "dtmi:example:room;1";

        /// <summary>
        /// Default Floor model Id prefix.
        /// </summary>
        public const string FloorModelIdPrefix = "dtmi:example:floor;1";

        /// <summary>
        /// Default Hvac model Id prefix.
        /// </summary>
        public const string HvacModelIdPrefix = "dtmi:example:hvac;1";

        /// <summary>
        /// Default Room with Wifi model Id prefix.
        /// </summary>
        public const string RoomWithWifiModelIdPrefix = "dtmi:example:wifiroom;1";

        /// <summary>
        /// Default Floor Model Id.
        /// </summary>
        public string FloorModelId { get; set; }

        /// <summary>
        /// Default Room Model Id.
        /// </summary>
        public string RoomModelId { get; set; }

        /// <summary>
        /// Default Hvac Model Id.
        /// </summary>
        public string HvacModelId { get; set; }

        /// <summary>
        /// Default Building Model Id.
        /// </summary>
        public string BuildingModelId { get; set; }

        /// <summary>
        /// Default Ward Model Id.
        /// </summary>
        public string WardModelId { get; set; }

        static TestAssetSettings()
        {
            if (Instance != null)
            {
                return;
            }

            // Initialize the settings related to test assets - Models and IDs
            var testsAssetSettingsConfigBuilder = new ConfigurationBuilder();

            string testAssetSettingsCommonPath = Path.Combine(
                TestSettings.Instance.WorkingDirectory,
                "config",
                "common.test.assets.config.json");
            testsAssetSettingsConfigBuilder.AddJsonFile(testAssetSettingsCommonPath);

            string testAssetSettingsUserPath = Path.Combine(
                TestSettings.Instance.WorkingDirectory,
                "config",
                $"{Environment.UserName}.test.assets.config.json");
            if (File.Exists(testAssetSettingsUserPath))
            {
                testsAssetSettingsConfigBuilder.AddJsonFile(testAssetSettingsUserPath);
            }

            IConfiguration config = testsAssetSettingsConfigBuilder.Build();

            Instance = config.Get<TestAssetSettings>();
        }
    }
}
