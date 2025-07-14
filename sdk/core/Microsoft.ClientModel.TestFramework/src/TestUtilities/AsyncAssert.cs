// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public static class AsyncAssert
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="AssertionException"></exception>
    public static async Task<T> ThrowsAsync<T>(Func<Task> action) where T : Exception
    {
        Exception? triggeredException = null;
        try
        {
            await action.Invoke().ConfigureAwait(false);
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
