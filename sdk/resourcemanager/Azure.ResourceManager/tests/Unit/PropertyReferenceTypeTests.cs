using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PropertyReferenceTypeTests
    {
        private static readonly Type PropertyReferenceTypeAttribute = typeof(PropertyReferenceTypeAttribute);
        private static readonly Type SerializationConstructor = typeof(SerializationConstructorAttribute);
        private static readonly Type InitializationConstructor = typeof(InitializationConstructorAttribute);
        private static readonly IEnumerable<Type> AssemblyTypes = typeof(ArmClient).Assembly.GetTypes();

        [Test]
        public void ValidatePropertyReferenceTypeAttribute()
        {
            var type = typeof(PropertyReferenceTypeAttribute);
            var fieldInfo = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(p => p.Name == "OptionalProperties");
            Assert.NotNull(fieldInfo, $"Field 'OptionalProperties' is not found");
            Assert.AreEqual(fieldInfo.PropertyType, typeof(string[]));
            Assert.True(fieldInfo.CanRead);
            Assert.False(fieldInfo.CanWrite);
        }

        [Test]
        public void ValidateSerializationConstructor()
        {
            foreach (var refType in AssemblyTypes.Where(t => HasAttribute(t.GetCustomAttributes<Attribute>(false), PropertyReferenceTypeAttribute)))
            {
                var serializationCtor = refType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(c => HasAttribute(c.GetCustomAttributes<Attribute>(false), SerializationConstructor)).FirstOrDefault();
                Assert.IsNotNull(serializationCtor);
                Assert.IsFalse(serializationCtor.IsPublic, $"Serialization ctor for {refType.Name} should not be public");
            }
        }

        [Test]
        public void ValidateInitializationConstructor()
        {
            foreach (var refType in AssemblyTypes.Where(t => HasAttribute(t.GetCustomAttributes<Attribute>(false), PropertyReferenceTypeAttribute)))
            {
                var initializationCtor = refType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(c => HasAttribute(c.GetCustomAttributes<Attribute>(false), InitializationConstructor)).FirstOrDefault();
                Assert.IsNotNull(initializationCtor, $"Initialization ctro was null for {refType.Name}");
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
