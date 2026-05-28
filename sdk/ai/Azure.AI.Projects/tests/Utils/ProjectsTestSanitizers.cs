// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.Projects.Tests.Utils
{
    /// <summary>
    /// Provides sanitization configuration for Azure.AI.Projects test recordings.
    /// This class centralizes all sanitization patterns and replacement values.
    /// </summary>
    public static class ProjectsTestSanitizers
    {
        // Common patterns for sanitization
        public const string AZURE_SUBSCRIPTION_PATTERN = @"(?<=/subscriptions/)([^/]+)(?=/)";
        public const string AZURE_RESOURCE_GROUP_PATTERN = @"(?<=/resourceGroups/)([^/]+)(?=/)";
        public const string AZURE_ACCOUNT_NAME_PATTERN = @"(?<=/accounts/)([^/]+)(?=/|$)";
        public const string AZURE_STORAGE_ACCOUNT_NAME_PATTERN = @"(?<=/storageAccounts/)([^/]+)(?=/|$)";
        public const string AZURE_PROJECT_NAME_PATTERN = @"(?<=/projects/)([^/]+)(?=[/?]|$)";
        public const string HOST_SUBDOMAIN_PATTERN = @"(?<=https://)([^.]+)(?=\.services\.ai\.azure\.com)";
        public const string OPENAI_HOST_PATTERN = @"(?<=https://)([^.]+)(?=\.openai\.azure\.com)";
        public const string AI_SEARCH_HOST_PATTERN = @"(?<=https://)([^.]+)(?=\.search\.windows\.net)";
        public const string AZURE_CONTAINER_NAME_PATTERN = @"\d+dp[^/\s]*container";

        // UUID pattern for various IDs
        public const string UUID_PATTERN = @"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}";

        // Base64 image pattern for sanitizing images
        public const string BASE64_IMAGE_PATTERN = @"(?<=data:image/[^;]+;base64,)(.+)";

        // Replacement values
        public const string SANITIZED_VALUE = "***";
        public const string SANITIZED_SUBSCRIPTION = "00000000-0000-0000-0000-000000000000";
        public const string SANITIZED_HOST = "sanitized-host";
        public const string SANITIZED_PROJECT = "sanitized-project";
        public const string SANITIZED_ACCOUNT = "sanitized-account";
        public const string SANITIZED_STORAGE_ACCOUNT = "sanitized-storage-account";
        public const string SANITIZED_RESOURCE_GROUP = "sanitized-rg";
        public const string SANITIZED_CONTAINER = "sanitized-container";

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
            // Remove default sanitizers that are too restrictive
            testBase.SanitizersToRemove.Add("AZSDK2003"); // Location header (we use a custom one)
            testBase.SanitizersToRemove.Add("AZSDK4001"); // Replaces entire host name (we want to keep structure)
            testBase.SanitizersToRemove.Add("AZSDK3430"); // OpenAI liberally uses "id" in responses, keep them
            testBase.SanitizersToRemove.Add("AZSDK3493"); // OpenAI uses "name" for legitimate purposes

            // URI-based sanitizers for hosts and Azure resource paths
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(HOST_SUBDOMAIN_PATTERN) { Value = SANITIZED_HOST });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(OPENAI_HOST_PATTERN) { Value = SANITIZED_HOST });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AI_SEARCH_HOST_PATTERN) { Value = SANITIZED_HOST });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_SUBSCRIPTION_PATTERN) { Value = SANITIZED_SUBSCRIPTION });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_RESOURCE_GROUP_PATTERN) { Value = SANITIZED_RESOURCE_GROUP });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_ACCOUNT_NAME_PATTERN) { Value = SANITIZED_ACCOUNT });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(AZURE_PROJECT_NAME_PATTERN) { Value = SANITIZED_PROJECT });

            // Header sanitizers
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN,
                Value = SANITIZED_SUBSCRIPTION
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN,
                Value = SANITIZED_RESOURCE_GROUP
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN,
                Value = SANITIZED_ACCOUNT
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN,
                Value = SANITIZED_PROJECT
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Azure-AsyncOperation")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN,
                Value = SANITIZED_SUBSCRIPTION
            });

            // JSON body sanitizers for common sensitive fields
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..endpoint")
            {
                Regex = HOST_SUBDOMAIN_PATTERN,
                Value = SANITIZED_HOST
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..target")
            {
                Regex = OPENAI_HOST_PATTERN,
                Value = SANITIZED_HOST
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..target")
            {
                Regex = AI_SEARCH_HOST_PATTERN,
                Value = SANITIZED_HOST
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..target")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN,
                Value = SANITIZED_SUBSCRIPTION
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..target")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN,
                Value = SANITIZED_RESOURCE_GROUP
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..target")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN,
                Value = SANITIZED_ACCOUNT
            });

            // Sanitize subscription IDs in JSON responses
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..id")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN,
                Value = SANITIZED_SUBSCRIPTION
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..id")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN,
                Value = SANITIZED_RESOURCE_GROUP
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..id")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN,
                Value = SANITIZED_ACCOUNT
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..id")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN,
                Value = SANITIZED_PROJECT
            });

            // Sanitize ResourceId metadata field
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..ResourceId")
            {
                Regex = AZURE_SUBSCRIPTION_PATTERN,
                Value = SANITIZED_SUBSCRIPTION
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..ResourceId")
            {
                Regex = AZURE_RESOURCE_GROUP_PATTERN,
                Value = SANITIZED_RESOURCE_GROUP
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..ResourceId")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN,
                Value = SANITIZED_ACCOUNT
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..ResourceId")
            {
                Regex = AZURE_STORAGE_ACCOUNT_NAME_PATTERN,
                Value = SANITIZED_STORAGE_ACCOUNT
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..AccountName")
            {
                Regex = AZURE_ACCOUNT_NAME_PATTERN,
                Value = SANITIZED_ACCOUNT
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..ContainerName")
            {
                Regex = AZURE_CONTAINER_NAME_PATTERN,
                Value = SANITIZED_CONTAINER
            });

            // Sanitize API keys and credentials using JSONPath
            testBase.JsonPathSanitizers.Add("$..key");
            testBase.JsonPathSanitizers.Add("$..apiKey");
            testBase.JsonPathSanitizers.Add("$..api_key");
            testBase.JsonPathSanitizers.Add("$..connectionString");

            // Sanitize base64 encoded images
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..url")
            {
                Regex = BASE64_IMAGE_PATTERN,
                Value = SMALL_1x1_PNG
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..b64_json")
            {
                Value = SMALL_1x1_PNG
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$..image")
            {
                Regex = BASE64_IMAGE_PATTERN,
                Value = SMALL_1x1_PNG
            });

            // Sanitize Variables section PROJECT_ENDPOINT
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$.Variables.PROJECT_ENDPOINT")
            {
                Regex = HOST_SUBDOMAIN_PATTERN,
                Value = SANITIZED_HOST
            });
            testBase.BodyKeySanitizers.Add(new BodyKeySanitizer("$.Variables.PROJECT_ENDPOINT")
            {
                Regex = AZURE_PROJECT_NAME_PATTERN,
                Value = SANITIZED_PROJECT
            });

            // Sanitize UUIDs in request IDs and operation IDs
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("apim-request-id")
            {
                Regex = UUID_PATTERN,
                Value = "00000000-0000-0000-0000-000000000000"
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-client-request-id")
            {
                Regex = UUID_PATTERN,
                Value = "00000000-0000-0000-0000-000000000000"
            });

            // Handle multipart form data boundaries
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Content-Type")
            {
                Regex = @"multipart/form-data; boundary=[^\s]+",
                Value = "multipart/form-data; boundary=***"
            });
        }
    }
}
