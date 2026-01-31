// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Gets variables created from test-resources.json.
    /// </summary>
    public class SearchTestEnvironment: TestEnvironment
    {
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
        /// Gets the optional OpenAI key
        /// </summary>
        public string OpenAIKey => GetRecordedOptionalVariable(OpenAIKeyVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the optional OpenAI URL used used for Vector Search.
        /// </summary>
        public string OpenAIEndpoint => GetRecordedOptionalVariable("OPENAI_ENDPOINT");

        /// <summary>
        /// Gets the environment of the Azure resource group to be used for Live tests (e.g. AzureCloud).
        /// Returns "AzureCloud" as default if the ENVIRONMENT variable is not set.
        /// </summary>
        public new string AzureEnvironment => GetRecordedOptionalVariable("ENVIRONMENT") ?? "AzureCloud";
    }
}
