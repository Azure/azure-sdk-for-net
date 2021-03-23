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
    /// Enables authentication to Azure Active Directory using data from Visual Studio
    /// </summary>
    public class VisualStudioCredential : TokenCredential
    {
        private const string TokenProviderFilePath = @".IdentityService\AzureServiceAuth\tokenprovider.json";
        private const string ResourceArgumentName = "--resource";
        private const string TenantArgumentName = "--tenant";

        private readonly CredentialPipeline _pipeline;
        private readonly string _tenantId;
        private readonly IFileSystemService _fileSystem;
        private readonly IProcessService _processService;

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCredential"/>.
        /// </summary>
        public VisualStudioCredential() : this(null) { }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCredential"/> with the specified options.
        /// </summary>
        /// <param name="options">Options for configuring the credential.</param>
        public VisualStudioCredential(VisualStudioCredentialOptions options) : this(options?.TenantId, CredentialPipeline.GetInstance(options), default, default) { }

        internal VisualStudioCredential(string tenantId, CredentialPipeline pipeline, IFileSystemService fileSystem, IProcessService processService)
        {
            _tenantId = tenantId;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(null);
            _fileSystem = fileSystem ?? FileSystemService.Default;
            _processService = processService ?? ProcessService.Default;
        }

        /// <inheritdoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await GetTokenImplAsync(requestContext, true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenImplAsync(requestContext, false, cancellationToken).EnsureCompleted();

        private async ValueTask<AccessToken> GetTokenImplAsync(TokenRequestContext requestContext, bool async, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("VisualStudioCredential.GetToken", requestContext);

            try
            {
                if (string.Equals(_tenantId, Constants.AdfsTenantId, StringComparison.Ordinal))
                {
                    throw new CredentialUnavailableException("VisualStudioCredential authentication unavailable. ADFS tenant/authorities are not supported.");
                }

                var tokenProviderPath = GetTokenProviderPath();
                var tokenProviders = GetTokenProviders(tokenProviderPath);

                var resource = ScopeUtilities.ScopesToResource(requestContext.Scopes);
                var processStartInfos = GetProcessStartInfos(tokenProviders, resource, cancellationToken);

                if (processStartInfos.Count == 0)
                {
                    throw new CredentialUnavailableException("No installed instance of Visual Studio was found");
                }

                var accessToken = await RunProcessesAsync(processStartInfos, async, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(accessToken);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private static string GetTokenProviderPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), TokenProviderFilePath);
            }

            throw new CredentialUnavailableException($"Operating system {RuntimeInformation.OSDescription} isn't supported.");
        }

        private async Task<AccessToken> RunProcessesAsync(List<ProcessStartInfo> processStartInfos, bool async, CancellationToken cancellationToken)
        {
            var exceptions = new List<Exception>();
            foreach (ProcessStartInfo processStartInfo in processStartInfos)
            {
                string output = string.Empty;
                try
                {
                    using var processRunner = new ProcessRunner(_processService.Create(processStartInfo), TimeSpan.FromSeconds(30), cancellationToken);
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
                    exceptions.Add(new CredentialUnavailableException($"Process \"{processStartInfo.FileName}\" has failed to get access token in 30 seconds."));
                }
                catch (JsonException exception)
                {
                    exceptions.Add(new CredentialUnavailableException($"Process \"{processStartInfo.FileName}\" has non-json output: {output}.", exception));
                }
                catch (Exception exception) when (!(exception is OperationCanceledException))
                {
                    exceptions.Add(new CredentialUnavailableException($"Process \"{processStartInfo.FileName}\" has failed with unexpected error: {exception.Message}.", exception));
                }
            }

            switch (exceptions.Count) {
                case 0:
                    throw new CredentialUnavailableException("No installed instance of Visual Studio was able to get credentials.");
                case 1:
                    ExceptionDispatchInfo.Capture(exceptions[0]).Throw();
                    return default;
                default:
                    throw new AggregateException(exceptions);
            }
        }

        private List<ProcessStartInfo> GetProcessStartInfos(VisualStudioTokenProvider[] visualStudioTokenProviders, string resource, CancellationToken cancellationToken)
        {
            List<ProcessStartInfo> processStartInfos = new List<ProcessStartInfo>();
            StringBuilder arguments = new StringBuilder();

            foreach (VisualStudioTokenProvider tokenProvider in visualStudioTokenProviders)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // If file does not exist, the version of Visual Studio that set the token provider may be uninstalled.
                if (!_fileSystem.FileExists(tokenProvider.Path))
                {
                    continue;
                }

                arguments.Clear();
                arguments.Append(ResourceArgumentName).Append(' ').Append(resource);

                if (_tenantId != default)
                {
                    arguments.Append(' ').Append(TenantArgumentName).Append(' ').Append(_tenantId);
                }

                // Add the arguments set in the token provider file.
                if (tokenProvider.Arguments?.Length > 0)
                {
                    foreach (var argument in tokenProvider.Arguments)
                    {
                        arguments.Append(' ').Append(argument);
                    }
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
