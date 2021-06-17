// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of a resource that is contained in a subscription.
    /// </summary>
    public class PreDefinedTagsResourceIdentifier : SubscriptionResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTagsResourceIdentifier"/> class.
        /// </summary>
        /// <param name="parent"> The identifier of the subscription that is the parent of this resource. </param>
        /// <param name="tag"> The name of the tag. </param>
        internal PreDefinedTagsResourceIdentifier(SubscriptionResourceIdentifier parent, PreDefinedTagData tag)
            : base(parent, ResourceIdentifier.TagsKey, tag.TagName)
        {
            Tag = tag;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTagsResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> A string representation of a tag resource identifier. </param>
        public PreDefinedTagsResourceIdentifier(string resourceId)
        {
            var id = ResourceIdentifier.Create(resourceId) as PreDefinedTagsResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid location level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            Tag = id.Tag;
            SubscriptionId = id.SubscriptionId;
        }

        /// <summary>
        /// The tag of the resource.
        /// </summary>
        public PreDefinedTagData Tag { get; }

        /// <inheritdoc/>
        public override bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = SubscriptionId;
            return true;
        }

        /// <summary>
        /// Convert resourceId string to TagsResourceIdentifier.
        /// </summary>
        /// <param name="other">A string representation of a resource id.</param>
        public static implicit operator PreDefinedTagsResourceIdentifier(string other)
        {
            if (other is null)
                return null;
            PreDefinedTagsResourceIdentifier id = ResourceIdentifier.Create(other) as PreDefinedTagsResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tag level resource", nameof(other));
            return id;
        }
    }
}
