// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// <param name="entitiesResult"></param>
        /// <param name="piiEntitiesResult"></param>
        /// <param name="keyPhraseResult"></param>
        /// <param name="map"></param>
        internal AnalyzeOperationResult(EntitiesResult entitiesResult, PiiEntitiesResult piiEntitiesResult, KeyPhraseResult keyPhraseResult, IDictionary<string, int> map)
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

    }
}
