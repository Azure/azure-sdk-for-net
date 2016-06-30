namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    
    public class ObjectFactoryConstructionSpecification
    {
        public Type Type { get; private set; }

        public Func<object> Constructor { get; private set; }

        public ObjectFactoryConstructionSpecification(Type type, Func<object> constructor)
        {
            this.Type = type;
            this.Constructor = constructor;
        }
    }
}
