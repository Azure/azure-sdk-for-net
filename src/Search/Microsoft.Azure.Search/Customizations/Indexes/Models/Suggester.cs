// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines how the Suggest API should apply to a group of fields in the
    /// index.
    /// </summary>
    public class Suggester
    {
        /// <summary>
        /// Initializes a new instance of the Suggester class.
        /// </summary>
        public Suggester() { }

        /// <summary>
        /// Initializes a new instance of the Suggester class.
        /// </summary>
        public Suggester(string name, SuggesterSearchMode searchMode, IList<string> sourceFields)
        {
            Name = name;
            SearchMode = searchMode;
            SourceFields = sourceFields;
        }

        /// <summary>
        /// Initializes a new instance of the Suggester class with required
        /// arguments.
        /// </summary>
        /// <param name="name">The name of the suggester.</param>
        /// <param name="searchMode">A value indicating the capabilities of the suggester.</param>
        /// <param name="sourceFields">The list of field names to which the suggester applies; Each field must be
        /// searchable.</param>
        public Suggester(string name, SuggesterSearchMode searchMode, params string[] sourceFields)
            : this(name, searchMode, sourceFields.ToList())
        {
            // Do nothing.
        }

        /// <summary>
        /// Gets or sets the name of the suggester.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the capabilities of the suggester.
        /// Possible values for this property include:
        /// 'analyzingInfixMatching'.
        /// </summary>
        [JsonProperty(PropertyName = "searchMode")]
        public SuggesterSearchMode SearchMode { get; set; }

        /// <summary>
        /// Gets the list of field names to which the suggester applies. Each
        /// field must be searchable.
        /// </summary>
        [JsonProperty(PropertyName = "sourceFields")]
        public IList<string> SourceFields { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (SourceFields == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SourceFields");
            }
        }
    }
}
