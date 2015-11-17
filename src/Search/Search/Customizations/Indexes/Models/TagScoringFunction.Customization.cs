// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class TagScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the TagScoringFunction class with
        /// required arguments.
        /// </summary>
        public TagScoringFunction(TagScoringParameters parameters, string fieldName, double boost)
            : this()
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            
            if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }
            
            this.Tag = parameters;
            this.FieldName = fieldName;
            this.Boost = boost;
        }

        /// <summary>
        /// Gets parameter values for the tag scoring function.
        /// </summary>
        [JsonIgnore]
        public TagScoringParameters Parameters 
        {
            get { return this.Tag; }
        }
    }
}
