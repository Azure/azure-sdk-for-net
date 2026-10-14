// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Projects.Agents;

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

        InternalBottomRight = [.. bottomRight.Select(x => (object)x)];
        InternalTopLeft = [.. topLeft.Select(x => (object)x)];
    }

    /// <summary> Initializes a new instance of <see cref="VoiceAgentAvatarVideoCrop"/>. </summary>
    /// <param name="bottomRight"></param>
    /// <param name="topLeft"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="bottomRight"/> or <paramref name="topLeft"/> is null. </exception>
    internal VoiceAgentAvatarVideoCrop(IEnumerable<object> bottomRight, IEnumerable<object> topLeft)
    {
        Argument.AssertNotNull(bottomRight, nameof(bottomRight));
        Argument.AssertNotNull(topLeft, nameof(topLeft));

        InternalBottomRight = [..bottomRight];
        InternalTopLeft = [..topLeft];
    }

    /// <summary> Gets the BottomRight. </summary>
    [CodeGenMember("BottomRight")]
    public IList<object> InternalBottomRight { get; }

    /// <summary> Gets the TopLeft. </summary>
    [CodeGenMember("TopLeft")]
    public IList<object> InternalTopLeft { get; }

    /// <summary> Gets the BottomRight. </summary>
    public IList<uint> BottomRight { get => [.. InternalBottomRight.Select(x => uint.Parse(x.ToString()))]; }

    /// <summary> Gets the TopLeft. </summary>
    public IList<uint> TopLeft { get => [.. InternalTopLeft.Select(x => uint.Parse(x.ToString()))]; }
}
