// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public readonly partial struct LogicalOperationKind
    {
        /// <summary>
        /// "AND" logical operation.
        /// </summary>
        [CodeGenMember("AND")]
        public static LogicalOperationKind And => AND;

        /// <summary>
        /// "OR" logical operation.
        /// </summary>
        [CodeGenMember("OR")]
        public static LogicalOperationKind Or => OR;
    }
}
