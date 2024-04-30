// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Vision.Face
{
    /// <summary> Request for creating liveness session. </summary>
    public partial class CreateLivenessSessionContent
    {
        internal CreateLivenessSessionContentForMultipart ToMultipartContent()
        {
            return new CreateLivenessSessionContentForMultipart(
                LivenessOperationMode,
                SendResultsToClient,
                DeviceCorrelationIdSetInClient,
                DeviceCorrelationId,
                AuthTokenTimeToLiveInSeconds,
                _serializedAdditionalRawData);
        }
    }
}
