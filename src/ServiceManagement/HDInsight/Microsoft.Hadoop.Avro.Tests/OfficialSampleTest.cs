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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [DataContract(Name = "SensorDataValue", Namespace = "Sensors")]
    internal class SensorData
    {
        [DataMember(Name = "Location")]
        public Location Position { get; set; }

        [DataMember(Name = "Value")]
        public byte[] Value { get; set; }
    }

    [DataContract]
    internal struct Location
    {
        [DataMember]
        public int Floor { get; set; }

        [DataMember]
        public int Room { get; set; }
    }

    [TestClass]
    public class OfficialSampleTest
    {
        [TestMethod]
        [TestCategory("CheckIn")]
        public void TestSerializeDeserializeObject()
        {
            //CreateDeserializerOnly a new AvroSerializer instance and specify a custom serialization strategy AvroDataContractResolver
            //for serializing only properties attributed with DataContract/DateMember
            var settings = new AvroSerializerSettings();
            var avroSerializer = AvroSerializer.Create<SensorData>(settings);

            //CreateDeserializerOnly a new buffer
            using (var buffer = new MemoryStream())
            {
                //CreateDeserializerOnly sample data
                var expected = new SensorData { Value = new byte[] { 1, 2, 3, 4, 5 }, Position = new Location { Room = 243, Floor = 1 } };

                //Serialize the data to the specified stream
                avroSerializer.Serialize(buffer, expected);

                //Prepare the stream for deserializing the data
                buffer.Seek(0, SeekOrigin.Begin);

                //Derserialize data from the stream and cast it to the same type used for serialization
                var actual = avroSerializer.Deserialize(buffer);

                //Finally, verify that deserialized data matches the original ones
                Assert.IsTrue(this.Equal(expected, actual));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [SuppressMessage("Microsoft.Usage", "CA2202:DoNotDisposeObjectsMultipleTimes",
        Justification = "Our implementation should be able to handle double dispose.")]
        public void TestSerializeDeserializeUsingSequentialContainers()
        {
            //CreateDeserializerOnly a new AvroSerializer instance and specify a custom serialization strategy AvroDataContractResolver
            //for handling only properties attributed with DataContract/DateMember.
            var settings = new AvroSerializerSettings();

            //CreateDeserializerOnly a new buffer
            using (var buffer = new MemoryStream())
            {
                //CreateDeserializerOnly sample data
                var testData = new List<SensorData>
                        {
                            new SensorData { Value = new byte[] { 1, 2, 3, 4, 5 }, Position = new Location { Room = 243, Floor = 1 } },
                            new SensorData { Value = new byte[] { 6, 7, 8, 9 }, Position = new Location { Room = 244, Floor = 1 } }
                        };

                //CreateDeserializerOnly a SequentialWriter instance for type SensorData which can serialize a sequence of SensorData objects to stream
                using (var w = AvroContainer.CreateWriter<SensorData>(buffer, settings, Codec.Null))
                {
                    using (var writer = new SequentialWriter<SensorData>(w, 24))
                    {
                        // Serialize the data to stream using the sequential writer
                        testData.ForEach(writer.Write);
                    }
                }

                //Prepare the stream for deserializing the data
                buffer.Seek(0, SeekOrigin.Begin);

                //CreateDeserializerOnly a SequentialReader for type SensorData which will derserialize all serialized objects from the given stream
                //It allows iterating over the deserialized objects because it implements IEnumerable<T> interface
                using (var reader = new SequentialReader<SensorData>(
                    AvroContainer.CreateReader<SensorData>(buffer, true, settings, new CodecFactory())))
                {
                    var results = reader.Objects;

                    //Finally, verify that deserialized data matches the original ones
                    var pairs = testData.Zip(results, (serialized, deserialized) => new { expected = serialized, actual = deserialized });
                    foreach (var pair in pairs)
                    {
                        Assert.IsTrue(this.Equal(pair.expected, pair.actual));
                    }
                }
            }
        }

        private bool Equal(SensorData left, SensorData right)
        {
            return left.Position.Equals(right.Position) && left.Value.SequenceEqual(right.Value);
        }
    }
}
