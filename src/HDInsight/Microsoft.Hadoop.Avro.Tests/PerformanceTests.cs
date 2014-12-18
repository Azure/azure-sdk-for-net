// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class PerformanceTests
    {
        private const int NumberOfRuns = 100000;

        [TestMethod]
        [TestCategory("CheckIn")]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void Performance_SimpleFlatClass()
        {
            var serializationTime = new Stopwatch();
            var deserializationTime = new Stopwatch();
            var expected = SimpleFlatClass.Create();
            var serializer = AvroSerializer.Create<SimpleFlatClass>(new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) });

            using (var stream = new MemoryStream())
            {
                serializationTime.Start();
                for (var i = 0; i < NumberOfRuns; i++)
                {
                    serializer.Serialize(stream, expected);
                }
                serializationTime.Stop();

                stream.Seek(0, SeekOrigin.Begin);

                deserializationTime.Start();
                for (var i = 0; i < NumberOfRuns; i++)
                {
                    var deserialized = serializer.Deserialize(stream);
                }
                deserializationTime.Stop();

                Console.WriteLine(serializationTime.ElapsedTicks);
                Console.WriteLine(deserializationTime.ElapsedTicks);
            }
        }
    }
}
