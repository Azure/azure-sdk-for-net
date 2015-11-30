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
// It demonstrates how to utilize Custom Compression Codec with Avro Object Container files.  
// Specifically - Deflate implementation of .NET Framework 4.5
// (vs Deflate of .NET Framework 4.0 used in Microsoft Avro Library)
// 
// This code needs to be compiled with the parameter Target Framework set as ".NET Framework 4.5"
// to ensure the desired implementation of Deflate compression algorithm is used
// Ensure your C# Project is set up accordingly
//

namespace Microsoft.Hadoop.Avro.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Runtime.Serialization;

    using Microsoft.Hadoop.Avro.Container;


    #region Defining objects for serialization
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
    #endregion

    #region Defining custom codec based on .NET Framework V.4.5 Deflate
    //Microsoft Avro Library Codec class contains two methods 
    //GetCompressedStreamOver(Stream uncompressed) and GetDecompressedStreamOver(Stream compressed)
    //which are the key ones for data compression.
    //To enable a custom codec one needs to implement these methods for the required codec

    #region Defining Compression and Decompression Streams
    //DeflateStream (class from System.IO.Compression namespace that implements Deflate algorithm)
    //can not be directly used for Avro because it does not support vital operations like Seek.
    //Thus one needs to implement two classes inherited from Stream
    //(one for compressed and one for decompressed stream)
    //that use Deflate compression and implement all required features 
    internal sealed class CompressionStreamDeflate45 : Stream
    {
        private readonly Stream buffer;
        private DeflateStream compressionStream;

        public CompressionStreamDeflate45(Stream buffer)
        {
            Debug.Assert(buffer != null, "Buffer is not allowed to be null.");

            this.compressionStream = new DeflateStream(buffer, CompressionLevel.Fastest, true);
            this.buffer = buffer;
        }

        public override bool CanRead
        {
            get { return this.buffer.CanRead; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return this.buffer.CanWrite; }
        }

        public override void Flush()
        {
            this.compressionStream.Close();
        }

        public override long Length
        {
            get { return this.buffer.Length; }
        }

        public override long Position
        {
            get
            {
                return this.buffer.Position;
            }

            set
            {
                this.buffer.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.buffer.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.buffer.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.compressionStream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposed)
        {
            base.Dispose(disposed);

            if (disposed)
            {
                this.compressionStream.Dispose();
                this.compressionStream = null;
            }
        }
    }

    internal sealed class DecompressionStreamDeflate45 : Stream
    {
        private readonly DeflateStream decompressed;

        public DecompressionStreamDeflate45(Stream compressed)
        {
            this.decompressed = new DeflateStream(compressed, CompressionMode.Decompress, true);
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            this.decompressed.Close();
        }

        public override long Length
        {
            get { return this.decompressed.Length; }
        }

        public override long Position
        {
            get
            {
                return this.decompressed.Position;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.decompressed.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                this.decompressed.Dispose();
            }
        }
    }
    #endregion

    #region Define Codec
    //Define the actual codec class containing the required methods for manipulating streams:
    //GetCompressedStreamOver(Stream uncompressed) and GetDecompressedStreamOver(Stream compressed)
    //Codec class uses classes for comressed and decompressed streams defined above
    internal sealed class DeflateCodec45 : Codec
    {

        //We merely use different IMPLEMENTATION of Deflate, so the CodecName remains "deflate"
        public static readonly string CodecName = "deflate";

        public DeflateCodec45()
            : base(CodecName)
        {
        }

        public override Stream GetCompressedStreamOver(Stream decompressed)
        {
            if (decompressed == null)
            {
                throw new ArgumentNullException("decompressed");
            }

            return new CompressionStreamDeflate45(decompressed);
        }

        public override Stream GetDecompressedStreamOver(Stream compressed)
        {
            if (compressed == null)
            {
                throw new ArgumentNullException("compressed");
            }

            return new DecompressionStreamDeflate45(compressed);
        }
    }
    #endregion

    #region Define modified Codec Factory
    //Define modified Codec Factory to be used in Reader
    //It will catch the attempt to use "deflate" and provide Custom Codec 
    //For all other cases it will rely on the base class (CodecFactory)
    internal sealed class CodecFactoryDeflate45 : CodecFactory
    {

        public override Codec Create(string codecName)
        {
            if (codecName == DeflateCodec45.CodecName)
                return new DeflateCodec45();
            else
                return base.Create(codecName);
        }
    }
    #endregion

    #endregion

    #region Sample Class with demonstration methods
    //This class contains methods demonstrating
    //the usage of Microsoft Avro Library
    public class AvroSample
    {

        //Serializes and deserializes sample data set using Reflection and Avro Object Container Files
        //Serialized data is compressed with the Custom compression codec (Deflate of .NET Framework 4.5)
        //
        //This sample uses Memory Stream for all operations related to serialization, deserialization and
        //Object Container manipulation, though File Stream could be easily used.
        public void SerializeDeserializeUsingObjectContainersReflectionCustomCodec()
        {

            Console.WriteLine("SERIALIZATION USING REFLECTION, AVRO OBJECT CONTAINER FILES AND CUSTOM CODEC\n");

            //Path for Avro Object Container File
            string path = "AvroSampleReflectionDeflate45.avro";

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
                //Here the custom Codec is introduced. For convenience the next commented code line shows how to use built-in Deflate.
                //Note, that because the sample deals with different IMPLEMENTATIONS of Deflate, built-in and custom codecs are interchangeable
                //in read-write operations
                //using (var w = AvroContainer.CreateWriter<SensorData>(buffer, Codec.Deflate))
                using (var w = AvroContainer.CreateWriter<SensorData>(buffer, new DeflateCodec45()))
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

                //Because of SequentialReader<T> constructor signature an AvroSerializerSettings instance is required
                //when Codec Factory is explicitly specified
                //You may comment the line below if you want to use built-in Deflate (see next comment)
                AvroSerializerSettings settings = new AvroSerializerSettings();

                //Create a SequentialReader for type SensorData which will derserialize all serialized objects from the given stream
                //It allows iterating over the deserialized objects because it implements IEnumerable<T> interface
                //Here the custom Codec Factory is introduced.
                //For convenience the next commented code line shows how to use built-in Deflate
                //(no explicit Codec Factory parameter is required in this case).
                //Note, that because the sample deals with different IMPLEMENTATIONS of Deflate, built-in and custom codecs are interchangeable
                //in read-write operations
                //using (var reader = new SequentialReader<SensorData>(AvroContainer.CreateReader<SensorData>(buffer, true)))
                using (var reader = new SequentialReader<SensorData>(
                    AvroContainer.CreateReader<SensorData>(buffer, true, settings, new CodecFactoryDeflate45())))
                {
                    var results = reader.Objects;

                    //Finally, verify that deserialized data matches the original one
                    Console.WriteLine("Comparing Initial and Deserialized Data Sets...");
                    bool isEqual;
                    int count = 1;
                    var pairs = testData.Zip(results, (serialized, deserialized) => new { expected = serialized, actual = deserialized });
                    foreach (var pair in pairs)
                    {
                        isEqual = this.Equal(pair.expected, pair.actual);
                        Console.WriteLine("For Pair {0} result of Data Set Identity Comparison is {1}", count, isEqual.ToString());
                        count++;
                    }
                }
            }

            //Delete the file
            RemoveFile(path);
        }
    #endregion

        #region Helper Methods

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
        #endregion

        static void Main()
        {

            string sectionDivider = "---------------------------------------- ";

            //Create an instance of AvroSample Class and invoke methods
            //illustrating different serializing approaches
            AvroSample Sample = new AvroSample();

            //Serialization using Reflection to Avro Object Container File using Custom Codec
            Sample.SerializeDeserializeUsingObjectContainersReflectionCustomCodec();

            Console.WriteLine(sectionDivider);
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
