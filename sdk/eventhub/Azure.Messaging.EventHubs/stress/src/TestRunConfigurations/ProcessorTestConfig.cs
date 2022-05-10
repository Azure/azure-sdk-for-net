// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class ProcessorTestConfig : TestConfig
    {
        private static string[] _roles = { "publisher", "processor" };
        public new List<string> Roles = new List<string>(_roles);

        public string StorageConnectionString = String.Empty;
        public string BlobContainer = String.Empty;
        public TimeSpan ReadTimeout = TimeSpan.FromMinutes(1);
    }
}