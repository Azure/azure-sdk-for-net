// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    internal static class SessionModeExtensions
    {
        public static SessionMode ResolveAuto(this SessionMode sessionMode)
        {
            // Auto maps to Disabled today, may change in the future.
            if (sessionMode == SessionMode.Auto)
            {
                return SessionMode.Disabled;
            }
            return sessionMode;
        }
    }
}
