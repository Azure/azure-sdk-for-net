// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
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
            string connectionString = TestEnvironment.IotHubConnectionString;

            // In playback mode we will restore the shared access key to an invalid value so the connection string can be parsed.
            if (Recording.Mode == RecordedTestMode.Playback)
            {
                connectionString = connectionString.Replace(";SharedAccessKey=", ";SharedAccessKey=Kg==;");
            }

            return InstrumentClient(
                new IoTHubServiceClient(
                    connectionString,
                    Recording.InstrumentClientOptions(new IoTHubServiceClientOptions())));
        }

        protected string GetRandom()
        {
            return Recording.GenerateId();
        }
    }
}
