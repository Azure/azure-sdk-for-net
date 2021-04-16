// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal enum RequestType
    {
        Ignored,
        Connect,
        Disconnect,
        User
    }

    internal static class RequestTypeExtensions
    {
        public static bool IsSyncMethod(this RequestType requestType)
        {
            return requestType == RequestType.Connect || requestType == RequestType.User;
        }
    }
}