// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID using Azure CLI to obtain an access token.
    /// </summary>
    public class AzureCliCredential : TokenCredential
    {
        internal const string AzureCLINotInstalled = "Azure CLI not installed";
        internal const string AzNotLogIn = "Please run 'az login' to set up account";
        internal const string WinAzureCLIError = "'az' is not recognized";
        internal const string AzureCliTimeoutError = "Azure CLI authentication timed out.";
        internal const string AzureCliFailedError = "Azure CLI authentication failed due to an unknown error.";
        internal const string Troubleshoot = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/azclicredential/troubleshoot";
        internal const string InteractiveLoginRequired = "Azure CLI could not login. Interactive login is required.";
        internal const string CLIInternalError = "CLIInternalError: The command failed with an unexpected error. Here is the traceback:";
        internal TimeSpan ProcessTimeout { get; private set; }

        // The default install paths are used to find Azure CLI if no path is specified. This is to prevent executing out of the current working directory.
        private static readonly string DefaultPathWindows = $"{EnvironmentVariables.ProgramFilesX86}\\Microsoft SDKs\\Azure\\CLI2\\wbin;{EnvironmentVariables.ProgramFiles}\\Microsoft SDKs\\Azure\\CLI2\\wbin";
        private static readonly string DefaultWorkingDirWindows = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private const string DefaultPathNonWindows = "/usr/bin:/usr/local/bin";
        private const string DefaultWorkingDirNonWindows = "/bin/";
        private const string RefreshTokeExpired = "The provided authorization code or refresh token has expired due to inactivity. Send a new interactive authorization request for this user and resource.";
        private static readonly string DefaultPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultPathWindows : DefaultPathNonWindows;
        private static readonly string DefaultWorkingDir = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultWorkingDirWindows : DefaultWorkingDirNonWindows;

        private static readonly Regex AzNotFoundPattern = new Regex("az:(.*)not found");

        private readonly string _path;

        private readonly CredentialPipeline _pipeline;
        private readonly IProcessService _processService;
        private readonly bool _logPII;
        private readonly bool _logAccountDetails;
        internal string TenantId { get; }
        internal string Subscription { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        internal bool _isChainedCredential;
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Create an instance of <see cref="AzureCliCredential"/> class.
        /// </summary>
        public AzureCliCredential()
            : this(CredentialPipeline.GetInstance(null), default)
        { }

        /// <summary>
        /// Create an instance of <see cref="AzureCliCredential"/> class.
        /// </summary>
        /// <param name="options"> The Microsoft Entra tenant (directory) ID of the service principal. </param>
        public AzureCliCredential(AzureCliCredentialOptions options)
            : this(CredentialPipeline.GetInstance(null), default, options)
        { }

        internal AzureCliCredential(CredentialPipeline pipeline, IProcessService processService, AzureCliCredentialOptions options = null)
        {
            _logPII = options?.IsUnsafeSupportLoggingEnabled ?? false;
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            _pipeline = pipeline;
            _path = !string.IsNullOrEmpty(EnvironmentVariables.Path) ? EnvironmentVariables.Path : DefaultPath;
            _processService = processService ?? ProcessService.Default;
            TenantId = Validations.ValidateTenantId(options?.TenantId, $"{nameof(options)}.{nameof(options.TenantId)}", true);
            Subscription = options?.Subscription;
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
            ProcessTimeout = options?.ProcessTimeout ?? TimeSpan.FromSeconds(13);
            _isChainedCredential = options?.IsChainedCredential ?? false;
        }

        /// <summary>
        /// Obtains a access token from Azure CLI credential, using this access token to authenticate. This method called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a access token from Azure CLI service, using the access token to authenticate. This method id called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("AzureCliCredential.GetToken", requestContext);

            try
            {
                AccessToken token = await RequestCliAccessTokenAsync(async, requestContext, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, isCredentialUnavailable: _isChainedCredential);
            }
        }

        private async ValueTask<AccessToken> RequestCliAccessTokenAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(context.Scopes);
            string tenantId = TenantIdResolver.Resolve(TenantId, context, AdditionallyAllowedTenantIds);

            Validations.ValidateTenantId(tenantId, nameof(context.TenantId), true);
            ScopeUtilities.ValidateScope(resource);

            GetFileNameAndArguments(resource, tenantId, Subscription, out string fileName, out string argument);
            ProcessStartInfo processStartInfo = GetAzureCliProcessStartInfo(fileName, argument);
            using var processRunner = new ProcessRunner(_processService.Create(processStartInfo), ProcessTimeout, _logPII, cancellationToken);

            string output;
            try
            {
                output = async ? await processRunner.RunAsync().ConfigureAwait(false) : processRunner.Run();
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                if (_isChainedCredential)
                {
                    throw new CredentialUnavailableException(AzureCliTimeoutError);
                }
                else
                {
                    throw new AuthenticationFailedException(AzureCliTimeoutError);
                }
            }
            catch (InvalidOperationException exception)
            {
                bool isWinError = exception.Message.StartsWith(WinAzureCLIError, StringComparison.CurrentCultureIgnoreCase);

                bool isOtherOsError = AzNotFoundPattern.IsMatch(exception.Message);

                if (isWinError || isOtherOsError)
                {
                    throw new CredentialUnavailableException(AzureCLINotInstalled);
                }

                bool isAADSTSError = exception.Message.Contains("AADSTS");
                bool isLoginError = exception.Message.IndexOf("az login", StringComparison.OrdinalIgnoreCase) != -1 ||
                                    exception.Message.IndexOf("az account set", StringComparison.OrdinalIgnoreCase) != -1;

                if (isLoginError && !isAADSTSError)
                {
                    throw new CredentialUnavailableException(AzNotLogIn);
                }

                bool isRefreshTokenFailedError = exception.Message.IndexOf(AzureCliFailedError, StringComparison.OrdinalIgnoreCase) != -1 &&
                                                 exception.Message.IndexOf(RefreshTokeExpired, StringComparison.OrdinalIgnoreCase) != -1 ||
                                                 exception.Message.IndexOf("CLIInternalError", StringComparison.OrdinalIgnoreCase) != -1;

                if (isRefreshTokenFailedError)
                {
                    throw new CredentialUnavailableException(InteractiveLoginRequired);
                }

                if (_isChainedCredential)
                {
                    throw new CredentialUnavailableException($"{AzureCliFailedError} {Troubleshoot} {exception.Message}");
                }
                else
                {
                    throw new AuthenticationFailedException($"{AzureCliFailedError} {Troubleshoot} {exception.Message}");
                }
            }

            AccessToken token = DeserializeOutput(output);
            if (_logAccountDetails)
            {
                var accountDetails = TokenHelper.ParseAccountInfoFromToken(token.Token);
                AzureIdentityEventSource.Singleton.AuthenticatedAccountDetails(accountDetails.ClientId, accountDetails.TenantId ?? TenantId, accountDetails.Upn, accountDetails.ObjectId);
            }

            return token;
        }

        private ProcessStartInfo GetAzureCliProcessStartInfo(string fileName, string argument) =>
            new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = argument,
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WorkingDirectory = DefaultWorkingDir,
                Environment = { { "PATH", _path } }
            };

        private static void GetFileNameAndArguments(string resource, string tenantId, string subscriptionId, out string fileName, out string argument)
        {
            string command = tenantId switch
            {
                null => $"az account get-access-token --output json --resource {resource}",
                _ => $"az account get-access-token --output json --resource {resource} --tenant {tenantId}"
            };

            if (!string.IsNullOrEmpty(subscriptionId))
            {
                command += $" --subscription \"{subscriptionId}\"";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe");
                argument = $"/d /c \"{command}\"";
            }
            else
            {
                fileName = "/bin/sh";
                argument = $"-c \"{command}\"";
            }
        }

        private static AccessToken DeserializeOutput(string output)
        {
            using JsonDocument document = JsonDocument.Parse(output);

            JsonElement root = document.RootElement;
            string accessToken = root.GetProperty("accessToken").GetString();
            DateTimeOffset expiresOn = root.TryGetProperty("expires_on", out JsonElement expires_on)
                ? DateTimeOffset.FromUnixTimeSeconds(expires_on.GetInt64())
                : DateTimeOffset.ParseExact(root.GetProperty("expiresOn").GetString(), "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal);

            return new AccessToken(accessToken, expiresOn);
        }
    }
}
