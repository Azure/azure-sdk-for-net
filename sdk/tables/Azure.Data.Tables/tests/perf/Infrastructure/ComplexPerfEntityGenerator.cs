// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.Tables.Performance
{
    public class ComplexPerfEntityGenerator : EntityGenerator<ComplexPerfEntity>
    {
        public override IEnumerable<ComplexPerfEntity> Generate(int count)
        {
            var guid = Guid.NewGuid();
            var dt = DateTime.UtcNow;
            var binary = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };

            return Enumerable.Range(1, count).Select(n =>
                {
                    string number = n.ToString();
                    return new ComplexPerfEntity
                    {
                        PartitionKey = "performance",
                        RowKey = n.ToString("D4"),
                        StringTypeProperty = "This is a string",
                        DatetimeTypeProperty = dt,
                        GuidTypeProperty = guid,
                        BinaryTypeProperty = binary,
                        Int64TypeProperty = 1234L,
                        DoubleTypeProperty = 1234.5,
                        IntTypeProperty = 1234,
                    };
                }).ToList();
        }
    }
}
