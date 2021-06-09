// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// a Recognize PII Entities action in a set of documents.
    /// For example, set model version, filter the response entities by a given
    /// domain filter, and more.
    /// </summary>
    public class RecognizePiiEntitiesAction : RecognizePiiEntitiesOptions
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
    }
}
