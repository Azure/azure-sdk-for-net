// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
        private const string CertificateStoreLocation = "CertificateStoreLocation";

        /// <summary>
        /// Returns a specific token provider based on authentication option specified in the connection string. 
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        /// <param name="azureAdInstance"></param>
        /// <returns></returns>
        internal static NonInteractiveAzureServiceTokenProviderBase Create(string connectionString, string azureAdInstance)
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
                azureServiceTokenProvider = new WindowsAuthenticationAzureServiceTokenProvider(new AdalAuthenticationContext(), azureAdInstance);
            }
            else if (string.Equals(runAs, App, StringComparison.OrdinalIgnoreCase))
            {
                // If RunAs=App
                // If AppId key is present, use certificate or Client Secret based token provider
                if (connectionSettings.ContainsKey(AppId))
                {
                    ValidateAttribute(connectionSettings, AppId, connectionString);
                    ValidateAttribute(connectionSettings, TenantId, connectionString);
                    ValidateAttributes(connectionSettings, new List<string> { CertificateStoreLocation, AppKey}, connectionString);

                    if (connectionSettings.ContainsKey(CertificateStoreLocation))
                    {
                        ValidateAttributes(connectionSettings, new List<string> { CertificateSubjectName, CertificateThumbprint }, connectionString);
                        ValidateAttribute(connectionSettings, CertificateStoreLocation, connectionString);
                        ValidateStoreLocation(connectionSettings, connectionString);

                        azureServiceTokenProvider =
                            new ClientCertificateAzureServiceTokenProvider(
                                connectionSettings[AppId],
                                connectionSettings.ContainsKey(CertificateThumbprint)
                                    ? connectionSettings[CertificateThumbprint]
                                    : connectionSettings[CertificateSubjectName],
                                connectionSettings.ContainsKey(CertificateThumbprint),
                                connectionSettings[CertificateStoreLocation],
                                connectionSettings[TenantId],
                                azureAdInstance,
                                new AdalAuthenticationContext());
                    }
                    else
                    {
                        ValidateAttribute(connectionSettings, AppKey, connectionString);

                        azureServiceTokenProvider =
                            new ClientSecretAccessTokenProvider(
                                connectionSettings[AppId],
                                connectionSettings[AppKey],
                                connectionSettings[TenantId],
                                azureAdInstance,
                                new AdalAuthenticationContext());
                    }
                }
                else
                {
                    // If AppId is not specified, use Managed service identity
                    azureServiceTokenProvider = new MsiAccessTokenProvider();
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

        private static Dictionary<string, string> ParseConnectionString(string connectionString)
        {
            Dictionary<string, string> connectionSettings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                // Split by ;
                string[] splitted = connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string splitSetting in splitted)
                {
                    // Remove spaces before and after key=value
                    string setting = splitSetting.Trim();

                    // If setting is empty, continue. This is an empty space at the end e.g. "key=value; "
                    if (setting.Length == 0)
                        continue;

                    if (setting.Contains("="))
                    {
                        // Key is the first part before =
                        string[] keyValuePair = setting.Split('=');
                        string key = keyValuePair[0].Trim();

                        // Value is everything else as is
                        var value = setting.Substring(keyValuePair[0].Length + 1).Trim();

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
                    else
                    {
                        throw new ArgumentException(
                            $"Connection string {connectionString} is not in a proper format. Expected format is Key1=Value1;Key2=Value=2;");
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
