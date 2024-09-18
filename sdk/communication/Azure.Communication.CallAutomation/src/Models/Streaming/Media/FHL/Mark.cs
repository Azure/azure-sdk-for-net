// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation.FHL
{
    public class Mark
    {
        /// <summary>
        /// Mark constructor
        /// </summary>
        /// <param name="sequence">Incrementing sequence of the audio byte</param>
        public Mark(string sequence)
        {
            Sequence = sequence;
        }

        /// <summary>
        /// Increasing Sequence
        /// IsRequired = true
        /// </summary>
        public string Sequence { get; }
    }
}
