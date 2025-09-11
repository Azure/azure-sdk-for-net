// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Provides retry functionality for test operations with configurable delays and iteration limits.
/// Useful for handling flaky test scenarios or operations that may need multiple attempts to succeed.
/// </summary>
public class TestRetryHelper
{
    private readonly bool _noWait;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestRetryHelper"/> class.
    /// </summary>
    /// <param name="noWait">If true, disables delays between retry attempts; if false, uses the specified delay.</param>
    public TestRetryHelper(bool noWait)
    {
        _noWait = noWait;
    }

    /// <summary>
    /// Retries an asynchronous operation until it succeeds or the maximum number of iterations is reached.
    /// </summary>
    /// <typeparam name="T">The return type of the operation.</typeparam>
    /// <param name="operation">The asynchronous operation to retry.</param>
    /// <param name="maxIterations">The maximum number of retry attempts (default is 20).</param>
    /// <param name="delay">The delay between retry attempts (default is 5 seconds).</param>
    /// <returns>The result of the successful operation.</returns>
    /// <exception cref="AggregateException">Thrown when all retry attempts fail, containing the exceptions from failed attempts.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the operation fails without throwing exceptions.</exception>
    public async Task<T> RetryAsync<T>(Func<Task<T>> operation, int maxIterations = 20, TimeSpan delay = default)
    {
        if (delay == default)
        {
            delay = TimeSpan.FromSeconds(5);
        }

        if (_noWait)
        {
            delay = TimeSpan.Zero;
        }

        List<Exception>? exceptions = null;

        for (int i = 0; i < maxIterations; i++)
        {
            try
            {
                return await operation().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                exceptions ??= new List<Exception>();
                exceptions.Add(e);

                await Task.Delay(delay).ConfigureAwait(false);
            }
        }

        if (exceptions is null)
        {
            throw new InvalidOperationException("operation failed");
        }
        else
        {
            throw new AggregateException(exceptions);
        }
    }
}
