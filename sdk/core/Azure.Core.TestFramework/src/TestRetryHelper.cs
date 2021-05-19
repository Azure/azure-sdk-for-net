// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    public static class TestRetryHelper
    {
        public static async Task<T> RetryAsync<T>(Func<Task<T>> operation, int maxIterations = 20, TimeSpan delay = default)
        {
            if (delay == default)
            {
                delay = TimeSpan.FromSeconds(5);
            }

            List<Exception> exceptions = null;

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

                    await Task.Delay(delay);
                }
            }

            throw new AggregateException(exceptions);
        }
    }
}
