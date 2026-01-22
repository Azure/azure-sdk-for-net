// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class DownloadCertificateOptionsTests
    {
        [Test]
        public void ConstructorArgumentValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new DownloadCertificateOptions(null));
            Assert.That(ex.ParamName, Is.EqualTo("certificateName"));

            ex = Assert.Throws<ArgumentException>(() => new DownloadCertificateOptions(string.Empty));
            Assert.That(ex.ParamName, Is.EqualTo("certificateName"));
        }
    }
}
