// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Gallery;

namespace Microsoft.Azure.Gallery
{
    public partial class GalleryItem
    {
        private IList<Artifact> _artifacts;
        
        /// <summary>
        /// Optional. Gets or sets gallery item artifacts.
        /// </summary>
        public IList<Artifact> Artifacts
        {
            get { return this._artifacts; }
            set { this._artifacts = value; }
        }
        
        private IList<string> _categories;
        
        /// <summary>
        /// Optional. Gets or sets gallery item category identifiers.
        /// </summary>
        public IList<string> Categories
        {
            get { return this._categories; }
            set { this._categories = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional. Gets or sets gallery item description.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private string _displayName;
        
        /// <summary>
        /// Optional. Gets or sets gallery item display name.
        /// </summary>
        public string DisplayName
        {
            get { return this._displayName; }
            set { this._displayName = value; }
        }
        
        private IList<Filter> _filters;
        
        /// <summary>
        /// Optional. Gets or sets gallery item filters.
        /// </summary>
        public IList<Filter> Filters
        {
            get { return this._filters; }
            set { this._filters = value; }
        }
        
        private IDictionary<string, string> _iconFileUris;
        
        /// <summary>
        /// Optional. Gets or sets gallery item screenshot Uris
        /// </summary>
        public IDictionary<string, string> IconFileUris
        {
            get { return this._iconFileUris; }
            set { this._iconFileUris = value; }
        }
        
        private string _identity;
        
        /// <summary>
        /// Optional. Gets or sets gallery item identity.
        /// </summary>
        public string Identity
        {
            get { return this._identity; }
            set { this._identity = value; }
        }
        
        private IList<Link> _links;
        
        /// <summary>
        /// Optional. Gets or sets gallery item links.
        /// </summary>
        public IList<Link> Links
        {
            get { return this._links; }
            set { this._links = value; }
        }
        
        private string _longSummary;
        
        /// <summary>
        /// Optional. Gets or sets gallery item long summary.
        /// </summary>
        public string LongSummary
        {
            get { return this._longSummary; }
            set { this._longSummary = value; }
        }
        
        private MarketingMaterial _marketingMaterial;
        
        /// <summary>
        /// Optional. Gets or sets gallery item marketing information.
        /// </summary>
        public MarketingMaterial MarketingMaterial
        {
            get { return this._marketingMaterial; }
            set { this._marketingMaterial = value; }
        }
        
        private IDictionary<string, string> _metadata;
        
        /// <summary>
        /// Optional. Gets or sets gallery item metadata.
        /// </summary>
        public IDictionary<string, string> Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. Gets or sets gallery item name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private IList<Product> _products;
        
        /// <summary>
        /// Optional. Gets or sets gallery item product definition.
        /// </summary>
        public IList<Product> Products
        {
            get { return this._products; }
            set { this._products = value; }
        }
        
        private IDictionary<string, string> _properties;
        
        /// <summary>
        /// Optional. Gets or sets gallery item user visible properties.
        /// </summary>
        public IDictionary<string, string> Properties
        {
            get { return this._properties; }
            set { this._properties = value; }
        }
        
        private string _publisher;
        
        /// <summary>
        /// Optional. Gets or sets gallery item publisher.
        /// </summary>
        public string Publisher
        {
            get { return this._publisher; }
            set { this._publisher = value; }
        }
        
        private string _publisherDisplayName;
        
        /// <summary>
        /// Optional. Gets or sets gallery item publisher display name.
        /// </summary>
        public string PublisherDisplayName
        {
            get { return this._publisherDisplayName; }
            set { this._publisherDisplayName = value; }
        }
        
        private IList<string> _screenshotUris;
        
        /// <summary>
        /// Optional. Gets or sets gallery item screenshot Uris
        /// </summary>
        public IList<string> ScreenshotUris
        {
            get { return this._screenshotUris; }
            set { this._screenshotUris = value; }
        }
        
        private string _summary;
        
        /// <summary>
        /// Optional. Gets or sets gallery item summary.
        /// </summary>
        public string Summary
        {
            get { return this._summary; }
            set { this._summary = value; }
        }
        
        private string _uiDefinitionUri;
        
        /// <summary>
        /// Optional. Gets or sets Azure Portal Uder Interface Definition
        /// artificat Uri.
        /// </summary>
        public string UiDefinitionUri
        {
            get { return this._uiDefinitionUri; }
            set { this._uiDefinitionUri = value; }
        }
        
        private string _version;
        
        /// <summary>
        /// Optional. Gets or sets gallery item version.
        /// </summary>
        public string Version
        {
            get { return this._version; }
            set { this._version = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the GalleryItem class.
        /// </summary>
        public GalleryItem()
        {
            this.Artifacts = new LazyList<Artifact>();
            this.Categories = new LazyList<string>();
            this.Filters = new LazyList<Filter>();
            this.IconFileUris = new LazyDictionary<string, string>();
            this.Links = new LazyList<Link>();
            this.Metadata = new LazyDictionary<string, string>();
            this.Products = new LazyList<Product>();
            this.Properties = new LazyDictionary<string, string>();
            this.ScreenshotUris = new LazyList<string>();
        }
    }
}
