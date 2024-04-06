// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID using Azure PowerShell to obtain an access token.
    /// </summary>
    public class AzurePowerShellCredential : TokenCredential
    {
        private readonly CredentialPipeline _pipeline;
        private readonly IProcessService _processService;
        internal TimeSpan ProcessTimeout { get; private set; }
        internal bool UseLegacyPowerShell { get; set; }
        internal TenantIdResolverBase TenantIdResolver { get; }

        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/powershellcredential/troubleshoot";
        internal const string AzurePowerShellFailedError = "Azure PowerShell authentication failed due to an unknown error. " + Troubleshooting;
        private const string RunConnectAzAccountToLogin = "Run Connect-AzAccount to login";
        private const string NoAccountsWereFoundInTheCache = "No accounts were found in the cache";
        private const string CannotRetrieveAccessToken = "cannot retrieve access token";
        private const string AzurePowerShellNoAzAccountModule = "NoAzAccountModule";
        private static readonly string DefaultWorkingDirWindows = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private const string DefaultWorkingDirNonWindows = "/bin/";
        private static readonly string DefaultWorkingDir = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultWorkingDirWindows : DefaultWorkingDirNonWindows;
        internal string TenantId { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        private readonly bool _logPII;
        private readonly bool _logAccountDetails;
        internal readonly bool _isChainedCredential;
        internal const string AzurePowerShellNotLogInError = "Please run 'Connect-AzAccount' to set up account.";
        internal const string AzurePowerShellModuleNotInstalledError = "Az.Accounts module >= 2.2.0 is not installed.";
        internal const string PowerShellNotInstalledError = "PowerShell is not installed.";
        internal const string AzurePowerShellTimeoutError = "Azure PowerShell authentication timed out.";

        /// <summary>
        /// Creates a new instance of the <see cref="AzurePowerShellCredential"/>.
        /// </summary>
        public AzurePowerShellCredential()
            : this(default, default, default)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="AzurePowerShellCredential"/> with the specified options.
        /// </summary>
        /// <param name="options">Options for configuring the credential.</param>
        public AzurePowerShellCredential(AzurePowerShellCredentialOptions options) : this(options, default, default)
        { }

        internal AzurePowerShellCredential(AzurePowerShellCredentialOptions options, CredentialPipeline pipeline, IProcessService processService)
        {
            UseLegacyPowerShell = false;
            _logPII = options?.IsUnsafeSupportLoggingEnabled ?? false;
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            TenantId = Validations.ValidateTenantId(options?.TenantId, $"{nameof(options)}.{nameof(options.TenantId)}", true);
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            _processService = processService ?? ProcessService.Default;
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
            ProcessTimeout = options?.ProcessTimeout ?? TimeSpan.FromSeconds(10);
            _isChainedCredential = options?.IsChainedCredential ?? false;
        }

        /// <summary>
        /// Obtains a access token from Azure PowerShell, using the access token to authenticate. This method id called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a access token from Azure PowerShell, using the access token to authenticate. This method id called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("AzurePowerShellCredential.GetToken", requestContext);

            try
            {
                AccessToken token = await RequestAzurePowerShellAccessTokenAsync(async, requestContext, cancellationToken).ConfigureAwait(false);
                if (_logAccountDetails)
                {
                    var accountDetails = TokenHelper.ParseAccountInfoFromToken(token.Token);
                    AzureIdentityEventSource.Singleton.AuthenticatedAccountDetails(accountDetails.ClientId, accountDetails.TenantId ?? TenantId, accountDetails.Upn, accountDetails.ObjectId);
                }
                return scope.Succeeded(token);
            }
            // External execution is wrapped in a "cmd /c" command which will never throw a native Win32Exception ERROR_FILE_NOT_FOUND
            // Check against the message for constant PowerShellNotInstalledError
            // Do not retry if already using legacy PowerShell to prevent delays, also used in tests to ensure a single process result
            catch (CredentialUnavailableException ex) when (UseLegacyPowerShell == false && ex.Message == PowerShellNotInstalledError && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                UseLegacyPowerShell = true;
                try
                {
                    AccessToken token = await RequestAzurePowerShellAccessTokenAsync(async, requestContext, cancellationToken).ConfigureAwait(false);

                    if (_logAccountDetails)
                    {
                        AzureIdentityEventSource.Singleton.AuthenticatedAccountDetails(null, TenantId, null, null);
                    }

                    return scope.Succeeded(token);
                }
                catch (Exception e)
                {
                    throw scope.FailWrapAndThrow(e, isCredentialUnavailable: _isChainedCredential);
                }
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, isCredentialUnavailable: _isChainedCredential);
            }
        }

        private async ValueTask<AccessToken> RequestAzurePowerShellAccessTokenAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(context.Scopes);

            var tenantId = TenantIdResolver.Resolve(TenantId, context, AdditionallyAllowedTenantIds);

            Validations.ValidateTenantId(tenantId, nameof(context.TenantId), true);

            ScopeUtilities.ValidateScope(resource);

            GetFileNameAndArguments(resource, tenantId, out string fileName, out string argument);
            ProcessStartInfo processStartInfo = GetAzurePowerShellProcessStartInfo(fileName, argument);
            using var processRunner = new ProcessRunner(
                _processService.Create(processStartInfo),
                ProcessTimeout,
                _logPII,
                cancellationToken);

            string output;
            try
            {
                output = async ? await processRunner.RunAsync().ConfigureAwait(false) : processRunner.Run();
                CheckForErrors(output, processRunner.ExitCode);
                ValidateResult(output);
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                throw new AuthenticationFailedException(AzurePowerShellTimeoutError);
            }
            catch (InvalidOperationException exception)
            {
                CheckForErrors(exception.Message, processRunner.ExitCode);
                if (_isChainedCredential)
                {
                    throw new CredentialUnavailableException($"{AzurePowerShellFailedError} {exception.Message}");
                }
                else
                {
                    throw new AuthenticationFailedException($"{AzurePowerShellFailedError} {exception.Message}");
                }
            }
            return DeserializeOutput(output);
        }

        private static void CheckForErrors(string output, int exitCode)
        {
            int notFoundExitCode = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 9009 : 127;
            bool noPowerShell = (exitCode == notFoundExitCode || output.IndexOf("not found", StringComparison.OrdinalIgnoreCase) != -1 ||
                                output.IndexOf("is not recognized", StringComparison.OrdinalIgnoreCase) != -1) &&
                                // If the error contains AADSTS, this should be treated as a general error to be bubbled to the user
                                output.IndexOf("AADSTS", StringComparison.OrdinalIgnoreCase) == -1;
            if (noPowerShell)
            {
                throw new CredentialUnavailableException(PowerShellNotInstalledError);
            }
            if (output.IndexOf(AzurePowerShellNoAzAccountModule, StringComparison.OrdinalIgnoreCase) != -1)
            {
                throw new CredentialUnavailableException(AzurePowerShellModuleNotInstalledError);
            }

            var needsLogin = output.IndexOf(RunConnectAzAccountToLogin, StringComparison.OrdinalIgnoreCase) != -1 ||
                             output.IndexOf(NoAccountsWereFoundInTheCache, StringComparison.OrdinalIgnoreCase) != -1 ||
                             output.IndexOf(CannotRetrieveAccessToken, StringComparison.OrdinalIgnoreCase) != -1;
            if (needsLogin)
            {
                throw new CredentialUnavailableException(AzurePowerShellNotLogInError);
            }
        }

        private static void ValidateResult(string output)
        {
            if (output.IndexOf(@"<Property Name=""Token"" Type=""System.String"">", StringComparison.OrdinalIgnoreCase) < 0)
            {
                throw new CredentialUnavailableException("PowerShell did not return a valid response.");
            }
        }

        private static ProcessStartInfo GetAzurePowerShellProcessStartInfo(string fileName, string argument) =>
            new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = argument,
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WorkingDirectory = DefaultWorkingDir,
                Environment =
                {
                    ["POWERSHELL_UPDATECHECK"] = "Off",
                },
            };

        private void GetFileNameAndArguments(string resource, string tenantId, out string fileName, out string argument)
        {
            string powershellExe = "pwsh -NoProfile -NonInteractive -EncodedCommand";

            if (UseLegacyPowerShell)
            {
                powershellExe = "powershell -NoProfile -NonInteractive -EncodedCommand";
            }

            var tenantIdArg = tenantId == null ? string.Empty : $" -TenantId {tenantId}";

            string command = @$"
$ErrorActionPreference = 'Stop'
[version]$minimumVersion = '2.2.0'

$m = Import-Module Az.Accounts -MinimumVersion $minimumVersion -PassThru -ErrorAction SilentlyContinue

if (! $m) {{
    Write-Output '{AzurePowerShellNoAzAccountModule}'
    exit
}}

$token = Get-AzAccessToken -ResourceUrl '{resource}'{tenantIdArg}
$customToken = New-Object -TypeName psobject
$customToken | Add-Member -MemberType NoteProperty -Name Token -Value $token.Token
$customToken | Add-Member -MemberType NoteProperty -Name ExpiresOn -Value $token.ExpiresOn.ToUnixTimeSeconds()

$x = $customToken | ConvertTo-Xml
return $x.Objects.FirstChild.OuterXml
";

            string commandBase64 = Base64Encode(command);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = Path.Combine(DefaultWorkingDirWindows, "cmd.exe");
                argument = $"/d /c \"{powershellExe} \"{commandBase64}\" \" & exit";
            }
            else
            {
                fileName = $"{DefaultWorkingDirNonWindows}sh";
                argument = $"-c \"{powershellExe} \"{commandBase64}\" \"";
            }
        }

        private static AccessToken DeserializeOutput(string output)
        {
            XDocument document = XDocument.Parse(output);
            string accessToken = null;
            DateTimeOffset expiresOn = default;

            if (document?.Root == null)
            {
                throw new CredentialUnavailableException("Error parsing token response.");
            }

            foreach (var e in document.Root.Elements())
            {
                switch (e.Attribute("Name")?.Value)
                {
                    case "Token":
                        accessToken = e.Value;
                        break;

                    case "ExpiresOn":
                        expiresOn = DateTimeOffset.FromUnixTimeSeconds(long.Parse(e.Value));
                        break;
                }

                if (expiresOn != default && accessToken != null)
                    break;
            }

            if (accessToken == null)
            {
                throw new CredentialUnavailableException("Error parsing token response.");
            }

            return new AccessToken(accessToken, expiresOn);
        }

        private static string Base64Encode(string text)
        {
            var plainTextBytes = Encoding.Unicode.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
