// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteConfigWebContainerTests : AppServiceTestBase
    {
        public SiteConfigWebContainerTests(bool isAsync)
            : base(isAsync, Azure.Core.TestFramework.RecordedTestMode.Record)
        {
        }
    }
}
