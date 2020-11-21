// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
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
        private const string AzurePowerShellNotLogInError = "Please run 'Connect-AzAccount' to set up account.";
        private const string AzurePowerShellModuleNotInstalledError = "Az.Accounts module is not installed.";
        private const string PowerShellNotInstalledError = "PowerShell is not installed.";

        private const string AzurePowerShellNoContext = "NoContext";
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

                throw new AuthenticationFailedException($"{AzurePowerShellFailedError} {exception.Message}");
            }

            return GetTokenWithExpirationDateTimeUtc(output);
        }

        private static void CheckForErrors(string output)
        {
            if (output.IndexOf(AzurePowerShellNoContext, StringComparison.OrdinalIgnoreCase) != -1)
            {
                throw new CredentialUnavailableException(AzurePowerShellNotLogInError);
            }

            if (output.IndexOf(AzurePowerShellNoAzAccountModule, StringComparison.OrdinalIgnoreCase) != -1)
            {
                throw new CredentialUnavailableException(AzurePowerShellModuleNotInstalledError);
            }
        }

        private ProcessStartInfo GetAzurePowerShellProcessStartInfo(string fileName, string argument) =>
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

            string command = $"$ErrorActionPreference = 'Stop'; $skip = $false; $m = Get-Module Az.Accounts -ListAvailable; if (! $m) {{$skip = $true; Write-Output '{AzurePowerShellNoAzAccountModule}'}}; if (! $skip) {{ $c = Get-AzContext ; if (! $c) {{$skip = $true; Write-Output '{AzurePowerShellNoContext}'}}}} ; if (! $skip) {{$token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($c.Account, $c.Environment, $c.Tenant.Id, $null, $null, $null, '{resource}'); return $token.AccessToken}}";

            string commandBase64 = Base64Encode(command);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe");
                argument = $"/c \"{powershellExe} \"{commandBase64}\" \"";
            }
            else
            {
                fileName = "/bin/sh";
                argument = $"-c \"{powershellExe} \"{commandBase64}\" \"";
            }
        }

        private static AccessToken GetTokenWithExpirationDateTimeUtc(string token)
        {
            var jwtSecurityToken = new JwtSecurityToken(token);
            return new AccessToken(token, jwtSecurityToken.ValidTo);
        }

        private static string Base64Encode(string text)
        {
            var plainTextBytes = Encoding.Unicode.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
