// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("DigitalTwinsModelData")]
    public partial class DigitalTwinsModelData
    {
        // This class declaration:
        // - Changes the namespace and renames the type from "ModelData" to "DigitalTwinsModelData"
        // - Makes the generated class of the same name declare Model as a **string** rather than an **object**.
        // - Renames Model to DtdlModel.
        // Do not remove.

        /// <summary>
        /// The model definition that conforms to the Digital Twins Definition Language (DTDL).
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models"/>
        [CodeGenMember("Model")]
        public string DtdlModel { get; }

        #region null overrides

#pragma warning disable CA1801 // Remove unused parameter

        private DigitalTwinsModelData(string id)
        {
        }

#pragma warning restore CA1801 // Remove unused parameter

        #endregion null overrides
    }
}
