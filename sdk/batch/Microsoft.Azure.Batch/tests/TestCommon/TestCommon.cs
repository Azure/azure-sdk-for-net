// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchTestCommon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TestCommon
    {
        public class TestConfiguration
        {
            public const string BatchSubscriptionEnivronmentSettingName = "MABOM_BatchAccountSubscriptionId";

            public const string BatchManagementUrlEnvironmentSettingName = "MABOM_BatchManagementEndpoint";

            public const string BatchAccountKeyEnvironmentSettingName = "MABOM_BatchAccountKey";

            public const string BatchAccountNameEnvironmentSettingName = "MABOM_BatchAccountName";

            public const string BatchTenantIDEnvironmentSettingName = "MABOM_BatchTenantID";

            public const string BatchAccountUrlEnvironmentSettingName = "MABOM_BatchAccountEndpoint";

            public const string StorageAccountKeyEnvironmentSettingName = "MABOM_StorageKey";

            public const string ClientIDEnvironmentSettingName = "MABOM_ClientID";

            public const string ClientKeyEnvironmentSettingName = "MABOM_ClientKey";

            public const string StorageAccountNameEnvironmentSettingName = "MABOM_StorageAccount";

            public const string StorageAccountBlobEndpointEnvironmentSettingName = "MABOM_BlobEndpoint";

            public const string BatchAccountResourceGroupEnvironmentSettingName = "MABOM_BatchAccountResourceGroupName";

            public const string StorageAccountResourceGroupEnvironmentSettingName = "MABOM_StorageAccountResourceGroupName";

            // Required only for Microsoft pre-production test environments

            // The client Id from the Azure Active Directory, this is used for connecting to the management api.
            public const string AzureAuthenticationClientIdEnvironmentSettingName = "MABOM_AzureAuthenticationClientId";

            // The client key from the Azure Active Directory app. 
            public const string AzureAuthenticationClientSecretEnvironmentSettingName = "MABOM_AzureAuthenticationClientSecret";

            public const string BatchAuthorityUrlEnvironmentSettingName = "MABOM_BatchAuthorityUrl";

            public const string BatchTRPCertificateThumbprintEnvironmentSettingName = "MABOM_BatchTRPCertificateThumbprint";

            //Should be a string like so: header1=value1;header2=value2;...
            // Required only for Microsoft pre-production test environments
            public const string BatchTRPExtraHeadersEnvironmentSettingName = "MABOM_BatchTRPExtraHeaders";

            public readonly string BatchSubscription = GetEnvironmentVariableOrThrow(BatchSubscriptionEnivronmentSettingName);

            public readonly string BatchManagementUrl = GetEnvironmentVariableOrThrow(BatchManagementUrlEnvironmentSettingName);

            public readonly string ClientKey = GetEnvironmentVariableOrThrow(ClientKeyEnvironmentSettingName);

            public readonly string ClientId = GetEnvironmentVariableOrThrow(ClientIDEnvironmentSettingName);

            public readonly string BatchAccountKey = GetEnvironmentVariableOrThrow(BatchAccountKeyEnvironmentSettingName);

            public readonly string BatchAccountName = GetEnvironmentVariableOrThrow(BatchAccountNameEnvironmentSettingName);

            public readonly string BatchAccountUrl = GetEnvironmentVariableOrThrow(BatchAccountUrlEnvironmentSettingName);

            public readonly string BatchTenantID = GetEnvironmentVariableOrThrow(BatchTenantIDEnvironmentSettingName);

            public readonly string StorageAccountKey = GetEnvironmentVariableOrThrow(StorageAccountKeyEnvironmentSettingName);

            public readonly string StorageAccountName = GetEnvironmentVariableOrThrow(StorageAccountNameEnvironmentSettingName);

            public readonly string StorageAccountBlobEndpoint = GetEnvironmentVariableOrThrow(StorageAccountBlobEndpointEnvironmentSettingName);

            public readonly string BatchAccountResourceGroup = GetEnvironmentVariableOrThrow(BatchAccountResourceGroupEnvironmentSettingName);

            public readonly string StorageAccountResourceGroup = GetEnvironmentVariableOrThrow(StorageAccountResourceGroupEnvironmentSettingName);

            public readonly Func<string> BatchTRPCertificateThumbprint = () => GetEnvironmentVariableOrThrow(BatchTRPCertificateThumbprintEnvironmentSettingName);

            public readonly string AzureAuthenticationClientId = GetEnvironmentVariableOrThrow(AzureAuthenticationClientIdEnvironmentSettingName);

            public readonly string AzureAuthenticationClientSecret = GetEnvironmentVariableOrThrow(AzureAuthenticationClientSecretEnvironmentSettingName);

            public readonly IReadOnlyDictionary<string, string> BatchTRPExtraHeaders = ParseHeaderEnvironmentVariable(BatchTRPExtraHeadersEnvironmentSettingName);

            public readonly string BatchAuthorityUrl = GetEnvironmentVariableOrDefault(BatchAuthorityUrlEnvironmentSettingName, "https://login.microsoftonline.com/microsoft.onmicrosoft.com");

            private static IReadOnlyDictionary<string, string> ParseHeaderEnvironmentVariable(string environmentSettingName)
            {
                string settingString = Environment.GetEnvironmentVariable(environmentSettingName);
                IReadOnlyDictionary<string, string> result = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(settingString))
                {
                    IEnumerable<string> pairs = settingString.Split(';');
                    result = pairs.ToDictionary(pair => pair.Split('=')[0], pair => pair.Split('=')[1]);
                }

                return result;
            }

            private static string GetEnvironmentVariableOrThrow(string environmentSettingName)
            {
                string result = Environment.GetEnvironmentVariable(environmentSettingName);
                if (string.IsNullOrEmpty(result))
                {
                    throw new ArgumentException(string.Format("Missing required environment variable {0}", environmentSettingName));
                }

                return result;
            }

            private static string GetEnvironmentVariableOrDefault(string environmentSettingName, string defaultValue)
            {
                string result = Environment.GetEnvironmentVariable(environmentSettingName);
                if (string.IsNullOrEmpty(result))
                {
                    return defaultValue;
                }

                return result;
            }
        }

        private static readonly Lazy<TestConfiguration> configurationInstance = new Lazy<TestConfiguration>(() => new TestConfiguration());

        public static TestConfiguration Configuration
        {
            get { return configurationInstance.Value; }
        }
    }
}