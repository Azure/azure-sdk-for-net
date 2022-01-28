// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class ModelsTests
    {
        private bool ReflectiveValueEqual(object left, object right, int recusrsiveLimit = 10)
        {
            if (recusrsiveLimit <= 0)
            {
                throw new ArgumentException("Hit recursive limit for equality test");
            }

            if (left == default && right == default)
            {
                return true;
            }
            else if (left == default || right == default)
            {
                return false;
            }

            if (left.GetType() != right.GetType())
            {
                return false;
            }
            if (left.GetType().IsValueType)
            {
                return left == right;
            }

            bool equal = true;
            PropertyInfo[] properties = left.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsValueType)
                {
                    var leftval = property.GetValue(left);
                    var rightval = property.GetValue(right);
                    equal &= leftval.Equals(rightval);
                }
                else
                {
                    equal &= ReflectiveValueEqual(property.GetValue(left), property.GetValue(right), recusrsiveLimit - 1);
                }

                if (!equal)
                {
                    return false;
                }
            }
            return true;
        }

        [Test]
        public void BlobDownloadOptionsDeepCopy()
        {
            // note these are all non-default values
            BlobDownloadOptions MakeOriginal()
            {
                return new BlobDownloadOptions
                {
                    Conditions = new BlobRequestConditions
                    {
                        IfModifiedSince = DateTime.Now,
                        IfUnmodifiedSince = DateTime.Now,
                        IfMatch = new ETag("foo"),
                        IfNoneMatch = new ETag("bar")
                    },
                    Range = new HttpRange(offset: 1, length: 1),
                    TransactionalHashingOptions = new DownloadTransactionalHashingOptions
                    {
                        Algorithm = TransactionalHashAlgorithm.MD5,
                        Validate = true
                    }
                };
            }

            var original = MakeOriginal();
            var deepCopy = BlobDownloadOptions.CloneOrDefault(original);

            // test deep copy successful equality
            Assert.IsTrue(ReflectiveValueEqual(original, deepCopy), "deep copy did not properly clone");

            // test deep copy no longer equal when one value changed
            deepCopy.Range = new HttpRange(offset: 1, length: 2);
            Assert.IsFalse(ReflectiveValueEqual(original, deepCopy), "change to deep copy affected original");

            // TODO perhaps come up with exhaustive test to ensure this is true for all possible changes
        }

        [Test]
        public void BlobDownloadOptionsDeepCopyDefault()
        {
            BlobDownloadOptions original = default;
            BlobDownloadOptions deepCopy = BlobDownloadOptions.CloneOrDefault(original);

            Assert.IsNull(deepCopy);
        }
    }
}
