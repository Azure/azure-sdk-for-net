#pragma warning disable SA1636
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
#pragma warning restore SA1636

namespace Azure.Messaging.ServiceBus
{
    /// <summary>An empty struct, used to represent void in generic types.</summary>
    // https://github.com/dotnet/runtime/blob/main/src/libraries/System.Threading.Channels/src/System/VoidResult.cs
    internal readonly struct VoidResult { }
}
