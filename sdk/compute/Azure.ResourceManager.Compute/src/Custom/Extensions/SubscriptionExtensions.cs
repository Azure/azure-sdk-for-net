// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public static partial class SubscriptionExtensions
    {
        #region SharedGallery
        /// <summary> Gets an object representing a SharedGalleryCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> Resource location. </param>
        /// <returns> Returns a <see cref="SharedGalleryCollection" /> object. </returns>
        public static SharedGalleryCollection GetSharedGalleries(this Subscription subscription, string location)
        {
            return new SharedGalleryCollection(subscription, location);
        }
        #endregion
    }
}
