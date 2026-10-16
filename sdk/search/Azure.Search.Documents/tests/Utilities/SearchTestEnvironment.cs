// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Gets variables created from test-resources.json.
    /// </summary>
    public class SearchTestEnvironment : TestEnvironment
    {
        public string StorageResourceId => GetRecordedVariable("SEARCH_STORAGE_RESOURCE_ID");

        public bool RunDoubleEncryptedIndex =>
            IsDoubleEncryptedIndexEnabled(GetOptionalVariable("RUN_DOUBLE_ENCRYPTED_INDEX"));

        internal static bool IsDoubleEncryptedIndexEnabled(string value) =>
            string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);

        public void ValidateDoubleEncryptedIndexConfiguration() =>
            ValidateDoubleEncryptedIndexConfiguration(GetOptionalVariable);

        internal static void ValidateDoubleEncryptedIndexConfiguration(Func<string, string> getVariable)
        {
            string serviceName = getVariable("SEARCH_SERVICE_NAME");
            string storageName = getVariable("SEARCH_STORAGE_NAME");
            string storageResourceId = getVariable("SEARCH_STORAGE_RESOURCE_ID");
            string keyVaultUrl = getVariable("SEARCH_KEYVAULT_URL");
            List<string> errors = new List<string>();

            Require(serviceName, "SEARCH_SEARCH_SERVICE_NAME");
            Require(storageName, "SEARCH_SEARCH_STORAGE_NAME");
            Require(storageResourceId, "SEARCH_SEARCH_STORAGE_RESOURCE_ID");
            Require(keyVaultUrl, "SEARCH_SEARCH_KEYVAULT_URL");

            if (!string.IsNullOrWhiteSpace(keyVaultUrl) &&
                (!Uri.TryCreate(keyVaultUrl, UriKind.Absolute, out Uri vaultUri) || vaultUri.Scheme != Uri.UriSchemeHttps))
            {
                errors.Add("SEARCH_SEARCH_KEYVAULT_URL must be an absolute HTTPS vault URL.");
            }

            if (!string.IsNullOrWhiteSpace(storageResourceId))
            {
                Match match = Regex.Match(
                    storageResourceId,
                    @"^/subscriptions/[^/]+/resourceGroups/[^/]+/providers/Microsoft\.Storage/storageAccounts/([^/]+)$",
                    RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    errors.Add("SEARCH_SEARCH_STORAGE_RESOURCE_ID must be the full ARM resource ID of a storage account.");
                }
                else if (!string.IsNullOrWhiteSpace(storageName) &&
                    !string.Equals(match.Groups[1].Value, storageName, StringComparison.OrdinalIgnoreCase))
                {
                    errors.Add("SEARCH_SEARCH_STORAGE_RESOURCE_ID must identify SEARCH_SEARCH_STORAGE_NAME.");
                }
            }

            if (errors.Count > 0)
            {
                throw new InvalidOperationException(
                    "CreateDoubleEncryptedIndex configuration is invalid:" + Environment.NewLine +
                    string.Join(Environment.NewLine, errors) + Environment.NewLine +
                    "Load the package .env into the test process using tests\\Set-RecordingEnvironment.ps1. " +
                    "See tests\\README.md#customer-managed-encryption-test for resources, role scopes, and recording commands. " +
                    "No test resources have been created.");
            }

            void Require(string value, string name)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    errors.Add($"Missing {name}.");
                }
            }
        }

        public override TokenCredential Credential => Mode != RecordedTestMode.Playback && !GlobalIsRunningInCI
            ? CreateDeveloperCredential()
            : base.Credential;

        protected override TokenCredential CreateDeveloperCredential() =>
            new AzureCliCredential(new AzureCliCredentialOptions { TenantId = GetOptionalVariable("TENANT_ID") });

        /// <summary>
        /// The name of the variable for <see cref="RecordedClientSecret"/>.
        /// </summary>
        public const string ClientSecretVariableName = "CLIENT_SECRET";

        /// <summary>
        /// The name of the variable for <see cref="SearchServiceName"/>.
        /// </summary>
        public const string SearchServiceNameVariableName = "SEARCH_SERVICE_NAME";

        /// <summary>
        /// The name of the variable for <see cref="SearchAdminKey"/>.
        /// </summary>
        public const string SearchAdminKeyVariableName = "SEARCH_ADMIN_API_KEY";

        /// <summary>
        /// The name of the variable for <see cref="SearchQueryKey"/>.
        /// </summary>
        public const string SearchQueryKeyVariableName = "SEARCH_QUERY_API_KEY";

        /// <summary>
        /// The name of the variable for <see cref="SearchStorageKey"/>.
        /// </summary>
        public const string StorageAccountKeyVariableName = "SEARCH_STORAGE_KEY";

        /// <summary>
        /// The name of the variable for <see cref="SearchStorageName"/>.
        /// </summary>
        public const string StorageAccountNameVariableName = "SEARCH_STORAGE_NAME";

        /// <summary>
        /// The name of the variable for <see cref="SearchCognitiveKey"/>.
        /// </summary>
        public const string CognitiveKeyVariableName = "SEARCH_COGNITIVE_KEY";

        /// <summary>
        /// The name of the variable for <see cref="OpenAIKeyVariableName"/>.
        /// </summary>
        public const string OpenAIKeyVariableName = "OPENAI_KEY";

        /// <summary>
        /// Gets the service name.
        /// </summary>
        public string SearchServiceName => GetRecordedVariable(SearchServiceNameVariableName);

        /// <summary>
        /// Gets the admin key (read-write).
        /// </summary>
        public string SearchAdminKey => GetRecordedVariable(SearchAdminKeyVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the query key (read-only).
        /// </summary>
        public string SearchQueryKey => GetRecordedVariable(SearchQueryKeyVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the name of the storage account for external data sources.
        /// </summary>
        public string SearchStorageName => GetRecordedVariable(StorageAccountNameVariableName);

        /// <summary>
        /// Gets the storage account key for external data sources.
        /// </summary>
        public string SearchStorageKey => GetRecordedVariable(StorageAccountKeyVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the Cognitive Services key for skillsets.
        /// </summary>
        public string SearchCognitiveKey => GetRecordedVariable(CognitiveKeyVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the Cognitive Services endpoint.
        /// </summary>
        public string SearchCognitiveEndpoint => GetRecordedOptionalVariable("SEARCH_COGNITIVE_ENDPOINT");

        /// <summary>
        /// Gets the search service suffix.
        /// </summary>
        public string SearchEndpointSuffix => GetRecordedOptionalVariable("SEARCH_ENDPOINT_SUFFIX") ?? "search.windows.net";

        /// <summary>
        /// Gets the optional Key Vault URL used for double-encrypted indexes.
        /// </summary>
        public string KeyVaultUrl => GetRecordedOptionalVariable("SEARCH_KEYVAULT_URL");

        /// <summary>
        /// Gets the recorded value for the CLIENT_ID, which gets sanitized as part of the payload.
        /// </summary>
        public string RecordedClientSecret => GetRecordedVariable(ClientSecretVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the optional OpenAI URL used used for Vector Search.
        /// </summary>
        public string OpenAIEndpoint => GetRecordedOptionalVariable("OPENAI_ENDPOINT");

        /// <summary>
        /// Gets the optional query source authorization token for external knowledge sources
        /// (e.g. Work IQ, Fabric Ontology, Fabric Data Agent).
        /// </summary>
        public string QuerySourceAuthorization => GetRecordedOptionalVariable("SEARCH_QUERY_SOURCE_AUTH", options => options.IsSecret());

        /// <summary>
        /// Gets the optional Microsoft Fabric workspace ID.
        /// </summary>
        public string FabricWorkspaceId => GetRecordedOptionalVariable("SEARCH_FABRIC_WORKSPACE_ID");

        /// <summary>
        /// Gets the optional Fabric Ontology ID.
        /// </summary>
        public string FabricOntologyId => GetRecordedOptionalVariable("SEARCH_FABRIC_ONTOLOGY_ID");

        /// <summary>
        /// Gets the optional Fabric Data Agent ID.
        /// </summary>
        public string FabricDataAgentId => GetRecordedOptionalVariable("SEARCH_FABRIC_DATA_AGENT_ID");

        /// <summary>
        /// Gets the environment of the Azure resource group to be used for Live tests (e.g. AzureCloud).
        /// Returns "AzureCloud" as default if the ENVIRONMENT variable is not set.
        /// </summary>
        public new string AzureEnvironment => GetRecordedOptionalVariable("ENVIRONMENT") ?? "AzureCloud";
    }
}
