// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create an instance of the IotHub client.
    /// </summary>
    [Parallelizable(ParallelScope.Self)]
    [Category("Live")] // This category indicates the tests hit a "live" service: https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md#to-test-1
    public abstract class E2eTestBase : RecordedTestBase<IotHubTestEnvironment>
    {
        protected static readonly int MaxTries = 10;

        public E2eTestBase(bool isAsync)
         : base(isAsync)
        {
        }

        public E2eTestBase(bool isAsync, RecordedTestMode testMode)
           : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
}
