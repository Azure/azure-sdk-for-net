// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    // Mock classes for testing
    internal class MockThroughputMonitor : ThroughputMonitor
    {
        private decimal _throughput;

        public MockThroughputMonitor(decimal throughput)
        {
            _throughput = throughput;
        }

        public override decimal Throughput => _throughput;
    }
}
