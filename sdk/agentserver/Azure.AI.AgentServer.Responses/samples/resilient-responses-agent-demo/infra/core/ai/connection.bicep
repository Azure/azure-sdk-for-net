targetScope = 'resourceGroup'

@description('AI Services account name')
param aiServicesAccountName string

@description('AI project name')
param aiProjectName string

// Connection configuration type definition
type ConnectionConfig = {
  @description('Name of the connection')
  name: string

  @description('Category of the connection (e.g., ContainerRegistry, AzureStorageAccount, CognitiveSearch, AzureOpenAI)')
  category: string

  @description('Target endpoint or URL for the connection')
  target: string

  @description('Authentication type')
  authType: 'AAD' | 'AccessKey' | 'AccountKey' | 'AgenticIdentity' | 'ApiKey' | 'CustomKeys' | 'ManagedIdentity' | 'None' | 'OAuth2' | 'PAT' | 'SAS' | 'ServicePrincipal' | 'UsernamePassword' | 'UserEntraToken' | 'ProjectManagedIdentity'

  @description('Whether the connection is shared to all users (optional, defaults to true)')
  isSharedToAll: bool?

  @description('Additional metadata for the connection (optional)')
  metadata: object?

  @description('Error message if the connection fails (optional)')
  error: string?

  @description('Expiry time for the connection (optional)')
  expiryTime: string?

  @description('Private endpoint requirement: Required, NotRequired, or NotApplicable (optional)')
  peRequirement: ('NotApplicable' | 'NotRequired' | 'Required')?

  @description('Private endpoint status: Active, Inactive, or NotApplicable (optional)')
  peStatus: ('Active' | 'Inactive' | 'NotApplicable')?

  @description('List of users to share the connection with (optional, alternative to isSharedToAll)')
  sharedUserList: string[]?

  @description('Whether to use workspace managed identity (optional)')
  useWorkspaceManagedIdentity: bool?

  @description('OAuth2 authorization endpoint URL (optional, OAuth2 authType only)')
  authorizationUrl: string?

  @description('OAuth2 token endpoint URL (optional, OAuth2 authType only)')
  tokenUrl: string?

  @description('OAuth2 refresh token endpoint URL (optional, OAuth2 authType only)')
  refreshUrl: string?

  @description('OAuth2 scopes to request (optional, OAuth2 authType only)')
  scopes: string[]?

  @description('Token audience for UserEntraToken / AgenticIdentity auth types (optional)')
  audience: string?

  @description('Managed connector name for OAuth2 managed connectors (optional)')
  connectorName: string?
}

@description('Connection configuration')
param connectionConfig ConnectionConfig

@secure()
@description('Credentials for the connection. Kept as a separate @secure parameter to prevent secrets from appearing in deployment logs. Shape depends on authType — e.g. { key: "..." } for ApiKey, { clientId: "...", clientSecret: "..." } for OAuth2/ServicePrincipal.')
param credentials object = {}


// Get reference to the AI Services account and project
resource aiAccount 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' existing = {
  name: aiServicesAccountName

  resource project 'projects' existing = {
    name: aiProjectName
  }
}

// Create the connection
resource connection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-04-01-preview' = {
  parent: aiAccount::project
  name: connectionConfig.name
  properties: {
    category: connectionConfig.category
    target: connectionConfig.target
    authType: connectionConfig.authType
    isSharedToAll: connectionConfig.?isSharedToAll ?? true
    credentials: !empty(credentials) ? credentials : null
    metadata: connectionConfig.?metadata
    // Only include if they appear in the connectionConfig
    ...connectionConfig.?error != null ? { error: connectionConfig.?error  } : {}
    ...connectionConfig.?expiryTime != null ? { expiryTime: connectionConfig.?expiryTime  } : {}
    ...connectionConfig.?peRequirement != null ? { peRequirement: connectionConfig.?peRequirement  } : {}
    ...connectionConfig.?peStatus != null ? { peStatus: connectionConfig.?peStatus  } : {}
    ...connectionConfig.?sharedUserList != null ? { sharedUserList: connectionConfig.?sharedUserList  } : {}
    ...connectionConfig.?useWorkspaceManagedIdentity != null ? { useWorkspaceManagedIdentity: connectionConfig.?useWorkspaceManagedIdentity  } : {}
    ...connectionConfig.?authorizationUrl != null ? { authorizationUrl: connectionConfig.?authorizationUrl } : {}
    ...connectionConfig.?tokenUrl != null ? { tokenUrl: connectionConfig.?tokenUrl } : {}
    ...connectionConfig.?refreshUrl != null ? { refreshUrl: connectionConfig.?refreshUrl } : {}
    ...connectionConfig.?scopes != null ? { scopes: connectionConfig.?scopes } : {}
    ...connectionConfig.?audience != null ? { audience: connectionConfig.?audience } : {}
    ...connectionConfig.?connectorName != null ? { connectorName: connectionConfig.?connectorName } : {}
  }
}

// Outputs
output connectionName string = connection.name
output connectionId string = connection.id
