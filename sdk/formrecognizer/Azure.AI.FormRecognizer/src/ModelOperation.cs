// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("GetOperationResponse")]
    public partial class ModelOperation
    {
        /// <summary> Operation result upon success. </summary>
        //TODO service is looking into fixing this so it has different return types that we can adapt.
        [CodeGenMember("Result")]
        public DocumentModel Result { get; }
    }
}
