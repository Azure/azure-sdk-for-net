﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.Hub.Service.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create and instance of the IoT Hub service client.
    /// </summary>
    [Parallelizable(ParallelScope.Self)]
    public abstract class E2eTestBase : RecordedTestBase<IotHubServiceTestEnvironment>
    {
        public E2eTestBase(bool isAsync)
         : base(isAsync, TestSettings.Instance.TestMode)
        {
            Sanitizer = new CustomRequestSanitizer();
        }

        public E2eTestBase(bool isAsync, RecordedTestMode testMode)
           : base(isAsync, testMode)
        {
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            TestDiagnostics = false;

            // TODO: set via client options and pipeline instead
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected IotHubServiceClient GetClient()
        {
            return InstrumentClient(
                new IotHubServiceClient(
                    TestEnvironment.IotHubConnectionString,
                    InstrumentClientOptions(new IotHubServiceClientOptions())));
        }

        /* Need to use this for playback tests to run, do not use a new instance of random */
        protected string GetRandom()
        {
            return Recording.GenerateId();
        }

        protected string GetHostName()
        {
            var iotHubConnectionString = ConnectionString.Parse(TestEnvironment.IotHubConnectionString);
            return iotHubConnectionString.GetRequired("HostName");
        }
    }
}
