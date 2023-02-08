// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The PreBuiltResult. </summary>
    public partial class PreBuiltResult
    {
        /// <summary> Initializes a new instance of PreBuiltResult. </summary>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="errors"/> or <paramref name="modelVersion"/> is null. </exception>
        public PreBuiltResult(IEnumerable<InputError> errors, string modelVersion)
        {
            Argument.AssertNotNull(errors, nameof(errors));
            Argument.AssertNotNull(modelVersion, nameof(modelVersion));

            Errors = errors.ToList();
            ModelVersion = modelVersion;
        }

        /// <summary> Initializes a new instance of PreBuiltResult. </summary>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        internal PreBuiltResult(IList<InputError> errors, RequestStatistics statistics, string modelVersion)
        {
            Errors = errors;
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary> Errors by document id. </summary>
        public IList<InputError> Errors { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public RequestStatistics Statistics { get; set; }
        /// <summary> This field indicates which model is used for scoring. </summary>
        public string ModelVersion { get; set; }
    }
}
