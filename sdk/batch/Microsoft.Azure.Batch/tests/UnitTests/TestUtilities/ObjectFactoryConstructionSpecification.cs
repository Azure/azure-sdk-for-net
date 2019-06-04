// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    
    public class ObjectFactoryConstructionSpecification
    {
        public Type Type { get; private set; }

        public Func<object> Constructor { get; private set; }

        public ObjectFactoryConstructionSpecification(Type type, Func<object> constructor)
        {
            this.Type = type;
            this.Constructor = constructor;
        }
    }
}
