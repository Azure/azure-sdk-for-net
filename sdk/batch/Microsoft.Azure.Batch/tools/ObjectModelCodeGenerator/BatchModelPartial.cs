// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace ObjectModelCodeGenerator
{
    using CodeGenerationLibrary;

    public partial class ModelClassTemplate
    {
        public ModelClassTemplate(ObjectModelTypeData type, string classContent)
        {
            this._classContentField = classContent;
            this._typeField = type;
        }
    }
}
