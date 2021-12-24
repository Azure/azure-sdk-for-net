// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.AI.Personalizer
{
    /// <summary> The class for Dispose helper </summary>
    public static class DisposeHelper
    {
        /// <summary> Safe dispose </summary>
        /// <param name="disposable"> Configuration. </param>
        public static void SafeDispose<TDisposable>(ref TDisposable disposable) where TDisposable : class, IDisposable
        {
            IDisposable localDisposable = Interlocked.Exchange(ref disposable, null);
            if (localDisposable != null)
            {
                localDisposable.Dispose();
            }
        }
    }
}
