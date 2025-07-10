// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    /// <summary> The FaceSession service client. </summary>
    public partial class FaceSessionClient
    {
        // Custom methods for CreateLivenessWithVerifySession have been removed
        // as the new generator only provides protocol methods for this operation.
        // These methods would need to be reimplemented if the custom functionality
        // is still required with the new generator model.
    }
}
