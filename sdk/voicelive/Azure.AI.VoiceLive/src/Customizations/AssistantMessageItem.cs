// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.VoiceLive
{
    /// <summary> The AssistantMessageItem. </summary>
    public partial class AssistantMessageItem
    {
        /// <summary> Initializes a new instance of <see cref="AssistantMessageItem"/>. </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public AssistantMessageItem(OutputTextContentPart content) : this(new[] { content }) { }

        /// <summary>
        /// Initializes a new instance of <see cref="AssistantMessageItem"/> with the specified assistant message text.
        /// </summary>
        /// <param name="assistantMessageText"></param>
        public AssistantMessageItem(string assistantMessageText) : this(new OutputTextContentPart(assistantMessageText)) { }
    }
}
