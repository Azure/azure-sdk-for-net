using System;
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
                Assert.IsTrue(serializationCtor.IsFamilyOrAssembly);
                Assert.IsFalse(serializationCtor.IsPublic);
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
                Assert.IsTrue(initializationCtor.IsFamily || initializationCtor.IsPublic);
                Assert.IsFalse(initializationCtor.IsAssembly);
            }
        }

        public bool HasAttribute(IEnumerable<Attribute> list, Type attributeType)
        {
            return list.FirstOrDefault(a => a.GetType() == attributeType) is not null;
        }
    }
}
