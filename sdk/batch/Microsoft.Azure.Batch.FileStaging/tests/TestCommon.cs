// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Batch.FileStaging.Tests
{
    using System;

    public static class TestCommon
    {
        public class TestConfiguration
        {
            public const string BatchAccountKeyEnvironmentSettingName = "MABOM_BatchAccountKey";

            public const string BatchAccountNameEnvironmentSettingName = "MABOM_BatchAccountName";

            public const string BatchAccountUrlEnvironmentSettingName = "MABOM_BatchAccountEndpoint";

            public const string StorageAccountKeyEnvironmentSettingName = "MABOM_StorageKey";

            public const string StorageAccountNameEnvironmentSettingName = "MABOM_StorageAccount";

            public const string StorageAccountBlobEndpointEnvironmentSettingName = "MABOM_BlobEndpoint";

            public readonly string BatchAccountKey = GetEnvironmentVariableOrThrow(BatchAccountKeyEnvironmentSettingName);

            public readonly string BatchAccountName = GetEnvironmentVariableOrThrow(BatchAccountNameEnvironmentSettingName);

            public readonly string BatchAccountUrl = GetEnvironmentVariableOrThrow(BatchAccountUrlEnvironmentSettingName);

            public readonly string StorageAccountKey = GetEnvironmentVariableOrThrow(StorageAccountKeyEnvironmentSettingName);

            public readonly string StorageAccountName = GetEnvironmentVariableOrThrow(StorageAccountNameEnvironmentSettingName);

            public readonly string StorageAccountBlobEndpoint = GetEnvironmentVariableOrThrow(StorageAccountBlobEndpointEnvironmentSettingName);

            private static string GetEnvironmentVariableOrThrow(string environmentSettingName)
            {
                string result = Environment.GetEnvironmentVariable(environmentSettingName);
                if (string.IsNullOrEmpty(result))
                {
                    throw new ArgumentException(string.Format("Missing required environment variable {0}", environmentSettingName));
                }

                return result;
            }

        }

        private static readonly Lazy<TestConfiguration> configurationInstance = new Lazy<TestConfiguration>(() => new TestConfiguration());

        public static TestConfiguration Configuration
        {
            get { return configurationInstance.Value; }
        }
    }
}