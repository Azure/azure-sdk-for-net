// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.ResourceManager.Redis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests.SerializationTests
{
    public class RedisCommonConfigurationSerializationTests
    {
        [TestCase("{ \"aof-backup-enabled\": true, \"rdb-backup-enabled\": true }")]
        [TestCase("{ \"aof-backup-enabled\": \"true\", \"rdb-backup-enabled\": \"true\" }")]
        public void DeserializeIsAofBackupEnabledAndIsRdbBackupEnabledTest(string rawJson)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(rawJson);

            RedisCommonConfiguration redisCommonConfiguration = RedisCommonConfiguration.DeserializeRedisCommonConfiguration(jsonDocument.RootElement);

            Assert.IsTrue(redisCommonConfiguration.IsAofBackupEnabled);
            Assert.IsTrue(redisCommonConfiguration.IsRdbBackupEnabled);
        }
    }
}
