// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class UtilitiesInternalUnitTests
    {
        private ITestOutputHelper testOutputHelper;

        public UtilitiesInternalUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        #region To/From ProtocolCollection tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestToProtocolCollectionWithNull()
        {
            IEnumerable<MetadataItem> collection = null;
            IEnumerable<Protocol.Models.MetadataItem> result = UtilitiesInternal.ConvertToProtocolCollection(collection);
            Assert.Null(result);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestToProtocolCollectionOneItem()
        {
            const string metadataKey = "Test";
            const string metadataValue = "Result";

            IEnumerable<MetadataItem> collection = new List<MetadataItem>()
                {
                    new MetadataItem(metadataKey, metadataValue)
                };

            
            IEnumerable<Protocol.Models.MetadataItem> result = UtilitiesInternal.ConvertToProtocolCollection(collection);
            
            Assert.NotNull(result);
            Assert.Single(result);

            Protocol.Models.MetadataItem protoItem = result.First();

            Assert.Equal(metadataKey, protoItem.Name);
            Assert.Equal(metadataValue, protoItem.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCollectionToThreadSafeCollectionWithNull()
        {
            IEnumerable<Protocol.Models.MetadataItem> collection = null;
            IEnumerable<MetadataItem> result = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                collection,
                objectCreationFunc: o => new MetadataItem(o));

            Assert.Null(result);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCollectionToThreadSafeCollectionOneItem()
        {
            const string metadataKey = "Test";
            const string metadataValue = "Result";

            IEnumerable<Protocol.Models.MetadataItem> collection = new List<Protocol.Models.MetadataItem>()
                {
                    new Protocol.Models.MetadataItem(metadataKey, metadataValue)
                };


            IEnumerable<MetadataItem> result = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                collection,
                objectCreationFunc: o => new MetadataItem(o));

            Assert.NotNull(result);
            Assert.Single(result);

            MetadataItem protoItem = result.First();

            Assert.Equal(metadataKey, protoItem.Name);
            Assert.Equal(metadataValue, protoItem.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCollectionToThreadSafeCollectionReadOnly()
        {
            const string metadataKey = "Test";
            const string metadataValue = "Result";

            IEnumerable<Protocol.Models.MetadataItem> collection = new List<Protocol.Models.MetadataItem>()
                {
                    new Protocol.Models.MetadataItem(metadataKey, metadataValue)
                };


            IEnumerable<MetadataItem> result = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                collection,
                objectCreationFunc: o => new MetadataItem(o)).AsReadOnly();

            Assert.NotNull(result);
            Assert.Single(result);

            MetadataItem protoItem = result.First();

            Assert.Equal(metadataKey, protoItem.Name);
            Assert.Equal(metadataValue, protoItem.Value);

            Assert.IsAssignableFrom<IReadOnlyList<MetadataItem>>(result); //The list should be read only
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCollectionToNonThreadSafeCollectionWithNull()
        {
            IEnumerable<Protocol.Models.MetadataItem> collection = null;
            IEnumerable<MetadataItem> result = UtilitiesInternal.CollectionToNonThreadSafeCollection(
                collection,
                objectCreationFunc: o => new MetadataItem(o));

            Assert.Null(result);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCollectionToNonThreadSafeCollectionOneItem()
        {
            const string metadataKey = "Test";
            const string metadataValue = "Result";

            IEnumerable<Protocol.Models.MetadataItem> collection = new List<Protocol.Models.MetadataItem>()
                {
                    new Protocol.Models.MetadataItem(metadataKey, metadataValue)
                };


            IEnumerable<MetadataItem> result = UtilitiesInternal.CollectionToNonThreadSafeCollection(
                collection,
                objectCreationFunc: o => new MetadataItem(o));

            Assert.NotNull(result);
            Assert.Single(result);

            MetadataItem protoItem = result.First();

            Assert.Equal(metadataKey, protoItem.Name);
            Assert.Equal(metadataValue, protoItem.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCollectionToThreadSafeCollectionNullItem()
        {
            IEnumerable<Protocol.Models.MetadataItem> collection = new List<Protocol.Models.MetadataItem>()
                {
                    null
                };

            IEnumerable<MetadataItem> result = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                collection,
                objectCreationFunc: o => new MetadataItem(o));

            Assert.NotNull(result);
            Assert.Single(result);

            MetadataItem protoItem = result.First();
            Assert.Null(protoItem);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void IModifiableCollectionFromExistingCollectionIsNotChanged()
        {
            IEnumerable<Protocol.Models.MetadataItem> collection = new List<Protocol.Models.MetadataItem>()
                {
                    new Protocol.Models.MetadataItem("a", "b")
                };

            ConcurrentChangeTrackedModifiableList<MetadataItem> result = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                collection,
                objectCreationFunc: o => new MetadataItem(o));

            Assert.False(result.HasBeenModified);
        }


        #endregion

        #region CertificateVisibilityTests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestParseNullCertificateVisibilityList_ResultIsNull()
        {
            CertificateVisibility? visibilityEnum = UtilitiesInternal.ParseCertificateVisibility(null);
            Assert.Null(visibilityEnum);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestParseEmptyCertificateVisibilityList_ResultIsNone()
        {
            List<Protocol.Models.CertificateVisibility> visibilityList = new List<Protocol.Models.CertificateVisibility>();
            CertificateVisibility? visibilityEnum = UtilitiesInternal.ParseCertificateVisibility(visibilityList);
            Assert.Equal(CertificateVisibility.None, visibilityEnum);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestParseSingleEntryCertificateVisibilityList()
        {
            List<Protocol.Models.CertificateVisibility> visibilityList = new List<Protocol.Models.CertificateVisibility>()
                {
                    Protocol.Models.CertificateVisibility.StartTask
                };
            CertificateVisibility? visibilityEnum = UtilitiesInternal.ParseCertificateVisibility(visibilityList);
            Assert.Equal(CertificateVisibility.StartTask, visibilityEnum);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestParseMultiWordCertificateVisibility()
        {
            List<Protocol.Models.CertificateVisibility> visibilityList = new List<Protocol.Models.CertificateVisibility>()
                {
                    Protocol.Models.CertificateVisibility.StartTask,
                    Protocol.Models.CertificateVisibility.RemoteUser,
                    Protocol.Models.CertificateVisibility.Task,
                };
            CertificateVisibility? visibilityEnum = UtilitiesInternal.ParseCertificateVisibility(visibilityList);

            Assert.NotNull(visibilityEnum);
            Assert.True(visibilityEnum.Value.HasFlag(CertificateVisibility.StartTask));
            Assert.True(visibilityEnum.Value.HasFlag(CertificateVisibility.RemoteUser));
            Assert.True(visibilityEnum.Value.HasFlag(CertificateVisibility.Task));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestNoneCertificateVisibilityToList_ItIsIgnored()
        {
            const CertificateVisibility visibility = CertificateVisibility.None;
            var visibilityList = UtilitiesInternal.CertificateVisibilityToList(visibility);
            Assert.Empty(visibilityList);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestStartTaskTaskCertificateVisibilityToList()
        {
            const CertificateVisibility visibility = CertificateVisibility.StartTask | CertificateVisibility.Task;
            var visibilityList = UtilitiesInternal.CertificateVisibilityToList(visibility);
            Assert.Equal(2, visibilityList.Count());
            Assert.Contains(Protocol.Models.CertificateVisibility.StartTask, visibilityList);
            Assert.Contains(Protocol.Models.CertificateVisibility.Task, visibilityList);
        }

        #endregion

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestStreamToStringAsciiEncoding()
        {
            using MemoryStream s = new MemoryStream();
            using StreamWriter streamWriter = new StreamWriter(s, Encoding.ASCII);
            const string expectedText = "I am Foo!";
            streamWriter.Write(expectedText);
            streamWriter.Flush();

            s.Seek(0, SeekOrigin.Begin);

            string text = UtilitiesInternal.StreamToString(s, Encoding.ASCII);
            Assert.Equal(expectedText, text);
        }

        [Theory, 
        InlineData(false), 
        InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestStreamToStringUtf8NoByteOrderMarking(bool includeByteOrderMarking)
        {
            using MemoryStream s = new MemoryStream();
            using StreamWriter streamWriter = new StreamWriter(s, new UTF8Encoding(includeByteOrderMarking));
            const string expectedText = "㌎ 丧 가";
            streamWriter.Write(expectedText);
            streamWriter.Flush();

            s.Seek(0, SeekOrigin.Begin);

            string text = UtilitiesInternal.StreamToString(s, Encoding.UTF8);
            Assert.Equal(expectedText, text);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestStreamToStringDoesntReadWholeStream()
        {
            using MemoryStream s = new MemoryStream();
            using StreamWriter streamWriter = new StreamWriter(s, new UTF8Encoding(false));
            const string inputText = "This is a test";
            streamWriter.Write(inputText);
            streamWriter.Flush();

            const int bytesToSkip = 4;

            s.Seek(bytesToSkip, SeekOrigin.Begin);

            string text = UtilitiesInternal.StreamToString(s, Encoding.UTF8);
            Assert.Equal(" is a test", text);
        }

    }
}
