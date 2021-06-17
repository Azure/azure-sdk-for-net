﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Gets or sets a value that, if set, indicates the version of the text
        /// analytics model that will be used to generate the result.  For supported
        /// model versions, see operation-specific documentation, for example:
        /// <see href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/concepts/model-versioning#available-versions"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// The default value of this property is 'true'. This means, Text Analytics service won't log your input text.
        /// Setting this property to 'false', enables logging your input text for 48 hours, solely to allow for troubleshooting issues.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1_Preview_5"/> and up.
        /// </remarks>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// Filters the response entities to ones only included in the specified domain.
        /// For more information see <see href="https://aka.ms/tanerpii"/>.
        /// </summary>
        public PiiEntityDomain DomainFilter { get; set; }

        /// <summary>
        /// Filters the response entities to entities that match the <see cref="PiiEntityCategory"/> specified.
        /// </summary>
        public IList<PiiEntityCategory> CategoriesFilter { get; internal set; } = new List<PiiEntityCategory>();
    }
}
