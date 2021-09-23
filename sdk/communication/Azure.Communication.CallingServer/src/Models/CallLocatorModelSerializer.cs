// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    internal class CallLocatorModelSerializer
    {
        internal static CallLocatorModel Serialize(CallLocator identifier)
            => identifier switch
            {
                ServerCallLocator serverCallLocator => new CallLocatorModel
                {
                    ServerCallLocator = new ServerCallLocatorModel(serverCallLocator.Id),
                },
                GroupCallLocator groupCallLocator => new CallLocatorModel
                {
                    GroupCallLocator = new GroupCallLocatorModel(groupCallLocator.Id),
                },
                _ => throw new NotSupportedException(),
            };
    }
}
