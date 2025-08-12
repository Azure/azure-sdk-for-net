// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Provides assertion methods for testing asynchronous operations that are expected to throw exceptions.
/// This class extends NUnit's assertion capabilities to handle async/await patterns more effectively.
/// </summary>
public static class AsyncAssert
{
    /// <summary>
    /// Verifies that an asynchronous operation throws an exception of the specified type.
    /// This method awaits the provided asynchronous action and validates that it throws
    /// an exception of type <typeparamref name="T"/> or a derived type.
    /// </summary>
    /// <typeparam name="T">The type of exception that is expected to be thrown. Must inherit from <see cref="Exception"/>.</typeparam>
    /// <param name="action">
    /// A function that returns a <see cref="Task"/> representing the asynchronous operation
    /// that is expected to throw an exception.
    /// </param>
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
