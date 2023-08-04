// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.Core.Experimental.Tests.Models
{
    /// <summary> The Pet output model. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        public Pet()
        {
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"></param>
        /// <param name="species"></param>
        public Pet(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public string Name { get; }
        public string Species { get; }

        // Cast from Response to Pet
        public static implicit operator Pet(Response response)
        {
            // [X] TODO: Add in (Gen 1) convenience client error semantics
            // [X] TODO: Use response.IsError
            // [X] TODO: Use throw new ResponseFailedException(response);

            if (response.IsError)
            {
                throw new RequestFailedException(response);
            }

            return DeserializePet(JsonDocument.Parse(response.Content.ToMemory()));
        }

        private static Pet DeserializePet(JsonDocument document)
        {
            return new Pet(
                document.RootElement.GetProperty("name").GetString(),
                document.RootElement.GetProperty("species").GetString());
        }
    }
}
