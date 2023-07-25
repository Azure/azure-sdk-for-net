// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.LoadTesting.Tests.Helpers
{
    public class LoadTestResourceHelper
    {
        public const string LOADTESTS_RESOURCE_LOCATION = "westus2";
        public const string LOADTESTS_RESOURCE_TYPE = "/loadtests";
        public const string LOAD_TEST_DESCRIPTION = "test";
    }
}
