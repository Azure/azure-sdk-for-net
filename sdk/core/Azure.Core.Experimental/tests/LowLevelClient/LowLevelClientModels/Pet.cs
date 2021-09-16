// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Core.Experimental.Tests.Models
{
    /// <summary> The Pet output model. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        internal Pet()
        {
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="species"></param>
        internal Pet(int? id, string name, string species)
        {
            Id = id;
            Name = name;
            Species = species;
        }

        public int? Id { get; }
        public string Name { get; }
        public string Species { get; }

        // Cast from Response to Pet
        public static implicit operator Pet(Response r) => throw new NotImplementedException();
    }
}
