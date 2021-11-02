// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class RouterClientCrudTests
    {
        #region Channel tests

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_SetChannel(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.SetChannel(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_SetChannelAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.SetChannelAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_GetChannel(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.GetChannel(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_GetChannelAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.GetChannelAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_DeleteChannel(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.DeleteChannel(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_DeleteChannelAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.DeleteChannelAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        #endregion Channel tests

        #region Classification Policy tests

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_SetClassificationPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.SetClassificationPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_SetClassificationPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.SetClassificationPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_GetClassificationPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.GetClassificationPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_GetClassificationPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.GetClassificationPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_DeleteClassificationPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.DeleteClassificationPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_DeleteClassificationPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.DeleteClassificationPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        #endregion Classification Policy tests

        #region Distribution Policy tests

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_SetDistributionPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.SetDistributionPolicy(input, TimeSpan.Zero, new LongestIdleMode());
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_SetDistributionPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.SetDistributionPolicyAsync(input, TimeSpan.Zero, new LongestIdleMode());
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_GetDistributionPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.GetDistributionPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_GetDistributionPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.GetDistributionPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_DeleteDistributionPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.DeleteDistributionPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_DeleteDistributionPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.DeleteDistributionPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        #endregion Distribution Policy tests

        #region Exception Policy tests

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_SetExceptionPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.SetExceptionPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_SetExceptionAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.SetExceptionPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_GetExceptionPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.GetExceptionPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_GetExceptionPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.GetExceptionPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_DeleteExceptionPolicy(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.DeleteExceptionPolicy(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_DeleteExceptionPolicyAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.DeleteExceptionPolicyAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        #endregion Exception Policy tests

        #region Job tests

        #endregion Job tests

        #region Queue tests

        [Test]
        [TestCase(new string?[] { null, null }, typeof(ArgumentNullException))]
        [TestCase(new string?[]{null, ""}, typeof(ArgumentNullException))]
        [TestCase(new string?[] { "", null }, typeof(ArgumentException))]
        [TestCase(new string?[] { "value", null }, typeof(ArgumentNullException))]
        [TestCase(new string?[] { null, "value" }, typeof(ArgumentNullException))]
        [TestCase(new string?[] { "value", "" }, typeof(ArgumentException))]
        [TestCase(new string?[] { "", "value" }, typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_SetQueue(string?[] input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.SetQueue(input[0], input[1]);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(new string?[] { null, null }, typeof(ArgumentNullException))]
        [TestCase(new string?[] { null, "" }, typeof(ArgumentNullException))]
        [TestCase(new string?[] { "", null }, typeof(ArgumentException))]
        [TestCase(new string?[] { "value", null }, typeof(ArgumentNullException))]
        [TestCase(new string?[] { null, "value" }, typeof(ArgumentNullException))]
        [TestCase(new string?[] { "value", "" }, typeof(ArgumentException))]
        [TestCase(new string?[] { "", "value" }, typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_SetQueueAsync(string?[] input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.SetQueueAsync(input[0], input[1]);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_GetQueue(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.GetQueue(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_GetQueueAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.GetQueueAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_DeleteQueue(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.DeleteQueue(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_DeleteQueueAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.DeleteQueueAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        #endregion Queue tests

        #region Worker tests

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_RegisterWorker(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.RegisterWorker(input, 0);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_RegisterWorkerAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.RegisterWorkerAsync(input, 0);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_GetWorker(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.GetWorker(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_GetWorkerAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.GetWorkerAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public void NullOrEmptyIdThrowsError_DeregisterWorker(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = client.DeregisterWorker(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("  ", typeof(ArgumentException))]
        public async Task NullOrEmptyIdThrowsError_DeregisterWorkerAsync(string? input, Type exceptionType)
        {
            var client = CreateMockRouterClient(200);
            try
            {
                var response = await client.DeregisterWorkerAsync(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
            }
        }

        #endregion Worker tests

        #region private helpers

        private RouterClient CreateMockRouterClient(int responseCode, string? responseContent = null)
        {
            var connectionString = "endpoint=https://dummyresource.communication.azure.net/;accesskey=Kg==";
            var mockResponse = new MockResponse(responseCode);
            if (responseContent != null)
            {
                mockResponse.SetContent(responseContent);
            }

            var routerClientOptions = new RouterClientOptions()
            {
                Transport = new MockTransport(mockResponse)
            };

            return new RouterClient(connectionString, routerClientOptions);
        }

        #endregion private helpers
    }
}
