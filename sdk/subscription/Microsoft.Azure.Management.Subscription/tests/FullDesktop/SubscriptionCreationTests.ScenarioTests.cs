// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using FullDesktop.Tests.Helpers;
using FullDesktop.Tests.SpecTestSupport.Subscription;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.TransientFaultHandling;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Text;
using Xunit;

namespace FullDesktop.Tests
{
    /// <summary>
    /// These tests exercise Microsoft.Subscription/subscriptionDefinitions PUT, GET and LIST
    /// This api can be used to create, get and list subscriptions.
    /// 
    ///  To run tests, output Test\Windoows\Test Explorer and find these tests in the list. If they don't show up, then double check that the nugets have been installed correctly.
    ///  To Record:
    ///     - use the vs 2017 powershell command prompt
    ///     - run azure-sdk-for-net\tools> Import-Module .\Repo-Tasks.psd1
    ///     - set the following with a tenantId, subscriptionId, and userId
    /// $env:TEST_CSM_ORGID_AUTHENTICATION = "SubscriptionId=00000000-0000-0000-0000-000000000000;HttpRecorderMode=Record;Environment=Dogfood;UserId=xxxxxxxxxxxxxx@live.com;AADTenant=00000000-0000-0000-0000-000000000000"
    ///      - set the mode as record 
    /// $env:AZURE_TEST_MODE = "Record"
    ///       - set the output directory for where you want to record session files to be placed:
    /// $Varname="OutputDirectory"
    /// Set-Item "env:OutputDirectory" "D:\src\xxxxxxxx\azure-sdk-for-net\xxxxxx\SessionRecords"
    ///      - invoke vs: devenv .\Resources.sln
    /// </summary>
    public class LiveSubscriptionCreationTests : TestBase
    {
        public SubscriptionClient GetSubscriptionClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClientWithHandler(context, handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void CreateSubscription()
        {
            var env = new StringBuilder();
            foreach (DictionaryEntry e in System.Environment.GetEnvironmentVariables())
            {
                env = env.Append(e.Key + " " + e.Value + "\r\n");
            }
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                const string enrollmentAccountName = "465c11a0-38c3-4ecc-92e9-996c69ae9e76";
                const string offerType = "MS-AZR-0017P";
                var body = new SubscriptionCreationParameters()
                {
                    DisplayName = "TestSubscription_AzureSDK",
                    OfferType = offerType
                };
                var client = GetSubscriptionClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));
                var subscriptionResult = client.Subscription.CreateSubscriptionInEnrollmentAccountWithHttpMessagesAsync(
                    enrollmentAccountName, body).ConfigureAwait(false).GetAwaiter().GetResult();

                Assert.Equal(HttpStatusCode.OK, subscriptionResult.Response.StatusCode);
                Assert.NotNull(subscriptionResult);
                Assert.NotNull(subscriptionResult.Body.SubscriptionLink);
                Assert.StartsWith("/subscriptions", subscriptionResult.Body.SubscriptionLink);
            }
        }

        private static bool IsRecordMode()
        {
            return Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record";
        }

        private static string GetSessionsDirectoryPath()
        {
            string dir = Environment.GetEnvironmentVariable("OutputDirectory");
            if (!IsRecordMode())
            {
                // get the directory where the dll is being copied from
                // then cut off the file:/// and change the forward slash to backslahes
                string temp = Assembly.GetExecutingAssembly().CodeBase.Substring(0, Assembly.GetExecutingAssembly().CodeBase.LastIndexOf('/') + 1) + "SessionRecords";
                dir = temp.Substring(8).Replace('/', '\\');
            }
            return dir;
        }
    }
}
