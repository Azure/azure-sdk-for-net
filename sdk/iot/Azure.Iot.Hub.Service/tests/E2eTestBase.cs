// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
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
            Sanitizer = new TestConnectionStringSanitizer();
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

        protected IoTHubServiceClient GetClient()
        {
            return InstrumentClient(
                new IoTHubServiceClient(
                    TestEnvironment.IotHubConnectionString,
                    Recording.InstrumentClientOptions(new IoTHubServiceClientOptions())));
        }

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
