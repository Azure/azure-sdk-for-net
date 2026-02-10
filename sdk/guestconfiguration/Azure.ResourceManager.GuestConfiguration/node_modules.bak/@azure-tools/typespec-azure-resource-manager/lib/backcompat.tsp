using Azure.ResourceManager.CommonTypes;

namespace Azure.ResourceManager;

// customer-managed-keys
alias InfrastructureEncryption = CommonTypes.InfrastructureEncryption;
alias KeyEncryptionIdentity = CommonTypes.KeyEncryptionKeyIdentity;
alias KeyEncryptionKeyIdentity = CommonTypes.KeyEncryptionKeyIdentity;
alias CustomerManagedKeyEncryption = CommonTypes.CustomerManagedKeyEncryption;
alias EncryptionConfiguration = CommonTypes.Encryption;

// private-links
alias PrivateEndpoint = CommonTypes.PrivateEndpoint;
alias PrivateEndpointConnection = CommonTypes.PrivateEndpointConnection;
alias PrivateEndpointConnectionProperties = CommonTypes.PrivateEndpointConnectionProperties;
alias PrivateLinkServiceConnectionState = CommonTypes.PrivateLinkServiceConnectionState;
alias PrivateEndpointConnectionProvisioningState = CommonTypes.PrivateEndpointConnectionProvisioningState;
alias PrivateEndpointServiceConnectionStatus = CommonTypes.PrivateEndpointServiceConnectionStatus;
alias PrivateEndpointConnectionParameter = CommonTypes.PrivateEndpointConnectionParameter;
alias PrivateLinkResource = CommonTypes.PrivateLinkResource;
alias PrivateLinkResourceProperties = CommonTypes.PrivateLinkResourceProperties;
alias PrivateLinkResourceParameter = CommonTypes.PrivateLinkResourceParameter;
alias PrivateEndpointConnectionResourceListResult = CommonTypes.PrivateEndpointConnectionListResult;
#suppress "deprecated" "Need for back compatibility in common-types"
alias PrivateEndpointConnectionResourceListResultV5 = CommonTypes.PrivateEndpointConnectionListResultV5;
alias PrivateLinkResourceListResult = CommonTypes.PrivateLinkResourceListResult;
#suppress "deprecated" "Need for back compatibility in common-types"
alias PrivateLinkResourceListResultV5 = CommonTypes.PrivateLinkResourceListResultV5;

// types
alias ErrorResponse = CommonTypes.ErrorResponse;
