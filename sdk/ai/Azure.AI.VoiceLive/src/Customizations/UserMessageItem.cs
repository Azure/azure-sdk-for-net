// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.VoiceLive
{
    /// <summary> The UserMessageItem. </summary>
    public partial class UserMessageItem : MessageItem
    {
        /// <summary> Initializes a new instance of <see cref="UserMessageItem"/>. </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public UserMessageItem(UserContentPart content) : this(new[] { content })
        {
        }
    }
}
