// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal static class ReadOnlyList<T>
    {
        private static IReadOnlyList<T> emptyList;

        public static IReadOnlyList<T> Empty
        {
            get
            {
                emptyList ??= new ReadOnlyCollection<T>(new List<T>(0));
                return emptyList;
            }
        }
    }
}
