// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class SearchTestUtilities
    {
        public static string GenerateServiceName()
        {
            return TestUtilities.GenerateName(prefix: "azs-");
        }

        public static void WaitForIndexing()
        {
            TestUtilities.Wait(TimeSpan.FromSeconds(2));
        }

        public static bool WaitForSearchServiceDns(string searchServiceName, TimeSpan maxDelay)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                // Nothing to wait for when we're running mocked.
                return true;
            }

            TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            Uri baseUri = testEnvironment.GetBaseSearchUri(searchServiceName);

            TimeSpan retryDelay = TimeSpan.FromSeconds(1);
            
            long maxRetries = (long)(maxDelay.TotalSeconds / retryDelay.TotalSeconds);
            int retries = 0;

            while (retries < maxRetries)
            {
                try
                {
                    Dns.GetHostEntry(baseUri.DnsSafeHost);
                    return true;
                }
                catch (SocketException e)
                {
                    if (e.Message.Contains("The remote name could not be resolved") ||
                        e.Message.Contains("No such host is known"))
                    {
                        Thread.Sleep(retryDelay);
                        retries++;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return false;
        }
    }
}
