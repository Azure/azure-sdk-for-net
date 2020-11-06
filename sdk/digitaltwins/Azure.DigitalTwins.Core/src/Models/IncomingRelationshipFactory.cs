// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.Models
{
    /// <summary>
    /// IncomingRelationship model factory that enables mocking of that type.
    /// </summary>
    public static class IncomingRelationshipFactory
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IncomingRelationship"/> for mocking purposes.
        /// </summary>
        /// <param name="relationshipId"> A user-provided string representing the id of this relationship, unique in the context of the source digital twin, i.e. sourceId + relationshipId is unique in the context of the service. </param>
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
