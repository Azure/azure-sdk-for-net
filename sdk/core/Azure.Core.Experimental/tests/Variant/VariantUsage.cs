// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class VariantUsage
    {
        [Test]
        public void CanUseVariantAsString()
        {
            Variant variant = "hi";

            Assert.That((string)variant, Is.EqualTo("hi"));

            Assert.That("hi", Is.EqualTo((string)variant));
            Assert.That((string)variant, Is.EqualTo("hi"));

            Assert.That($"{(string)variant}", Is.EqualTo("hi"));
        }

        [Test]
        public void CanTestForNull()
        {
            Variant variant = Variant.Null;
            Assert.That(variant.IsNull, Is.True);

            Assert.That(new Variant((object)null).IsNull, Is.True);
        }

        [TestCaseSource(nameof(VariantValues))]
        public void CanGetAsString(Variant v, Variant s)
        {
            string value = (string)s;
            Assert.That(v.ToString(), Is.EqualTo(value));
        }

        [Test]
        public void VariantDoesntStoreVariant()
        {
            Variant a = new("hi");
            Variant b = new(a);

            Assert.That(b, Is.EqualTo(a));
            Assert.That(b.Type, Is.EqualTo(typeof(string)));
        }

        [Test]
        public void VariantAssignmentHasReferenceSemantics()
        {
            // Variant should use reference semantics with reference types
            // so that it behaves like object in these cases.
            //
            // e.g. since:
            //   List<string> list = new List<string> { "1" };
            //   object oa = list;
            //   object ob = oa;
            //   list[0] = "2";
            //
            //   Assert.AreEqual("2", list[0]);
            //   Assert.AreEqual("2", ((List<string>)oa)[0]);
            //   Assert.AreEqual("2", ((List<string>)ob)[0]);
            //
            // Variant should do the same.
            // The following test validates this functionality.

            List<string> list = new List<string> { "1" };
            Variant a = new(list);

            Assert.That(list[0], Is.EqualTo("1"));
            Assert.That(a.As<List<string>>()[0], Is.EqualTo("1"));

            list[0] = "2";

            Assert.That(list[0], Is.EqualTo("2"));
            Assert.That(a.As<List<string>>()[0], Is.EqualTo("2"));

            Variant b = new(a);

            Assert.That(b, Is.EqualTo(a));
            Assert.That(b.As<List<string>>()[0], Is.EqualTo("2"));

            list[0] = "3";

            Assert.That(list[0], Is.EqualTo("3"));
            Assert.That(a.As<List<string>>()[0], Is.EqualTo("3"));
            Assert.That(b.As<List<string>>()[0], Is.EqualTo("3"));
        }

        [Test]
        public void ReferenceTypesCanBeNull()
        {
            string s = null;
            Variant stringVariant = new(s);

            Assert.That(stringVariant, Is.EqualTo(Variant.Null));
            Assert.That(stringVariant.As<string>(), Is.Null);

            List<int> list = null;
            Variant listVariant = new(list);

            Assert.That(listVariant, Is.EqualTo(Variant.Null));
            Assert.That(listVariant.As<string>(), Is.Null);
        }

        [Test]
        public void NonNullableValueTypesCannotBeNull()
        {
            int? i = null;
            Variant intVariant = new(i);

            Assert.That(intVariant, Is.EqualTo(Variant.Null));
            Assert.Throws<InvalidCastException>(() => intVariant.As<int>());
        }

        [Test]
        public void NullableValueTypesCanBeNull()
        {
            int? i = null;
            Variant intVariant = new(i);

            Assert.That(intVariant, Is.EqualTo(Variant.Null));
            Assert.That(intVariant.As<int?>(), Is.Null);
        }

        #region Helpers
        public static IEnumerable<Variant[]> VariantValues()
        {
            yield return new Variant[] { (byte)42, "42" };
            yield return new Variant[] { (sbyte)42, "42" };
            yield return new Variant[] { (short)42, "42" };
            yield return new Variant[] { (ushort)42, "42" };
            yield return new Variant[] { 42U, "42" };
            yield return new Variant[] { 42UL, "42" };
            yield return new Variant[] { 42, "42" };
            yield return new Variant[] { 42L, "42" };
            yield return new Variant[] { 1.0, "1" };
            yield return new Variant[] { 1.1D, "1.1" };
            yield return new Variant[] { 1.1F, "1.1" };
            yield return new Variant[] { Variant.Null, "null" };
            yield return new Variant[] { 'a', "a" };
            yield return new Variant[] { true, "true" };
            yield return new Variant[] { false, "false" };
            DateTimeOffset dateTime = new(2002, 8, 9, 10, 11, 12, TimeSpan.Zero);
            yield return new Variant[] { dateTime.DateTime, dateTime.DateTime.ToString() };
            yield return new Variant[] { dateTime, dateTime.ToString() };
            ArraySegment<byte> bytes = new("variant"u8.ToArray());
            yield return new Variant[] { bytes, bytes.ToString() };
            ArraySegment<char> chars = new("variant".AsSpan().ToArray());
            yield return new Variant[] { chars, chars.ToString() };
            yield return new Variant[] { new(Color.Blue), Color.Blue.ToString() };
        }

        #endregion
    }
}
