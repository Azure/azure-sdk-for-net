// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    // Note: The addition of the optional field Skill.Name changed auto generated constructors
    // such that they were no longer be binary backwards compatiable. This additional constructor
    // is to preserve backwards compatability such that this new field is not considered a breaking change.
    // This customization can be removed in the next major version bump (10.0.0)
    public partial class Skill
    {
        /// <summary>
        /// Initializes a new instance of the Skill class.
        /// </summary>
        /// <param name="inputs">Inputs of the skills could be a column in the
        /// source data set, or the output of an upstream skill.</param>
        /// <param name="outputs">The output of a skill is either a field in an
        /// Azure Search index, or a value that can be consumed as an input by
        /// another skill.</param>
        /// <param name="description">The description of the skill which
        /// describes the inputs, outputs, and usage of the skill.</param>
        /// <param name="context">Represents the level at which operations take
        /// place, such as the document root or document content (for example,
        /// /document or /document/content). The default is /document.</param>
        public Skill(IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, string description = default(string), string context = default(string))
        {
            Name = null;
            Description = description;
            Context = context;
            Inputs = inputs;
            Outputs = outputs;
            CustomInit();
        }
    }
}
