// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// ModelMetadata is designated to store KPIs from model parsing.
    /// </summary>
    internal class ModelMetadata
    {
        public ModelMetadata(string id, IList<string> extends, IList<string> componentSchemas)
        {
            Id = id;
            Extends = extends;
            ComponentSchemas = componentSchemas;
        }

        public string Id { get; }
        public IList<string> Extends { get; }
        public IList<string> ComponentSchemas { get; }
        public IList<string> Dependencies => Extends.Union(ComponentSchemas).ToList();
    }
}
