// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The set of options that can be specified when calling the build model method
    /// to configure the behavior of the request. For example, set a filter to apply
    /// to the documents in the source path or set a model description.
    /// </summary>
    public class BuildModelOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildModelOptions"/> class which
        /// allows to set options that can be specified when calling the training method
        /// to configure the behavior of the request. For example, set a filter to apply
        /// to the documents in the source path or set a model description.
        /// </summary>
        public BuildModelOptions()
        {
        }

        /// <summary>
        /// An optional, model description.
        /// </summary>
        public string ModelDescription { get; set; }

        /// <summary>
        /// A case-sensitive prefix string to filter documents in the source path for building a model.
        /// For example, you may use the prefix to restrict subfolders.
        /// </summary>
        public string Prefix { get; set; }
    }
}
