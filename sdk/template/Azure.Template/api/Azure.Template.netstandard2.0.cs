namespace Azure.Template.Models
{
    public partial class BaseClass
    {
        public BaseClass(string baseClassProperty) { }
        public string BaseClassProperty { get { throw null; } set { } }
    }
    public partial class BaseClassWithDiscriminator : Azure.Template.Models.BaseClass
    {
        public BaseClassWithDiscriminator(string baseClassProperty) : base (default(string)) { }
    }
    public partial class DerivedFromBaseClassA : Azure.Template.Models.BaseClass
    {
        public DerivedFromBaseClassA(string baseClassProperty, string derivedClassAProperty) : base (default(string)) { }
        public string DerivedClassAProperty { get { throw null; } set { } }
    }
    public partial class DerivedFromBaseClassB : Azure.Template.Models.BaseClass
    {
        public DerivedFromBaseClassB(string baseClassProperty, string derivedClassBProperty) : base (default(string)) { }
        public string DerivedClassBProperty { get { throw null; } set { } }
    }
    public partial class DerivedFromBaseClassWithDiscriminatorA : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithDiscriminatorA(string baseClassProperty) : base (default(string)) { }
    }
    public partial class DerivedFromBaseClassWithDiscriminatorB : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithDiscriminatorB(string baseClassProperty) : base (default(string)) { }
    }
    public partial class ModelWithPolymorphicProperty
    {
        public ModelWithPolymorphicProperty(Azure.Template.Models.BaseClassWithDiscriminator polymorphicProperty) { }
        public Azure.Template.Models.BaseClassWithDiscriminator PolymorphicProperty { get { throw null; } set { } }
    }
}
