// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Health.Deidentification
{
    [CodeGenSuppress("TaggedPhiEntities", typeof(TextEncodingType), typeof(IEnumerable<SimplePhiEntity>))]
    public partial class TaggedPhiEntities
    {
        /// <summary> Initializes a new instance of <see cref="TaggedPhiEntities"/>. </summary>
        /// <param name="entities"> List of PHI entities using UTF-16 encoding. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="entities"/> is null. </exception>
        public TaggedPhiEntities(IEnumerable<SimplePhiEntity> entities)
        {
            Argument.AssertNotNull(entities, nameof(entities));

            Encoding = TextEncodingType.Utf16;
            Entities = entities.ToList();
        }
    }
}
