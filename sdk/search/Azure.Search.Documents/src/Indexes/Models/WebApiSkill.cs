// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class WebApiSkill
    {
        /// <summary> Initializes a new instance of <see cref="WebApiSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="uri"> The url for the Web API. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/>, <paramref name="outputs"/> or <paramref name="uri"/> is null. </exception>
        public WebApiSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, string uri) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));
            Argument.AssertNotNull(uri, nameof(uri));

            Uri = uri;
            HttpHeaders = new ChangeTrackingDictionary<string, string>();
            ODataType = "#Microsoft.Skills.Custom.WebApiSkill";
        }

        /// <summary> Initializes a new instance of <see cref="WebApiSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        internal WebApiSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            HttpHeaders = new ChangeTrackingDictionary<string, string>();
            ODataType = "#Microsoft.Skills.Custom.WebApiSkill";
        }

        /// <summary> The headers required to make the http request. </summary>
        public IDictionary<string, string> HttpHeaders { get; }

        /// <summary> The URI of the Web API providing the vectorizer. </summary>
        [CodeGenMember("Url")]
        public string Uri { get; set; }
    }
}
