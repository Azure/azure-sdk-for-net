// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Management.BotService.Customizations
{
    /// <summary>
    /// Configuration for the bot service client
    /// </summary>
    internal static class BotServiceConfiguration
    {
        public const string DefaultKind = "bot";
        public const string DefaultLocationName = "West US";
        public const string DefaultLocationCode = "westus";
        public const string DefaultSkuName = "S1";

        public const string BotTemplateBlob = "https://connectorprod.blob.core.windows.net/bot-packages/csharp-abs-webapp_simpleechobot_precompiled.zip";

        private const string ProdBotEnvironment = "prod";
        private const string PpeBotEnvironment = "ppe";
        private const string ScratchBotEnvironment = "scratch";
        private const string DefaultBotEnvironment = ProdBotEnvironment;
        private const string BotEnvironmentVariableName = "botenvironment";
        private const string OmitMsaAppIdCreationEnvironmentVariableName = "BOT_SERVICE_OMIT_MSA_APPID";

        private const string ScratchDevPortalUrl = "https://scratch.botframework.com/";
        private const string PpeDevPortalUrl = "https://ppe.botframework.com/";
        private const string ProdDevPortalUrl = "https://dev.botframework.com/";

        private static readonly string[] BotEnvironments = { ProdBotEnvironment, PpeBotEnvironment, ScratchBotEnvironment };

        /// <summary>
        /// Environment of the bot service to target. By default, the production environment will be targeted.
        /// </summary>
        public static string BotEnvironment
        {
            get
            {
                // The environment variable "botenvironment" can be set to override the default
                // environment of the bot framework
                string environmentOverride = Environment.GetEnvironmentVariable(BotEnvironmentVariableName);

                if (string.IsNullOrEmpty(environmentOverride) || !BotEnvironments.Contains(environmentOverride.ToLowerInvariant()))
                {
                    return DefaultBotEnvironment;
                }

                return environmentOverride;
            }
        }

        /// <summary>
        /// Url for Bot Framework developer portal for the configured Bot environment
        /// </summary>
        public static string DevPortalUrl
        {
            get
            {
                switch (BotEnvironment)
                {
                    case ScratchBotEnvironment:
                        return ScratchDevPortalUrl;
                    case PpeBotEnvironment:
                        return PpeDevPortalUrl;
                    default:
                        return ProdDevPortalUrl;
                }
            }
        }

        /// <summary>
        /// Determines whether on bot creation we should provision an Msa app id. The default is yes, 
        /// but when test environment variables are set, we avoid provisioning an Msa app id since it
        /// requires user credentials
        /// </summary>
        public static bool ShouldProvisionMsaApp
        {
            get
            {
                // The environment variable BOT_SERVICE_OMIT_MSA_APPID is set on test environments
                string environmentOverride = Environment.GetEnvironmentVariable(OmitMsaAppIdCreationEnvironmentVariableName);
                return string.IsNullOrEmpty(environmentOverride);
            }
        }
    }
}
