// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("BottomRight")]
[CodeGenSuppress("TopLeft")]
public partial class VoiceAgentAvatarVideoCrop
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentAvatarVideoCrop"/>. </summary>
    /// <param name="bottomRight"></param>
    /// <param name="topLeft"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="bottomRight"/> or <paramref name="topLeft"/> is null. </exception>
    public VoiceAgentAvatarVideoCrop(IEnumerable<uint> bottomRight, IEnumerable<uint> topLeft)
    {
        Argument.AssertNotNull(bottomRight, nameof(bottomRight));
        Argument.AssertNotNull(topLeft, nameof(topLeft));

        BottomRight = [.. bottomRight];
        TopLeft = [.. topLeft];
    }

    /// <summary> Gets the BottomRight. </summary>
    public IList<uint> BottomRight { get; }

    /// <summary> Gets the TopLeft. </summary>
    public IList<uint> TopLeft { get; }
}
