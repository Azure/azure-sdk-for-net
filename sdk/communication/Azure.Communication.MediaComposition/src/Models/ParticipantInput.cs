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

        /// <summary> Initializes a new instance of ParticipantInput. </summary>
        /// <param name="kind"> Kind of media input. </param>
        /// <param name="placeholderImageUri"> Image url to be used if participant has no video stream. </param>
        /// <param name="serviceId"> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model is polymorphic: Apart from kind and rawId, at most one further property may be set which must match the kind enum value. </param>
        /// <param name="call"> The id of the teams meeting or call. </param>
        internal ParticipantInput(MediaInputType kind, string placeholderImageUri, CommunicationIdentifierModel serviceId, string call) : base(kind, placeholderImageUri)
        {
            ServiceId = serviceId;
            Call = call;
            Kind = kind;
            Id = CommunicationIdentifierSerializer.Deserialize(serviceId);
        }

        // This is a direct copy of the auto-rest generated constructor but we want to make it internal.
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
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (call == null)
            {
                throw new ArgumentNullException(nameof(call));
            }

            ServiceId = CommunicationIdentifierSerializer.Serialize(id);
            Call = call;
            Kind = MediaInputType.Participant;
            Id = id;
        }
    }
}
