// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Template.Models
{
    /// <summary> Response to the get custom model operation. </summary>
    public partial class Model
    {
        /// <summary> Basic custom model information. </summary>
        public ModelInfo ModelInfo { get; set; } = new ModelInfo();
        /// <summary> Keys extracted by the custom model. </summary>
        public KeysResult Keys { get; set; }
        /// <summary> Custom model training result. </summary>
        public TrainResult TrainResult { get; set; }
    }
}
