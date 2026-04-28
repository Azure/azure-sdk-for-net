// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class AzureMachineLearningVectorizer
    {
        /// <summary> Specifies the properties of the AML vectorizer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("AMLParameters has been renamed to AmlParameters. Please use AmlParameters instead.")]
        public AzureMachineLearningParameters AMLParameters
        {
            get => AmlParameters;
            set => AmlParameters = value;
        }
    }
}
