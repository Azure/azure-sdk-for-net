// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class TestRetryHelper
{
    private readonly bool _noWait;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="noWait"></param>
    public TestRetryHelper(bool noWait)
    {
        _noWait = noWait;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operation"></param>
    /// <param name="maxIterations"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    /// <exception cref="AggregateException"></exception>
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
                exceptions = [e];

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
