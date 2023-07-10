// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class BlobPathSourceTests
    {
        [Test]
        public void TestToString()
        {
            IBlobPathSource path1 = BlobPathSource.Create(@"container/dir/subdir/{name}.csv");
            IBlobPathSource path2 = BlobPathSource.Create(@"container/dir/subdir/{name}.csv");
            IBlobPathSource path3 = BlobPathSource.Create(@"container/dir/subdir/other.csv");

            Assert.AreEqual(path1.ToString(), path2.ToString());
            Assert.AreNotEqual(path2.ToString(), path3.ToString());
        }

        private static IDictionary<string, string> Match(string a, string b)
        {
            var pathA = BlobPathSource.Create(a);
            BlobPath pathB = null;
            BlobPath.TryParse(b, false, out pathB);

            IReadOnlyDictionary<string, object> bindingData = pathA.CreateBindingData(pathB);

            if (bindingData == null)
            {
                return null;
            }

            IDictionary<string, string> matches = new Dictionary<string, string>();

            foreach (KeyValuePair<string, object> item in bindingData)
            {
                matches.Add(item.Key, item.Value.ToString());
            }

            return matches;
        }

        [Test]
        public void BlobPathSource_Throws_OnBackslash()
        {
            var exc = Assert.Throws<FormatException>(() => BlobPathSource.Create("container\\blob"));
            StringAssert.Contains("Paths must be in the format 'container/blob'", exc.Message);
        }

        [Test]
        public void BlobPathSource_Throws_OnEmpty()
        {
            var exc = Assert.Throws<FormatException>(() => BlobPathSource.Create("/"));
            StringAssert.Contains("Paths must be in the format 'container/blob'", exc.Message);
        }

        [Test]
        public void BlobPathSource_Throws_OnContainerResolves()
        {
            var exc = Assert.Throws<FormatException>(() => BlobPathSource.Create("container{resolve}/blob"));
            StringAssert.Contains("Container paths cannot contain {resolve} tokens.", exc.Message);
        }

        [Test]
        public void TestMethod1()
        {
            var d = Match("container", "container/item");
            Assert.NotNull(d);
            Assert.AreEqual(0, d.Count);
        }

        [Test]
        public void TestMethod2()
        {
            var d = Match(@"container/blob", @"container/blob");
            Assert.NotNull(d);
            Assert.AreEqual(0, d.Count);
        }

        [Test]
        public void TestMethod3()
        {
            var d = Match(@"container/{name}.csv", @"container/foo.csv");
            Assert.NotNull(d);
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual("foo", d["name"]);
        }

        [Test]
        public void TestMethod4()
        {
            // Test corner case where matching at end
            var d = Match(@"container/{name}", @"container/foo.csv");
            Assert.NotNull(d);
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual("foo.csv", d["name"]);
        }

        [Test]
        public void TestMethodExtension()
        {
            // {name} is greedy when matching up to an extension.
            var d = Match(@"container/{name}.csv", @"container/foo.alpha.csv");
            Assert.NotNull(d);
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual("foo.alpha", d["name"]);
        }

        [Test]
        public void TestGreedy()
        {
            var d = Match(@"container/{a}.{b}", @"container/foo.alpha.beta.csv");
            Assert.NotNull(d);
            Assert.AreEqual(2, d.Count);
            Assert.AreEqual("foo.alpha.beta", d["a"]);
            Assert.AreEqual("csv", d["b"]);
        }

        [Test]
        public void TestMethod6()
        {
            // Test corner case where matching on last
            var d = Match(@"daas-test-input/{name}.txt", @"daas-test-input/bob.txtoutput");
            Assert.Null(d);
        }

        [Test]
        public void TestMethod5()
        {
            // Test corner case where matching on last
            var d = Match(@"container/{name}-{date}.csv", @"container/foo-Jan1st.csv");
            Assert.NotNull(d);
            Assert.AreEqual(2, d.Count);
            Assert.AreEqual("foo", d["name"]);
            Assert.AreEqual("Jan1st", d["date"]);
        }

        [Test]
        public void GetNames()
        {
            var path = BlobPathSource.Create(@"container/{name}-{date}.csv");
            var d = path.ParameterNames;
            var names = d.ToArray();

            Assert.AreEqual(2, names.Length);
            Assert.AreEqual("name", names[0]);
            Assert.AreEqual("date", names[1]);
        }
    }
}
