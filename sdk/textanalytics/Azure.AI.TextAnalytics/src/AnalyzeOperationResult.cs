// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="JobMetadata"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    public class AnalyzeOperationResult
    {
        /// <summary>
        /// </summary>
        /// <param name="entitiesResult">Entities result returned from the service</param>
        /// <param name="piiEntitiesResult">PII Entities result returned from the service</param>
        /// <param name="keyPhraseResult">Keyphrase result returned from the service</param>
        /// <param name="map">Variable to map documents with id and maintaining the order</param>
        /// <param name="displayName">DisplayName for the Job</param>
        internal AnalyzeOperationResult(EntitiesResult entitiesResult, PiiEntitiesResult piiEntitiesResult, KeyPhraseResult keyPhraseResult, IDictionary<string, int> map, string displayName)
        {
            if (entitiesResult != null)
            {
                EntitiesResult = Transforms.ConvertToRecognizeEntitiesResultCollection(entitiesResult, map);
            }

            if (piiEntitiesResult != null)
            {
                PiiEntitiesResult = Transforms.ConvertToRecognizePiiEntitiesResultCollection(piiEntitiesResult, map);
            }

            if (keyPhraseResult != null)
            {
                KeyPhraseResult = Transforms.ConvertToExtractKeyPhrasesResultCollection(keyPhraseResult, map);
            }
            if (displayName != null)
            {
                DisplayName = displayName;
            }
        }

        /// <summary>
        /// EntityRecognitionTasks
        /// </summary>
        public RecognizeEntitiesResultCollection EntitiesResult { get; }

        /// <summary>
        /// EntityRecognitionPiiTasks
        /// </summary>
        public RecognizePiiEntitiesResultCollection PiiEntitiesResult { get; }

        /// <summary>
        /// KeyPhraseExtractionTasks
        /// </summary>
        public ExtractKeyPhrasesResultCollection KeyPhraseResult { get; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName { get; }
    }
}
