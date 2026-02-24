// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Configuration for interim responses using predefined static text messages.
    /// These responses provide immediate user feedback during delays in voice interactions.
    /// </summary>
    public class StaticInterimResponseConfig : InterimResponseConfigBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="StaticInterimResponseConfig"/>.
        /// </summary>
        public StaticInterimResponseConfig()
        {
            Texts = new List<string>();
        }

        /// <summary>
        /// Gets the collection of static text messages that can be used as interim responses.
        /// These messages are randomly selected or cycled through when interim responses are triggered.
        /// </summary>
        public IList<string> Texts { get; }
    }
}