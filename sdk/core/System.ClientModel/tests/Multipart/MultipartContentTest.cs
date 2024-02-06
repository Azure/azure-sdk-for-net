// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Multipart
{
    internal class MultipartContentTest
    {
        internal class TestModel
        {
            public TestModel(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get;}
            public int Age { get;}
        }
        [Test]
        public void TestToContent()
        {
            MultipartFormData content = new MultipartFormData();
            content.Add(new BinaryData("part1"));
            content.Add(new BinaryData("part2"));
            BinaryData binaryData = content.ToContent();
            string raw = binaryData.ToString();
            Console.WriteLine(binaryData.ToString());
        }
        [Test]
        public void TestToContentForFormData()
        {
            MultipartFormData content = new MultipartFormData();
            content.Add(new BinaryData("part1", "text/plainText"), "part1");
            content.Add(new BinaryData("part2"), "part2");
            content.Add(BinaryData.FromObjectAsJson(new TestModel("model1", 10)), "model");
            content.Add(BinaryData.FromStream(File.Open("D:\\materials\\test.png", FileMode.Open)), "file", "file.wav", null);
            //BinaryData binaryData = content.ToContent();
            BinaryData binaryData = ModelReaderWriter.Write(content, new ModelReaderWriterOptions("MPFD"));
            byte[] data = binaryData.ToArray();
            int len1 = data.Length;
            string raw = binaryData.ToString();
            int len = raw.Length;
            Console.WriteLine(binaryData.ToString());
            MultipartFormData content2 = MultipartFormData.Create(binaryData);
            BinaryData binaryData2 = content2.ToContent();
            byte[] data2 = binaryData2.ToArray();
            int length2 = data2.Length;
            try
            {
                byte[] data3 = content2.ContentParts[3].Content.ToArray();
                using (var fs = new FileStream("D:\\materials\\testreturn.png", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(data3, 0, data3.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
            }
        }
    }
}
