// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;

namespace Azure.AI.Projects.Agents.Tests
{
    /// <summary>
    /// Provides sanitization configuration for Azure.AI.Projects test recordings.
    /// This class centralizes all sanitization patterns and replacement values.
    /// </summary>
    public static class ProjectsTestSanitizers
    {
        internal const string LegacyAgentInsightsFeaturePattern = @"(?:^AgentInsights=V1Preview(?:,|$)|,AgentInsights=V1Preview(?=,|$))";
        internal const string LegacyDefaultVoiceAgentFeaturePattern = @"(\AMemoryStores=V1Preview,WorkflowAgents=V1Preview,(?:[^,]+,)*DraftAgents=V1Preview),VoiceAgents=V1Preview(?=,ModelRouterControls=V1Preview(?:,|\z))";
        internal const string LegacyDefaultVoiceAgentFeatureReplacement = "${1}";

        internal const string LegacyRealtimeVoiceDefinitionPattern = @"(""definition""\s*:\s*\{\s*""kind""\s*:\s*""voice""\s*,)(?![^{}]*""sub_protocol""\s*:)";
        internal const string LegacyRealtimeVoiceDefinitionReplacement = "${1}\"sub_protocol\":\"realtime\",";
        internal const string LegacyTelephonyCallJobPathPattern = @"(/agents/[^/?]+/)telephony/call_jobs(?=/|:|\?|$)";
        internal const string LegacyTelephonyCallJobPathReplacement = "${1}telephony_call_jobs";
        internal const string LegacySkillsPathPattern = @"(\Ahttps?://[^/?#]+/api/projects/[^/?#]+/)openai/v1/skills(?=/|[?#]|$)";
        internal const string LegacySkillsPathReplacement = "${1}skills";

        internal static void ApplyLegacyVoiceHistoryRecordingHeaders<TEnvironment>(RecordedTestBase<TEnvironment> testBase)
            where TEnvironment : TestEnvironment, new()
        {
            if (testBase.Mode == RecordedTestMode.Playback)
            {
                // Old history/telephony recordings sent a bundle that GA omits; matcher ignores still compare presence.
                // Remove both sides only in these playback fixtures. VoiceAgentPreviewHeaderTests checks exact headers.
                testBase.CustomSanitizers.Add(new RemoveHeaderSanitizer(new("Foundry-Features")));
            }
        }

        internal static void ApplyLegacyTelephonyCallJobRecordingRoutes<TEnvironment>(RecordedTestBase<TEnvironment> testBase)
            where TEnvironment : TestEnvironment, new()
        {
            if (testBase.Mode == RecordedTestMode.Playback)
            {
                // Match legacy recording routes without changing requests sent to the live service.
                testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(new()
                {
                    Regex = LegacyTelephonyCallJobPathPattern,
                    Value = LegacyTelephonyCallJobPathReplacement
                }));
            }
        }

