// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Azure.Core;

namespace Azure.Identity
{
    internal class DefaultAzureCredentialFactory
    {
        private readonly string _customEnvironmentVariableName;
        private static string _troubleshootingMessage = $" See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/defaultazurecredential/troubleshoot";

        public DefaultAzureCredentialFactory(DefaultAzureCredentialOptions options)
            : this(options, CredentialPipeline.GetInstance(options))
        { }

        public DefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, string customEnvironmentVariableName)
            : this(options, CredentialPipeline.GetInstance(options), customEnvironmentVariableName)
        { }

        protected DefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, CredentialPipeline pipeline)
        {
            Pipeline = pipeline;
            Options = options?.Clone<DefaultAzureCredentialOptions>() ?? new DefaultAzureCredentialOptions();
        }

        protected DefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, CredentialPipeline pipeline, string customEnvironmentVariableName)
        {
            Argument.AssertNotNullOrEmpty(customEnvironmentVariableName, nameof(customEnvironmentVariableName));

            Pipeline = pipeline;
            Options = options?.Clone<DefaultAzureCredentialOptions>() ?? new DefaultAzureCredentialOptions();
            _customEnvironmentVariableName = customEnvironmentVariableName;
        }

        public DefaultAzureCredentialOptions Options { get; }
        public CredentialPipeline Pipeline { get; }

        public TokenCredential[] CreateCredentialChain()
        {
            TokenCredential[] tokenCredentials = Array.Empty<TokenCredential>();
            string credentialSelection = Options.CredentialSource ?? EnvironmentVariables.CredentialSelection?.Trim().ToLowerInvariant();

            if (_customEnvironmentVariableName != null)
            {
                // When using custom environment variable, read from that variable and validate it's set
                credentialSelection = ValidateAndGetCustomEnvironmentVariable(_customEnvironmentVariableName);
                // For custom environment variables, always use the token credentials logic
                tokenCredentials = ProcessCredentialSelection(credentialSelection, _customEnvironmentVariableName);
            }
            else if (credentialSelection != null)
            {
                tokenCredentials = ProcessCredentialSelection(credentialSelection, "AZURE_TOKEN_CREDENTIALS");
            }
            else
            {
                List<TokenCredential> chain = new(10);

                if (!Options.ExcludeEnvironmentCredential)
                {
                    chain.Add(CreateEnvironmentCredential());
                }

                if (!Options.ExcludeWorkloadIdentityCredential)
                {
                    chain.Add(CreateWorkloadIdentityCredential());
                }

                if (!Options.ExcludeManagedIdentityCredential)
                {
                    chain.Add(CreateManagedIdentityCredential());
                }
#pragma warning disable CS0618 // Type of member is obsolete
                if (!Options.ExcludeSharedTokenCacheCredential)
                {
                    chain.Add(CreateSharedTokenCacheCredential());
                }
#pragma warning restore CS0618

                if (!Options.ExcludeVisualStudioCredential)
                {
                    chain.Add(CreateVisualStudioCredential());
                }

                if (!Options.ExcludeVisualStudioCodeCredential)
                {
                    chain.Add(CreateVisualStudioCodeCredential());
                }

                if (!Options.ExcludeAzureCliCredential)
                {
                    chain.Add(CreateAzureCliCredential());
                }

                if (!Options.ExcludeAzurePowerShellCredential)
                {
                    chain.Add(CreateAzurePowerShellCredential());
                }

                if (!Options.ExcludeAzureDeveloperCliCredential)
                {
                    chain.Add(CreateAzureDeveloperCliCredential());
                }

                if (!Options.ExcludeInteractiveBrowserCredential)
                {
                    chain.Add(CreateInteractiveBrowserCredential());
                }
                if (!Options.ExcludeBrokerCredential)
                {
                    chain.Add(CreateBrokerCredential());
                }
                tokenCredentials = chain.ToArray();
            }

            if (tokenCredentials.Length == 0)
            {
                throw new ArgumentException("At least one credential type must be included in the authentication flow.", "options");
            }

            return tokenCredentials;
        }

        /// <summary>
        /// Validates and retrieves the value from a custom environment variable.
        /// Throws InvalidOperationException if the variable is not set or is empty.
        /// </summary>
        /// <param name="environmentVariableName">The name of the environment variable to validate and retrieve.</param>
        /// <returns>The trimmed and lowercased environment variable value.</returns>
        private static string ValidateAndGetCustomEnvironmentVariable(string environmentVariableName)
        {
            // Validate environment variable name contains only letters, digits, or underscores
            for (int i = 0; i < environmentVariableName.Length; i++)
            {
                char c = environmentVariableName[i];
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    throw new ArgumentException($"Invalid environment variable name: '{environmentVariableName}'. Only letters, digits, and underscores are allowed.{_troubleshootingMessage}", nameof(environmentVariableName));
                }
            }

            string credentialSelection = Environment.GetEnvironmentVariable(environmentVariableName);
            if (string.IsNullOrEmpty(credentialSelection))
            {
                throw new InvalidOperationException($"Environment variable '{environmentVariableName}' is not set or is empty.{_troubleshootingMessage}");
            }
            return credentialSelection.Trim().ToLowerInvariant();
        }

        /// <summary>
        /// Processes a credential selection value and returns the appropriate credential chain.
        /// </summary>
        /// <param name="credentialSelection">The credential selection value (already trimmed and lowercased).</param>
        /// <param name="environmentVariableName">The environment variable name for error messages.</param>
        /// <returns>Array of TokenCredential instances based on the selection.</returns>
        private TokenCredential[] ProcessCredentialSelection(string credentialSelection, string environmentVariableName)
        {
            bool useDevCredentials = Constants.DevCredentials.Equals(credentialSelection, StringComparison.OrdinalIgnoreCase);
            bool useProdCredentials = Constants.ProdCredentials.Equals(credentialSelection, StringComparison.OrdinalIgnoreCase);

            return (useDevCredentials, useProdCredentials) switch
            {
                (true, _) => CreateDevelopmentCredentialChain(),
                (_, true) => CreateProductionCredentialChain(),
                _ => CreateSpecificCredentialChain(credentialSelection, environmentVariableName)
            };
        }

        /// <summary>
        /// Creates the development credential chain.
        /// </summary>
        /// <returns>Array of development TokenCredential instances.</returns>
        private TokenCredential[] CreateDevelopmentCredentialChain()
        {
            List<TokenCredential> chain = new();
            if (!Options.ExcludeVisualStudioCredential)
            {
                chain.Add(CreateVisualStudioCredential());
            }
            if (!Options.ExcludeVisualStudioCodeCredential)
            {
                chain.Add(CreateVisualStudioCodeCredential());
            }
            if (!Options.ExcludeAzureCliCredential)
            {
                chain.Add(CreateAzureCliCredential());
            }
            if (!Options.ExcludeAzurePowerShellCredential)
            {
                chain.Add(CreateAzurePowerShellCredential());
            }
            if (!Options.ExcludeAzureDeveloperCliCredential)
            {
                chain.Add(CreateAzureDeveloperCliCredential());
            }
            if (!Options.ExcludeBrokerCredential)
            {
                chain.Add(CreateBrokerCredential());
            }
            return chain.ToArray();
        }

        /// <summary>
        /// Creates the production credential chain.
        /// </summary>
        /// <returns>Array of production TokenCredential instances.</returns>
        private TokenCredential[] CreateProductionCredentialChain()
        {
            List<TokenCredential> chain = new();

            if (!Options.ExcludeEnvironmentCredential)
            {
                chain.Add(CreateEnvironmentCredential());
            }
            if (!Options.ExcludeWorkloadIdentityCredential)
            {
                chain.Add(CreateWorkloadIdentityCredential());
            }
            if (!Options.ExcludeManagedIdentityCredential)
            {
                chain.Add(CreateManagedIdentityCredential());
            }
            return chain.ToArray();
        }

        /// <summary>
        /// Creates a credential chain for a specific credential type.
        /// </summary>
        /// <param name="credentialSelection">The specific credential type selected.</param>
        /// <param name="environmentVariableName">The environment variable name for error messages.</param>
        /// <returns>Array containing the specific TokenCredential instance.</returns>
        private TokenCredential[] CreateSpecificCredentialChain(string credentialSelection, string environmentVariableName)
        {
            string validCredentials = $"'{Constants.DevCredentials}', '{Constants.ProdCredentials}', '{Constants.VisualStudioCredential}', '{Constants.VisualStudioCodeCredential}', '{Constants.AzureCliCredential}', '{Constants.AzurePowerShellCredential}', '{Constants.AzureDeveloperCliCredential}', '{Constants.EnvironmentCredential}', '{Constants.WorkloadIdentityCredential}', '{Constants.ManagedIdentityCredential}', '{Constants.InteractiveBrowserCredential}', '{Constants.BrokerCredential}'";

            return credentialSelection switch
            {
                Constants.VisualStudioCredential => [CreateVisualStudioCredential()],
                Constants.VisualStudioCodeCredential => [CreateVisualStudioCodeCredential()],
                Constants.AzureCliCredential => [CreateAzureCliCredential()],
                Constants.AzurePowerShellCredential => [CreateAzurePowerShellCredential()],
                Constants.AzureDeveloperCliCredential => [CreateAzureDeveloperCliCredential()],
                Constants.EnvironmentCredential => [CreateEnvironmentCredential()],
                Constants.WorkloadIdentityCredential => [CreateWorkloadIdentityCredential()],
                Constants.ManagedIdentityCredential => [CreateManagedIdentityCredential(false)],
                Constants.InteractiveBrowserCredential => [CreateInteractiveBrowserCredential()],
                Constants.BrokerCredential => [CreateBrokerCredential()],
                _ => throw new InvalidOperationException($"Invalid value for environment variable {environmentVariableName}: {credentialSelection}. Valid values are {validCredentials}.{_troubleshootingMessage}")
            };
        }

        public virtual TokenCredential CreateEnvironmentCredential()
        {
            var options = Options.Clone<EnvironmentCredentialOptions>();

            if (!string.IsNullOrEmpty(options.TenantId))
            {
                options.TenantId = Options.TenantId;
            }

            return new EnvironmentCredential(Pipeline, options);
        }

        public virtual TokenCredential CreateWorkloadIdentityCredential()
        {
            var options = Options.Clone<WorkloadIdentityCredentialOptions>();

            options.ClientId = Options.WorkloadIdentityClientId;
            options.TenantId = Options.TenantId;
            options.Pipeline = Pipeline;

            return new WorkloadIdentityCredential(options);
        }

        public virtual TokenCredential CreateManagedIdentityCredential(bool isProbeEnabled = true)
        {
            var options = Options.Clone<DefaultAzureCredentialOptions>();
            options.IsChainedCredential = isProbeEnabled;

            if (options.ManagedIdentityClientId != null && options.ManagedIdentityResourceId != null)
            {
                throw new ArgumentException(
                    $"{nameof(DefaultAzureCredentialOptions)} cannot specify both {nameof(options.ManagedIdentityResourceId)} and {nameof(options.ManagedIdentityClientId)}.");
            }

            var miOptions = new ManagedIdentityClientOptions
            {
                Pipeline = CredentialPipeline.GetInstance(options, IsManagedIdentityCredential: true),
                Options = options,
                InitialImdsConnectionTimeout = TimeSpan.FromSeconds(1),
                ExcludeTokenExchangeManagedIdentitySource = options.ExcludeWorkloadIdentityCredential,
                IsForceRefreshEnabled = options.IsForceRefreshEnabled,
            };

            if (!string.IsNullOrEmpty(options.ManagedIdentityClientId))
            {
                miOptions.ManagedIdentityId = ManagedIdentityId.FromUserAssignedClientId(options.ManagedIdentityClientId);
            }
            else if (options.ManagedIdentityResourceId != null)
            {
                miOptions.ManagedIdentityId = ManagedIdentityId.FromUserAssignedResourceId(options.ManagedIdentityResourceId);
            }
            else
            {
                miOptions.ManagedIdentityId = ManagedIdentityId.SystemAssigned;
            }

            return new ManagedIdentityCredential(new ManagedIdentityClient(miOptions));
        }

        public virtual TokenCredential CreateSharedTokenCacheCredential()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var options = Options.Clone<SharedTokenCacheCredentialOptions>();

            options.TenantId = Options.SharedTokenCacheTenantId;

            options.Username = Options.SharedTokenCacheUsername;

            return new SharedTokenCacheCredential(Options.SharedTokenCacheTenantId, Options.SharedTokenCacheUsername, options, Pipeline);
