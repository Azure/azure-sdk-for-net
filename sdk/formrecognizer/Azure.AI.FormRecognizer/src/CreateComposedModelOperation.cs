// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Tracks the status of a long-running operation for creating a composed model from a
    /// collection of existing models trained with labels.
    /// </summary>
    public class CreateComposedModelOperation : CreateCustomFormModelOperation
    {
        internal CreateComposedModelOperation(string location, FormRecognizerRestClient allOperations, ClientDiagnostics diagnostics) : base(location, allOperations, diagnostics) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateComposedModelOperation"/> class which
        /// tracks the status of a long-running operation for creating a composed model from a
        /// collection of existing models trained with labels.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public CreateComposedModelOperation(string operationId, FormTrainingClient client) : base(operationId, client) { }
    }
}
