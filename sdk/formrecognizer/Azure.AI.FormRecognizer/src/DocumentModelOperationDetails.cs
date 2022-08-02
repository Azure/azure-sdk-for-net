// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Details about a document model long-running operation.
    /// </summary>
    public class DocumentModelOperationDetails
    {
        internal DocumentModelOperationDetails(GetOperationResponse response)
            : this(response.OperationId, response.Status, response.PercentCompleted, response.CreatedOn, response.LastUpdatedOn, response.Kind, response.ResourceLocation, response.Tags, response.Error, new DocumentModelDetails(response.Result))
        {
        }

        internal DocumentModelOperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, DocumentOperationKind kind, Uri resourceLocation, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentModelDetails result)
        {
            OperationId = operationId;
            Status = status;
            PercentCompleted = percentCompleted;
            Kind = kind;
            ResourceLocation = resourceLocation;
            CreatedOn = createdOn;
            LastUpdatedOn = lastUpdatedOn;
            Tags = tags;
            Error = error;
            Result = result;
        }

        /// <summary>
        /// Operation ID.
        /// </summary>
        public string OperationId { get; }

        /// <summary>
        /// Operation status.
        /// </summary>
        public DocumentOperationStatus Status { get; }

        /// <summary>
        /// Operation progress (0-100).
        /// </summary>
        public int? PercentCompleted { get; }

        /// <summary>
        /// Date and time (UTC) when the operation was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Date and time (UTC) when the operation was last updated.
        /// </summary>
        public DateTimeOffset LastUpdatedOn { get; }

        /// <summary>
        /// Type of operation.
        /// </summary>
        public DocumentOperationKind Kind { get; }

        /// <summary>
        /// URI of the resource targeted by this operation.
        /// </summary>
        public Uri ResourceLocation { get; }

        /// <summary>
        /// A list of user-defined key-value tag attributes associated with the model.
        /// </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary>
        /// Gets the error that occurred during the operation. The value is <c>null</c> if the operation succeeds.
        /// </summary>
        public ResponseError Error { get; }

        /// <summary>
        /// Operation result upon success.
        /// </summary>
        public DocumentModelDetails Result { get; }
    }
}
