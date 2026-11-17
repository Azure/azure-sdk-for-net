// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// cspell:ignore hnsw vectorizer vectorizers

param location string
param accountName string
param projectName string
param storageAccountName string
param searchServiceName string
param sharedSearchIdentityResourceId string
param ownerToken string

@minLength(1)
param indexName string = 'sample_index'
@minLength(3)
param containerName string = 'documents'

resource storage 'Microsoft.Storage/storageAccounts@2023-05-01' existing = {
  name: storageAccountName
}
resource blobService 'Microsoft.Storage/storageAccounts/blobServices@2023-05-01' existing = {
  parent: storage
  name: 'default'
}
resource documents 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-05-01' = {
  parent: blobService
  name: containerName
  properties: {
    publicAccess: 'None'
  }
}
resource account 'Microsoft.CognitiveServices/accounts@2025-10-01-preview' existing = {
  name: accountName
}
resource project 'Microsoft.CognitiveServices/accounts/projects@2025-10-01-preview' existing = {
  parent: account
  name: projectName
}
resource search 'Microsoft.Search/searchServices@2024-06-01-preview' existing = {
  name: searchServiceName
}
resource embedding 'Microsoft.CognitiveServices/accounts/deployments@2025-10-01-preview' = {
  parent: account
  name: 'text-embedding-3-small'
  sku: {
    name: 'GlobalStandard'
    capacity: 10
  }
  properties: {
    model: {
      format: 'OpenAI'
      name: 'text-embedding-3-small'
      version: '1'
    }
    versionUpgradeOption: 'NoAutoUpgrade'
  }
}

var dimensions = 1536
var searchEndpoint = 'https://${search.name}.search.windows.net'
var embeddingEndpoint = 'https://${account.name}.openai.azure.com'
var indexingPrefix = replace(indexName, '_', '-')
var datasourceName = '${indexingPrefix}-datasource'
var skillsetName = '${indexingPrefix}-skillset'
var searchIdentity = {
  '@odata.type': '#Microsoft.Azure.Search.DataUserAssignedIdentity'
  userAssignedIdentity: sharedSearchIdentityResourceId
}
var embeddingParameters = {
  resourceUri: embeddingEndpoint
  deploymentId: embedding.name
  modelName: 'text-embedding-3-small'
  authIdentity: searchIdentity
}
var index = {
  name: indexName
  fields: [
    { name: 'chunk_id', type: 'Edm.String', key: true, searchable: true, analyzer: 'keyword' }
    { name: 'parent_id', type: 'Edm.String', filterable: true }
    { name: 'chunk', type: 'Edm.String', searchable: true, retrievable: true }
    { name: 'title', type: 'Edm.String', retrievable: true }
    { name: 'category', type: 'Edm.String', filterable: true, retrievable: true }
    {
      name: 'text_vector'
      type: 'Collection(Edm.Single)'
      searchable: true
      dimensions: dimensions
      vectorSearchProfile: 'embedding_config'
    }
  ]
  vectorSearch: {
    algorithms: [{ name: 'embed-algorithms-config', kind: 'hnsw' }]
    profiles: [{
      name: 'embedding_config'
      algorithm: 'embed-algorithms-config'
      vectorizer: 'search_vectorizer'
    }]
    vectorizers: [{
      name: 'search_vectorizer'
      kind: 'azureOpenAI'
      azureOpenAIParameters: embeddingParameters
    }]
  }
  semantic: {
    defaultConfiguration: 'semantic_search'
    configurations: [{
      name: 'semantic_search'
      prioritizedFields: {
        titleField: { fieldName: 'title' }
        prioritizedContentFields: [{ fieldName: 'chunk' }]
      }
    }]
  }
}
var skillset = {
  name: skillsetName
  skills: [
    {
      '@odata.type': '#Microsoft.Skills.Text.SplitSkill'
      name: 'document_chunking_skill'
      context: '/document'
      textSplitMode: 'pages'
      maximumPageLength: 2000
      pageOverlapLength: 500
      inputs: [{ name: 'text', source: '/document/content' }]
      outputs: [{ name: 'textItems', targetName: 'pages' }]
    }
    {
      '@odata.type': '#Microsoft.Skills.Text.AzureOpenAIEmbeddingSkill'
      name: 'embedding_generation_skill'
      context: '/document/pages/*'
      resourceUri: embeddingEndpoint
      deploymentId: embedding.name
      modelName: 'text-embedding-3-small'
      authIdentity: searchIdentity
      dimensions: dimensions
      inputs: [{ name: 'text', source: '/document/pages/*' }]
      outputs: [{ name: 'embedding', targetName: 'text_vector' }]
    }
  ]
  indexProjections: {
    selectors: [{
      targetIndexName: indexName
      parentKeyFieldName: 'parent_id'
      sourceContext: '/document/pages/*'
      mappings: [
        { name: 'text_vector', source: '/document/pages/*/text_vector' }
        { name: 'chunk', source: '/document/pages/*' }
        { name: 'title', source: '/document/title' }
        { name: 'category', source: '/document/category' }
      ]
    }]
    parameters: { projectionMode: 'skipIndexingParentDocuments' }
  }
}
var indexers = [for format in [
  { suffix: 'markdown', extensions: '.md', parsingMode: 'markdown' }
  { suffix: 'documents', extensions: '.pdf,.docx,.pptx,.xlsx,.txt', parsingMode: 'default' }
]: {
  name: '${indexingPrefix}-${format.suffix}-indexer'
  dataSourceName: datasourceName
  targetIndexName: indexName
  skillsetName: skillsetName
  fieldMappings: [
    { sourceFieldName: 'metadata_storage_name', targetFieldName: 'title' }
    { sourceFieldName: 'category', targetFieldName: 'category' }
  ]
  parameters: {
    batchSize: 10
    maxFailedItems: 0
    maxFailedItemsPerBatch: 0
    configuration: {
      parsingMode: format.parsingMode
      indexedFileNameExtensions: format.extensions
      allowSkillsetToReadFileData: format.parsingMode == 'default'
    }
  }
}]

