// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.Calling.Server.Tests
{
    public class ServerCallingLiveTestBase : RecordedTestBase<ServerCallingTestEnvironment>
    {
        public ServerCallingLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new ServerCallingRecordedTestSanitizer();

        public CallClient CreateServerCallingClient()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            CallClient client = new CallClient(connectionString, CreateServerCallingClientOptions());

            #region Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@CallClient client = new CallClient(connectionString);
            #endregion Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
            return InstrumentClient(client);
        }

        // Todo: add CorrelationVectorLogs
        private CallClientOptions CreateServerCallingClientOptions()
        {
            CallClientOptions callClientOptions = new CallClientOptions();
            return InstrumentClientOptions(callClientOptions);
        }
    }
}
