// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Storage
{
    internal struct Volatile<T> where T : class
    {
        private T m_t;

        public T Value
        {
            get => Volatile.Read(ref m_t);
            set => Volatile.Write(ref m_t, value);
        }
        public static implicit operator T(Volatile<T> volatileT) => volatileT.Value;
    }
}
