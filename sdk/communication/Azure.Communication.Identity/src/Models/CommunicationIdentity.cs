// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Identity
{
    // Reduced to internal: wire model, not part of the public contract. Belongs in a spec-repo client.tsp via @access(Access.internal).
    [CodeGenSuppress("CommunicationIdentity", typeof(string))]
    [CodeGenSuppress("CommunicationIdentity", typeof(string), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("CommunicationIdentity")]
    internal partial class CommunicationIdentity
    {
        /// <summary> Initializes a new instance of <see cref="CommunicationIdentity"/>. </summary>
        /// <param name="id"> Identifier of the identity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        internal CommunicationIdentity(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Id = id;
        }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentity"/>. </summary>
        /// <param name="id"> Identifier of the identity. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        internal CommunicationIdentity(string id, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Id = id;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
