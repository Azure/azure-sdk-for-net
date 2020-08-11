// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{    

    /// <summary>
    /// String constants class
    /// </summary>
    internal class Constants
    {

        /// <summary>
        /// List Format
        /// </summary>
        public const string ListFormat =
            @"{{ 'value':[ {0} ], 'nextLink': '{1}' }}";

        /// <summary>
        /// Next page link 
        /// </summary>
        public const string NextPageLink = "http://integrationAccountlistnextlink";

        /// <summary>
        /// Default test subscription
        /// </summary>
        public const string DefaultSubscription = "80d4fe69-c95b-4dd2-a938-9250f1c8ab03";
        
        /// <summary>
        /// Default test resource group
        /// </summary>
        public const string DefaultResourceGroup = "flowrg";
        
        /// <summary>
        /// Default test azure location
        /// </summary>
        public const string DefaultLocation = "westus";

        /// <summary>
        /// Default test service plan
        /// </summary>
        public const string DefaultServicePlan = "ServicePlan";

        /// <summary>
        /// Default trigger name
        /// </summary>
        public const string DefaultTriggerName = "manual";

        #region Prefix

        /// <summary>
        /// Test integration account name prefix
        /// </summary>
        public const string IntegrationAccountPrefix = "IntegrationAccount";

        /// <summary>
        /// Test integration account agreement name prefix
        /// </summary>
        public const string IntegrationAccountAgreementPrefix = "IntegrationAccountAgreement";

        /// <summary>
        /// Test integration account assembly name prefix
        /// </summary>
        public const string IntegrationAccountAssemblyPrefix = "IntegrationAccountAssembly";

        /// <summary>
        /// Test integration account batch configuration name prefix
        /// </summary>
        /// <remarks>
        /// Max limit of 20 characters
        /// </remarks>
        public const string IntegrationAccountBatchConfigurationPrefix = "IABatchConfig";

        /// <summary>
        /// Test IntegrationAccount schema name prefix
        /// </summary>
        public const string IntegrationAccountSchemaPrefix = "IntegrationAccountSchema";

        /// <summary>
        /// Test integration account partner name prefix
        /// </summary>
        public const string IntegrationAccountPartnerPrefix = "IntegrationAccountPartner";

        /// <summary>
        /// Test integration account map name prefix
        /// </summary>
        public const string IntegrationAccountMapPrefix = "IntegrationAccountMap";

        /// <summary>
        /// Test integration account certificate name prefix
        /// </summary>
        public const string IntegrationAccountCertificatePrefix = "IntegrationAccountCertificate";

        /// <summary>
        /// Test integration account session name prefix
        /// </summary>
        public const string IntegrationAccountSessionPrefix = "IntegrationAccountSession";

        /// <summary>
        /// Test workflow name prefix
        /// </summary>
        public const string WorkflowPrefix = "Workflow";

        #endregion Prefix

    }
}
