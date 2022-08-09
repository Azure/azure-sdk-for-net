// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.MediaComposition.Models
{
    /// <summary>Participant input.</summary>
    [CodeGenModel("Participant")]
    public partial class ParticipantInput
    {
        [CodeGenMember("Id")]
        internal CommunicationIdentifierModel ServiceId { get; set; }

        /// <summary> The CommunicationIdentifier that identifies the participant.</summary>
        public CommunicationIdentifier Id { get; private set; }

        internal ParticipantInput(CommunicationIdentifierModel serviceId, string call)
        {
            if (serviceId == null)
            {
                throw new ArgumentNullException(nameof(serviceId));
            }
            if (call == null)
            {
                throw new ArgumentNullException(nameof(call));
            }

            ServiceId = serviceId;
            Call = call;
            Kind = MediaInputType.Participant;
            Id = CommunicationIdentifierSerializer.Deserialize(serviceId);
        }

        /// <summary> Initializes a new instance of ParticipantInput. </summary>
        /// <param name="id"> The CommunicationIdentifier of the participant. </param>
        /// <param name="call"> The id of the teams meeting or call. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="call"/> is null. </exception>
        public ParticipantInput(CommunicationIdentifier id, string call)
            : this(CommunicationIdentifierSerializer.Serialize(id), call) { }
    }
}
