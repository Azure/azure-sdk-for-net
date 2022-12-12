// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    internal enum JobPartPlanBlockBlobTier
    {
        /// <summary> None. </summary>
        None = 0,
        /// <summary> Hot. </summary>
        Hot = 1,
        /// <summary> Cool. </summary>
        Cool = 2,
        /// <summary> Archive. </summary>
        Archive = 3,
    }
}
