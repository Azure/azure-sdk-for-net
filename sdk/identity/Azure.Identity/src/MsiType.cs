// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


namespace Azure.Identity
{
    internal enum MsiType
    {
        Unknown = 0,
        Imds = 1,
        AppService = 2,
        CloudShell = 3,
        Unavailable = 4
    }
}
