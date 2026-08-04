// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Compatibility customization so AzureRealtimeNativeVoice always participates
    /// in VoiceProvider polymorphism across generation baselines.
    /// </summary>
    internal partial class AzureRealtimeNativeVoice : VoiceProvider
    {
    }
}
