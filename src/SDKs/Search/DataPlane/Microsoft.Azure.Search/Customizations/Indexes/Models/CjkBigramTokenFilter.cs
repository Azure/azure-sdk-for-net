// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Forms bigrams of CJK terms that are generated from StandardTokenizer. This tokenizer is implemented using Apache Lucene.
    /// </summary>
    [JsonObject("#Microsoft.Azure.Search.CjkBigramTokenFilter")]
    public partial class CjkBigramTokenFilter : TokenFilter
    {
        /// <summary>
        /// Initializes a new instance of the CjkBigramTokenFilter class.
        /// </summary>
        public CjkBigramTokenFilter() { }

        /// <summary>
        /// Initializes a new instance of the CjkBigramTokenFilter class.
        /// </summary>
        public CjkBigramTokenFilter(string name, IList<CjkBigramTokenFilterScripts> ignoreScripts = default(IList<CjkBigramTokenFilterScripts>), bool? outputUnigrams = default(bool?))
            : base(name)
        {
            IgnoreScripts = ignoreScripts;
            OutputUnigrams = outputUnigrams;
        }

        /// <summary>
        /// Gets or sets the scripts to ignore.
        /// </summary>
        [JsonProperty(PropertyName = "ignoreScripts")]
        public IList<CjkBigramTokenFilterScripts> IgnoreScripts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to output both unigrams
        /// and bigrams (if true), or just bigrams (if false). Default is
        /// false.
        /// </summary>
        [JsonProperty(PropertyName = "outputUnigrams")]
        public bool? OutputUnigrams { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
