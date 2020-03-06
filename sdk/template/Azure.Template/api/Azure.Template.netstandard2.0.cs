namespace Azure.Template
{
    public partial class TemplateClient
    {
        protected TemplateClient() { }
        public TemplateClient(System.Uri endpoint) { }
        public TemplateClient(System.Uri endpoint, Azure.Template.TemplateClientOptions options) { }
        public Azure.Response<Azure.Template.Models.Model> Operation(Azure.Template.Models.Model body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Response<Azure.Template.Models.Model>> OperationAsync(Azure.Template.Models.Model body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Template.Models.DaysOfWeek Friday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Monday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Saturday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Sunday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Thursday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Tuesday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.DaysOfWeek Wednesday { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
    public readonly partial struct Fruit : System.IEquatable<Azure.Template.Models.Fruit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Fruit(string value) { throw null; }
        public static Azure.Template.Models.Fruit Apple { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Template.Models.Fruit Pear { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool Equals(Azure.Template.Models.Fruit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Template.Models.Fruit left, Azure.Template.Models.Fruit right) { throw null; }
        public static implicit operator Azure.Template.Models.Fruit (string value) { throw null; }
        public static bool operator !=(Azure.Template.Models.Fruit left, Azure.Template.Models.Fruit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Model
    {
        public Model() { }
        public Azure.Template.Models.DaysOfWeek DaysOfWeek { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Template.Models.Fruit Fruit { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ModelProperty { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
}
