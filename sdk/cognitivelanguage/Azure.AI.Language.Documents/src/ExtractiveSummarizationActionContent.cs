// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Documents
{
    [CodeGenSuppress("StringIndexType")]
    [CodeGenSuppress(".ctor")]
    public partial class ExtractiveSummarizationActionContent
    {
        /// <summary> Initializes a new instance of <see cref="ExtractiveSummarizationActionContent"/>. </summary>
        public ExtractiveSummarizationActionContent()
        {
            StringIndexType = Azure.AI.Language.Documents.StringIndexType.TextElementsV8;
        }

        internal StringIndexType? StringIndexType { get; set; }
    }
}
