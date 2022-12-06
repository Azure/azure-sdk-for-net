// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
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

        public MockTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, !IsMockServerRunning()? RecordedTestMode.Playback: mode)
        {
        }

        private void EnsureMockServerRunning()
        {
            if (Mode == RecordedTestMode.Record)
                TestMockServerRunning();
        }

        private static bool IsMockServerRunning()
        {
            try
            {
                TestMockServerRunning();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static void TestMockServerRunning()
        {
            using (var tcpClient = new TcpClient())
            {
                try
                {
                    var uri = new Uri(MockTestEnvironment.MockEndPoint);
                    tcpClient.Connect(uri.Host, uri.Port);
                }
                catch (SocketException)
                {
                    throw new InvalidOperationException("The mock server is not running, please start the mock server following this guide `https://github.com/Azure/azure-sdk-tools/tree/main/tools/mock-service-host` in order to record the test");
                }
            }
        }
    }
}
