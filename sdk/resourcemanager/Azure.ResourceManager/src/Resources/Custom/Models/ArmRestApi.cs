// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Describes the properties of an Operation value. </summary>
    public partial class ArmRestApi
    {
        /// <summary> Initializes a new instance of RestApi for mocking. </summary>
        internal ArmRestApi()
        {
        }

        /// <summary> Initializes a new instance of RestApi. </summary>
        /// <param name="origin"> The origin of the operation. </param>
        /// <param name="name"> The name of the operation. </param>
        /// <param name="operation"> The display name of the operation. </param>
        /// <param name="resource"> The display name of the resource the operation applies to. </param>
        /// <param name="description"> The description of the operation. </param>
        /// <param name="provider"> The resource provider for the operation. </param>
        internal ArmRestApi(string origin, string name, string operation, string resource, string description, string provider)
        {
            Origin = origin;
            Name = name;
            Operation = operation;
            Resource = resource;
            Description = description;
            Provider = provider;
        }

        /// <summary> The origin of the operation. </summary>
        public string Origin { get; }
        /// <summary> The name of the operation. </summary>
        public string Name { get; }
        /// <summary> The display name of the operation. </summary>
        public string Operation { get; }
        /// <summary> The display name of the resource the operation applies to. </summary>
        public string Resource { get; }
        /// <summary> The description of the operation. </summary>
        public string Description { get; }
        /// <summary> The resource provider for the operation. </summary>
        public string Provider { get; }
    }
}
