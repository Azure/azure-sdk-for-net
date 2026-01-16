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

            Assert.That(path2.ToString(), Is.EqualTo(path1.ToString()));
            Assert.That(path3.ToString(), Is.Not.EqualTo(path2.ToString()));
        }

        private static IDictionary<string, string> Match(string a, string b)
        {
            var pathA = BlobPathSource.Create(a);
            BlobPath pathB = null;
            BlobPath.TryParse(b, false, false, out pathB);

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
            Assert.That(exc.Message, Does.Contain("Paths must be in the format 'container/blob'"));
        }

        [Test]
        public void BlobPathSource_Throws_OnEmpty()
        {
            var exc = Assert.Throws<FormatException>(() => BlobPathSource.Create("/"));
            Assert.That(exc.Message, Does.Contain("Paths must be in the format 'container/blob'"));
        }

        [Test]
        public void BlobPathSource_Throws_OnContainerResolves()
        {
            var exc = Assert.Throws<FormatException>(() => BlobPathSource.Create("container{resolve}/blob"));
            Assert.That(exc.Message, Does.Contain("Container paths cannot contain {resolve} tokens."));
        }

        [Test]
        public void TestMethod1()
        {
            var d = Match("container", "container/item");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestMethod2()
        {
            var d = Match(@"container/blob", @"container/blob");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestMethod3()
        {
            var d = Match(@"container/{name}.csv", @"container/foo.csv");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(1));
            Assert.That(d["name"], Is.EqualTo("foo"));
        }

        [Test]
        public void TestMethod4()
        {
            // Test corner case where matching at end
            var d = Match(@"container/{name}", @"container/foo.csv");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(1));
            Assert.That(d["name"], Is.EqualTo("foo.csv"));
        }

        [Test]
        public void TestMethodExtension()
        {
            // {name} is greedy when matching up to an extension.
            var d = Match(@"container/{name}.csv", @"container/foo.alpha.csv");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(1));
            Assert.That(d["name"], Is.EqualTo("foo.alpha"));
        }

        [Test]
        public void TestGreedy()
        {
            var d = Match(@"container/{a}.{b}", @"container/foo.alpha.beta.csv");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(2));
            Assert.That(d["a"], Is.EqualTo("foo.alpha.beta"));
            Assert.That(d["b"], Is.EqualTo("csv"));
        }

        [Test]
        public void TestMethod6()
        {
            // Test corner case where matching on last
            var d = Match(@"daas-test-input/{name}.txt", @"daas-test-input/bob.txtoutput");
            Assert.That(d, Is.Null);
        }

        [Test]
        public void TestMethod5()
        {
            // Test corner case where matching on last
            var d = Match(@"container/{name}-{date}.csv", @"container/foo-Jan1st.csv");
            Assert.That(d, Is.Not.Null);
            Assert.That(d.Count, Is.EqualTo(2));
            Assert.That(d["name"], Is.EqualTo("foo"));
            Assert.That(d["date"], Is.EqualTo("Jan1st"));
        }

        [Test]
        public void GetNames()
        {
            var path = BlobPathSource.Create(@"container/{name}-{date}.csv");
            var d = path.ParameterNames;
            var names = d.ToArray();

            Assert.That(names.Length, Is.EqualTo(2));
            Assert.That(names[0], Is.EqualTo("name"));
            Assert.That(names[1], Is.EqualTo("date"));
        }
    }
}
