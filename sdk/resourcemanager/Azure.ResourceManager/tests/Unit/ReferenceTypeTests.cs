using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
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
                Assert.IsTrue(refType.IsAbstract ? serializationCtor.IsFamily : serializationCtor.IsFamilyOrAssembly, $"Serialization ctor for {refType.Name} should be {GetExpectedSerializationCtorModifiers(refType.IsAbstract)}");
                Assert.IsFalse(serializationCtor.IsPublic, $"Serialization ctor for {refType.Name} should not be public");
            }
        }

        private string GetExpectedSerializationCtorModifiers(bool isAbstract)
        {
            return isAbstract ? "protected" : "protected internal";
        }

        [Test]
        public void ValidateInitializationConstructor()
        {
            foreach (var refType in AssemblyTypes.Where(t => HasAttribute(t.GetCustomAttributes<Attribute>(false), ReferenceAttribute)))
            {
                var initializationCtor = refType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(c => HasAttribute(c.GetCustomAttributes<Attribute>(false), InitializationConstructor)).FirstOrDefault();
                Assert.IsNotNull(initializationCtor);
                Assert.IsTrue((refType.IsAbstract || AllNonSetterProperties(refType)) == initializationCtor.IsFamily, $"If {refType.Name} is abstract then its initialization ctor should be protected");
                Assert.IsTrue((refType.IsAbstract || AllNonSetterProperties(refType)) != initializationCtor.IsPublic, $"If {refType.Name} is abstract then its initialization ctor should not be public");
                Assert.IsFalse(initializationCtor.IsAssembly, $"Initialization ctor for {refType.Name} should not be internal");
            }
        }

        public bool HasAttribute(IEnumerable<Attribute> list, Type attributeType)
        {
            return list.FirstOrDefault(a => a.GetType() == attributeType) is not null;
        }

        public bool AllNonSetterProperties(Type referenceType)
        {
            List<PropertyInfo> properties = referenceType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
