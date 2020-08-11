// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

using Microsoft.Rest.Serialization;

using Newtonsoft.Json;

namespace Microsoft.Rest.ClientRuntime.Tests.Resources
{
    [JsonObject("animal")]
    public class Animal
    {
        [JsonProperty("bestFriend")]
        public Animal BestFriend { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(UnixTimeJsonConverter))]
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }
    }

    [JsonObject("dog")]
    public class Dog : Animal
    {
        [JsonProperty("likesDogfood")]
        public bool LikesDogfood { get; set; }
    }

    [JsonObject("cat")]
    public class Cat : Animal
    {
        [JsonProperty("likesMice")]
        public bool LikesMice { get; set; }

        [JsonProperty("dislikes")]
        public Animal Dislikes { get; set; }
    }

    [JsonObject("siamese")]
    public class Martian : Alien
    {
        [JsonProperty("robot")]
        public string Robot { get; set; }
    }

    [JsonObject("siamese")]
    public class Siamese : Cat
    {
        [JsonProperty("color")]
        public string Color { get; private set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties2 { get; set; }
    }

    [JsonObject("alien")]
    public class Alien
    {
        public Alien()
        {
            
        }

        public Alien(string color, string smell)
        {
            Color = color;
            Smell = smell;
        }

        private string _planet;

        [JsonProperty("planet")]
        public string Planet { set { _planet = value; } }

        [JsonProperty("color")]
        public string Color { get; private set; }

        [JsonProperty("smell")]
        public string Smell { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("body")]
        public dynamic Body { get; set; }

        public string GetPlanetName()
        {
            return _planet;
        }
    }

    public class Zoo
    {
        public int Id { get; set; }
        private List<Animal> _animals = new List<Animal>();
        public List<Animal> Animals { get { return _animals; } set { _animals = value; } }
    }
}
