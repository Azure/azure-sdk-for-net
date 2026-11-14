// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents.Custom.Internal
{
    internal class FoundryFeaturesPolicy(string feature, Uri endpoint) : PipelinePolicy
    {
        private const string _FEATURE_HEADER = "Foundry-Features";
        private const string VoiceAgentsPreview = "VoiceAgents=V1Preview";

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            ApplyFeatures(message.Request);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            ApplyFeatures(message.Request);
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }

        private void ApplyFeatures(PipelineRequest request)
        {
            VoiceFeatureScope scope = GetVoiceFeatureScope(request.Uri);
            bool hasExplicitFeatures = request.Headers.TryGetValue(_FEATURE_HEADER, out string explicitFeatures);
            if (scope == VoiceFeatureScope.Required)
            {
                if (string.IsNullOrWhiteSpace(explicitFeatures))
                {
                    request.Headers.Set(_FEATURE_HEADER, VoiceAgentsPreview);
                    return;
                }
                bool hasVoiceAgentsPreview = false;
                foreach (string value in explicitFeatures.Split(','))
                {
                    if (string.Equals(value.Trim(), VoiceAgentsPreview, StringComparison.OrdinalIgnoreCase))
                    {
                        hasVoiceAgentsPreview = true;
                    }
                    else if (value.Trim().StartsWith("VoiceAgents=", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException("The Foundry-Features header must opt into VoiceAgents=V1Preview for this operation.");
                    }
                }
                if (!hasVoiceAgentsPreview)
                {
                    request.Headers.Set(_FEATURE_HEADER, $"{explicitFeatures},{VoiceAgentsPreview}");
                }
            }
            else if (!hasExplicitFeatures && scope == VoiceFeatureScope.Other && !string.IsNullOrEmpty(feature))
            {
                request.Headers.Set(_FEATURE_HEADER, feature);
            }
        }

        private VoiceFeatureScope GetVoiceFeatureScope(Uri uri)
        {
            string prefix = endpoint.AbsolutePath.TrimEnd('/') + "/";
            if (!string.Equals(uri.Scheme, endpoint.Scheme, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(uri.Host, endpoint.Host, StringComparison.OrdinalIgnoreCase) ||
                uri.Port != endpoint.Port ||
                !uri.AbsolutePath.StartsWith(prefix, StringComparison.Ordinal))
            {
                return VoiceFeatureScope.Other;
            }
            string path = uri.AbsolutePath.Substring(prefix.Length);
            if (string.Equals(path, "agents:generate", StringComparison.Ordinal))
            {
                return VoiceFeatureScope.GA;
            }
            string[] segments = path.Split('/');
            if (segments.Length < 3 || segments[0] != "agents")
            {
                return VoiceFeatureScope.Other;
            }
            if (segments[2] == "telephony_campaigns")
            {
                return VoiceFeatureScope.Required;
            }
            if (segments[2] is "telephony" or "telephony_call_jobs")
            {
                // Conditional SIP opt-ins must come from the caller, including ID-only operations.
                return VoiceFeatureScope.Conditional;
            }
            if (segments.Length >= 5 && segments[2] == "endpoint" &&
                segments[3] == "protocols" && segments[4] == "voice")
            {
                return segments.Length > 5 && segments[5] == "live"
                    ? VoiceFeatureScope.Required
                    : VoiceFeatureScope.Conditional;
            }
            return VoiceFeatureScope.Other;
        }

        private enum VoiceFeatureScope
        {
            Other,
            GA,
            Conditional,
            Required
        }
    }
}
