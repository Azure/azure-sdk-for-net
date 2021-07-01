// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class SearchTestUtilities
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static string GenerateServiceName()
        {
            return TestUtilities.GenerateName(prefix: "azs-");
        }

        public static string GenerateStorageAccountName()
        {
            return TestUtilities.GenerateName(prefix: "azsstorage");
        }

        public static string GenerateName()
        {
            return TestUtilities.GenerateName();
        }

        public static void WaitForIndexing()
        {
            TestUtilities.Wait(TimeSpan.FromSeconds(2));
        }

        public static void WaitForSynonymMapUpdate()
        {
            TestUtilities.Wait(TimeSpan.FromSeconds(5));
        }

        public static void WaitForServiceProvisioning()
        {
            TestUtilities.Wait(TimeSpan.FromSeconds(10));
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
                if (CanResolve(baseUri))
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(retryDelay);
                    retries++;
                }
            }

            return false;
        }

        // Workaround since the Dns class is not available in PCLs.
        private static bool CanResolve(Uri url)
        {
            try
            {
                return _httpClient.GetAsync(url).Wait(TimeSpan.FromSeconds(5));
            }
            catch (AggregateException e)
            {
                HttpRequestException httpEx = e.InnerExceptions.FirstOrDefault() as HttpRequestException;
                if (httpEx != null)
                {
                    if (httpEx.InnerException != null && 
                        httpEx.InnerException.Message.Contains("could not be resolved"))
                    {
                        return false;
                    }
                }

                throw;
            }
        }
    }
}
