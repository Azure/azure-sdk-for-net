// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndexerSkill
    {
        /// <summary> Initializes a new instance of SearchIndexerSkill. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"><paramref name="inputs"/> or <paramref name="outputs"/> is null.</exception>
        private protected SearchIndexerSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            Inputs = inputs.ToList();
            Outputs = outputs.ToList();
        }

        /// <summary>
        /// The name of the skill which uniquely identifies it within the skillset.
        /// A skill with no name defined will be given a default name of its 1-based index in the skills array prefaced with the character "#" in debug sessions and error messages.
        /// </summary>
        public string Name { get; set; }

        /// <summary> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </summary>
        public IList<InputFieldMappingEntry> Inputs { get; }

        /// <summary> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </summary>
        public IList<OutputFieldMappingEntry> Outputs { get; }
    }
}
