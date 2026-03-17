// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Creates credential instances for a ChainedTokenCredential from configuration.
    /// Each source in the chain is a full credential configuration object (DefaultAzureCredentialOptions)
    /// with its own CredentialSource and properties. Credentials are constructed directly using
    /// their public constructors with credential-specific options rather than routing through
    /// DefaultAzureCredentialFactory.
    /// </summary>
    internal static class ChainedTokenCredentialFactory
    {
        private static readonly string s_validSources =
            $"'{Constants.AzureCliCredential}', '{Constants.AzureDeveloperCliCredential}', " +
            $"'{Constants.AzurePipelinesCredential}', '{Constants.AzurePowerShellCredential}', " +
            $"'{Constants.BrokerCredential}', '{Constants.EnvironmentCredential}', " +
            $"'{Constants.InteractiveBrowserCredential}', '{Constants.ManagedIdentityCredential}', " +
            $"'{Constants.ManagedIdentityAsFederatedIdentityCredential}', '{Constants.VisualStudioCredential}', " +
            $"'{Constants.VisualStudioCodeCredential}', '{Constants.WorkloadIdentityCredential}'";

        /// <summary>
        /// Creates an array of TokenCredential instances from the Sources in the parent options.
        /// </summary>
        internal static TokenCredential[] CreateCredentialChain(DefaultAzureCredentialOptions parentOptions)
        {
            var sources = parentOptions.Sources;

            if (sources is not { Length: > 0 })
            {
                throw new InvalidOperationException("Sources must be specified when CredentialSource is 'ChainedTokenCredential'.");
            }

            var chain = new TokenCredential[sources.Length];

            for (int i = 0; i < sources.Length; i++)
            {
                chain[i] = CreateCredential(sources[i]);
            }

            return chain;
        }

        private static TokenCredential CreateCredential(DefaultAzureCredentialOptions source)
        {
            var credentialSource = source.CredentialSource;

            if (credentialSource == null)
            {
                throw new InvalidOperationException("Each source in a ChainedTokenCredential configuration must specify a CredentialSource.");
            }

            if (credentialSource == Constants.ApiKeyCredential)
            {
                throw new InvalidOperationException("ApiKeyCredential cannot be used in a chained credential configuration because it is not a token-based credential.");
            }

            if (credentialSource == Constants.ChainedTokenCredential)
            {
                throw new InvalidOperationException("ChainedTokenCredential cannot be nested inside a chained credential configuration.");
            }

            return credentialSource switch
            {
                Constants.AzureCliCredential => CreateAzureCliCredential(source),
                Constants.AzurePowerShellCredential => CreateAzurePowerShellCredential(source),
                Constants.AzureDeveloperCliCredential => CreateAzureDeveloperCliCredential(source),
                Constants.VisualStudioCredential => CreateVisualStudioCredential(source),
                Constants.VisualStudioCodeCredential => CreateVisualStudioCodeCredential(source),
                Constants.EnvironmentCredential => CreateEnvironmentCredential(source),
                Constants.WorkloadIdentityCredential => CreateWorkloadIdentityCredential(source),
                Constants.ManagedIdentityCredential => CreateManagedIdentityCredential(source),
                Constants.InteractiveBrowserCredential => CreateInteractiveBrowserCredential(source),
                Constants.BrokerCredential => CreateBrokerCredential(source),
                Constants.AzurePipelinesCredential => CreateAzurePipelinesCredential(source),
                Constants.ManagedIdentityAsFederatedIdentityCredential => CreateManagedIdentityAsFederatedIdentityCredential(source),
                _ => throw new InvalidOperationException($"Unsupported CredentialSource in Sources: '{credentialSource}'. Valid values are {s_validSources}.")
            };
        }

        private static TokenCredential CreateAzureCliCredential(DefaultAzureCredentialOptions source)
        {
            var options = new AzureCliCredentialOptions();
            options.TenantId = source.TenantId;
            options.ProcessTimeout = source.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            if (!string.IsNullOrEmpty(source.Subscription))
            {
                options.Subscription = source.Subscription;
            }

            CopyAdditionallyAllowedTenants(source, options);
            return new AzureCliCredential(options);
        }

        private static TokenCredential CreateAzurePowerShellCredential(DefaultAzureCredentialOptions source)
        {
            var options = new AzurePowerShellCredentialOptions();
            options.TenantId = source.TenantId;
            options.ProcessTimeout = source.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            CopyAdditionallyAllowedTenants(source, options);
            return new AzurePowerShellCredential(options);
        }

        private static TokenCredential CreateAzureDeveloperCliCredential(DefaultAzureCredentialOptions source)
        {
            var options = new AzureDeveloperCliCredentialOptions();
            options.TenantId = source.TenantId;
            options.ProcessTimeout = source.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            CopyAdditionallyAllowedTenants(source, options);
            return new AzureDeveloperCliCredential(options);
        }

        private static TokenCredential CreateVisualStudioCredential(DefaultAzureCredentialOptions source)
        {
            var options = new VisualStudioCredentialOptions();
            options.TenantId = source.TenantId;
            options.ProcessTimeout = source.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            CopyAdditionallyAllowedTenants(source, options);
            return new VisualStudioCredential(options);
        }

        private static TokenCredential CreateVisualStudioCodeCredential(DefaultAzureCredentialOptions source)
        {
            var options = new VisualStudioCodeCredentialOptions();
            options.TenantId = source.TenantId;
            options.IsChainedCredential = true;

            CopyAdditionallyAllowedTenants(source, options);
            return new VisualStudioCodeCredential(options);
        }

        private static TokenCredential CreateEnvironmentCredential(DefaultAzureCredentialOptions source)
        {
            var options = new EnvironmentCredentialOptions();

            if (!string.IsNullOrEmpty(source.TenantId))
            {
                options.TenantId = source.TenantId;
            }

            if (!string.IsNullOrEmpty(source.ClientId))
            {
                options.ClientId = source.ClientId;
            }

            if (!string.IsNullOrEmpty(source.EnvironmentClientSecret))
            {
                options.ClientSecret = source.EnvironmentClientSecret;
            }

            if (!string.IsNullOrEmpty(source.EnvironmentClientCertificatePath))
            {
                options.ClientCertificatePath = source.EnvironmentClientCertificatePath;
            }

            if (!string.IsNullOrEmpty(source.EnvironmentClientCertificatePassword))
            {
                options.ClientCertificatePassword = source.EnvironmentClientCertificatePassword;
            }

            if (source.EnvironmentSendCertificateChain.HasValue)
            {
                options.SendCertificateChain = source.EnvironmentSendCertificateChain.Value;
            }

            if (!string.IsNullOrEmpty(source.EnvironmentUsername))
            {
                options.Username = source.EnvironmentUsername;
            }

            if (!string.IsNullOrEmpty(source.EnvironmentPassword))
            {
                options.Password = source.EnvironmentPassword;
            }

            return new EnvironmentCredential(options);
        }

        private static TokenCredential CreateWorkloadIdentityCredential(DefaultAzureCredentialOptions source)
        {
            var options = new WorkloadIdentityCredentialOptions();
            options.ClientId = source.ClientId;
            options.TenantId = source.TenantId;

            if (!string.IsNullOrEmpty(source.WorkloadTokenFilePath))
            {
                options.TokenFilePath = source.WorkloadTokenFilePath;
            }

            CopyAdditionallyAllowedTenants(source, options);
            return new WorkloadIdentityCredential(options);
        }

        private static TokenCredential CreateManagedIdentityCredential(DefaultAzureCredentialOptions source)
        {
            ManagedIdentityId managedIdentityId = ResolveManagedIdentityId(source);

            // Use ManagedIdentityClientOptions with the source options directly so that
            // any Transport or IsForceRefreshEnabled set on the source flows through.
            source.IsChainedCredential = true;

            var miOptions = new ManagedIdentityClientOptions
            {
                Pipeline = CredentialPipeline.GetInstance(source, IsManagedIdentityCredential: true),
                Options = source,
                ManagedIdentityId = managedIdentityId,
                InitialImdsConnectionTimeout = TimeSpan.FromSeconds(1),
                IsForceRefreshEnabled = source.IsForceRefreshEnabled,
            };

            return new ManagedIdentityCredential(new ManagedIdentityClient(miOptions));
        }

        private static TokenCredential CreateInteractiveBrowserCredential(DefaultAzureCredentialOptions source)
        {
            var options = new InteractiveBrowserCredentialOptions();
            options.TenantId = source.TenantId;
            options.ClientId = source.ClientId ?? Constants.DeveloperSignOnClientId;
            options.TokenCachePersistenceOptions ??= new TokenCachePersistenceOptions();
            options.IsChainedCredential = true;

            if (source.DisableAutomaticAuthentication)
            {
                options.DisableAutomaticAuthentication = true;
            }

            CopyAdditionallyAllowedTenants(source, options);
            return new InteractiveBrowserCredential(options);
        }

        private static TokenCredential CreateBrokerCredential(DefaultAzureCredentialOptions source)
        {
            if (!DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var brokerOptions))
            {
                throw new InvalidOperationException("Must reference the Azure.Identity.Broker package to use broker authentication.");
            }

            brokerOptions.TenantId = source.TenantId;
            brokerOptions.ClientId = source.ClientId ?? Constants.DeveloperSignOnClientId;
            brokerOptions.TokenCachePersistenceOptions ??= new TokenCachePersistenceOptions();
            brokerOptions.IsChainedCredential = true;

            CopyAdditionallyAllowedTenants(source, brokerOptions);

            if (brokerOptions is DevelopmentBrokerOptions devBrokerOptions)
            {
                return new BrokerCredential(devBrokerOptions);
            }

            throw new InvalidOperationException("Broker options type mismatch. Expected DevelopmentBrokerOptions.");
        }

        private static TokenCredential CreateAzurePipelinesCredential(DefaultAzureCredentialOptions source)
        {
            var options = new AzurePipelinesCredentialOptions();

            if (source.TokenCachePersistenceOptions != null)
            {
                options.TokenCachePersistenceOptions = source.TokenCachePersistenceOptions;
            }

            var tenantId = source.TenantId;
            var clientId = source.ClientId;
            var serviceConnectionId = source.AzurePipelinesServiceConnectionId;
            var systemAccessToken = source.AzurePipelinesSystemAccessToken;

            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));
            Argument.AssertNotNullOrEmpty(clientId, nameof(clientId));
            Argument.AssertNotNullOrEmpty(serviceConnectionId, nameof(serviceConnectionId));
            Argument.AssertNotNullOrEmpty(systemAccessToken, nameof(systemAccessToken));

            CopyAdditionallyAllowedTenants(source, options);
            return new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, systemAccessToken, options);
        }

        private static TokenCredential CreateManagedIdentityAsFederatedIdentityCredential(DefaultAzureCredentialOptions source)
        {
            ManagedIdentityId managedIdentityId;

            if (!string.IsNullOrEmpty(source.ManagedIdentityIdKind))
            {
                managedIdentityId = source.ManagedIdentityIdKind switch
                {
                    "ClientId" => ManagedIdentityId.FromUserAssignedClientId(source.ManagedIdentityId),
                    "ResourceId" => ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(source.ManagedIdentityId)),
                    "ObjectId" => ManagedIdentityId.FromUserAssignedObjectId(source.ManagedIdentityId),
                    _ => throw new ArgumentException($"Invalid {nameof(source.ManagedIdentityIdKind)} value: '{source.ManagedIdentityIdKind}'. For ManagedIdentityAsFederatedIdentityCredential, valid values are 'ClientId', 'ResourceId', 'ObjectId'. SystemAssigned is not supported."),
                };
            }
            else
            {
                throw new ArgumentException(
                    "A user-assigned managed identity must be specified for ManagedIdentityAsFederatedIdentityCredential. " +
                    "Set ManagedIdentityIdKind and ManagedIdentityId in the configuration.");
            }

            string tokenScope = TranslateCloudToTokenScope(source.AzureCloud);
            var managedIdentityCredential = new ManagedIdentityCredential(managedIdentityId);
            var tokenContext = new TokenRequestContext(new[] { tokenScope });

            var assertionOptions = new ClientAssertionCredentialOptions();

            if (source.AdditionallyAllowedTenants?.Count > 0)
            {
                foreach (var tenant in source.AdditionallyAllowedTenants)
                {
                    assertionOptions.AdditionallyAllowedTenants.Add(tenant);
                }
            }

            return new ClientAssertionCredential(
                source.TenantId,
                source.ClientId,
                async _ => (await managedIdentityCredential.GetTokenAsync(tokenContext).ConfigureAwait(false)).Token,
                assertionOptions);
        }

        private static ManagedIdentityId ResolveManagedIdentityId(DefaultAzureCredentialOptions source)
        {
            if (string.IsNullOrEmpty(source.ManagedIdentityIdKind))
            {
                return ManagedIdentityId.SystemAssigned;
            }

            return source.ManagedIdentityIdKind switch
            {
                "SystemAssigned" => ManagedIdentityId.SystemAssigned,
                "ClientId" => ManagedIdentityId.FromUserAssignedClientId(source.ManagedIdentityId),
                "ResourceId" => ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(source.ManagedIdentityId)),
                "ObjectId" => ManagedIdentityId.FromUserAssignedObjectId(source.ManagedIdentityId),
                _ => throw new ArgumentException($"Invalid {nameof(source.ManagedIdentityIdKind)} value: '{source.ManagedIdentityIdKind}'. Valid values are 'SystemAssigned', 'ClientId', 'ResourceId', 'ObjectId'."),
            };
        }

        private static void CopyAdditionallyAllowedTenants(DefaultAzureCredentialOptions source, TokenCredentialOptions target)
        {
            if (source.AdditionallyAllowedTenants?.Count > 0 && target is ISupportsAdditionallyAllowedTenants aatTarget)
            {
                foreach (var tenant in source.AdditionallyAllowedTenants)
                {
                    aatTarget.AdditionallyAllowedTenants.Add(tenant);
                }
            }
        }

        private static string TranslateCloudToTokenScope(string azureCloud) =>
            azureCloud?.ToLowerInvariant() switch
            {
                "public" => "api://AzureADTokenExchange/.default",
                "usgov" => "api://AzureADTokenExchangeUSGov/.default",
                "china" => "api://AzureADTokenExchangeChina/.default",
                _ => throw new ArgumentException($"Unknown Azure cloud: '{azureCloud}'. Valid values are 'public', 'usgov', 'china'.", nameof(azureCloud)),
            };
    }
}
