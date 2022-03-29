// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Core.TestFramework
{
    public abstract class DisposableConfig : IDisposable
    {
        private readonly SemaphoreSlim _lock;
        // Common environment variables to be saved off for tests. Add more as needed
        protected readonly Dictionary<string, string> _originalValues = new();

        public DisposableConfig(string name, string value, SemaphoreSlim sem)
        {
            _lock = sem;
            var acquired = _lock.Wait(TimeSpan.Zero);
            if (!acquired)
            {
                throw new Exception($"Concurrent use of {nameof(TestEnvVar)}. Consider marking these tests as NonParallelizable.");
            }

            InitValues();
            SetValue(name, value);
        }

        public DisposableConfig(Dictionary<string, string> values, SemaphoreSlim sem)
        {
            _lock = sem;
            var acquired = _lock.Wait(TimeSpan.Zero);
            if (!acquired)
            {
                throw new Exception($"Concurrent use of {nameof(TestEnvVar)}. Consider marking these tests as NonParallelizable.");
            }

            InitValues();
            SetValues(values);
        }

        internal abstract void SetValue(string name, string value);
        internal abstract void SetValues(Dictionary<string, string> values);
        internal abstract void InitValues();
        internal abstract void Cleanup();

        public void Dispose()
        {
            Cleanup();
            _lock.Release();
        }
    }
}
