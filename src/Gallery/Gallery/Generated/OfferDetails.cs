// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Gallery;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// A gallery item offer details.
    /// </summary>
    public partial class OfferDetails
    {
        private string _offerIdentifier;
        
        /// <summary>
        /// Optional. Gets or sets offer identifier.
        /// </summary>
        public string OfferIdentifier
        {
            get { return this._offerIdentifier; }
            set { this._offerIdentifier = value; }
        }
        
        private IList<Plan> _plans;
        
        /// <summary>
        /// Optional. Gets or sets plans.
        /// </summary>
        public IList<Plan> Plans
        {
            get { return this._plans; }
            set { this._plans = value; }
        }
        
        private string _publisherIdentifier;
        
        /// <summary>
        /// Optional. Gets or sets publisher identifier.
        /// </summary>
        public string PublisherIdentifier
        {
            get { return this._publisherIdentifier; }
            set { this._publisherIdentifier = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the OfferDetails class.
        /// </summary>
        public OfferDetails()
        {
            this.Plans = new LazyList<Plan>();
        }
    }
}
