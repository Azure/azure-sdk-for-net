﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// a Recognize Entities action in a set of documents.
    /// For example, set model version, disable service logging, and more.
    /// </summary>
    public class RecognizeEntitiesAction : RecognizeEntitiesOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeEntitiesAction"/>
        /// class which allows callers to specify details about how to execute
        /// a Recognize Entities action in a set of documents.
        /// For example, set model version, disable service logging, and more.
        /// </summary>
        public RecognizeEntitiesAction()
        {
        }
    }
}
