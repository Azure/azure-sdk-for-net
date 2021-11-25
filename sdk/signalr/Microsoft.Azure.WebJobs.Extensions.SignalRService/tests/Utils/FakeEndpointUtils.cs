// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.SignalR.Tests.Common
{
    public static class FakeEndpointUtils
    {
        public const string FakeAccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static IEnumerable<string> GetFakeConnectionString(int count)
        {
            return Enumerable.Range(StaticRandom.Next(0, 9999), count).Select(i => $"Endpoint=http://localhost{i};AccessKey={FakeAccessKey};Version=1.0;");
        }

        public static IEnumerable<ServiceEndpoint> GetFakeEndpoint(int count)
        {
            return GetFakeConnectionString(count).Select(connectionString => new ServiceEndpoint(connectionString));
        }
    }
}