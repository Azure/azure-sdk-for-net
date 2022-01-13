// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Personalizer.Models
{
    internal partial class PersonalizerClientProperties
    {
        internal PersonalizerClientProperties(string applicationID, string modelBlobUri, float initialExplorationEpsilon, PersonalizerLearningMode learningMode, string initialCommandLine)
        {
            ApplicationID = applicationID;
            ModelBlobUri = modelBlobUri;
            InitialExplorationEpsilon = initialExplorationEpsilon;
            LearningMode = learningMode;
            InitialCommandLine = initialCommandLine;
        }
        /// <summary>
        /// Unique identifier for this Personalizer instance.
        /// </summary>
        public string ApplicationID { get;  }

        /// <summary>
        /// Event hub connection string for sending interactions.
        /// </summary>
        public string EventHubInteractionConnectionString { get;}

        /// <summary>
        /// Event hub connection string for sending observations.
        /// </summary>
        public string EventHubObservationConnectionString { get;  }

        /// <summary>
        /// SAS Uri for the inference model.
        /// </summary>
        public string ModelBlobUri { get;  }

        /// <summary>
        /// Exploration value used before downloading model in CB.
        /// </summary>
        public float InitialExplorationEpsilon { get;  }

        /// <summary>
        /// Learning Mode setting.
        /// </summary>
        public PersonalizerLearningMode LearningMode { get;  }

        /// <summary>
        /// Command line used for prediction before downloading model.
        /// </summary>
        public string InitialCommandLine { get;  }

        /// <summary>
        /// Version used by reinforcement learning client.
        /// </summary>
        public int ProtocolVersion { get; }
    }
}
