namespace Azure.Template
{
    public partial class TemplateClient
    {
        protected TemplateClient() { }
        public TemplateClient(System.Uri endpoint) { }
        public TemplateClient(System.Uri endpoint, Azure.Template.TemplateClientOptions options) { }
        public virtual Azure.Response<Azure.Template.Models.ServiceModel> Operation(Azure.Template.Models.ServiceModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.ServiceModel>> OperationAsync(Azure.Template.Models.ServiceModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateClientOptions : Azure.Core.ClientOptions
    {
        public TemplateClientOptions(Azure.Template.TemplateClientOptions.ServiceVersion version = Azure.Template.TemplateClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
namespace Azure.Template.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaysOfWeek : System.IEquatable<Azure.Template.Models.DaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaysOfWeek(string value) { throw null; }
        public static Azure.Template.Models.DaysOfWeek Friday { get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Monday { get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Saturday { get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Sunday { get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Thursday { get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Tuesday { get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.Template.Models.DaysOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Template.Models.DaysOfWeek left, Azure.Template.Models.DaysOfWeek right) { throw null; }
        public static implicit operator Azure.Template.Models.DaysOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.Template.Models.DaysOfWeek left, Azure.Template.Models.DaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FruitType : System.IEquatable<Azure.Template.Models.FruitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FruitType(string value) { throw null; }
        public static Azure.Template.Models.FruitType Apple { get { throw null; } }
        public static Azure.Template.Models.FruitType Pear { get { throw null; } }
        public bool Equals(Azure.Template.Models.FruitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Template.Models.FruitType left, Azure.Template.Models.FruitType right) { throw null; }
        public static implicit operator Azure.Template.Models.FruitType (string value) { throw null; }
        public static bool operator !=(Azure.Template.Models.FruitType left, Azure.Template.Models.FruitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceModel
    {
        public ServiceModel(Azure.Template.Models.FruitType fruit, Azure.Template.Models.DaysOfWeek daysOfWeek) { }
        public Azure.Template.Models.DaysOfWeek DaysOfWeek { get { throw null; } }
        public Azure.Template.Models.FruitType Fruit { get { throw null; } }
        public string ModelProperty { get { throw null; } set { } }
    }
}
