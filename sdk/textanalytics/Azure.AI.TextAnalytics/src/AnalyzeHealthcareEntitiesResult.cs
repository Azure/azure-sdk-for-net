// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the analyze healthcare operation,
    /// containing the predicted healthcare entities, warning, and relations.
    /// </summary>
    public partial class AnalyzeHealthcareEntitiesResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<HealthcareEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeHealthcareEntitiesResult"/>.
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
        /// Initializes a new instance of the <see cref="AnalyzeHealthcareEntitiesResult"/>.
        /// </summary>
        /// <param name="id">Analyze operation id.</param>
        /// <param name="error">Operation error object.</param>
        internal AnalyzeHealthcareEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Warnings encountered while processing document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// The language of the input document as detected by the service when requested to perform automatic language
        /// detection, which is possible by specifying "auto" as the language of the input document.
        /// </summary>
        public string DetectedLanguage { get; }

        /// <summary>
        /// Gets the collection of healthcare entities in the document.
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
        /// Gets the relations between the entities. <see cref="HealthcareEntityRelation"/>.
        /// </summary>
        public IReadOnlyCollection<HealthcareEntityRelation> EntityRelations { get; }

        /// <summary>
        /// Gets the FHIR bundle that was produced for this result according to the specified <see cref="AnalyzeHealthcareEntitiesOptions.FhirVersion"/>.
        /// For additional information, see <see href="https://www.hl7.org/fhir/overview.html"/>.
        /// </summary>
        public BinaryData FhirBundle { get; }
    }
}
