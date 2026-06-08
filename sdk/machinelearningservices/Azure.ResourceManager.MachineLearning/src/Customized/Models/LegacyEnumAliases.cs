// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat enum aliases are grouped to keep related shims together.

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy enum member casing/acronym aliases after TypeSpec normalization.
    public readonly partial struct MachineLearningConnectionCategory
    {
        /// <summary> Gets the AdlsGen2. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AdlsGen2 => ADLSGen2;

        /// <summary> Gets the AzureMySqlDB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzureMySqlDB => AzureMySqlDb;

        /// <summary> Gets the AzurePostgresDB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzurePostgresDB => AzurePostgresDb;

        /// <summary> Gets the AzureSqlDB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzureSqlDB => AzureSqlDb;
    }

    public readonly partial struct MachineLearningEndpointAuthMode
    {
        /// <summary> Gets the AadToken. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningEndpointAuthMode AadToken => AADToken;

        /// <summary> Gets the AmlToken. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningEndpointAuthMode AmlToken => AMLToken;
    }

    public readonly partial struct MachineLearningEndpointComputeType
    {
        /// <summary> Gets the AmlCompute. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningEndpointComputeType AmlCompute => AzureMLCompute;
    }

    public readonly partial struct MachineLearningLoadBalancerType
    {
        /// <summary> Gets the PublicIP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningLoadBalancerType PublicIP => PublicIp;
    }

    public readonly partial struct ImageType
    {
        /// <summary> Gets the AzureML. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageType AzureML => Azureml;
    }

    public readonly partial struct MachineLearningBillingCurrency
    {
        /// <summary> Gets the Usd. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningBillingCurrency Usd => USD;
    }

    public readonly partial struct MachineLearningSourceType
    {
        /// <summary> Gets the Uri. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningSourceType Uri => URI;
    }

    public readonly partial struct MachineLearningStorageAccountType
    {
        /// <summary> Gets the PremiumLrs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningStorageAccountType PremiumLrs => PremiumLRS;

        /// <summary> Gets the StandardLrs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningStorageAccountType StandardLrs => StandardLRS;
    }
}

#pragma warning restore SA1402
