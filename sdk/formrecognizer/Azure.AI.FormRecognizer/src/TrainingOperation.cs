﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Tracks the status of a long-running operation for training a model from a collection of custom forms.
    /// </summary>
    public class TrainingOperation : CreateCustomFormModelOperation
    {
        internal TrainingOperation(string location, FormRecognizerRestClient allOperations, ClientDiagnostics diagnostics, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(location, allOperations, diagnostics, serviceVersion) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingOperation"/> class which
        /// tracks the status of a long-running operation for training a model from a collection of custom forms.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public TrainingOperation(string operationId, FormTrainingClient client) : base(operationId, client) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingOperation"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected TrainingOperation() : base() { }
    }
}
