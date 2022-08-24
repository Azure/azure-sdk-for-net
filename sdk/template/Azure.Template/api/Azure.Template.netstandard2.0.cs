namespace Azure.Template.Models
{
    public abstract partial class BaseClass
    {
        internal BaseClass() { }
        public string BaseClassProperty { get { throw null; } set { } }
    }
    public abstract partial class BaseClassWithDiscriminator : Azure.Template.Models.BaseClass
    {
        internal BaseClassWithDiscriminator() { }
    }
    public partial class DerivedFromBaseClassA : Azure.Template.Models.BaseClass
    {
        public DerivedFromBaseClassA(string baseClassProperty, string derivedClassAProperty) { }
        public string DerivedClassAProperty { get { throw null; } set { } }
    }
    public partial class DerivedFromBaseClassB : Azure.Template.Models.BaseClass
    {
        public DerivedFromBaseClassB(string baseClassProperty, string derivedClassBProperty) { }
        public string DerivedClassBProperty { get { throw null; } set { } }
    }
    public partial class DerivedFromBaseClassWithDiscriminatorA : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithDiscriminatorA(string baseClassProperty) { }
    }
    public partial class DerivedFromBaseClassWithDiscriminatorB : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithDiscriminatorB(string baseClassProperty) { }
    }
    public partial class DerivedFromBaseClassWithUnknownDiscriminator : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithUnknownDiscriminator(string baseClassProperty) { }
    }
    public partial class ModelWithPolymorphicProperty
    {
        public ModelWithPolymorphicProperty(Azure.Template.Models.BaseClassWithDiscriminator polymorphicProperty) { }
        public Azure.Template.Models.BaseClassWithDiscriminator PolymorphicProperty { get { throw null; } set { } }
    }
}
