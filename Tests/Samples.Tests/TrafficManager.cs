// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class TrafficManager : Samples.Tests.TestBase
    {
        public TrafficManager(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "TrafficManager")]
        public void ManageTrafficManagerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageTrafficManager.Program.RunSample);
        }
    }
}
