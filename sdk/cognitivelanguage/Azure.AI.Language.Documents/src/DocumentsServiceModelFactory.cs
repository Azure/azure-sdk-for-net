// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Documents
{
    /// <summary> Model factory for models. </summary>
    [CodeGenType("LanguageDocumentsModelFactory")]
    [CodeGenSuppress("PiiActionContent", typeof(bool?), typeof(string), typeof(PiiDomain?), typeof(IEnumerable<PiiCategoriesExtended>), typeof(StringIndexType?), typeof(IEnumerable<PiiCategories>), typeof(ValueExclusionPolicy), typeof(IEnumerable<EntitySynonyms>), typeof(IEnumerable<RedactionPolicy>), typeof(ConfidenceScoreThreshold), typeof(bool?))]
    [CodeGenSuppress("ExtractiveSummarizationOptions", typeof(bool?), typeof(string), typeof(long?), typeof(ExtractiveSummarizationOrder?), typeof(StringIndexType?), typeof(string))]
    [CodeGenSuppress("AbstractiveSummarizationOptions", typeof(bool?), typeof(string), typeof(int?), typeof(StringIndexType?), typeof(SummarySize?), typeof(string))]
    public static partial class DocumentsServiceModelFactory
    {
        /// <summary> Supported parameters for a PII Entities Recognition task. </summary>
        /// <param name="loggingOptOut"> logging opt out. </param>
        /// <param name="modelVersion"> model version. </param>
        /// <param name="domain"> Domain for PII task. </param>
        /// <param name="piiCategories"> Enumeration of PII categories to be returned in the response. </param>
        /// <param name="excludePiiCategories"> Enumeration of PII categories to be excluded in the response. </param>
        /// <param name="valueExclusionPolicy"> Policy for specific words and terms that should be excluded from detection by the PII detection service. </param>
        /// <param name="entitySynonyms"> (Optional) request parameter that allows the user to provide synonyms for context words that to enhance pii entity detection. </param>
        /// <param name="redactionPolicies"> List of RedactionPolicies to be used on the input. </param>
        /// <param name="confidenceScoreThreshold"> Confidence score threshold configuration for PII entity recognition. </param>
        /// <param name="disableEntityValidation"> Disable entity validation for PII entity recognition. </param>
        /// <returns> A new <see cref="PiiActionContent"/> instance for mocking. </returns>
        public static PiiActionContent PiiActionContent(
            bool? loggingOptOut = default,
            string modelVersion = default,
            PiiDomain? domain = default,
            IEnumerable<PiiCategoriesExtended> piiCategories = default,
            IEnumerable<PiiCategories> excludePiiCategories = default,
            ValueExclusionPolicy valueExclusionPolicy = default,
            IEnumerable<EntitySynonyms> entitySynonyms = default,
            IEnumerable<RedactionPolicy> redactionPolicies = default,
            ConfidenceScoreThreshold confidenceScoreThreshold = default,
            bool? disableEntityValidation = default)
        {
            piiCategories ??= new ChangeTrackingList<PiiCategoriesExtended>();
            excludePiiCategories ??= new ChangeTrackingList<PiiCategories>();
            entitySynonyms ??= new ChangeTrackingList<EntitySynonyms>();
            redactionPolicies ??= new ChangeTrackingList<RedactionPolicy>();

            return new PiiActionContent(
                loggingOptOut,
                modelVersion,
                domain,
                piiCategories.ToList(),
                default,
                excludePiiCategories.ToList(),
                valueExclusionPolicy,
                entitySynonyms.ToList(),
                redactionPolicies.ToList(),
                confidenceScoreThreshold,
                disableEntityValidation,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Supported parameters for an Extractive Summarization task. </summary>
        /// <param name="loggingOptOut"> logging opt out. </param>
        /// <param name="modelVersion"> model version. </param>
        /// <param name="sentenceCount"> Specifies the number of sentences in the extracted summary. </param>
        /// <param name="orderBy"> Specifies how to sort the extracted summaries. </param>
        /// <param name="query"> (Optional) If provided, the query will be used to extract most relevant sentences from the document. </param>
        /// <returns> A new <see cref="ExtractiveSummarizationOptions"/> instance for mocking. </returns>
        public static ExtractiveSummarizationOptions ExtractiveSummarizationOptions(
            bool? loggingOptOut = default,
            string modelVersion = default,
            long? sentenceCount = default,
            ExtractiveSummarizationOrder? orderBy = default,
            string query = default)
        {
            return new ExtractiveSummarizationOptions(
                loggingOptOut,
                modelVersion,
                sentenceCount,
                orderBy,
                default,
                query,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Supported parameters for the pre-built Abstractive Summarization task. </summary>
        /// <param name="shouldLog"> logging opt out. </param>
        /// <param name="modelVersion"> model version. </param>
        /// <param name="sentenceCount"> Controls the approximate number of sentences in the output summaries. </param>
        /// <param name="summaryLength"> (NOTE: Recommended to use summaryLength over sentenceCount) Controls the approximate length of the output summaries. </param>
        /// <param name="instruction"> (Optional) If provided, the instruction will be used to generate the summary. </param>
        /// <returns> A new <see cref="AbstractiveSummarizationOptions"/> instance for mocking. </returns>
        public static AbstractiveSummarizationOptions AbstractiveSummarizationOptions(
            bool? shouldLog = default,
            string modelVersion = default,
            int? sentenceCount = default,
            SummarySize? summaryLength = default,
            string instruction = default)
        {
            return new AbstractiveSummarizationOptions(
                shouldLog,
                modelVersion,
                sentenceCount,
                default,
                summaryLength,
                instruction,
                additionalBinaryDataProperties: null);
        }
    }
}
