// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    // Exercises the internal CertificateProperties.TagsIfSet accessor added in
    // Phase 2 to back CertificateMapper.WriteUpdateBody. The invariant being
    // pinned: an untouched .Tags bag must surface as null on the wire so the
    // PATCH body never emits an empty "tags" object (which the server would
    // interpret as "wipe existing tags").
    public class CertificatePropertiesTagsIfSetTests
    {
        [Test]
        public void NewProperties_TagsIfSet_IsNull()
        {
            var props = new CertificateProperties("name");
            Assert.IsNull(props.TagsIfSet,
                "TagsIfSet must be null until the public Tags property is read or assigned.");
        }

        [Test]
        public void AccessingTags_AllocatesLazyBag_TagsIfSet_IsNonNullEmpty()
        {
            var props = new CertificateProperties("name");

            // Touching the public Tags getter triggers LazyInitializer.EnsureInitialized.
            IDictionary<string, string> bag = props.Tags;
            Assert.IsNotNull(bag);

            IDictionary<string, string> peek = props.TagsIfSet;
            Assert.IsNotNull(peek, "After reading .Tags, TagsIfSet must surface the backing dictionary.");
            Assert.AreEqual(0, peek.Count);
            Assert.AreSame(bag, peek);
        }

        [Test]
        public void PopulatedTags_TagsIfSet_ReturnsSameBag()
        {
            var props = new CertificateProperties("name");
            props.Tags["env"] = "prod";
            props.Tags["owner"] = "rohit";

            IDictionary<string, string> peek = props.TagsIfSet;
            Assert.IsNotNull(peek);
            Assert.AreEqual(2, peek.Count);
            Assert.AreEqual("prod", peek["env"]);
            Assert.AreEqual("rohit", peek["owner"]);
        }

        [Test]
        public void ClearedTags_TagsIfSet_IsEmptyNotNull()
        {
            // Customer reads .Tags (e.g. to remove all entries) but does not
            // null out the bag. TagsIfSet must reflect the still-allocated
            // but empty dictionary so the PATCH-body writer can apply the
            // "Count > 0" guard correctly.
            var props = new CertificateProperties("name");
            props.Tags["env"] = "prod";
            props.Tags.Clear();

            IDictionary<string, string> peek = props.TagsIfSet;
            Assert.IsNotNull(peek, "Cleared (but allocated) Tags must still surface from TagsIfSet.");
            Assert.AreEqual(0, peek.Count);
        }
    }
}
