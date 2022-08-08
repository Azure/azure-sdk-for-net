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
    public partial class DerivedFromBaseClassWithDiscriminatorA : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithDiscriminatorA(string baseClassProperty) : base (default(string)) { }
    }
    public partial class DerivedFromBaseClassWithDiscriminatorB : Azure.Template.Models.BaseClassWithDiscriminator
    {
        public DerivedFromBaseClassWithDiscriminatorB(string baseClassProperty) : base (default(string)) { }
    }
}
