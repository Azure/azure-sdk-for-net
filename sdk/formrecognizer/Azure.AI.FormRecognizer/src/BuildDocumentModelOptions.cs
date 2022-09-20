// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The set of options that can be specified when calling the build document model
    /// method to configure the behavior of the request. For example, set the model tags
    /// a model description.
    /// </summary>
    public class BuildDocumentModelOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildDocumentModelOptions"/> class which
        /// allows to set options that can be specified when calling the training method
        /// to configure the behavior of the request. For example, set the model tags or
        /// a model description.
        /// </summary>
        public BuildDocumentModelOptions()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary>
        /// An optional model description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A list of user-defined key-value tag attributes associated with the model.
        /// </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
