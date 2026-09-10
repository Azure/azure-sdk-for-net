// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Customization to restore properties dropped by MPG generator due to
    // @@alternateType identity-aliasing on LinkedServiceReference (issue #59298).
    public partial class CustomActivityReferenceObject
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public IList<DataFactoryLinkedServiceReference> LinkedServices { get; } = new ChangeTrackingList<DataFactoryLinkedServiceReference>();
    }
}
