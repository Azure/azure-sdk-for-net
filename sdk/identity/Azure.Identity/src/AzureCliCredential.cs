// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using Azure CLI to obtain an access token.
    /// </summary>
    public class AzureCliCredential : TokenCredential
    {
        private const string AzureCLINotInstalled = "Azure CLI not installed";
        private const string AzNotLogIn = "Please run 'az login' to set up account";
        private const string WinAzureCLIError = "'az' is not recognized";
        private const string AzureCliTimeoutError = "Azure CLI authentication timed out.";
        private const string AzureCliFailedError = "Azure CLI authentication failed due to an unknown error.";
        private const int CliProcessTimeoutMs = 10000;

        // The default install paths are used to find Azure CLI if no path is specified. This is to prevent executing out of the current working directory.
        private static readonly string DefaultPathWindows = $"{EnvironmentVariables.ProgramFilesX86}\\Microsoft SDKs\\Azure\\CLI2\\wbin;{EnvironmentVariables.ProgramFiles}\\Microsoft SDKs\\Azure\\CLI2\\wbin";
        private static readonly string DefaultWorkingDirWindows = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private const string DefaultPathNonWindows = "/usr/bin:/usr/local/bin";
        private const string DefaultWorkingDirNonWindows = "/bin/";
        private static readonly string DefaultPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultPathWindows : DefaultPathNonWindows;
        private static readonly string DefaultWorkingDir = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultWorkingDirWindows : DefaultWorkingDirNonWindows;

        private static readonly Regex AzNotFoundPattern = new Regex("az:(.*)not found");

        private readonly string _path;

        private readonly CredentialPipeline _pipeline;
        private readonly IProcessService _processService;

        /// <summary>
        /// Create an instance of CliCredential class.
        /// </summary>
        public AzureCliCredential()
            : this(CredentialPipeline.GetInstance(null), default)
        { }

        internal AzureCliCredential(CredentialPipeline pipeline, IProcessService processService)
        {
            _pipeline = pipeline;
            _path = !string.IsNullOrEmpty(EnvironmentVariables.Path) ? EnvironmentVariables.Path : DefaultPath;
            _processService = processService ?? ProcessService.Default;
        }

        /// <summary>
        /// Obtains a access token from Azure CLI credential, using this access token to authenticate. This method called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a access token from Azure CLI service, using the access token to authenticate. This method id called by Azure SDK clients.
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
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("AzureCliCredential.GetToken", requestContext);

            try
            {
                AccessToken token = await RequestCliAccessTokenAsync(async, requestContext.Scopes, cancellationToken).ConfigureAwait(false);
                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<AccessToken> RequestCliAccessTokenAsync(bool async, string[] scopes, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(scopes);

            ScopeUtilities.ValidateScope(resource);

            GetFileNameAndArguments(resource, out string fileName, out string argument);
            ProcessStartInfo processStartInfo = GetAzureCliProcessStartInfo(fileName, argument);
            using var processRunner = new ProcessRunner(_processService.Create(processStartInfo), TimeSpan.FromMilliseconds(CliProcessTimeoutMs), cancellationToken);

            string output;
            try
            {
                output = async ? await processRunner.RunAsync().ConfigureAwait(false) : processRunner.Run();
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                throw new AuthenticationFailedException(AzureCliTimeoutError);
            }
            catch (InvalidOperationException exception)
            {
                bool isWinError = exception.Message.StartsWith(WinAzureCLIError, StringComparison.CurrentCultureIgnoreCase);

                bool isOtherOsError = AzNotFoundPattern.IsMatch(exception.Message);

                if (isWinError || isOtherOsError)
                {
                    throw new CredentialUnavailableException(AzureCLINotInstalled);
                }

                bool isLoginError = exception.Message.IndexOf("az login", StringComparison.OrdinalIgnoreCase) != -1 || exception.Message.IndexOf("az account set", StringComparison.OrdinalIgnoreCase) != -1;

                if (isLoginError)
                {
                    throw new CredentialUnavailableException(AzNotLogIn);
                }

                throw new AuthenticationFailedException($"{AzureCliFailedError} {exception.Message}");
            }

            return DeserializeOutput(output);
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
                Environment = {{"PATH", _path}}
            };

        private static void GetFileNameAndArguments(string resource, out string fileName, out string argument)
        {
            string command = $"az account get-access-token --output json --resource {resource}";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe");
                argument = $"/c \"{command}\"";
            } else {
                fileName = "/bin/sh";
                argument = $"-c \"{command}\"";
            }
        }

        private static AccessToken DeserializeOutput(string output)
        {
            using JsonDocument document = JsonDocument.Parse(output);

            JsonElement root = document.RootElement;
            string accessToken = root.GetProperty("accessToken").GetString();
            DateTimeOffset expiresOn = root.TryGetProperty("expiresIn", out JsonElement expiresIn)
                ? DateTimeOffset.UtcNow + TimeSpan.FromSeconds(expiresIn.GetInt64())
                : DateTimeOffset.ParseExact(root.GetProperty("expiresOn").GetString(), "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal);

            return new AccessToken(accessToken, expiresOn);
        }
    }
}
