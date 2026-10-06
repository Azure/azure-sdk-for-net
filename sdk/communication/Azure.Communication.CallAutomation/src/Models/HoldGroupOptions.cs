// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for creating a hold group.
    /// </summary>
    public class HoldGroupOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HoldGroupOptions"/>.
        /// </summary>
        /// <param name="playSource">The play source for the hold audio.</param>
        public HoldGroupOptions(PlaySource playSource)
        {
            PlaySource = playSource;
        }

        /// <summary>
        /// Gets or sets the play source for the hold group audio.
        /// </summary>
        public PlaySource PlaySource { get; set; }

        /// <summary>
        /// Gets or sets the operation context.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
