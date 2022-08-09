// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StreamAnalytics.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StreamAnalytics.Tests.TestCase
{
    public class StreamAnalyticsCluserResourceTests : StreamAnalyticsManagementTestBase
    {
        public StreamAnalyticsCluserResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }
    }
}
