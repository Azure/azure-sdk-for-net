﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ReferenceTypeTests
    {
        private static readonly Type ReferenceAttribute = typeof(ReferenceTypeAttribute);
        private static readonly Type SerializationConstructor = typeof(SerializationConstructorAttribute);
        private static readonly Type InitializationConstructor = typeof(InitializationConstructorAttribute);
        private static readonly IEnumerable<Type> AssemblyTypes = typeof(ArmClient).Assembly.GetTypes();

        [Test]
        public void ValidateSerializationConstructor()
        {
            foreach (var refType in AssemblyTypes.Where(t => HasAttribute(t.GetCustomAttributes<Attribute>(false), ReferenceAttribute)))
            {
                var serializationCtor = refType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(c => HasAttribute(c.GetCustomAttributes<Attribute>(false), SerializationConstructor)).FirstOrDefault();
                Assert.IsNotNull(serializationCtor);
                Assert.IsTrue(serializationCtor.IsFamilyOrAssembly, $"Serialization ctor for {refType.Name} should be protected internal");
                Assert.IsFalse(serializationCtor.IsPublic, $"Serialization ctor for {refType.Name} should not be public");
            }
        }

        [Test]
        public void ValidateInitializationConstructor()
        {
            foreach (var refType in AssemblyTypes.Where(t => HasAttribute(t.GetCustomAttributes<Attribute>(false), ReferenceAttribute)))
            {
                var initializationCtor = refType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(c => HasAttribute(c.GetCustomAttributes<Attribute>(false), InitializationConstructor)).FirstOrDefault();
                Assert.IsNotNull(initializationCtor);
                Assert.IsTrue(refType.IsAbstract == initializationCtor.IsFamily, $"If {refType.Name} is abstract then its initialization ctor should be protected");
                Assert.IsTrue(refType.IsAbstract != initializationCtor.IsPublic, $"If {refType.Name} is abstract then its initialization ctor should be public");
                Assert.IsFalse(initializationCtor.IsAssembly, $"Initialization ctor for {refType.Name} should not be internal");
            }
        }

        public bool HasAttribute(IEnumerable<Attribute> list, Type attributeType)
        {
            return list.FirstOrDefault(a => a.GetType() == attributeType) is not null;
        }
    }
}
