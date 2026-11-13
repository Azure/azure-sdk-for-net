// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Base for any response item; discriminated by `type`.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="SessionResponseMessageItem"/>, <see cref="ResponseFunctionCallItem"/>, and <see cref="ResponseFunctionCallOutputItem"/>.
    /// </summary>
    public abstract partial class SessionResponseItem
    {
        /// <summary> Gets the Object. </summary>
        internal string Object { get; }
    }
}
