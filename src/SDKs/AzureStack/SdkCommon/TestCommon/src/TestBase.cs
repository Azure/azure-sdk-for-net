// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;


namespace Microsoft.AzureStack.TestFramework
{
    public abstract class TestBase<T> where T : class
    {

        protected T client;

        private static void Assert(bool test, string message) {
            if (test) return;
            throw new Exception($"Assertion failed: {0}");
        }

        protected void InitializeContext(MockContext context) {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            handler.IsPassThrough = true;
            client = context.GetServiceClient<T>(handlers: handler);
        }

        /// <summary>
        /// Validate the client
        /// </summary>
        /// <param name="client">The client we are validating</param>
        protected abstract void ValidateClient(T client);

        /// <summary>
        /// The default location for all admin actions.  Override in derived class as needed.
        /// </summary>
        protected string Location = "local";

        /// <summary>
        /// Run a test that accepts no arguments
        /// </summary>
        /// <param name="test"></param>
        protected void RunTest(Action<T> test,
            Action before = null,
            Action after = null,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName= "testframework_failed") {

            Exception caught = null;

            try
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                handler.IsPassThrough = true;

                using (MockContext context = MockContext.Start(typeof(T).Name, methodName))
                {
                    var client = context.GetServiceClient<T>(handlers: handler);
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

        public void IgnoreExceptions(Action action) {
            try { action(); }
            catch (Exception) { }
        }

    }
}