// Search objects and blob uploads are data-plane operations, not ARM resources.
// The existing Search UAMI has bootstrap-owned grants; this module writes no IAM.
resource indexing 'Microsoft.Resources/deploymentScripts@2023-08-01' = {
  name: 'ai-search-indexing'
  location: location
  kind: 'AzureCLI'
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${sharedSearchIdentityResourceId}': {}
    }
  }
  properties: {
    azCliVersion: '2.76.0'
    timeout: 'PT30M'
    retentionInterval: 'P1D'
    cleanupPreference: 'Always'
    forceUpdateTag: ownerToken
    environmentVariables: [{
      name: 'SEARCH_INDEXING_CONFIGURATION'
      value: string({
        searchEndpoint: searchEndpoint
        storageEndpoint: storage.properties.primaryEndpoints.blob
        containerName: documents.name
        blobs: [
          { name: 'product_info.md', content: loadTextContent('../search_documents/product_info.md') }
          { name: 'product_info.txt', content: loadTextContent('../search_documents/product_info.md') }
        ]
        index: index
        datasource: {
          name: datasourceName
          type: 'azureblob'
          credentials: { connectionString: 'ResourceId=${storage.id};' }
          container: { name: documents.name }
          identity: searchIdentity
        }
        skillset: skillset
        indexers: indexers
      })
    }]
    scriptContent: format('''set -euo pipefail
python3 - <<'PY'
{0}
PY
''', loadTextContent('./search-indexing.py'))
  }
}

output environment object = {
  AZURE_AI_SEARCH_ENDPOINT: searchEndpoint
  AI_SEARCH_PROJECT_CONNECTION_ID: '${project.id}/connections/${search.name}'
  AI_SEARCH_INDEX_NAME: indexName
  AZURE_AI_EMBED_DEPLOYMENT_NAME: embedding.name
  AZURE_AI_EMBED_DIMENSIONS: string(dimensions)
  AZURE_BLOB_CONTAINER_NAME: documents.name
  AI_SEARCH_USER_INPUT: 'What is the temperature rating of the cozynights sleeping bag?'
}
