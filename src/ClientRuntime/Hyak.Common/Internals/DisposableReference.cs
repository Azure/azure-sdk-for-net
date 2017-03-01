// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;

namespace Hyak.Common.Internals
{
    /// <summary>
    /// Wrapper class that provides manual reference count functionality
    /// </summary>
    /// <typeparam name="T">Type to wrap around. Must be disposable.</typeparam>
    internal class DisposableReference<T>
        : IDisposable
        where T : class, IDisposable
    {
        public T Reference { get; private set; }
        public uint ReferenceCount { get; private set; }
        private object _lock = new object();

        public DisposableReference(T reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException("reference");
            }

            Reference = reference;
            ReferenceCount = 1;
        }

        public void AddReference()
        {
            lock (_lock)
            {
                ReferenceCount++;
            }
        }

        public void ReleaseReference()
        {
            lock (_lock)
            {
                if (ReferenceCount == 0)
                {
                    throw new ObjectDisposedException(typeof(T).FullName);
                }

                if (--ReferenceCount == 0)
                {
                    Reference.Dispose();
                    Reference = null;
                }
            }
        }

        void IDisposable.Dispose()
        {
            ReleaseReference();
        }
    }
}
