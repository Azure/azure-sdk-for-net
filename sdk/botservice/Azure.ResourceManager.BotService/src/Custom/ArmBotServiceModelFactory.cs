// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.BotService.Models
{
    public static partial class ArmBotServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.BotConnectionSettingProperties"/>. </summary>
        /// <param name="clientId"> Client Id associated with the Connection Setting. </param>
        /// <param name="settingId"> Setting Id set by the service for the Connection Setting. </param>
        /// <param name="clientSecret"> Client Secret associated with the Connection Setting. </param>
        /// <param name="scopes"> Scopes associated with the Connection Setting. </param>
        /// <param name="serviceProviderId"> Service Provider Id associated with the Connection Setting. </param>
        /// <param name="serviceProviderDisplayName"> Service Provider Display Name associated with the Connection Setting. </param>
        /// <param name="parameters"> Service Provider Parameters associated with the Connection Setting. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Models.BotConnectionSettingProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BotConnectionSettingProperties BotConnectionSettingProperties(string clientId, string settingId, string clientSecret, string scopes, string serviceProviderId, string serviceProviderDisplayName, IEnumerable<BotConnectionSettingParameter> parameters, string provisioningState)
        {
            return BotConnectionSettingProperties(
                id: null,
                name: null,
                clientId,
                settingId,
                clientSecret,
                scopes,
                serviceProviderId,
                serviceProviderDisplayName,
                parameters,
                provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.BotProperties"/>. </summary>
        /// <param name="displayName"> The Name of the bot. </param>
        /// <param name="description"> The description of the bot. </param>
        /// <param name="iconUri"> The Icon Url of the bot. </param>
        /// <param name="endpoint"> The bot's endpoint. </param>
        /// <param name="endpointVersion"> The bot's endpoint version. </param>
        /// <param name="allSettings"> Contains resource all settings defined as key/value pairs. </param>
        /// <param name="parameters"> Contains resource parameters defined as key/value pairs. </param>
        /// <param name="manifestUri"> The bot's manifest url. </param>
        /// <param name="msaAppType"> Microsoft App Type for the bot. </param>
        /// <param name="msaAppId"> Microsoft App Id for the bot. </param>
        /// <param name="msaAppTenantId"> Microsoft App Tenant Id for the bot. </param>
        /// <param name="msaAppMSIResourceId"> Microsoft App Managed Identity Resource Id for the bot. </param>
        /// <param name="configuredChannels"> Collection of channels for which the bot is configured. </param>
        /// <param name="enabledChannels"> Collection of channels for which the bot is enabled. </param>
        /// <param name="developerAppInsightKey"> The Application Insights key. </param>
        /// <param name="developerAppInsightsApiKey"> The Application Insights Api Key. </param>
        /// <param name="developerAppInsightsApplicationId"> The Application Insights App Id. </param>
        /// <param name="luisAppIds"> Collection of LUIS App Ids. </param>
        /// <param name="luisKey"> The LUIS Key. </param>
        /// <param name="isCmekEnabled"> Whether Cmek is enabled. </param>
        /// <param name="cmekKeyVaultUri"> The CMK Url. </param>
        /// <param name="cmekEncryptionStatus"> The CMK encryption status. </param>
        /// <param name="tenantId"> The Tenant Id for the bot. </param>
        /// <param name="publicNetworkAccess"> Whether the bot is in an isolated network. </param>
        /// <param name="isStreamingSupported"> Whether the bot is streaming supported. </param>
        /// <param name="isDeveloperAppInsightsApiKeySet"> Whether the bot is developerAppInsightsApiKey set. </param>
        /// <param name="migrationToken"> Token used to migrate non Azure bot to azure subscription. </param>
        /// <param name="isLocalAuthDisabled"> Opt-out of local authentication and ensure only MSI and AAD can be used exclusively for authentication. </param>
        /// <param name="schemaTransformationVersion"> The channel schema transformation version for the bot. </param>
        /// <param name="storageResourceId"> The storage resourceId for the bot. </param>
        /// <param name="privateEndpointConnections"> List of Private Endpoint Connections configured for the bot. </param>
        /// <param name="openWithHint"> The hint to browser (e.g. protocol handler) on how to open the bot for authoring. </param>
        /// <param name="appPasswordHint"> The hint (e.g. keyVault secret resourceId) on how to fetch the app secret. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="publishingCredentials"> Publishing credentials of the resource. </param>
        /// <returns> A new <see cref="Models.BotProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BotProperties BotProperties(string displayName, string description, Uri iconUri, Uri endpoint, string endpointVersion, IDictionary<string, string> allSettings, IDictionary<string, string> parameters, Uri manifestUri, BotMsaAppType? msaAppType, string msaAppId, string msaAppTenantId, ResourceIdentifier msaAppMSIResourceId, IEnumerable<string> configuredChannels, IEnumerable<string> enabledChannels, string developerAppInsightKey, string developerAppInsightsApiKey, string developerAppInsightsApplicationId, IEnumerable<string> luisAppIds, string luisKey, bool? isCmekEnabled, Uri cmekKeyVaultUri, string cmekEncryptionStatus, Guid? tenantId, BotServicePublicNetworkAccess? publicNetworkAccess, bool? isStreamingSupported, bool? isDeveloperAppInsightsApiKeySet, string migrationToken, bool? isLocalAuthDisabled, string schemaTransformationVersion, ResourceIdentifier storageResourceId, IEnumerable<BotServicePrivateEndpointConnectionData> privateEndpointConnections, string openWithHint = null, string appPasswordHint = null, string provisioningState = null, string publishingCredentials = null)
        {
            return BotProperties(
                displayName,
                description,
                iconUri,
                endpoint,
                endpointVersion,
                allSettings,
                parameters,
                manifestUri,
                msaAppType,
                msaAppId,
                msaAppTenantId,
                msaAppMSIResourceId,
                configuredChannels,
                enabledChannels,
                developerAppInsightKey,
                developerAppInsightsApiKey,
                developerAppInsightsApplicationId,
                luisAppIds,
                luisKey,
                isCmekEnabled,
                cmekKeyVaultUri,
                cmekEncryptionStatus,
                tenantId,
                publicNetworkAccess,
                isStreamingSupported,
                isDeveloperAppInsightsApiKeySet,
                migrationToken,
                isLocalAuthDisabled,
                schemaTransformationVersion,
                storageResourceId,
                privateEndpointConnections,
                networkSecurityPerimeterConfigurations: null,
                openWithHint,
                appPasswordHint,
                provisioningState,
                publishingCredentials);
        }
    }
}
