// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Documents
{
    [CodeGenSuppress("StringIndexType")]
    [CodeGenSuppress(".ctor")]
    public partial class AbstractiveSummarizationOptions
    {
        /// <summary> Initializes a new instance of <see cref="AbstractiveSummarizationOptions"/>. </summary>
        public AbstractiveSummarizationOptions()
        {
            StringIndexType = Documents.StringIndexType.TextElementsV8;
        }

        internal StringIndexType? StringIndexType { get; set; }
    }
}