#pragma warning restore CS0618
        }

        public virtual TokenCredential CreateInteractiveBrowserCredential()
        {
            var options = Options.Clone<InteractiveBrowserCredentialOptions>();

            options.TokenCachePersistenceOptions = new TokenCachePersistenceOptions();

            options.TenantId = Options.InteractiveBrowserTenantId;

            return new InteractiveBrowserCredential(
                Options.InteractiveBrowserTenantId,
                Options.InteractiveBrowserCredentialClientId ?? Constants.DeveloperSignOnClientId,
                options,
                Pipeline);
        }

        internal TokenCredential CreateBrokerCredential()
        {
            var options = Options.Clone<DevelopmentBrokerOptions>();
            options.TokenCachePersistenceOptions = new TokenCachePersistenceOptions();
            options.TenantId = Options.InteractiveBrowserTenantId;
            options.IsChainedCredential = true;

            return new BrokerCredential(options);
        }

        public virtual TokenCredential CreateAzureDeveloperCliCredential()
        {
            var options = Options.Clone<AzureDeveloperCliCredentialOptions>();
            options.TenantId = Options.TenantId;
            options.ProcessTimeout = Options.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            return new AzureDeveloperCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateAzureCliCredential()
        {
            var options = Options.Clone<AzureCliCredentialOptions>();
            options.TenantId = Options.TenantId;
            options.ProcessTimeout = Options.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            return new AzureCliCredential(Pipeline, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCredential()
        {
            var options = Options.Clone<VisualStudioCredentialOptions>();
            options.TenantId = Options.VisualStudioTenantId;
            options.ProcessTimeout = Options.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            return new VisualStudioCredential(Options.VisualStudioTenantId, Pipeline, default, default, options);
        }

        public virtual TokenCredential CreateVisualStudioCodeCredential()
        {
            var options = Options.Clone<VisualStudioCodeCredentialOptions>();
            options.TenantId = Options.VisualStudioCodeTenantId;
            options.IsChainedCredential = true;

            return new VisualStudioCodeCredential(options);
        }

        public virtual TokenCredential CreateAzurePowerShellCredential()
        {
            var options = Options.Clone<AzurePowerShellCredentialOptions>();
            options.TenantId = Options.TenantId;
            options.ProcessTimeout = Options.CredentialProcessTimeout;
            options.IsChainedCredential = true;

            return new AzurePowerShellCredential(options, Pipeline, default);
        }

        /// <summary>
        /// Creates a DevelopmentBrokerOptions instance if the Azure.Identity.Broker assembly is loaded.
        /// This is used to enable broker authentication for development purposes.
        /// </summary>
        /// <param name="options"></param>
        internal static bool TryCreateDevelopmentBrokerOptions(out InteractiveBrowserCredentialOptions options)
        {
            options = null;
            try
            {
                // Use Type.GetType and ConstructorInfo because they can be analyzed by the ILLinker and are
                // AOT friendly.

                // Try to get the options type
                var optionsType = Type.GetType("Azure.Identity.Broker.DevelopmentBrokerOptions, Azure.Identity.Broker", throwOnError: false);
                if (optionsType == null)
                    return false;

                var constructor = optionsType.GetConstructor(Type.EmptyTypes);
                if (constructor == null)
                    return false;

                var instance = constructor.Invoke(null);
                options = instance as InteractiveBrowserCredentialOptions;

                if (options == null)
                    return false;

                options.IsChainedCredential = true;

                // Set platform-specific options
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    options.RedirectUri = new Uri(Constants.MacBrokerRedirectUri);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
