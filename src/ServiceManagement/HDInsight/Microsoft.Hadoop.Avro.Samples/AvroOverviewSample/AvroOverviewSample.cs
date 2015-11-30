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



// 
// This sample shows how to use Microsoft Avro Library.
// It uses different methods to serialize and deserialize some sample data sets
// and demonstrates the usage of Avro Object Container files
// 


namespace Microsoft.Hadoop.Avro.Sample
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.Hadoop.Avro.Schema;

    //Sample Class used in serialization samples
    [DataContract(Name = "SensorDataValue", Namespace = "Sensors")]
    internal class SensorData
    {
        [DataMember(Name = "Location")]
        public Location Position { get; set; }

        [DataMember(Name = "Value")]
        public byte[] Value { get; set; }
    }

    //Sample struct used in serialization samples
    [DataContract]
    internal struct Location
    {
        [DataMember]
        public int Floor { get; set; }

        [DataMember]
        public int Room { get; set; }
    }

    //This class contains all methods demonstrating
    //the usage of Microsoft Avro Library
    public class AvroSample
    {

        //Serialize and deserialize sample data set represented as an object using Reflection
        //No explicit schema definition is required - schema of serialized objects is automatically built
        public void SerializeDeserializeObjectUsingReflection()
        {

            Console.WriteLine("SERIALIZATION USING REFLECTION\n");
            Console.WriteLine("Serializing Sample Data Set...");

            //Create a new AvroSerializer instance and specify a custom serialization strategy AvroDataContractResolver
            //for serializing only properties attributed with DataContract/DateMember
            var avroSerializer = AvroSerializer.Create<SensorData>();

            //Create a Memory Stream buffer
            using (var buffer = new MemoryStream())
            {
                //Create a data set using sample Class and struct 
                var expected = new SensorData { Value = new byte[] { 1, 2, 3, 4, 5 }, Position = new Location { Room = 243, Floor = 1 } };

                //Serialize the data to the specified stream
                avroSerializer.Serialize(buffer, expected);

      
                Console.WriteLine("Deserializing Sample Data Set...");

                //Prepare the stream for deserializing the data
                buffer.Seek(0, SeekOrigin.Begin);

                //Deserialize data from the stream and cast it to the same type used for serialization
                var actual = avroSerializer.Deserialize(buffer);

                Console.WriteLine("Comparing Initial and Deserialized Data Sets...");

                //Finally, verify that deserialized data matches the original one
                bool isEqual = this.Equal(expected, actual);

                Console.WriteLine("Result of Data Set Identity Comparison is {0}" , isEqual);
                
            }
        }

        //Serialize and deserialize sample data set using Generic Record.
        //Generic Record is a special class with the schema explicitly defined in JSON.
        //All serialized data should be mapped to the fields of Generic Record,
        //which in turn will be then serialized.
        //
        //This approach is generally slower than using Reflection,
        //but comes very handy in cases, where for example the data is represented
        //as Comma Separated Values (CSV) files rather than objects.
        //
        //In SerializeDeserializeObjectUsingGenericRecords() we will emulate this case
        //though explicit filling up the fields of the Generic Record
        public void SerializeDeserializeObjectUsingGenericRecords()
        {
            Console.WriteLine("SERIALIZATION USING GENERIC RECORD\n");
            Console.WriteLine("Defining the Schema and creating Sample Data Set...");

            //Define the schema in JSON
            const string Schema = @"{
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Specifications.SensorData"",
                                ""fields"":
                                    [
                                        { 
                                            ""name"":""Location"", 
                                            ""type"":
                                                {
                                                    ""type"":""record"",
                                                    ""name"":""Microsoft.Hadoop.Avro.Specifications.Location"",
                                                    ""fields"":
                                                        [
                                                            { ""name"":""Floor"", ""type"":""int"" },
                                                            { ""name"":""Room"", ""type"":""int"" }
                                                        ]
                                                }
                                        },
                                        { ""name"":""Value"", ""type"":""bytes"" }
                                    ]
                            }";

            //Create a generic serializer based on the schema
            var serializer = AvroSerializer.CreateGeneric(Schema);
            var rootSchema = serializer.WriterSchema as RecordSchema;

            //Create a Memory Stream buffer
            using (var stream = new MemoryStream())
            {
                //Create a generic record to represent the data
                dynamic location = new AvroRecord(rootSchema.GetField("Location").TypeSchema);
                location.Floor = 1;
                location.Room = 243;

                dynamic expected = new AvroRecord(serializer.WriterSchema);
                expected.Location = location;
                expected.Value = new byte[] { 1, 2, 3, 4, 5 };

                Console.WriteLine("Serializing Sample Data Set...");

                //Serialize the data
                serializer.Serialize(stream, expected);

                stream.Seek(0, SeekOrigin.Begin);

                Console.WriteLine("Deserializing Sample Data Set...");

                //Deserialize the data into a generic record
                dynamic actual = serializer.Deserialize(stream);

                Console.WriteLine("Comparing Initial and Deserialized Data Sets...");

                //Finally, verify the results
                bool isEqual = expected.Location.Floor.Equals(actual.Location.Floor);
                isEqual = isEqual && expected.Location.Room.Equals(actual.Location.Room);
                isEqual = isEqual && ((byte[])expected.Value).SequenceEqual((byte[])actual.Value);
                Console.WriteLine("Result of Data Set Identity Comparison is {0}", isEqual);
            }
        }

        //Serializes and deserializes sample data set using Reflection and Avro Object Container Files
        //Serialized data is compressed with Deflate codec
        //
        //This sample uses Memory Stream for all operations related to serialization, deserialization and
        //Object Container manipulation, though File Stream could be easily used.
        public void SerializeDeserializeUsingObjectContainersReflection()
        {

            Console.WriteLine("SERIALIZATION USING REFLECTION AND AVRO OBJECT CONTAINER FILES\n");

            //Path for Avro Object Container File
            string path = "AvroSampleReflectionDeflate.avro";

            //Create a data set using sample Class and struct
            var testData = new List<SensorData>
                        {
                            new SensorData { Value = new byte[] { 1, 2, 3, 4, 5 }, Position = new Location { Room = 243, Floor = 1 } },
                            new SensorData { Value = new byte[] { 6, 7, 8, 9 }, Position = new Location { Room = 244, Floor = 1 } }
                        };

            //Serializing and saving data to file
            //Creating a Memory Stream buffer
            using (var buffer = new MemoryStream())
            {
                Console.WriteLine("Serializing Sample Data Set...");

                //Create a SequentialWriter instance for type SensorData which can serialize a sequence of SensorData objects to stream
                //Data will be compressed using Deflate codec
                using (var w = AvroContainer.CreateWriter<SensorData>(buffer, Codec.Deflate))
                {
                    using (var writer = new SequentialWriter<SensorData>(w, 24))
                    {
                        // Serialize the data to stream using the sequential writer
                        testData.ForEach(writer.Write);
                    }
                }

                //Save stream to file
                Console.WriteLine("Saving serialized data to file...");
                if (!WriteFile(buffer, path))
                {
                    Console.WriteLine("Error during file operation. Quitting method");
                    return;
                }
            }

            //Reading and deserializing data
            //Creating a Memory Stream buffer
            using (var buffer = new MemoryStream())
            {
                Console.WriteLine("Reading data from file...");

                //Reading data from Object Container File
                if (!ReadFile(buffer, path))
                {
                    Console.WriteLine("Error during file operation. Quitting method");
                    return;
                }

                Console.WriteLine("Deserializing Sample Data Set...");

                //Prepare the stream for deserializing the data
                buffer.Seek(0, SeekOrigin.Begin);

                //Create a SequentialReader for type SensorData which will derserialize all serialized objects from the given stream
                //It allows iterating over the deserialized objects because it implements IEnumerable<T> interface
                using (var reader = new SequentialReader<SensorData>(
                    AvroContainer.CreateReader<SensorData>(buffer, true)))
                {
                    var results = reader.Objects;

                    //Finally, verify that deserialized data matches the original one
                    Console.WriteLine("Comparing Initial and Deserialized Data Sets...");
                    int count = 1;
                    var pairs = testData.Zip(results, (serialized, deserialized) => new { expected = serialized, actual = deserialized });
                    foreach (var pair in pairs)
                    {
                        bool isEqual = this.Equal(pair.expected, pair.actual);
                        Console.WriteLine("For Pair {0} result of Data Set Identity Comparison is {1}", count, isEqual.ToString());
                        count++;
                    }
                }
            }

            //Delete the file
            RemoveFile(path);
        }

        //Serializes and deserializes sample data set using Generic Record and Avro Object Container Files
        //Serialized data is not compressed
        //
        //This sample uses Memory Stream for all operations related to serialization, deserialization and
        //Object Container manipulation, though File Stream could be easily used.
        public void SerializeDeserializeUsingObjectContainersGenericRecord()
        {
            Console.WriteLine("SERIALIZATION USING GENERIC RECORD AND AVRO OBJECT CONTAINER FILES\n");

            //Path for Avro Object Container File
            string path = "AvroSampleGenericRecordNullCodec.avro";

            Console.WriteLine("Defining the Schema and creating Sample Data Set...");

            //Define the schema in JSON
            const string Schema = @"{
                                ""type"":""record"",
                                ""name"":""Microsoft.Hadoop.Avro.Specifications.SensorData"",
                                ""fields"":
                                    [
                                        { 
                                            ""name"":""Location"", 
                                            ""type"":
                                                {
                                                    ""type"":""record"",
                                                    ""name"":""Microsoft.Hadoop.Avro.Specifications.Location"",
                                                    ""fields"":
                                                        [
                                                            { ""name"":""Floor"", ""type"":""int"" },
                                                            { ""name"":""Room"", ""type"":""int"" }
                                                        ]
                                                }
                                        },
                                        { ""name"":""Value"", ""type"":""bytes"" }
                                    ]
                            }";

            //Create a generic serializer based on the schema
            var serializer = AvroSerializer.CreateGeneric(Schema);
            var rootSchema = serializer.WriterSchema as RecordSchema;

            //Create a generic record to represent the data
            var testData = new List<AvroRecord>();

            dynamic expected1 = new AvroRecord(rootSchema);
            dynamic location1 = new AvroRecord(rootSchema.GetField("Location").TypeSchema);
            location1.Floor = 1;
            location1.Room = 243;
            expected1.Location = location1;
            expected1.Value = new byte[] { 1, 2, 3, 4, 5 };
            testData.Add(expected1);

            dynamic expected2 = new AvroRecord(rootSchema);
            dynamic location2 = new AvroRecord(rootSchema.GetField("Location").TypeSchema);
            location2.Floor = 1;
            location2.Room = 244;
            expected2.Location = location2;
            expected2.Value = new byte[] { 6, 7, 8, 9 };
            testData.Add(expected2);

            //Serializing and saving data to file
            //Create a MemoryStream buffer
            using (var buffer = new MemoryStream())
            {
                Console.WriteLine("Serializing Sample Data Set...");

                //Create a SequentialWriter instance for type SensorData which can serialize a sequence of SensorData objects to stream
                //Data will not be compressed (Null compression codec)
                using (var writer = AvroContainer.CreateGenericWriter(Schema, buffer, Codec.Null))
                {
                    using (var streamWriter = new SequentialWriter<object>(writer, 24))
                    {
                        // Serialize the data to stream using the sequential writer
                        testData.ForEach(streamWriter.Write);
                    }
                }

                Console.WriteLine("Saving serialized data to file...");

                //Save stream to file
                if (!WriteFile(buffer, path))
                {
                    Console.WriteLine("Error during file operation. Quitting method");
                    return;
                }
            }

            //Reading and deserializng the data
            //Create a Memory Stream buffer
            using (var buffer = new MemoryStream())
            {
                Console.WriteLine("Reading data from file...");

                //Reading data from Object Container File
                if (!ReadFile(buffer, path))
                {
                    Console.WriteLine("Error during file operation. Quitting method");
                    return;
                }

                Console.WriteLine("Deserializing Sample Data Set...");

                //Prepare the stream for deserializing the data
                buffer.Seek(0, SeekOrigin.Begin);

                //Create a SequentialReader for type SensorData which will derserialize all serialized objects from the given stream
                //It allows iterating over the deserialized objects because it implements IEnumerable<T> interface
                using (var reader = AvroContainer.CreateGenericReader(buffer))
                {
                    using (var streamReader = new SequentialReader<object>(reader))
                    {
                        var results = streamReader.Objects;

                        Console.WriteLine("Comparing Initial and Deserialized Data Sets...");

                        //Finally, verify the results
                        var pairs = testData.Zip(results, (serialized, deserialized) => new { expected = (dynamic)serialized, actual = (dynamic)deserialized });
                        int count = 1;
                        foreach (var pair in pairs)
                        {
                            bool isEqual = pair.expected.Location.Floor.Equals(pair.actual.Location.Floor);
                            isEqual = isEqual && pair.expected.Location.Room.Equals(pair.actual.Location.Room);
                            isEqual = isEqual && ((byte[])pair.expected.Value).SequenceEqual((byte[])pair.actual.Value);
                            Console.WriteLine("For Pair {0} result of Data Set Identity Comparison is {1}", count, isEqual.ToString());
                            count++;
                        }
                    }
                }
            }

            //Delete the file
            RemoveFile(path);
        }

        //
        //Helper methods
        //

        //Comparing two SensorData objects
        private bool Equal(SensorData left, SensorData right)
        {
            return left.Position.Equals(right.Position) && left.Value.SequenceEqual(right.Value);
        }

        //Saving memory stream to a new file with the given path
        private bool WriteFile(MemoryStream InputStream, string path)
        {
            if (!File.Exists(path))
            {
                try
                { 
                    using (FileStream fs = File.Create(path))
                    {
                        InputStream.Seek(0, SeekOrigin.Begin);
                        InputStream.CopyTo(fs);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The following exception was thrown during creation and writing to the file \"{0}\"", path);
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Can not create file \"{0}\". File already exists", path);
                return false;

            }
        }

        //Reading a file content using given path to a memory stream
        private bool ReadFile(MemoryStream OutputStream, string path)
        {
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open))
                {
                    fs.CopyTo(OutputStream);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("The following exception was thrown during reading from the file \"{0}\"", path);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Deleting file using given path
        private void RemoveFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The following exception was thrown during deleting the file \"{0}\"", path);
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Can not delete file \"{0}\". File does not exist", path);
            }
        }

        static void Main()
        {
            
            string sectionDivider = "---------------------------------------- ";
            
            //Create an instance of AvroSample Class and invoke methods
            //illustrating different serializing approaches
            AvroSample Sample = new AvroSample();

            //Serialization to memory using Reflection
            Sample.SerializeDeserializeObjectUsingReflection();

            Console.WriteLine(sectionDivider + "\n");

            //Serialization to memory using Generic Record
            Sample.SerializeDeserializeObjectUsingGenericRecords();

            Console.WriteLine(sectionDivider + "\n");

            //Serialization using Reflection to Avro Object Container File
            Sample.SerializeDeserializeUsingObjectContainersReflection();

            Console.WriteLine(sectionDivider + "\n");

            //Serialization using Generic Record to Avro Object Container File
            Sample.SerializeDeserializeUsingObjectContainersGenericRecord();

            Console.WriteLine(sectionDivider);
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
