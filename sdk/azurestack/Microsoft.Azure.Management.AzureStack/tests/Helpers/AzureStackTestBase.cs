// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.AzureStack.Tests
{
    using System;
    using System.Net;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    /// <summary>
    /// Base class for all AzureStack tests.  This class should not be modified but extended through a child class.
    /// </summary>
    ///
    public class AzureStackTestBase
    {
        /// <summary>
        /// Validate the client.
        /// </summary>
        /// <param name="client">The instantiated client we want to validate.</param>
        protected void ValidateClient(IAzureStackManagementClient client)
        {
            Assert.NotNull(client);
            Assert.NotNull(client.Operations);
            Assert.NotNull(client.Registrations);
            Assert.NotNull(client.Products);
            Assert.NotNull(client.CustomerSubscriptions);
        }

        /// <summary>
        /// Run a test that accepts no arguments.
        /// </summary>
        /// <param name="test">The test we wish to run.</param>
        /// <param name="before">Function to execute before your test has completed.</param>
        /// <param name="after">Function to execute after your test has completed.</param>
        /// <param name="status">Expected returned HttpStatusCode.</param>
        /// <exception cref="System.Exception">Thrown when an unexpected exception occurs.</exception>  
        protected void RunTest(Action<AzureStackManagementClient> test,
            Action before = null,
            Action after = null,
            HttpStatusCode status = HttpStatusCode.OK,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName= "testframework_failed")
        {

            Exception caught = null;

            try
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = status };
                handler.IsPassThrough = true;

                using (MockContext context = MockContext.Start(nameof(AzureStackManagementClient), methodName))
                {
                    var client = context.GetServiceClient<AzureStackManagementClient>(handlers: handler);
                    ValidateClient(client);

                    before?.Invoke();
                    test(client);
                    after?.Invoke();
                }
            }
            catch (Exception ex)
            {
                caught = ex;
            }
            finally
            {
                if (caught != null)
                {
                    throw new Exception("Test failed", caught);
                }
            }
        }

        public void IgnoreExceptions(Action action)
        {
            try { action(); }
            catch (Exception) { }
        }

    }
}