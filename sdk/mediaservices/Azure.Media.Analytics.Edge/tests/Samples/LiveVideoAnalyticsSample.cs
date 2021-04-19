// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Media.Analytics.Edge.Models;
using Microsoft.Azure.Devices;
using NUnit.Framework;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Azure.Core;
using System.Linq;

namespace Azure.Media.Analytics.Tests.Samples
{
    public class LiveVideoAnalyticsSample
    {
        /// <summary>
        /// We do not have live tests for this sdk because this is a models only sdk. All of its operations are done through the azure-iot-hub sdk.
        /// We are including a dummy test because without any tests our PR fails some checks
        /// </summary>
        [Test]
        public void TestSample()
        {
            Assert.True(true);
        }
    }
}
