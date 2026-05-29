// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class CollectionResultNameVisitorTests
    {
        [Test]
        public void RenamesLongCollectionResultType()
        {
            const string name = "MicrosoftCertificateRegistrationAppServiceCertificateOrdersRetrieveCertificateEmailHistoryAsyncCollectionResultOfT";
            var type = new TestTypeProvider(name);

            VisitType(type);

            Assert.That(type.Name, Is.Not.EqualTo(name));
            Assert.That(type.Name.Length, Is.LessThanOrEqualTo(CollectionResultNameVisitor.MaxCollectionResultNameLength));
            Assert.That(type.Name, Does.EndWith("AsyncCollectionResultOfT"));
        }

        [Test]
        public void KeepsShortCollectionResultType()
        {
            const string name = "FoosGetAllAsyncCollectionResultOfT";
            var type = new TestTypeProvider(name);

            VisitType(type);

            Assert.That(type.Name, Is.EqualTo(name));
        }

        [Test]
        public void KeepsLongNonCollectionResultType()
        {
            const string name = "MicrosoftCertificateRegistrationAppServiceCertificateOrdersRetrieveCertificateEmailHistoryModel";
            var type = new TestTypeProvider(name);

            VisitType(type);

            Assert.That(type.Name, Is.EqualTo(name));
        }

        private static void VisitType(TypeProvider type)
        {
            ManagementMockHelpers.LoadMockPlugin();

            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            visitTypeCore!.Invoke(new CollectionResultNameVisitor(), [type]);
        }

        private class TestTypeProvider(string name) : TypeProvider
        {
            protected override string BuildName() => name;

            protected override string BuildRelativeFilePath() => $"{Name}.cs";
        }
    }
}
