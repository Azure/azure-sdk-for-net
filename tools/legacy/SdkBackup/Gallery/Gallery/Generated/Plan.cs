// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// A gallery item plan.
    /// </summary>
    public partial class Plan
    {
        private string _description;
        
        /// <summary>
        /// Optional. Gets or sets the plan description.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private string _displayName;
        
        /// <summary>
        /// Optional. Gets or sets the plan display name.
        /// </summary>
        public string DisplayName
        {
            get { return this._displayName; }
            set { this._displayName = value; }
        }
        
        private string _planIdentifier;
        
        /// <summary>
        /// Optional. Gets or sets the plan identifier.
        /// </summary>
        public string PlanIdentifier
        {
            get { return this._planIdentifier; }
            set { this._planIdentifier = value; }
        }
        
        private string _summary;
        
        /// <summary>
        /// Optional. Gets or sets the plan summary.
        /// </summary>
        public string Summary
        {
            get { return this._summary; }
            set { this._summary = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Plan class.
        /// </summary>
        public Plan()
        {
        }
    }
}
