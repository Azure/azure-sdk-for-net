// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Model factory that enables mocking of the models within the Digital Twins library.
    /// These models cannot be created otherwise due to having only internal or private constructors.
    /// </summary>
    public static class DigitalTwinsModelFactory
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

        /// <summary>
        /// Initializes a new instance of <see cref="IncomingRelationship"/> for mocking purposes.
        /// </summary>
        /// <param name="relationshipId"> A user-provided string representing the id of this relationship, unique in the context of the source digital twin,
        /// i.e. sourceId + relationshipId is unique in the context of the service.</param>
        /// <param name="sourceId"> The id of the source digital twin. </param>
        /// <param name="relationshipName"> The name of the relationship. </param>
        /// <param name="relationshipLink"> Link to the relationship, to be used for deletion. </param>
        /// <returns>The new instance of <see cref="IncomingRelationship"/> to be used for mocking purposes.</returns>
        public static IncomingRelationship IncomingRelationship(string relationshipId, string sourceId, string relationshipName, string relationshipLink)
        {
            return new IncomingRelationship(relationshipId, sourceId, relationshipName, relationshipLink);
        }
    }
}
