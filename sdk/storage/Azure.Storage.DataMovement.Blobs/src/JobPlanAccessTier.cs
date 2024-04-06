// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Blobs
{
    internal enum JobPlanAccessTier : byte
    {
        None = 0,
        Hot = 1,
        Cool = 2,
        Cold = 3,
        Archive = 4,
        Premium = 5,

        P4 = 11,
        P6 = 12,
        P10 = 13,
        P15 = 14,
        P20 = 15,
        P30 = 16,
        P40 = 17,
        P50 = 18,
        P60 = 19,
        P70 = 20,
        P80 = 21,
    }
}