        internal static void ApplyLegacyRealtimeVoiceRecordingDefaults<TEnvironment>(RecordedTestBase<TEnvironment> testBase)
            where TEnvironment : TestEnvironment, new()
        {
            if (testBase.Mode == RecordedTestMode.Playback)
            {
                // Older Realtime recordings omit the now-required default discriminator. Keep explicit protocols and body matching intact.
                testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(new()
                {
                    Regex = LegacyRealtimeVoiceDefinitionPattern,
                    Value = LegacyRealtimeVoiceDefinitionReplacement,
                    Condition = new(@"/agents/[^/?]+/versions(?:/[^/?]+)?\?")
                }));
            }
        }

        // Replacement values
        public const string SANITIZED_SUBSCRIPTION = "00000000-0000-0000-0000-000000000000";
        public const string SANITIZED_HOST = "sanitized-host";
        public const string SANITIZED_PROJECT = "sanitized-project";
        public const string SANITIZED_ACCOUNT = "sanitized-account";
        public const string SANITIZED_STORAGE_ACCOUNT = "sanitized-storage-account";
        public const string SANITIZED_RESOURCE_GROUP = "sanitized-rg";
        public const string SANITIZED_CONTAINER = "sanitized-container";
        public const string SANITIZED_CONNECTION = "sanitizedconnection";
        public const string SANITIZED_AZURE_OPENAI_ENDPOINT = "sanitized";

        // Common patterns for sanitization
        public static readonly UriRegexSanitizerBody AZURE_SUBSCRIPTION_PATTERN = BodySanitizer(@"(?<=/subscriptions/)([^/]+)(?=/)", SANITIZED_SUBSCRIPTION);
        public static readonly UriRegexSanitizerBody AZURE_RESOURCE_GROUP_PATTERN = BodySanitizer(@"(?<=/resourceGroups/)([^/]+)(?=/)", SANITIZED_RESOURCE_GROUP);
        public static readonly UriRegexSanitizerBody AZURE_ACCOUNT_NAME_PATTERN = BodySanitizer(@"(?<=/accounts/)([^/]+)(?=/|$)", SANITIZED_ACCOUNT);
        public static readonly UriRegexSanitizerBody AZURE_STORAGE_ACCOUNT_NAME_PATTERN = BodySanitizer(@"(?<=/storageAccounts/)([^/]+)(?=/|$)", SANITIZED_STORAGE_ACCOUNT);
        public static readonly UriRegexSanitizerBody AZURE_PROJECT_NAME_PATTERN = BodySanitizer(@"(?<=/projects/)([^/]+)(?=[/?]|$)", SANITIZED_PROJECT);
        public static readonly UriRegexSanitizerBody HOST_SUBDOMAIN_PATTERN = BodySanitizer(@"(?<=https://)([^.]+)(?=\.services\.ai\.azure\.com)", SANITIZED_HOST);
        public static readonly UriRegexSanitizerBody OPENAI_HOST_PATTERN = BodySanitizer(@"(?<=https://)([^.]+)(?=\.openai\.azure\.com)", SANITIZED_HOST);
        public static readonly UriRegexSanitizerBody AI_SEARCH_HOST_PATTERN = BodySanitizer(@"(?<=https://)([^.]+)(?=\.search\.windows\.net)", SANITIZED_HOST);
        public static readonly UriRegexSanitizerBody AZURE_CONTAINER_NAME_PATTERN = BodySanitizer(@"\d+dp[^/\s]*container", SANITIZED_CONTAINER);
        public static readonly UriRegexSanitizerBody AZURE_CONNECTION_PATTERN = BodySanitizer(@"(?<=/connections/)([^/]+)$", SANITIZED_CONNECTION);
        public static readonly UriRegexSanitizerBody AZURE_CONNECTION_PATTERN_URI = BodySanitizer(@"(?<=/connections/)([^?]+)(?=[?])", SANITIZED_CONNECTION);
        public static readonly UriRegexSanitizerBody AZURE_OPENAI_ENDPOINT = BodySanitizer(@"(?<=https://)([^/]+)(?=\.cognitiveservices\.azure.com\/)", SANITIZED_AZURE_OPENAI_ENDPOINT);

        // UUID pattern for various IDs
        public const string UUID_PATTERN = @"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}";

        // Base64 image pattern for sanitizing images
        public const string BASE64_IMAGE_PATTERN = @"(?<=data:image/[^;]+;base64,)(.+)";

        // Small 1x1 PNG image for sanitizing base64 images
        public const string SMALL_1x1_PNG = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiQAABYkAZsVxhQAAAAMSURBVBhXY2BgYAAAAAQAAVzN/2kAAAAASUVORK5CYII=";

        /// <summary>
        /// Applies sanitizers to the recording options for Azure.AI.Projects tests.
        /// This method works with Azure.Core.TestFramework RecordedTestBase.
        /// </summary>
        /// <param name="testBase">The RecordedTestBase instance to configure.</param>
        public static void ApplySanitizers<TEnvironment>(RecordedTestBase<TEnvironment> testBase)
            where TEnvironment : TestEnvironment, new()
        {
            if (testBase.Mode == RecordedTestMode.Playback)
            {
                // Older recordings opted into Agent Insights before its feature flag was retired.
                testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Foundry-Features")
                {
                    Regex = LegacyAgentInsightsFeaturePattern,
                    Value = string.Empty
                }));
                // Remove only the obsolete token embedded in the legacy defaults, not explicit Voice opt-ins.
                testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Foundry-Features")
                {
                    Regex = LegacyDefaultVoiceAgentFeaturePattern,
                    Value = LegacyDefaultVoiceAgentFeatureReplacement
                }));
                // Match prior /openai/v1 recordings to the pinned /skills contract without changing live requests.
                testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(new()
                {
                    Regex = LegacySkillsPathPattern,
                    Value = LegacySkillsPathReplacement
                }));
            }

            // Remove default sanitizers that are too restrictive
            testBase.SanitizersToRemove.Add("AZSDK2003"); // Location header (we use a custom one)
            testBase.SanitizersToRemove.Add("AZSDK4001"); // Replaces entire host name (we want to keep structure)
            testBase.SanitizersToRemove.Add("AZSDK3430"); // OpenAI liberally uses "id" in responses, keep them
            testBase.SanitizersToRemove.Add("AZSDK3493"); // OpenAI uses "name" for legitimate purposes

            // URI-based sanitizers for hosts and Azure resource paths
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(HOST_SUBDOMAIN_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(OPENAI_HOST_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AI_SEARCH_HOST_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_SUBSCRIPTION_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_RESOURCE_GROUP_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_ACCOUNT_NAME_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_PROJECT_NAME_PATTERN));
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_CONNECTION_PATTERN_URI));

            // Header sanitizers
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Location")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN.Regex,
                Value = AZURE_SUBSCRIPTION_PATTERN.Value
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Location")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN.Regex,
                Value = AZURE_RESOURCE_GROUP_PATTERN.Value
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Location")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_ACCOUNT_NAME_PATTERN.Value
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Location")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN.Regex,
                Value = AZURE_PROJECT_NAME_PATTERN.Value
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("Azure-AsyncOperation")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN.Regex,
                Value = AZURE_SUBSCRIPTION_PATTERN.Value
            }));

            // JSON body sanitizers for common sensitive fields
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..endpoint")
            {
                Regex = HOST_SUBDOMAIN_PATTERN.Regex,
                Value = HOST_SUBDOMAIN_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target")
            {
                Regex = OPENAI_HOST_PATTERN.Regex,
                Value = OPENAI_HOST_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target")
            {
                Regex = AI_SEARCH_HOST_PATTERN.Regex,
                Value = AI_SEARCH_HOST_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN.Regex,
                Value = AZURE_SUBSCRIPTION_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN.Regex,
                Value = AZURE_RESOURCE_GROUP_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_ACCOUNT_NAME_PATTERN.Value
            }));

            // Sanitize subscription IDs in JSON responses
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..id")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN.Regex,
                Value = AZURE_SUBSCRIPTION_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..id")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN.Regex,
                Value = AZURE_RESOURCE_GROUP_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..id")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_ACCOUNT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..id")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN.Regex,
                Value = AZURE_PROJECT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..id")
            {
                Regex = AZURE_CONNECTION_PATTERN.Regex,
                Value = AZURE_CONNECTION_PATTERN.Value
            }));

            // Sanitize subscription Project Connection Ids in JSON responses
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..project_connection_id")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN.Regex,
                Value = AZURE_SUBSCRIPTION_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..project_connection_id")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN.Regex,
                Value = AZURE_RESOURCE_GROUP_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..project_connection_id")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_ACCOUNT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..project_connection_id")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN.Regex,
                Value = AZURE_PROJECT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..project_connection_id")
            {
                Regex = AZURE_CONNECTION_PATTERN.Regex,
                Value = AZURE_CONNECTION_PATTERN.Value
            }));

            // Sanitize ResourceId metadata field
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..ResourceId")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN.Regex,
                Value = AZURE_SUBSCRIPTION_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..ResourceId")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN.Regex,
                Value = AZURE_RESOURCE_GROUP_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..ResourceId")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_ACCOUNT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..ResourceId")
            {
                Regex = AZURE_STORAGE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_STORAGE_ACCOUNT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..AccountName")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN.Regex,
                Value = AZURE_ACCOUNT_NAME_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..ContainerName")
            {
                Regex = AZURE_CONTAINER_NAME_PATTERN.Regex,
                Value = AZURE_CONTAINER_NAME_PATTERN.Value
            }));

            // Sanitize API keys and credentials using JSONPath
            testBase.JsonPathSanitizers.Add("$..key");
            testBase.JsonPathSanitizers.Add("$..apiKey");
            testBase.JsonPathSanitizers.Add("$..api_key");
            testBase.JsonPathSanitizers.Add("$..connectionString");
            testBase.JsonPathSanitizers.Add("$..APPLICATIONINSIGHTS_CONNECTION_STRING");
            testBase.JsonPathSanitizers.Add("$.definition.image");

            // Sanitize base64 encoded images
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..url")
            {
                Regex = BASE64_IMAGE_PATTERN,
                Value = SMALL_1x1_PNG
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..b64_json")
            {
                Value = SMALL_1x1_PNG
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..image")
            {
                Regex = BASE64_IMAGE_PATTERN,
                Value = SMALL_1x1_PNG
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..AZURE_OPENAI_ENDPOINT")
            {
                Regex = AZURE_OPENAI_ENDPOINT.Regex,
                Value = AZURE_OPENAI_ENDPOINT.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..AGENT_PROJECT_RESOURCE_ID")
            {
                Regex = HOST_SUBDOMAIN_PATTERN.Regex,
                Value = HOST_SUBDOMAIN_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..AGENT_PROJECT_RESOURCE_ID")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN.Regex,
                Value = AZURE_PROJECT_NAME_PATTERN.Value
            }));

            // Sanitize Variables section PROJECT_ENDPOINT
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$.Variables.PROJECT_ENDPOINT")
            {
                Regex = HOST_SUBDOMAIN_PATTERN.Regex,
                Value = HOST_SUBDOMAIN_PATTERN.Value
            }));
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$.Variables.PROJECT_ENDPOINT")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN.Regex,
                Value = AZURE_PROJECT_NAME_PATTERN.Value
            }));

            // Sanitize the pass_threshold to avoid issues with float representation
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..initialization_parameters.pass_threshold")
            {
                Regex = @"\d+[.]\d+",
                Value = "[Sanitized]"
            }));

            // Sanitize UUIDs in request IDs and operation IDs
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("apim-request-id")
            {
                Regex = UUID_PATTERN,
                Value = "00000000-0000-0000-0000-000000000000"
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("x-ms-client-request-id")
            {
                Regex = UUID_PATTERN,
                Value = "00000000-0000-0000-0000-000000000000"
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("model-api-key")
            {
                Regex = @"\w+",
                Value = "Sanitized"
            }));
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new("model-endpoint")
            {
                Regex = @"(?<=https://)([^/]+)(?=[.]openai[.]azure[.]com/|$)",
                Value = "sanitized"
            }));
        }

        private static UriRegexSanitizerBody BodySanitizer(string regex, string value)
        {
            UriRegexSanitizerBody rv = new()
            {
                Regex = regex,
                Value = value,
            };
            return rv;
        }
    }
}
