// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Discovery
{
    public partial class KnowledgeBase
    {
        /// <summary> Initializes a new instance of <see cref="KnowledgeBase"/>. </summary>
        /// <param name="description"> The description. </param>
        /// <param name="copilotInstruction"> The copilot instruction. </param>
        /// <exception cref="ArgumentNullException"> An argument is null. </exception>
        public KnowledgeBase(string description, string copilotInstruction) : this()
        {
            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (copilotInstruction is null)
            {
                throw new ArgumentNullException(nameof(copilotInstruction));
            }

            Description = description;
            CopilotInstruction = copilotInstruction;
        }
    }
}
