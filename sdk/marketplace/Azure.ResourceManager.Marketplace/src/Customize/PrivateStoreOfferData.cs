// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Marketplace.Models;

namespace Azure.ResourceManager.Marketplace
{
    // Backward-compat shim: old API exposed writable IList/IDictionary properties on PrivateStoreOfferData.
    // The generated code uses IReadOnlyList/IReadOnlyDictionary because the model is output-only.
    // The partial properties below override the generated read-only flattened properties with writable wrappers.
    public partial class PrivateStoreOfferData
    {
        /// <summary> Plan ids limitation for this offer. </summary>
        public IList<string> SpecificPlanIdsLimitation
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PrivateStoreOfferResult();
                }
                return (IList<string>)Properties.SpecificPlanIdsLimitation;
            }
        }

        /// <summary> Icon File Uris. </summary>
        public IDictionary<string, Uri> IconFileUris
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PrivateStoreOfferResult();
                }
                return (IDictionary<string, Uri>)Properties.IconFileUris;
            }
        }

        /// <summary> Offer plans. </summary>
        public IList<PrivateStorePlan> Plans
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PrivateStoreOfferResult();
                }
                return (IList<PrivateStorePlan>)Properties.Plans;
            }
        }
    }
}
