// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// a Recognize PII Entities action in a set of documents.
    /// For example, set model version, filter the response entities by a given
    /// domain filter, and more.
    /// </summary>
    public class RecognizePiiEntitiesAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizePiiEntitiesAction"/>
        /// class which allows callers to specify details about how to execute
        /// a Recognize PII Entities action in a set of documents.
        /// For example, set model version, filter the response entities by a given
        /// domain filter, and more.
        /// </summary>
        public RecognizePiiEntitiesAction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizePiiEntitiesAction"/>
        /// class based on the values of a <see cref="RecognizePiiEntitiesOptions"/>.
        /// It sets the <see cref="ModelVersion"/>, <see cref="DisableServiceLogs"/>,
        /// <see cref="DomainFilter"/>, and <see cref="CategoriesFilter"/> properties.
        /// </summary>
        public RecognizePiiEntitiesAction(RecognizePiiEntitiesOptions options)
        {
            ModelVersion = options.ModelVersion;
            DisableServiceLogs = options.DisableServiceLogs;
            DomainFilter = options.DomainFilter;
            if (options.CategoriesFilter.Count > 0)
            {
                CategoriesFilter = new List<PiiEntityCategory>(options.CategoriesFilter);
            }
        }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the Language service
        /// model that will be used to generate the result.  For supported
        /// model versions, see operation-specific documentation, for example:
        /// <see href="https://docs.microsoft.com/azure/cognitive-services/language-service/concepts/model-lifecycle#available-versions"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// The default value of this property is 'true'. This means, the Language service won't log your input text.
        /// Setting this property to 'false', enables logging your input text for 48 hours, solely to allow for troubleshooting issues.
        /// <para>
        /// Please see Cognitive Services Compliance and Privacy notes at <see href="https://aka.ms/cs-compliance"/> for additional details,
        /// and Microsoft Responsible AI principles at <see href="https://www.microsoft.com/ai/responsible-ai"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1"/>, <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/>, and newer.
        /// </remarks>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// Filters the response entities to ones only included in the specified domain.
        /// For more information see <see href="https://aka.ms/azsdk/language/pii"/>.
        /// </summary>
        public PiiEntityDomain DomainFilter { get; set; }

        /// <summary>
        /// Filters the response entities to entities that match the <see cref="PiiEntityCategory"/> specified.
        /// </summary>
        public IList<PiiEntityCategory> CategoriesFilter { get; internal set; } = new List<PiiEntityCategory>();

        /// <summary>
        /// Gets or sets a name for this action. If not provided, the service will generate one.
        /// </summary>
        public string ActionName { get; set; }
    }
}
