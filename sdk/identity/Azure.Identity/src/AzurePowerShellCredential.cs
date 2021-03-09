// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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
    /// Enables authentication to Azure Active Directory using Azure PowerShell to obtain an access token.
    /// </summary>
    public class AzurePowerShellCredential: TokenCredential
    {
        private readonly CredentialPipeline _pipeline;
        private readonly IProcessService _processService;
        private const int PowerShellProcessTimeoutMs = 10000;
        internal bool UseLegacyPowerShell { get; }

        private const string AzurePowerShellFailedError = "Azure PowerShell authentication failed due to an unknown error.";
        private const string AzurePowerShellTimeoutError = "Azure PowerShell authentication timed out.";
        internal const string AzurePowerShellNotLogInError = "Please run 'Connect-AzAccount' to set up account.";
        internal const string AzurePowerShellModuleNotInstalledError = "Az.Account module >= 2.2.0 is not installed.";
        internal const string PowerShellNotInstalledError = "PowerShell is not installed.";

        private const string AzurePowerShellNoAzAccountModule = "NoAzAccountModule";
        private static readonly string DefaultWorkingDirWindows = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private const string DefaultWorkingDirNonWindows = "/bin/";
        private static readonly string DefaultWorkingDir = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultWorkingDirWindows : DefaultWorkingDirNonWindows;

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
        {
        }

        internal AzurePowerShellCredential(AzurePowerShellCredentialOptions options, CredentialPipeline pipeline, IProcessService processService)
        {
            UseLegacyPowerShell = options?.UseLegacyPowerShell ?? new AzurePowerShellCredentialOptions().UseLegacyPowerShell;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            _processService = processService ?? ProcessService.Default;
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
                AccessToken token = await RequestAzurePowerShellAccessTokenAsync(async, requestContext.Scopes, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<AccessToken> RequestAzurePowerShellAccessTokenAsync(bool async, string[] scopes, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(scopes);

            ScopeUtilities.ValidateScope(resource);

            GetFileNameAndArguments(resource, out string fileName, out string argument);
            ProcessStartInfo processStartInfo = GetAzurePowerShellProcessStartInfo(fileName, argument);
            using var processRunner = new ProcessRunner(_processService.Create(processStartInfo), TimeSpan.FromMilliseconds(PowerShellProcessTimeoutMs), cancellationToken);

            string output;
            try
            {
                output = async ? await processRunner.RunAsync().ConfigureAwait(false) : processRunner.Run();

                CheckForErrors(output);
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                throw new AuthenticationFailedException(AzurePowerShellTimeoutError);
            }
            catch (InvalidOperationException exception)
            {
                bool noPowerShell = exception.Message.IndexOf("not found", StringComparison.OrdinalIgnoreCase) != -1 || exception.Message.IndexOf("is not recognized", StringComparison.OrdinalIgnoreCase) != -1;

                if (noPowerShell)
                {
                    throw new CredentialUnavailableException(PowerShellNotInstalledError);
                }

                bool noLogin = exception.Message.IndexOf("Run Connect-AzAccount to login", StringComparison.OrdinalIgnoreCase) != -1;

                if (noLogin)
                {
                    throw new CredentialUnavailableException(AzurePowerShellNotLogInError);
                }

                throw new AuthenticationFailedException($"{AzurePowerShellFailedError} {exception.Message}");
            }

            return DeserializeOutput(output);
        }

        private static void CheckForErrors(string output)
        {
            if (output.IndexOf(AzurePowerShellNoAzAccountModule, StringComparison.OrdinalIgnoreCase) != -1)
            {
                throw new CredentialUnavailableException(AzurePowerShellModuleNotInstalledError);
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
                WorkingDirectory = DefaultWorkingDir
            };

        private void GetFileNameAndArguments(string resource, out string fileName, out string argument)
        {
            string powershellExe = "pwsh -EncodedCommand";

            if (UseLegacyPowerShell)
            {
                powershellExe = "powershell -EncodedCommand";
            }

            string command = @$"
$ErrorActionPreference = 'Stop'
[version]$minimumVersion = '2.2.0'

$m = Import-Module Az.Accounts -MinimumVersion $minimumVersion -PassThru -ErrorAction SilentlyContinue

if (! $m) {{
    Write-Output '{AzurePowerShellNoAzAccountModule}'
    exit
}}

$token = Get-AzAccessToken -ResourceUrl '{resource}'

return $token | ConvertTo-Json
";

            string commandBase64 = Base64Encode(command);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = Path.Combine(DefaultWorkingDirWindows, "cmd.exe");
                argument = $"/c \"{powershellExe} \"{commandBase64}\" \"";
            }
            else
            {
                fileName = $"{DefaultWorkingDirNonWindows}sh";
                argument = $"-c \"{powershellExe} \"{commandBase64}\" \"";
            }
        }

        private static AccessToken DeserializeOutput(string output)
        {
            using JsonDocument document = JsonDocument.Parse(output);

            JsonElement root = document.RootElement;
            string accessToken = root.GetProperty("Token").GetString();
            DateTimeOffset expiresOn = DateTimeOffset.ParseExact(root.GetProperty("ExpiresOn").GetString(), "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal);

            return new AccessToken(accessToken, expiresOn);
        }

        private static string Base64Encode(string text)
        {
            var plainTextBytes = Encoding.Unicode.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
