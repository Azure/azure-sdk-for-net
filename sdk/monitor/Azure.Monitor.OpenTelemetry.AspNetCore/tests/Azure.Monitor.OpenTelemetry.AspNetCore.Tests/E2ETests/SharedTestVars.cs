// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    public static class SharedTestVars
    {
        public const string TestServiceName = nameof(TestServiceName);
        public const string TestServiceNamespace = nameof(TestServiceNamespace);
        public const string TestServiceInstance = nameof(TestServiceInstance);
        public const string TestServiceVersion = nameof(TestServiceVersion);
        public const string TestRoleName = $"[{TestServiceNamespace}]/{TestServiceName}";

        public static Dictionary<string, object> TestResourceAttributes => _testResourceAttributes;

        private static readonly Dictionary<string, object> _testResourceAttributes = new()
        {
            { "service.name", TestServiceName },
            { "service.namespace", TestServiceNamespace },
            { "service.instance.id", TestServiceInstance },
            { "service.version", TestServiceVersion }
        };
    }
}
