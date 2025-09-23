// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.VoiceLive
{
    /// <summary> The AssistantMessageItem. </summary>
    public partial class AssistantMessageItem : MessageItem
    {
        /// <summary> Initializes a new instance of <see cref="AssistantMessageItem"/>. </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public AssistantMessageItem(OutputTextContentPart content) : this(new[] { content }) { }
    }
}
