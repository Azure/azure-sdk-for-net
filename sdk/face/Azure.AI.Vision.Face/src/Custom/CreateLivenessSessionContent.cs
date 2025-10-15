// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Vision.Face
{
    public partial class CreateLivenessSessionContent
    {
        /// <summary> The number of times a client can attempt a liveness check using the same authToken. Default value is 1. Maximum value is 3. </summary>
        public int NumberOfClientAttemptsAllowed { get; set; }
    }
}
