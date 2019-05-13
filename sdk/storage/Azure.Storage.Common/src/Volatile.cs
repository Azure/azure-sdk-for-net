// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Threading;

namespace Azure.Storage
{
    internal struct Volatile<T> where T : class
    {
        T m_t;

        public T Value
        {
            get => Volatile.Read(ref this.m_t);
            set => Volatile.Write(ref this.m_t, value);
        }
        public static implicit operator T(Volatile<T> volatileT) => volatileT.Value;
    }
}
