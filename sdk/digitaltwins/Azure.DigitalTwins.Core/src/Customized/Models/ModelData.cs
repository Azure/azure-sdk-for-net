// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("ModelData")]
    public partial class ModelData
    {
        // This class declaration makes the generated class of the same name declare Model as a **string** rather than an **object**.
        // It also changes displayName and description from objects (per swagger) to dictionaries (per swagger comment).
        // It also changes the namespace.
        // Do not remove.

        /// <summary> Initializes a new instance of ModelData. </summary>
        /// <param name="displayName"> A language map that contains the localized display names as specified in the model definition. </param>
        /// <param name="description"> A language map that contains the localized descriptions as specified in the model definition. </param>
        /// <param name="id"> The id of the model as specified in the model definition. </param>
        /// <param name="uploadTime"> The time the model was uploaded to the service. </param>
        /// <param name="decommissioned"> Indicates if the model is decommissioned. Decommissioned models cannot be referenced by newly created digital twins. </param>
        /// <param name="model"> The model definition. </param>
        internal ModelData(IDictionary<string, string> displayName, IDictionary<string, string> description, string id, DateTimeOffset? uploadTime, bool? decommissioned, string model)
        {
            DisplayName = displayName;
            Description = description;
            Id = id;
            UploadTime = uploadTime;
            Decommissioned = decommissioned;
            Model = model;
        }

        /// <summary>
        /// The model definition.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// A language map that contains the localized display names as specified in the model definition.
        /// </summary>
        public IDictionary<string, string> DisplayName { get; }

        /// <summary>
        /// A language map that contains the localized descriptions as specified in the model definition.
        /// </summary>
        public IDictionary<string, string> Description { get; }

        #region null overrides

#pragma warning disable CA1801 // Remove unused parameter

        private ModelData(string id)
        {
        }

#pragma warning restore CA1801 // Remove unused parameter

        #endregion null overrides
    }
}
