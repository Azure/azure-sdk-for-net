// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Shared = Azure.Storage.Shared;

#if CommonSDK
using Internals = Azure.Storage.Shared.Common;
namespace Azure.Storage.Shared.Common
#else
using Internals = Azure.Storage.Shared;
namespace Azure.Storage.Shared
#endif
{
internal struct Volatile<T> where T : class
    {
        private T m_t;

        public T Value
        {
            get => Volatile.Read(ref m_t);
            set => Volatile.Write(ref m_t, value);
        }
        public static implicit operator T(Internals.Volatile<T> volatileT) => volatileT.Value;
    }
}
