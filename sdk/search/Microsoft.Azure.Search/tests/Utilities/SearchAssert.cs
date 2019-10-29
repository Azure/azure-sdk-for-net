// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Net;
    using System.Threading;
    using Rest.Azure;
    using Xunit;

    internal static class SearchAssert
    {
        public static void DoesNotUseSynchronizationContext(Action action)
        {
            var context = new MockSynchronizationContext();
            SynchronizationContext oldContext = SynchronizationContext.Current;

            try
            {
                SynchronizationContext.SetSynchronizationContext(context);
                action();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }

            Assert.False(
                context.WasCalled,
                "Synchronization context was used unexpectedly. Is there a missing .ConfigureAwait(false) somewhere?");
        }

        public static CloudException ThrowsCloudException(Action action, HttpStatusCode expectedStatusCode, string expectedMessage = null)
        {
            return ThrowsCloudException(action, e => Assert.Equal(expectedStatusCode, e.Response.StatusCode), expectedMessage);
        }

        public static CloudException ThrowsCloudException(Action action, Func<CloudException, bool> checkException, string expectedMessage = null)
        {
            return ThrowsCloudException(action, e => Assert.True(checkException(e)));
        }

        private static CloudException ThrowsCloudException(Action action, Action<CloudException> assertException, string expectedMessage = null)
        {
            CloudException e = Assert.Throws<CloudException>(action);

            assertException(e);

            if (expectedMessage != null)
            {
                Assert.Contains(expectedMessage, e.Body.Message);
            }

            return e;
        }

        /// <summary>
        /// A mock SynchronizationContext that can report whether or not it was called by async tasks.
        /// </summary>
        private class MockSynchronizationContext : SynchronizationContext
        {
            public bool WasCalled { get; set; }

            public override void Post(SendOrPostCallback d, object state)
            {
                WasCalled = true;
                base.Post(d, state);
            }

            public override void Send(SendOrPostCallback d, object state)
            {
                WasCalled = true;
                base.Send(d, state);
            }
        }
    }
}
