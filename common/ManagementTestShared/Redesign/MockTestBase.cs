// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class MockTestBase : ManagementRecordedTestBase<MockTestEnvironment>
    {
        public MockTestBase(bool isAsync) : base(isAsync)
        {
            EnsureMockServerRunning();
        }

        public MockTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            EnsureMockServerRunning();
        }

        private void EnsureMockServerRunning()
        {
            if (Mode == RecordedTestMode.Record)
                TestMockServerRunning();
        }

        private void TestMockServerRunning()
        {
            using (var tcpClient = new TcpClient())
            {
                try
                {
                    var uri = new Uri(TestEnvironment.MockEndPoint);
                    tcpClient.Connect(uri.Host, uri.Port);
                }
                catch (SocketException)
                {
                    throw new InvalidOperationException("The mock server is not running, please start the mock server following this guide `https://devdiv.visualstudio.com/DevDiv/_git/avs?path=%2FREADME.md` in order to record the test");
                }
            }
        }
    }
}
