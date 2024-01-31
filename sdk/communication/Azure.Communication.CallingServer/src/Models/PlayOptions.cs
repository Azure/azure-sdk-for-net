// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Options to be used in the play operations.
    /// </summary>
    public class PlayOptions
    {
        /// <summary> The option to play the provided audio source in loop when set to true. </summary>
        public bool Loop { get; set; }

        /// <summary> The Operation Context. </summary>
        public string OperationContext { get; set; }
    }
}
