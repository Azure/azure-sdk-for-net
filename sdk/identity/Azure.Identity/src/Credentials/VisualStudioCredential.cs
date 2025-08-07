// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID using data from Visual Studio 2017 or later. See
    /// <seealso href="https://learn.microsoft.com/dotnet/azure/configure-visual-studio" /> for more information
    /// on how to configure Visual Studio for Azure development.
    /// </summary>
    public class VisualStudioCredential : TokenCredential
    {
        private static readonly string TokenProviderFilePath = Path.Combine(".IdentityService", "AzureServiceAuth", "tokenprovider.json");
        private const string ResourceArgumentName = "--resource";
        private const string TenantArgumentName = "--tenant";
        private readonly CredentialPipeline _pipeline;
        internal string TenantId { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        private readonly IFileSystemService _fileSystem;
        private readonly IProcessService _processService;
        private readonly bool _logPII;
        private readonly bool _logAccountDetails;
        internal bool _isChainedCredential;
        internal TimeSpan ProcessTimeout { get; private set; }
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCredential"/>.
        /// </summary>
        public VisualStudioCredential() : this(null) { }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCredential"/> with the specified options.
        /// </summary>
        /// <param name="options">Options for configuring the credential.</param>
        public VisualStudioCredential(VisualStudioCredentialOptions options) : this(options?.TenantId, CredentialPipeline.GetInstance(options), default, default, options)
        {
        }

        internal VisualStudioCredential(string tenantId, CredentialPipeline pipeline, IFileSystemService fileSystem, IProcessService processService, VisualStudioCredentialOptions options = null)
        {
            _logPII = options?.IsUnsafeSupportLoggingEnabled ?? false;
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            TenantId = tenantId;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(null);
            _fileSystem = fileSystem ?? FileSystemService.Default;
            _processService = processService ?? ProcessService.Default;
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
            ProcessTimeout = options?.ProcessTimeout ?? TimeSpan.FromSeconds(30);
            _isChainedCredential = options?.IsChainedCredential ?? false;
        }

        /// <summary>
        /// Obtains a access token from account signed in to Visual Studio.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await GetTokenImplAsync(requestContext, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Obtains a access token from account signed in to Visual Studio.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenImplAsync(requestContext, false, cancellationToken).EnsureCompleted();

        private async ValueTask<AccessToken> GetTokenImplAsync(TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("VisualStudioCredential.GetToken", requestContext);

            try
            {
                if (string.Equals(TenantId, Constants.AdfsTenantId, StringComparison.Ordinal))
                {
                    throw new CredentialUnavailableException("VisualStudioCredential authentication unavailable. ADFS tenant/authorities are not supported.");
                }

                var tokenProviderPath = GetTokenProviderPath();
                var tokenProviders = GetTokenProviders(tokenProviderPath);

                var resource = ScopeUtilities.ScopesToResource(requestContext.Scopes);
                var processStartInfos = GetProcessStartInfos(tokenProviders, resource, requestContext, cancellationToken);

                if (processStartInfos.Count == 0)
                {
                    throw new CredentialUnavailableException("No installed instance of Visual Studio was found");
                }

                var accessToken = await RunProcessesAsync(processStartInfos, async, cancellationToken).ConfigureAwait(false);

                if (_logAccountDetails)
                {
                    var accountDetails = TokenHelper.ParseAccountInfoFromToken(accessToken.Token);
                    AzureIdentityEventSource.Singleton.AuthenticatedAccountDetails(accountDetails.ClientId, accountDetails.TenantId ?? TenantId, accountDetails.Upn, accountDetails.ObjectId);
                }

                return scope.Succeeded(accessToken);
            }
            catch (Exception e)
            {
                // Treat all exceptions as credential unavailable, except for OperationCanceledException which is treated as a cancellation.
                bool IsCancellationRequested = e is OperationCanceledException && cancellationToken.IsCancellationRequested;
                throw scope.FailWrapAndThrow(e, isCredentialUnavailable: !IsCancellationRequested);
            }
        }

        private static string GetTokenProviderPath()
        {
            string baseFolder;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                if (string.IsNullOrEmpty(baseFolder))
                {
                    // There is a known issue that Environment.GetFolderPath does not work on Windows Nano: https://github.com/dotnet/runtime/issues/21430
                    baseFolder = Environment.GetEnvironmentVariable("LOCALAPPDATA");
                    if (string.IsNullOrEmpty(baseFolder))
                    {
                        throw new CredentialUnavailableException("Can't find the Local Application Data folder. See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/vscredential/troubleshoot");
                    }
                }
            }
            else
            {
                baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            return Path.Combine(baseFolder, TokenProviderFilePath);
        }

        private async Task<AccessToken> RunProcessesAsync(List<ProcessStartInfo> processStartInfos, bool async, CancellationToken cancellationToken)
        {
            var exceptions = new List<Exception>();
            foreach (ProcessStartInfo processStartInfo in processStartInfos)
            {
                string output = string.Empty;
                try
                {
                    using var processRunner = new ProcessRunner(_processService.Create(processStartInfo), ProcessTimeout, _logPII, cancellationToken);
                    output = async
                        ? await processRunner.RunAsync().ConfigureAwait(false)
                        : processRunner.Run();

                    JsonElement root = JsonDocument.Parse(output).RootElement;
                    string accessToken = root.GetProperty("access_token").GetString();
                    DateTimeOffset expiresOn = root.GetProperty("expires_on").GetDateTimeOffset();
                    return new AccessToken(accessToken, expiresOn);
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    exceptions.Add(new CredentialUnavailableException($"Process \"{processStartInfo.FileName}\" has failed to get access token in {ProcessTimeout.TotalSeconds} seconds."));
                }
                catch (JsonException exception)
                {
                    exceptions.Add(new CredentialUnavailableException($"Process \"{processStartInfo.FileName}\" has non-json output: {output}.", exception));
                }
                catch (Exception exception) when (!(exception is OperationCanceledException))
                {
                    if (_isChainedCredential)
                    {
                        exceptions.Add(new CredentialUnavailableException($"Process \"{processStartInfo.FileName}\" has failed with unexpected error: {exception.Message}.", exception));
                    }
                    else
                    {
                        exceptions.Add(new AuthenticationFailedException($"Process \"{processStartInfo.FileName}\" has failed with unexpected error: {exception.Message}.", exception));
                    }
                }
            }

            switch (exceptions.Count)
            {
                case 0:
                    throw new CredentialUnavailableException("No installed instance of Visual Studio was able to get credentials.");
                case 1:
                    ExceptionDispatchInfo.Capture(exceptions[0]).Throw();
                    return default;
                default:
                    throw new AggregateException(exceptions);
            }
        }

        private List<ProcessStartInfo> GetProcessStartInfos(VisualStudioTokenProvider[] visualStudioTokenProviders, string resource, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            List<ProcessStartInfo> processStartInfos = new();
            StringBuilder arguments = new();

            foreach (VisualStudioTokenProvider tokenProvider in visualStudioTokenProviders)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // If file does not exist, the version of Visual Studio that set the token provider may be uninstalled.
                if (!_fileSystem.FileExists(tokenProvider.Path))
                {
                    continue;
                }

                arguments.Clear();
                // Add the arguments set in the token provider file.
                if (tokenProvider.Arguments?.Length > 0)
                {
                    foreach (var argument in tokenProvider.Arguments)
                    {
                        arguments.Append(argument).Append(' ');
                    }
                }

                arguments.Append(ResourceArgumentName).Append(' ').Append(resource);

                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);
                if (tenantId != default)
                {
                    arguments.Append(' ').Append(TenantArgumentName).Append(' ').Append(tenantId);
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = tokenProvider.Path,
                    Arguments = arguments.ToString(),
                    ErrorDialog = false,
                    CreateNoWindow = true,
                };

                processStartInfos.Add(startInfo);
            }

            return processStartInfos;
        }

        private VisualStudioTokenProvider[] GetTokenProviders(string tokenProviderPath)
        {
            var content = GetTokenProviderContent(tokenProviderPath);

            try
            {
                using JsonDocument document = JsonDocument.Parse(content);

                JsonElement providersElement = document.RootElement.GetProperty("TokenProviders");

                var providers = new VisualStudioTokenProvider[providersElement.GetArrayLength()];
                for (int i = 0; i < providers.Length; i++)
                {
                    JsonElement providerElement = providersElement[i];

                    var path = providerElement.GetProperty("Path").GetString();
                    var preference = providerElement.GetProperty("Preference").GetInt32();
                    var arguments = GetStringArrayPropertyValue(providerElement, "Arguments");

                    providers[i] = new VisualStudioTokenProvider(path, arguments, preference);
                }

                Array.Sort(providers);
                return providers;
            }
            catch (JsonException exception)
            {
                throw new CredentialUnavailableException($"File found at \"{tokenProviderPath}\" isn't a valid JSON file", exception);
            }
            catch (Exception exception)
            {
                throw new CredentialUnavailableException($"JSON file found at \"{tokenProviderPath}\" has invalid schema.", exception);
            }
        }

        private string GetTokenProviderContent(string tokenProviderPath)
        {
            try
            {
                return _fileSystem.ReadAllText(tokenProviderPath);
            }
            catch (FileNotFoundException exception)
            {
                throw new CredentialUnavailableException($"Visual Studio Token provider file not found at {tokenProviderPath}", exception);
            }
            catch (IOException exception)
            {
                throw new CredentialUnavailableException($"Visual Studio Token provider can't be accessed at {tokenProviderPath}", exception);
            }
        }

        private static string[] GetStringArrayPropertyValue(JsonElement element, string name)
        {
            JsonElement arrayElement = element.GetProperty(name);
            var array = new string[arrayElement.GetArrayLength()];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = arrayElement[i].GetString();
            }

            return array;
        }

        private readonly struct VisualStudioTokenProvider : IComparable<VisualStudioTokenProvider>
        {
            private readonly int _preference;

            public string Path { get; }
            public string[] Arguments { get; }

            public VisualStudioTokenProvider(string path, string[] arguments, int preference)
            {
                Path = path;
                Arguments = arguments;
                _preference = preference;
            }

            public int CompareTo(VisualStudioTokenProvider other) => _preference.CompareTo(other._preference);
        }
    }
}
