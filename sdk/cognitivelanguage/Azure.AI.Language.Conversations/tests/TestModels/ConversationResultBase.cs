// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Shared attributes for all conversational task results. </summary>
    public partial class ConversationResultBase
    {
        /// <summary> Initializes a new instance of ConversationResultBase. </summary>
        /// <param name="id"> Unique, non-empty conversation identifier. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="warnings"/> is null. </exception>
        public ConversationResultBase(string id, IEnumerable<InputWarning> warnings)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(warnings, nameof(warnings));

            Id = id;
            Warnings = warnings.ToList();
        }

        /// <summary> Initializes a new instance of ConversationResultBase. </summary>
        /// <param name="id"> Unique, non-empty conversation identifier. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> If showStats=true was specified in the request this field will contain information about the conversation payload. </param>
        internal ConversationResultBase(string id, IList<InputWarning> warnings, ConversationStatistics statistics)
        {
            Id = id;
            Warnings = warnings;
            Statistics = statistics;
        }

        /// <summary> Unique, non-empty conversation identifier. </summary>
        public string Id { get; set; }
        /// <summary> Warnings encountered while processing document. </summary>
        public IList<InputWarning> Warnings { get; }
        /// <summary> If showStats=true was specified in the request this field will contain information about the conversation payload. </summary>
        public ConversationStatistics Statistics { get; set; }
    }
}
