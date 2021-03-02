// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.Tables.Performance
{
    public class SimplePerfEntityGenerator : EntityGenerator<SimplePerfEntity>
    {
        public override IEnumerable<SimplePerfEntity> Generate(int count)
        {
            var stringValue = "This is a string";

            return Enumerable.Range(1, count).Select(n =>
                {
                    string number = n.ToString();
                    return new SimplePerfEntity
                    {
                        PartitionKey = "performance",
                        RowKey = n.ToString("D4"),
                        StringTypeProperty1 = stringValue,
                        StringTypeProperty2 = stringValue,
                        StringTypeProperty3 = stringValue,
                        StringTypeProperty4 = stringValue,
                        StringTypeProperty5 = stringValue,
                        StringTypeProperty6 = stringValue,
                        StringTypeProperty7 = stringValue,
                    };
                }).ToList();
        }
    }
}
