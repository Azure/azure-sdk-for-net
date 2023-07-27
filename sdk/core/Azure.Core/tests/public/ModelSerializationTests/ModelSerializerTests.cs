// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class ModelSerializerTests
    {
        [Test]
        public void ValidateDefaultFormatValue()
        {
            ModelSerializerOptions options = default;
            Assert.AreEqual(default(ModelSerializerOptions), options);
            Assert.IsTrue(options.Equals(default(ModelSerializerOptions)));

            Assert.AreEqual(default(ModelSerializerFormat), options.Format);
            Assert.AreEqual(null, options.Format.ToString());
            Assert.Throws<ArgumentNullException>(() => options.Format.Equals(null));
            Assert.Throws<NullReferenceException>(() => options.Format.ToString().Equals(null));
        }
    }
}
