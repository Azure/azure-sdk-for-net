using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    public class TagsOperations : ResourceOperationsBase<SubscriptionResourceIdentifier, Tags>
    {
        /// <summary>
        /// The resource type for subscription
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/subscriptions";

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class for mocking.
        /// </summary>
        protected TagsOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="subscriptionGuid"> The Guid of the subscription. </param>
        internal TagsOperations(ClientContext clientContext, string subscriptionGuid)
            : base(clientContext, new SubscriptionResourceIdentifier(subscriptionGuid))
        {
        }

        /// <summary>
        /// Gets the valid resource type for this operation class
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private TagsRestOperations RestClient => new TagsRestOperations(Diagnostics, Pipeline, BaseUri);
    }
}
