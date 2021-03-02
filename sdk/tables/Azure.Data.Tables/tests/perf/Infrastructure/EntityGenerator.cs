// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Data.Tables.Performance
{
    public abstract class EntityGenerator<T> where T : ITableEntity
    {
        public abstract IEnumerable<T> Generate(int count);
    }
}
