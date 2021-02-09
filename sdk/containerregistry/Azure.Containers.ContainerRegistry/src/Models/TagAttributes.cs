// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Models
{
    public partial class TagAttributes
    {
        /// <summary> Tag name. </summary>
        public string Name { get { return Attributes.Name; } }
        /// <summary> Tag digest. </summary>
        public string Digest { get { return Attributes.Digest; } }

        // TODO: Why is this nullable?  does it need to be?
        /// <summary> Tag created time. </summary>
        public DateTimeOffset CreatedTime { get { return Attributes.CreatedTime.Value; } }

        // TODO: Why is this nullable?  does it need to be?
        /// <summary> Tag last update time. </summary>
        public DateTimeOffset? LastUpdateTime { get { return Attributes.LastUpdateTime.Value; } }

        /// <summary> Is signed. </summary>
        [CodeGenMember("Signed")]
        public bool IsSigned { get { return Attributes.Signed.Value; } }

        /// <summary> Changeable attributes. </summary>
        public ContentPermissions Permissions { get { return Attributes.ChangeableAttributes; } }

        internal TagAttributesBase Attributes { get; }
    }
}
