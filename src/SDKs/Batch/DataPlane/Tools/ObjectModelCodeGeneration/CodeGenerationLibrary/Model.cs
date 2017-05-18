// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace CodeGenerationLibrary
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the set of types to generate.
    /// </summary>
    public class Model
    {
        public Model()
        {
            this.Types = new List<ObjectModelTypeData>();
        }

        public List<ObjectModelTypeData> Types { get; private set; }
    }
}
