// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    internal interface ITransportObjectProvider<out T>
    {
        T GetTransportObject();
    }

    internal static class TransportObjectProviderExtensions
    {
        internal static T GetTransportObject<T>(this ITransportObjectProvider<T> objectProvider)
        {
            return objectProvider.GetTransportObject();
        }
    }
}
