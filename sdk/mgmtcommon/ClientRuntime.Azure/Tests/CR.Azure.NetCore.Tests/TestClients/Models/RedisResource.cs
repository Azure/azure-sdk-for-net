// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.TestClients.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class RedisCreateOrUpdateParameters
    {
        private string _location;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        private RedisProperties _properties;

        /// <summary>
        /// Optional.
        /// </summary>
        public RedisProperties Properties
        {
            get { return this._properties; }
            set { this._properties = value; }
        }
    }

    public partial class RedisResource : IResource
    {
        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Required. Gets or sets the location of the resource.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Optional. Gets or sets the tags attached to the resource.
        /// </summary>
        [JsonProperty("tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Location == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Location");
            }
        }

        private string _hostName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string HostName
        {
            get { return this._hostName; }
            set { this._hostName = value; }
        }

        private int? _port;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        private int? _sslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? SslPort
        {
            get { return this._sslPort; }
            set { this._sslPort = value; }
        }

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty("properties.provisioningState")]
        public string ProvisioningState { get; set; }
    }

    public partial class RedisSubResource : IResource
    {
        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        private string _hostName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string HostName
        {
            get { return this._hostName; }
            set { this._hostName = value; }
        }

        private int? _port;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        private int? _sslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? SslPort
        {
            get { return this._sslPort; }
            set { this._sslPort = value; }
        }
    }

    public partial class RedisProperties
    {
        private bool? _enableNonSslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public bool? EnableNonSslPort
        {
            get { return this._enableNonSslPort; }
            set { this._enableNonSslPort = value; }
        }

        private string _maxMemoryPolicy;

        /// <summary>
        /// Optional.
        /// </summary>
        public string MaxMemoryPolicy
        {
            get { return this._maxMemoryPolicy; }
            set { this._maxMemoryPolicy = value; }
        }

        private string _redisVersion;

        /// <summary>
        /// Optional.
        /// </summary>
        public string RedisVersion
        {
            get { return this._redisVersion; }
            set { this._redisVersion = value; }
        }

        private Sku _sku;

        /// <summary>
        /// Optional.
        /// </summary>
        public Sku Sku
        {
            get { return this._sku; }
            set { this._sku = value; }
        }
    }

    public partial class RedisReadableProperties
    {
        private string _hostName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string HostName
        {
            get { return this._hostName; }
            set { this._hostName = value; }
        }

        private int? _port;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        private string _provisioningState;

        /// <summary>
        /// Optional.
        /// </summary>
        public string ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }

        private int? _sslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? SslPort
        {
            get { return this._sslPort; }
            set { this._sslPort = value; }
        }
    }

    public partial class Sku
    {
        private int? _capacity;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Capacity
        {
            get { return this._capacity; }
            set { this._capacity = value; }
        }

        private string _family;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Family
        {
            get { return this._family; }
            set { this._family = value; }
        }

        private string _name;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
