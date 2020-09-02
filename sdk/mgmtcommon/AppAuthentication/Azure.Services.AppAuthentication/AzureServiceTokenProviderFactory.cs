// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Creates an access token provider based on the connection string. 
    /// </summary>
    internal class AzureServiceTokenProviderFactory
    {
        private const string RunAs = "RunAs";
        private const string Developer = "Developer";
        private const string AzureCli = "AzureCLI";
        private const string VisualStudio = "VisualStudio";
        private const string DeveloperTool = "DeveloperTool";
        private const string CurrentUser = "CurrentUser";
        private const string App = "App";
        private const string AppId = "AppId";
        private const string AppKey = "AppKey";
        private const string TenantId = "TenantId";
        private const string CertificateSubjectName = "CertificateSubjectName";
        private const string CertificateThumbprint = "CertificateThumbprint";
        private const string KeyVaultCertificateSecretIdentifier = "KeyVaultCertificateSecretIdentifier";
        private const string CertificateStoreLocation = "CertificateStoreLocation";
        private const string MsiRetryTimeout = "MsiRetryTimeout";

        // taken from https://github.com/dotnet/corefx/blob/master/src/Common/src/System/Data/Common/DbConnectionOptions.Common.cs
        private const string ConnectionStringPattern =                      // may not contain embedded null except trailing last value
                  "([\\s;]*"                                                // leading whitespace and extra semicolons
                + "(?![\\s;])"                                              // key does not start with space or semicolon
                + "(?<key>([^=\\s\\p{Cc}]|\\s+[^=\\s\\p{Cc}]|\\s+==|==)+)"  // allow any visible character for keyname except '=' which must quoted as '=='
                + "\\s*=(?!=)\\s*"                                          // the equal sign divides the key and value parts
                + "(?<value>"
                + "(\"([^\"\u0000]|\"\")*\")"                               // double quoted string, " must be quoted as ""
                + "|"
                + "('([^'\u0000]|'')*')"                                    // single quoted string, ' must be quoted as ''
                + "|"
                + "((?![\"'\\s])"                                           // unquoted value must not start with " or ' or space, would also like = but too late to change
                + "([^;\\s\\p{Cc}]|\\s+[^;\\s\\p{Cc}])*"                    // control characters must be quoted
                + "(?<![\"']))"                                             // unquoted value must not stop with " or '
                + ")(\\s*)(;|[\u0000\\s]*$)"                                // whitespace after value up to semicolon or end-of-line
                + ")*"                                                      // repeat the key-value pair
                + "[\\s;]*[\u0000\\s]*"                                     // trailing whitespace/semicolons (DataSourceLocator), embedded nulls are allowed only in the end
            ;
        private static readonly Regex ConnectionStringRegex = new Regex(ConnectionStringPattern, RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        /// <summary>
        /// Returns a specific token provider based on authentication option specified in the connection string. 
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        /// <param name="azureAdInstance"></param>
        /// <returns></returns>
        internal static NonInteractiveAzureServiceTokenProviderBase Create(string connectionString, string azureAdInstance, IHttpClientFactory httpClientFactory = default)
        {
            Dictionary<string, string> connectionSettings = ParseConnectionString(connectionString);

            NonInteractiveAzureServiceTokenProviderBase azureServiceTokenProvider;

            ValidateAttribute(connectionSettings, RunAs, connectionString);

            string runAs = connectionSettings[RunAs];

            if (string.Equals(runAs, Developer, StringComparison.OrdinalIgnoreCase))
            {
                // If RunAs=Developer
                ValidateAttribute(connectionSettings, DeveloperTool, connectionString);

                // And Dev Tool equals AzureCLI or VisualStudio
                if (string.Equals(connectionSettings[DeveloperTool], AzureCli,
                    StringComparison.OrdinalIgnoreCase))
                {
                    azureServiceTokenProvider = new AzureCliAccessTokenProvider(new ProcessManager());
                }
                else if (string.Equals(connectionSettings[DeveloperTool], VisualStudio,
                    StringComparison.OrdinalIgnoreCase))
                {
                    azureServiceTokenProvider = new VisualStudioAccessTokenProvider(new ProcessManager());
                }
                else
                {
                    throw new ArgumentException($"Connection string {connectionString} is not valid. {DeveloperTool} '{connectionSettings[DeveloperTool]}' is not valid. " +
                                                $"Allowed values are {AzureCli} or {VisualStudio}");
                }
            }
            else if (string.Equals(runAs, CurrentUser, StringComparison.OrdinalIgnoreCase))
            {
                // If RunAs=CurrentUser
#if FullNetFx
                azureServiceTokenProvider = new WindowsAuthenticationAzureServiceTokenProvider(new AdalAuthenticationContext(httpClientFactory), azureAdInstance);
#else
                throw new ArgumentException($"Connection string {connectionString} is not supported for .NET Core.");
#endif
            }
            else if (string.Equals(runAs, App, StringComparison.OrdinalIgnoreCase))
            {
                // If RunAs=App
                // If AppId key is present, use certificate, client secret, or MSI (with user assigned identity) based token provider
                if (connectionSettings.ContainsKey(AppId))
                {
                    ValidateAttribute(connectionSettings, AppId, connectionString);

                    if (connectionSettings.ContainsKey(CertificateStoreLocation))
                    {
                        ValidateAttributes(connectionSettings, new List<string> { CertificateSubjectName, CertificateThumbprint }, connectionString);
                        ValidateAttribute(connectionSettings, CertificateStoreLocation, connectionString);
                        ValidateStoreLocation(connectionSettings, connectionString);
                        ValidateAttribute(connectionSettings, TenantId, connectionString);

                        azureServiceTokenProvider =
                            new ClientCertificateAzureServiceTokenProvider(
                                connectionSettings[AppId],
                                connectionSettings.ContainsKey(CertificateThumbprint)
                                    ? connectionSettings[CertificateThumbprint]
                                    : connectionSettings[CertificateSubjectName],
                                connectionSettings.ContainsKey(CertificateThumbprint)
                                    ? ClientCertificateAzureServiceTokenProvider.CertificateIdentifierType.Thumbprint
                                    : ClientCertificateAzureServiceTokenProvider.CertificateIdentifierType.SubjectName,
                                connectionSettings[CertificateStoreLocation],
                                azureAdInstance,
                                connectionSettings[TenantId],
                                0,
                                new AdalAuthenticationContext(httpClientFactory));
                    }
                    else if (connectionSettings.ContainsKey(CertificateThumbprint) ||
                             connectionSettings.ContainsKey(CertificateSubjectName))
                    {
                        // if certificate thumbprint or subject name are specified but certificate store location is not, throw error
                        throw new ArgumentException($"Connection string {connectionString} is not valid. Must contain '{CertificateStoreLocation}' attribute and it must not be empty " +
                                                    $"when using '{CertificateThumbprint}' and '{CertificateSubjectName}' attributes");
                    }
                    else if (connectionSettings.ContainsKey(KeyVaultCertificateSecretIdentifier))
                    {
                        ValidateMsiRetryTimeout(connectionSettings, connectionString);

                        azureServiceTokenProvider =
                            new ClientCertificateAzureServiceTokenProvider(
                                connectionSettings[AppId],
                                connectionSettings[KeyVaultCertificateSecretIdentifier],
                                ClientCertificateAzureServiceTokenProvider.CertificateIdentifierType.KeyVaultCertificateSecretIdentifier,
                                null, // storeLocation unused
                                azureAdInstance,
                                connectionSettings.ContainsKey(TenantId) // tenantId can be specified in connection string or retrieved from Key Vault access token later
                                    ? connectionSettings[TenantId]
                                    : default,
                                connectionSettings.ContainsKey(MsiRetryTimeout)
                                    ? int.Parse(connectionSettings[MsiRetryTimeout])
                                    : 0,
                                new AdalAuthenticationContext(httpClientFactory));
                    }
                    else if (connectionSettings.ContainsKey(AppKey))
                    {
                        ValidateAttribute(connectionSettings, AppKey, connectionString);
                        ValidateAttribute(connectionSettings, TenantId, connectionString);

                        azureServiceTokenProvider =
                            new ClientSecretAccessTokenProvider(
                                connectionSettings[AppId],
                                connectionSettings[AppKey],
                                connectionSettings[TenantId],
                                azureAdInstance,
                                new AdalAuthenticationContext(httpClientFactory));
                    }
                    else
                    {
                        ValidateMsiRetryTimeout(connectionSettings, connectionString);

                        // If certificate or client secret are not specified, use the specified managed identity
                        azureServiceTokenProvider = new MsiAccessTokenProvider(
                            connectionSettings.ContainsKey(MsiRetryTimeout)
                                ? int.Parse(connectionSettings[MsiRetryTimeout])
                                : 0,
                            connectionSettings[AppId]);
                    }
                }
                else
                {
                    ValidateMsiRetryTimeout(connectionSettings, connectionString);

                    // If AppId is not specified, use Managed Service Identity
                    azureServiceTokenProvider = new MsiAccessTokenProvider(
                        connectionSettings.ContainsKey(MsiRetryTimeout)
                            ? int.Parse(connectionSettings[MsiRetryTimeout])
                            : 0);
                }
            }
            else
            {
                throw new ArgumentException($"Connection string {connectionString} is not valid. RunAs value '{connectionSettings[RunAs]}' is not valid.  " +
                                            $"Allowed values are {Developer}, {CurrentUser}, or {App}");
            }

            azureServiceTokenProvider.ConnectionString = connectionString;

            return azureServiceTokenProvider;

        }

        private static void ValidateAttribute(Dictionary<string, string> connectionSettings, string attribute,
        string connectionString)
        {
            if (connectionSettings != null &&
                (!connectionSettings.ContainsKey(attribute) || string.IsNullOrWhiteSpace(connectionSettings[attribute])))
            {
                throw new ArgumentException($"Connection string {connectionString} is not valid. Must contain '{attribute}' attribute and it must not be empty.");
            }
        }

        /// <summary>
        /// Throws an exception if none of the attributes are in the connection string
        /// </summary>
        /// <param name="connectionSettings">List of key value pairs in the connection string</param>
        /// <param name="attributes">List of attributes to test</param>
        /// <param name="connectionString">The connection string specified</param>
        private static void ValidateAttributes(Dictionary<string, string> connectionSettings, List<string> attributes,
        string connectionString)
        {
            if (connectionSettings != null)
            {
                foreach (string attribute in attributes)
                {
                    if (connectionSettings.ContainsKey(attribute))
                    {
                        return;
                    }
                }

                throw new ArgumentException($"Connection string {connectionString} is not valid. Must contain at least one of {string.Join(" or ", attributes)} attributes.");
            }
        }

        private static void ValidateStoreLocation(Dictionary<string, string> connectionSettings, string connectionString)
        {
            if (connectionSettings != null && connectionSettings.ContainsKey(CertificateStoreLocation))
            {
                if (!string.IsNullOrEmpty(connectionSettings[CertificateStoreLocation]))
                {
                    StoreLocation location;
                    string storeLocation = connectionSettings[CertificateStoreLocation];

                    bool parseSucceeded = Enum.TryParse(storeLocation, true, out location);
                    if (!parseSucceeded)
                    {
                        throw new ArgumentException(
                            $"Connection string {connectionString} is not valid. StoreLocation {storeLocation} is not valid. Valid values are CurrentUser and LocalMachine.");
                    }
                }

            }
        }

        private static void ValidateMsiRetryTimeout(Dictionary<string, string> connectionSettings, string connectionString)
        {
            if (connectionSettings != null && connectionSettings.ContainsKey(MsiRetryTimeout))
            {
                if (!string.IsNullOrEmpty(connectionSettings[MsiRetryTimeout]))
                {
                    int timeoutInt;
                    string timeoutString = connectionSettings[MsiRetryTimeout];

                    bool parseSucceeded = int.TryParse(timeoutString, out timeoutInt);
                    if (!parseSucceeded)
                    {
                        throw new ArgumentException(
                            $"Connection string {connectionString} is not valid. MsiRetryTimeout {timeoutString} is not valid. Valid values are integers greater than or equal to 0.");
                    }
                }

            }
        }

        // adapted from https://github.com/dotnet/corefx/blob/master/src/Common/src/System/Data/Common/DbConnectionOptions.Common.cs
        internal static Dictionary<string, string> ParseConnectionString(string connectionString)
        {
            Dictionary<string, string> connectionSettings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            const int KeyIndex = 1, ValueIndex = 2;

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                Match match = ConnectionStringRegex.Match(connectionString);
                if (!match.Success || (match.Length != connectionString.Length))
                {
                    throw new ArgumentException(
                            $"Connection string {connectionString} is not in a proper format. Expected format is Key1=Value1;Key2=Value2;");
                }

                int indexValue = 0;
                CaptureCollection keyValues = match.Groups[ValueIndex].Captures;
                foreach (Capture keyNames in match.Groups[KeyIndex].Captures)
                {
                    string key = keyNames.Value.Replace("==", "=");
                    string value = keyValues[indexValue++].Value;
                    if (value.Length > 0)
                    {
                        switch (value[0])
                        {
                            case '\"':
                                value = value.Substring(1, value.Length - 2).Replace("\"\"", "\"");
                                break;
                            case '\'':
                                value = value.Substring(1, value.Length - 2).Replace("\'\'", "\'");
                                break;
                            default:
                                break;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        if (!connectionSettings.ContainsKey(key))
                        {
                            connectionSettings[key] = value;
                        }
                        else
                        {
                            throw new ArgumentException(
                                $"Connection string {connectionString} is not in a proper format. Key '{key}' is repeated.");
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Connection string is empty.");
            }

            return connectionSettings;
        }
    }
}
