// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of analyzing the healthcare entities in a given document.
    /// </summary>
    public partial class AnalyzeHealthcareEntitiesResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<HealthcareEntity> _entities;

        /// <summary>
        /// Initializes a successful <see cref="AnalyzeHealthcareEntitiesResult"/>.
        /// </summary>
        internal AnalyzeHealthcareEntitiesResult(
            string id,
            TextDocumentStatistics statistics,
            IList<HealthcareEntity> healthcareEntities,
            IList<HealthcareEntityRelation> entityRelations,
            BinaryData fhirBundle,
            string detectedLanguage,
            IList<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _entities = new ReadOnlyCollection<HealthcareEntity>(healthcareEntities);
            EntityRelations = new ReadOnlyCollection<HealthcareEntityRelation>(entityRelations);
            FhirBundle = fhirBundle;
            DetectedLanguage = detectedLanguage;

            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Initializes an <see cref="AnalyzeHealthcareEntitiesResult"/> with an error.
        /// </summary>
        internal AnalyzeHealthcareEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// The language of the input document as detected by the service when requested to perform automatic language
        /// detection, which is possible by specifying "auto" as the language of the input document.
        /// </summary>
        public string DetectedLanguage { get; }

        /// <summary>
        /// The collection of healthcare entities that were recognized in this document.
        /// </summary>
        public IReadOnlyCollection<HealthcareEntity> Entities
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _entities;
            }
        }

        /// <summary>
        /// The collection of relations between the healthcare entities that were recognized in this document.
        /// </summary>
        public IReadOnlyCollection<HealthcareEntityRelation> EntityRelations { get; }

        /// <summary>
        /// The FHIR bundle that was produced for this document according to the specified
        /// <see cref="FhirVersion"/>. For additional information, see
        /// <see href="https://www.hl7.org/fhir/overview.html"/>.
        /// </summary>
        public BinaryData FhirBundle { get; }
    }
}
