// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The status of the rendering session. Once the status reached the &apos;Ready&apos; state it can be connected to. The terminal state is &apos;Stopped&apos;.
    /// </summary>
    [CodeGenModel("SessionStatus")]
    public partial struct RenderingSessionStatus
    {
    }
}
