// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    public enum ReceiveMode
    {
        /// <summary>Specifies the PeekLock receive mode. This is the default value for <see cref="Microsoft.Azure.ServiceBus.ReceiveMode" />.</summary>
        PeekLock,

        /// <summary>Specifies the ReceiveAndDelete receive mode.</summary>
        ReceiveAndDelete
    }
}