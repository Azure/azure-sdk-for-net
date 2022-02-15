// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Rl.Net;

namespace Azure.AI.Personalizer
{
    /// <summary> The Wrapper for Rl.Net.ActionProbability </summary>
    public class ActionProbabilityWrapper
    {
        private readonly ActionProbability _actionProbability;

        /// <summary> The probability </summary>
        public virtual float Probability { get { return _actionProbability.Probability; } }

        /// <summary> The action index </summary>
        public virtual long ActionIndex { get { return _actionProbability.ActionIndex; } }

        /// <summary> Initializes a new instance of ActionProbabilityWrapper. </summary>
        public ActionProbabilityWrapper()
        {
        }

        /// <summary> Initializes a new instance of ActionProbabilityWrapper. </summary>
        /// <param name="actionProbability"> An action probability </param>
        public ActionProbabilityWrapper(ActionProbability actionProbability)
        {
            _actionProbability = actionProbability;
        }
    }
}
