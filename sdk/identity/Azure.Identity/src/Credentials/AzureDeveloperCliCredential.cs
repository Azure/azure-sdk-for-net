// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID using Azure Developer CLI to obtain an access token.
    /// </summary>
    public class AzureDeveloperCliCredential : TokenCredential
    {
        internal const string AzdCliNotInstalled = "Azure Developer CLI could not be found.";
        internal const string AzdNotLogIn = "Please run 'azd auth login' from a command prompt to authenticate before using this credential.";
        internal const string WinAzdCliError = "'azd' is not recognized";
        internal const string AzdCliTimeoutError = "Azure Developer CLI authentication timed out.";
        internal const string AzdCliFailedError = "Azure Developer CLI authentication failed due to an unknown error.";
        internal const string Troubleshoot = "Please visit https://aka.ms/azure-dev for installation instructions and then, once installed, authenticate to your Azure account using 'azd auth login'.";
        internal const string InteractiveLoginRequired = "Azure Developer CLI could not login. Interactive login is required.";
        internal const string AzdCLIInternalError = "AzdCLIInternalError: The command failed with an unexpected error. Here is the traceback:";
        internal const string ClaimsChallengeLoginFormat = "Azure Developer CLI authentication requires multi-factor authentication or additional claims. Please run '{0}' to re-authenticate with the required claims. After completing login, retry the operation.";
        internal const string AzdUnknownClaimsFlagError = "Azure Developer CLI authentication requires multi-factor authentication or additional claims. However, claims challenges are not supported by the installed Azure Developer CLI version. Please update to version 1.18.1 or later.";
        internal TimeSpan ProcessTimeout { get; private set; }

        private static readonly string DefaultWorkingDirWindows = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private const string DefaultWorkingDirNonWindows = "/bin/";
        private const string RefreshTokeExpired = "The provided authorization code or refresh token has expired due to inactivity. Send a new interactive authorization request for this user and resource.";
        private static readonly string DefaultWorkingDir = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultWorkingDirWindows : DefaultWorkingDirNonWindows;
        private static readonly Regex AzdNotFoundPattern = new Regex("azd:(.*)not found");

        private readonly CredentialPipeline _pipeline;
        private readonly IProcessService _processService;
        private readonly bool _logPII;
        private readonly bool _logAccountDetails;
        internal string TenantId { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        internal bool _isChainedCredential;
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Create an instance of the <see cref="AzureDeveloperCliCredential"/> class.
        /// </summary>
        public AzureDeveloperCliCredential()
            : this(CredentialPipeline.GetInstance(null), default)
        { }

        /// <summary>
        /// Create an instance of the <see cref="AzureDeveloperCliCredential"/> class.
        /// </summary>
        /// <param name="options"> The Microsoft Entra tenant (directory) ID of the service principal. </param>
        public AzureDeveloperCliCredential(AzureDeveloperCliCredentialOptions options)
            : this(CredentialPipeline.GetInstance(null), default, options)
        { }

        internal AzureDeveloperCliCredential(CredentialPipeline pipeline, IProcessService processService, AzureDeveloperCliCredentialOptions options = null)
        {
            _logPII = options?.IsUnsafeSupportLoggingEnabled ?? false;
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            _pipeline = pipeline;
            _processService = processService ?? ProcessService.Default;
            TenantId = Validations.ValidateTenantId(options?.TenantId, $"{nameof(options)}.{nameof(options.TenantId)}", true);
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
            ProcessTimeout = options?.ProcessTimeout ?? TimeSpan.FromSeconds(13);
            _isChainedCredential = options?.IsChainedCredential ?? false;
        }

        /// <summary>
        /// Obtains an access token from Azure Developer CLI credential, using this access token to authenticate. This method called by Azure SDK clients.
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
        /// Obtains an access token from Azure Developer CLI service, using the access token to authenticate. This method is called by Azure SDK clients.
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
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("AzureDeveloperCliCredential.GetToken", requestContext);

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
            string tenantId = TenantIdResolver.Resolve(TenantId, context, AdditionallyAllowedTenantIds);

            Validations.ValidateTenantId(tenantId, nameof(context.TenantId), true);

            foreach (var scope in context.Scopes)
            {
                ScopeUtilities.ValidateScope(scope);
            }

            GetFileNameAndArguments(context.Scopes, tenantId, context.Claims, out string fileName, out string argument);
            ProcessStartInfo processStartInfo = GetAzureDeveloperCliProcessStartInfo(fileName, argument);
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
                    throw new CredentialUnavailableException(AzdCliTimeoutError);
                }
                else
                {
                    throw new AuthenticationFailedException(AzdCliTimeoutError);
                }
            }
            catch (InvalidOperationException exception)
            {
                // If an older azd version doesn't recognize the --claims flag, surface explicit guidance to update.
                if (!string.IsNullOrWhiteSpace(context.Claims) && exception.Message.IndexOf("unknown flag: --claims", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new AuthenticationFailedException(AzdUnknownClaimsFlagError);
                }

                // If a claims challenge was provided we attempted to invoke 'azd auth token' including the claims so azd can persist them.
                // Since azd cannot complete the authentication non-interactively it returns an error instructing the user to run 'azd auth login'.
                // Surface explicit guidance to the caller (never fall through when part of a chain) so they can remediate the challenge.
                if (!string.IsNullOrWhiteSpace(context.Claims))
                {
                    string loginCommand = string.IsNullOrEmpty(tenantId)
                        ? "azd auth login"
                        : $"azd auth login --tenant-id {tenantId}";
                    throw new AuthenticationFailedException(string.Format(CultureInfo.InvariantCulture, ClaimsChallengeLoginFormat, loginCommand));
                }

                bool isWinError = exception.Message.StartsWith(WinAzdCliError, StringComparison.CurrentCultureIgnoreCase);

                bool isOtherOsError = AzdNotFoundPattern.IsMatch(exception.Message);

                if (isWinError || isOtherOsError)
                {
                    throw new CredentialUnavailableException(AzdCliNotInstalled);
                }

                bool isAADSTSError = exception.Message.Contains("AADSTS");
                bool isLoginError = exception.Message.IndexOf("azd auth login", StringComparison.OrdinalIgnoreCase) != -1;

                if (isLoginError && !isAADSTSError)
                {
                    throw new CredentialUnavailableException(AzdNotLogIn);
                }

                bool isRefreshTokenFailedError = exception.Message.IndexOf(AzdCliFailedError, StringComparison.OrdinalIgnoreCase) != -1 &&
                                                 exception.Message.IndexOf(RefreshTokeExpired, StringComparison.OrdinalIgnoreCase) != -1 ||
                                                 exception.Message.IndexOf("CLIInternalError", StringComparison.OrdinalIgnoreCase) != -1;

                if (isRefreshTokenFailedError)
                {
                    throw new CredentialUnavailableException(InteractiveLoginRequired);
                }

                if (_isChainedCredential)
                {
                    throw new CredentialUnavailableException($"{AzdCliFailedError} {Troubleshoot} {exception.Message}");
                }
                else
                {
                    throw new AuthenticationFailedException($"{AzdCliFailedError} {Troubleshoot} {exception.Message}");
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

        private static ProcessStartInfo GetAzureDeveloperCliProcessStartInfo(string fileName, string argument) =>
            new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = argument,
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WorkingDirectory = DefaultWorkingDir
            };

        private static void GetFileNameAndArguments(string[] scopes, string tenantId, string claims, out string fileName, out string argument)
        {
            string scopeArgs = string.Join(" ", scopes.Select(scope => $"--scope {scope}"));
            // azd expects the value passed to --claims to be base64 encoded. TokenRequestContext.Claims is a JSON string
            // so we encode it here (the auth policy will decode it later).
            string claimsArg = string.Empty;
            if (!string.IsNullOrWhiteSpace(claims))
            {
                try
                {
                    string encodedClaims = Convert.ToBase64String(Encoding.UTF8.GetBytes(claims));
                    claimsArg = $" --claims {encodedClaims}";
                }
                catch (Exception)
                {
                    // If encoding fails, fall back to omitting claims to mirror the prior behavior of not throwing for formatting issues here.
                    claimsArg = string.Empty;
                }
            }
            string command = tenantId switch
            {
                null => $"azd auth token --output json --no-prompt {scopeArgs}{claimsArg}",
                _ => $"azd auth token --output json --no-prompt {scopeArgs} --tenant-id {tenantId}{claimsArg}"
            };

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
            string accessToken = root.GetProperty("token").GetString();
            DateTimeOffset expiresOn = root.GetProperty("expiresOn").GetDateTimeOffset();
            return new AccessToken(accessToken, expiresOn);
        }
    }
}
