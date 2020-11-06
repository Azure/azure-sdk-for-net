// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.DigitalTwins.Core.Models
{
    /// <summary>
    /// DigitalTwinModelData model factory that enables mocking of that type.
    /// </summary>
    public static class DigitalTwinsModelDataFactory
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DigitalTwinsModelData"/> for mocking purposes.
        /// </summary>
        /// <param name="languageDisplayNames">A language dictionary that contains the localized display names as specified in the model definition.</param>
        /// <param name="languageDescriptions">A language dictionary that contains the localized descriptions as specified in the model definition.</param>
        /// <param name="id">The Id of the model as specified in the model definition.</param>
        /// <param name="uploadedOn">The date and time the model was uploaded to the service.</param>
        /// <param name="decommissioned">Indicates if the model is decommissioned. Decommissioned models cannot be referenced by newly created digital twins.</param>
        /// <param name="dtdlModel">The model definition that conforms to Digital Twins Definition Language (DTDL) v2.</param>
        /// <returns>The new instance of <see cref="DigitalTwinsModelData"/> to be used for mocking purposes.</returns>
        public static DigitalTwinsModelData DigitalTwinsModelData(
            IReadOnlyDictionary<string, string> languageDisplayNames,
            IReadOnlyDictionary<string, string> languageDescriptions,
            string id,
            DateTimeOffset? uploadedOn,
            bool? decommissioned,
            string dtdlModel)
        {
            return new DigitalTwinsModelData(languageDisplayNames, languageDescriptions, id, uploadedOn, decommissioned, dtdlModel);
        }
    }
}
