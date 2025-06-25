// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID as the user signed in to Visual Studio Code via
    /// the broker. Note that this credential relies on a reference to the Azure.Identity.Broker package.
    /// </summary>
    public class VisualStudioCodeCredential : InteractiveBrowserCredential
    {
        private const string CredentialsSection = "VS Code Azure";
        private const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/vscodecredential/troubleshoot";

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
        public VisualStudioCodeCredential() : base(GetBrokerOptoins(FileSystemService.Default)) { }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCodeCredential"/>.
        /// </summary>
#pragma warning disable CS0618 // Type or member is obsolete
        public VisualStudioCodeCredential(VisualStudioCodeCredentialOptions options) { }
#pragma warning restore CS0618 // Type or member is obsolete

        /// <InheritDoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default) =>
            GetTokenImpl(false, requestContext, cancellationToken).EnsureCompleted();

        /// <InheritDoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default) =>
            await GetTokenImpl(true, requestContext, cancellationToken).ConfigureAwait(false);

        private async Task<AccessToken> GetTokenImpl(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(VisualStudioCodeCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                var token = async
                    ? await base.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                    : base.GetToken(requestContext, cancellationToken);
                scope.Succeeded(token);

                return token;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, "VisualStudioCodeCredential failed to silently authenticate via the broker", isCredentialUnavailable: true);
            }
        }

        internal static InteractiveBrowserCredentialOptions GetBrokerOptoins(IFileSystemService _fileSystem)
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                ClientId = "f8b0c6d2-1a3e-4b5c-9f7d-8e1f2b3c4d5e", // VS Code Azure Client ID
                AuthenticationRecord = GetAuthenticationRecord(_fileSystem)
            };
            return options;
        }

        internal static AuthenticationRecord GetAuthenticationRecord(IFileSystemService _fileSystem)
        {
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var authRecordPath = Path.Combine(homeDir, ".azure", "ms-azuretools.vscode-azureresourcegroups", "authRecord.json");
            if (!_fileSystem.FileExists(authRecordPath))
            {
                return null;
            }
            try
            {
                var content = _fileSystem.ReadAllText(authRecordPath);
                var authRecord = ParseAuthenticationRecordFromJson(content);
                if (authRecord != null && !string.IsNullOrEmpty(authRecord.TenantId) && !string.IsNullOrEmpty(authRecord.HomeAccountId))
                {
                    return authRecord;
                }
            }
            catch (IOException) { }
            return null;
        }

        /// <summary>
        /// Parses JSON content into an AuthenticationRecord object.
        /// </summary>
        /// <param name="jsonContent">The JSON content to parse.</param>
        /// <returns>An AuthenticationRecord if parsing succeeds, null otherwise.</returns>
        private static AuthenticationRecord ParseAuthenticationRecordFromJson(string jsonContent)
        {
            if (string.IsNullOrEmpty(jsonContent))
            {
                return null;
            }

            try
            {
                var jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                var reader = new Utf8JsonReader(jsonBytes);

                string username = null;
                string authority = null;
                string homeAccountId = null;
                string tenantId = null;
                string clientId = null;

                if (reader.Read() && reader.TokenType == JsonTokenType.StartObject)
                {
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                    {
                        if (reader.TokenType == JsonTokenType.PropertyName)
                        {
                            var propertyName = reader.GetString();
                            reader.Read(); // Move to the value

                            switch (propertyName)
                            {
                                case "username":
                                    username = reader.GetString();
                                    break;
                                case "authority":
                                    authority = reader.GetString();
                                    break;
                                case "homeAccountId":
                                    homeAccountId = reader.GetString();
                                    break;
                                case "tenantId":
                                    tenantId = reader.GetString();
                                    break;
                                case "clientId":
                                    clientId = reader.GetString();
                                    break;
                                    // Skip other properties like "datetime"
                            }
                        }
                    }
                }

                // Validate that we have all required fields
                if (!string.IsNullOrEmpty(username) &&
                    !string.IsNullOrEmpty(authority) &&
                    !string.IsNullOrEmpty(homeAccountId) &&
                    !string.IsNullOrEmpty(tenantId) &&
                    !string.IsNullOrEmpty(clientId))
                {
                    return new AuthenticationRecord(username, authority, homeAccountId, tenantId, clientId);
                }
            }
            catch (JsonException)
            {
                // Return null if JSON parsing fails
            }

            return null;
        }
    }
}
