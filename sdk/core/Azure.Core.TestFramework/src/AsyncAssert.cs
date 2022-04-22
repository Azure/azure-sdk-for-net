// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    public static class AsyncAssert
    {
        public static async Task<T> ThrowsAsync<T>(Func<Task> action) where T : Exception
        {
            Exception triggeredException = null;
            try
            {
                await action.Invoke();
            }
            catch (Exception ex)
            {
                triggeredException = ex;
            }
            if (triggeredException is not T exception)
            {
                // intentionally not using Assert.IsInstanceOf for testability
                throw new AssertionException($"\r\nExpected: {typeof(T)}\r\nBut was: {triggeredException?.GetType().ToString() ?? "null"}");
            }
            return exception;
        }
    }
}