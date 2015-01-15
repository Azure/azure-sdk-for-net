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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.Hadoop.Avro.Serializers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal abstract class IntegrationWithHiveDataProvider
    {
        protected readonly List<LargeClass> Expected;

        protected IntegrationWithHiveDataProvider(Codec codec)
        {
            this.Codec = codec;
            this.Expected = new List<LargeClass>();
            for (int i = 0; i < AvroIntegrationWithHiveConfigurations.NumberOfAvroRecords; i++)
            {
                this.Expected.Add(LargeClass.Create());
            }
        }

        protected Codec Codec { get; set; }

        public abstract void CompareToAvroFile(Stream stream);

        public void CompareToQueryResult(string result)
        {
            string[] queryRecords = result.TrimEnd(new[] { '\r', '\n' }).Split('\n');
            IEnumerable<LargeClass> actual = queryRecords.Select(LargeClass.Create);
            Assert.IsTrue(this.Expected.SequenceEqual(actual));
        }

        public Schema GetSchema()
        {
            return AvroSerializer.Create<LargeClass>(new AvroSerializerSettings { UsePosixTime = true }).WriterSchema;
        }

        public abstract void WriteAvroFile(Stream stream);
    }

    internal class LargeClassReflectionDataProvider : IntegrationWithHiveDataProvider
    {
        public LargeClassReflectionDataProvider(Codec codec) : base(codec)
        {
        }

        public override void CompareToAvroFile(Stream stream)
        {
            IAvroReader<LargeClass> avroReader = AvroContainer.CreateReader<LargeClass>(
                stream,
                true,
                new AvroSerializerSettings { UsePosixTime = true },
                new CodecFactory());
            using (var reader = new SequentialReader<LargeClass>(avroReader))
            {
                Assert.IsTrue(this.Expected.SequenceEqual(reader.Objects));
            }
        }

        public override void WriteAvroFile(Stream stream)
        {
            IAvroWriter<LargeClass> avroWriter = AvroContainer.CreateWriter<LargeClass>(
                stream,
                new AvroSerializerSettings { UsePosixTime = true },
                this.Codec);
            using (var writer = new SequentialWriter<LargeClass>(avroWriter, AvroIntegrationWithHiveConfigurations.AvroBlockSize))
            {
                foreach (LargeClass record in this.Expected)
                {
                    writer.Write(record);
                }
            }
        }
    }

    internal class LargeClassGenericDataProvider : IntegrationWithHiveDataProvider
    {
        public LargeClassGenericDataProvider(Codec codec) : base(codec)
        {
        }

        public override void CompareToAvroFile(Stream stream)
        {
            using (IAvroReader<object> streamReader = AvroContainer.CreateGenericReader(stream))
            {
                using (var sequentialReader = new SequentialReader<object>(streamReader))
                {
                    IEnumerable<LargeClass> actual = sequentialReader.Objects.Select(o => (AvroRecord)o).Select(LargeClass.Create);
                    Assert.IsTrue(this.Expected.SequenceEqual(actual));
                }
            }
        }

        public override void WriteAvroFile(Stream stream)
        {
            using (IAvroWriter<object> streamWriter = AvroContainer.CreateGenericWriter(this.GetSchema().ToString(), stream, this.Codec))
            {
                using (var sequentialWriter = new SequentialWriter<object>(streamWriter, AvroIntegrationWithHiveConfigurations.AvroBlockSize))
                {
                    foreach (LargeClass record in this.Expected)
                    {
                        sequentialWriter.Write(record.ToAvroRecord(this.GetSchema()));
                    }
                }
            }
        }
    }

    [DataContract]
    internal sealed class LargeClass : IEquatable<LargeClass>
    {
        public static LargeClass Create()
        {
            var result = new LargeClass
            {
                BoolMember = Utilities.GetRandom<bool>(false),
                SByteArrayMember = Utilities.GetRandom<sbyte[]>(false),
                DateTimeMember = Utilities.GetRandom<DateTime>(false),
                DecimalMember = Utilities.GetRandom<decimal>(false),
                DoubleMember = Utilities.GetRandom<double>(false),
                EnumMember = Utilities.GetRandom<Utilities.RandomEnumeration>(false),
                FloatMember = Utilities.GetRandom<float>(false),
                GuidMember = Utilities.GetRandom<Guid>(false),
                IntArrayMember = Utilities.GetRandom<int[]>(false),
                IntListMember = Utilities.GetRandom<List<int>>(false),
                IntMapMember = Utilities.GetRandom<Dictionary<string, int>>(false),
                IntMember = Utilities.GetRandom<int>(false),
                LongMember = Utilities.GetRandom<long>(false),
                StringMember = Utilities.GetRandom<string>(false)
            };

            return result;
        }

        public static LargeClass Create(string queryResult)
        {
            var actualTokens = queryResult.TrimEnd('\r').Split('\t');

            return new LargeClass
            {
                BoolMember = bool.Parse(actualTokens[0]),
                DateTimeMember = DateTimeSerializer.ConvertPosixTimeToDateTime(long.Parse(actualTokens[1])),
                DecimalMember = decimal.Parse(actualTokens[2]),
                DoubleMember = double.Parse(actualTokens[3], NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture),
                EnumMember = (Utilities.RandomEnumeration)Enum.Parse(typeof(Utilities.RandomEnumeration), actualTokens[4]),
                FloatMember = float.Parse(actualTokens[5], NumberStyles.Float, CultureInfo.InvariantCulture),
                GuidMember = new Guid(Convert.FromBase64String(actualTokens[6])),
                IntArrayMember = JArray.Parse(actualTokens[7]).Select(token => (int)token).ToArray(),
                IntListMember = JArray.Parse(actualTokens[8]).Select(token => (int)token).ToList(),
                IntMapMember = JsonConvert.DeserializeObject<Dictionary<string, int>>(actualTokens[9]),
                IntMember = int.Parse(actualTokens[10]),
                LongMember = long.Parse(actualTokens[11]),
                SByteArrayMember = JArray.Parse(actualTokens[12]).Select(token => (sbyte)token).ToArray(),
                StringMember = actualTokens[13]
            };
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", 
            Justification = "Creation of the class with random values is necessary for the test.")]
        public static LargeClass Create(AvroRecord record)
        {
            var dynamicRecord = (dynamic)record;

            return new LargeClass
            {
                BoolMember = dynamicRecord.BoolMember,
                DateTimeMember = DateTimeSerializer.ConvertPosixTimeToDateTime(dynamicRecord.DateTimeMember),
                DecimalMember = decimal.Parse(dynamicRecord.DecimalMember),
                DoubleMember = dynamicRecord.DoubleMember,
                EnumMember = Enum.Parse(typeof(Utilities.RandomEnumeration), dynamicRecord.EnumMember.Value),
                FloatMember = dynamicRecord.FloatMember,
                GuidMember = new Guid(dynamicRecord.GuidMember),
                IntArrayMember = ((Array)dynamicRecord.IntArrayMember).OfType<int>().ToArray(),
                IntListMember = ((Array)dynamicRecord.IntListMember).OfType<int>().ToList(),
                IntMapMember = ((Dictionary<string, object>)dynamicRecord.IntMapMember).ToDictionary(pair => pair.Key, pair => (int)pair.Value),
                IntMember = dynamicRecord.IntMember,
                LongMember = dynamicRecord.LongMember,
                SByteArrayMember = ((Array)dynamicRecord.SByteArrayMember).OfType<int>().Select(i => (sbyte)i).ToArray(),
                StringMember = dynamicRecord.StringMember,
            };
        }

        [DataMember]
        public bool BoolMember { get; set; }

        [DataMember]
        public DateTime DateTimeMember { get; set; }

        [DataMember]
        public decimal DecimalMember { get; set; }

        [DataMember]
        public double DoubleMember { get; set; }

        [DataMember]
        public Utilities.RandomEnumeration EnumMember { get; set; }

        [DataMember]
        public float FloatMember { get; set; }

        [DataMember]
        public Guid GuidMember { get; set; }

        [DataMember]
        public int[] IntArrayMember { get; set; }

        [DataMember]
        public List<int> IntListMember { get; set; }

        [DataMember]
        public Dictionary<string, int> IntMapMember { get; set; }

        [DataMember]
        public int IntMember { get; set; }

        [DataMember]
        public long LongMember { get; set; }

        [DataMember]
        public sbyte[] SByteArrayMember { get; set; }

        [DataMember]
        public string StringMember { get; set; }

        public bool Equals(LargeClass other)
        {
            if (other == null)
            {
                return false;
            }

            return 
                this.EnumMember == other.EnumMember 
                && this.StringMember == other.StringMember 
                && this.FloatMember == other.FloatMember 
                && this.IntMember == other.IntMember 
                && this.LongMember == other.LongMember 
                && this.DoubleMember == other.DoubleMember 
                && this.BoolMember == other.BoolMember 
                && this.DecimalMember == other.DecimalMember 
                && this.GuidMember == other.GuidMember 
                && this.DateTimeMember.Date == other.DateTimeMember.Date 
                && this.DateTimeMember.Hour == other.DateTimeMember.Hour
                && this.DateTimeMember.Minute == other.DateTimeMember.Minute
                && this.DateTimeMember.Second == other.DateTimeMember.Second
                && this.IntArrayMember.SequenceEqual(other.IntArrayMember) 
                && this.SByteArrayMember.SequenceEqual(other.SByteArrayMember) 
                && this.IntListMember.SequenceEqual(other.IntListMember) 
                && Utilities.DictionaryEquals(this.IntMapMember, other.IntMapMember);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.Equals(obj as LargeClass);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 83;
                hash = (hash * 13) + this.EnumMember.GetHashCode();
                hash = (hash * 13) + this.StringMember.GetHashCode();
                hash = (hash * 13) + this.FloatMember.GetHashCode();
                hash = (hash * 13) + this.IntMember.GetHashCode();
                hash = (hash * 13) + this.LongMember.GetHashCode();
                hash = (hash * 13) + this.DoubleMember.GetHashCode();
                hash = (hash * 13) + this.BoolMember.GetHashCode();
                hash = (hash * 13) + this.DecimalMember.GetHashCode();
                hash = (hash * 13) + this.GuidMember.GetHashCode();
                hash = (hash * 13) + this.DateTimeMember.GetHashCode();
                foreach (int member in this.IntArrayMember)
                {
                    hash = (hash * 13) + member.GetHashCode();
                }
                foreach (sbyte member in this.SByteArrayMember)
                {
                    hash = (hash * 13) + member.GetHashCode();
                }
                foreach (int member in this.IntListMember)
                {
                    hash = (hash * 13) + member.GetHashCode();
                }
                foreach (var member in this.IntMapMember)
                {
                    hash = (hash * 13) + member.Key.GetHashCode();
                    hash = (hash * 13) + member.Value.GetHashCode();
                }
                return hash;
            }
        }

        public AvroRecord ToAvroRecord(Schema schema)
        {
            var rs = schema as RecordSchema;
            var avroEnum = new AvroEnum(rs.GetField("EnumMember").TypeSchema)
            {
                Value = this.EnumMember.ToString()
            };

            var result = new AvroRecord(schema);
            result["EnumMember"] = avroEnum;
            result["StringMember"] = this.StringMember;
            result["FloatMember"] = this.FloatMember;
            result["IntMember"] = this.IntMember;
            result["LongMember"] = this.LongMember;
            result["DoubleMember"] = this.DoubleMember;
            result["BoolMember"] = this.BoolMember;
            result["DecimalMember"] = this.DecimalMember.ToString();
            result["GuidMember"] = this.GuidMember.ToByteArray();
            result["DateTimeMember"] = DateTimeSerializer.ConvertDateTimeToPosixTime(this.DateTimeMember);
            result["IntArrayMember"] = this.IntArrayMember;
            result["SByteArrayMember"] = this.SByteArrayMember;
            result["IntListMember"] = this.IntListMember.ToArray();
            result["IntMapMember"] = this.IntMapMember;

            return result;
        }
    }
}
