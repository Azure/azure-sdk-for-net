// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// General information regarding the current resource.
    /// </summary>
    public class ResourceDetails
    {
        internal ResourceDetails(ServiceResourceDetails details)
            : this(details.CustomDocumentModels.Count, details.CustomDocumentModels.Limit, details.CustomNeuralDocumentModelBuilds)
        {
        }

        internal ResourceDetails(int customDocumentModelCount, int customDocumentModelLimit, QuotaDetails customNeuralDocumentModelBuilds)
        {
            CustomDocumentModelCount = customDocumentModelCount;
            CustomDocumentModelLimit = customDocumentModelLimit;
            CustomNeuralDocumentModelBuilds = customNeuralDocumentModelBuilds;
        }

        /// <summary>
        /// Number of custom models in the current resource.
        /// </summary>
        public int CustomDocumentModelCount { get; }

        /// <summary>
        /// Maximum number of custom models supported in the current resource.
        /// </summary>
        public int CustomDocumentModelLimit { get; }

        /// <summary>
        /// Quota used, limit, and next reset date/time.
        /// </summary>
        public QuotaDetails CustomNeuralDocumentModelBuilds { get; }
    }
}
