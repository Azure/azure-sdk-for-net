// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub
{
    internal enum RequestType
    {
        Ignored,
        Connect,
        Connected,
        Disconnected,
        User
    }
}
