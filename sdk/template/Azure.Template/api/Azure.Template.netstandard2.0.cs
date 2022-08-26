namespace Azure.Template.Models
{
    public static partial class CollectionPropertiesBasicModelFactory
    {
        public static Azure.Template.Models.OutputModel OutputModel(System.Collections.Generic.IEnumerable<string> requiredStringList = null, System.Collections.Generic.IEnumerable<int> requiredIntList = null) { throw null; }
    }
    public partial class InputModel
    {
        public InputModel(System.Collections.Generic.IEnumerable<string> requiredStringList, System.Collections.Generic.IEnumerable<int> requiredIntList) { }
        public System.Collections.Generic.IList<int> RequiredIntList { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredStringList { get { throw null; } }
    }
    public partial class OutputModel
    {
        internal OutputModel() { }
        public System.Collections.Generic.IReadOnlyList<int> RequiredIntList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredStringList { get { throw null; } }
    }
    public partial class RoundTripModel
    {
        public RoundTripModel(System.Collections.Generic.IEnumerable<string> requiredStringList, System.Collections.Generic.IEnumerable<int> requiredIntList) { }
        public System.Collections.Generic.IList<int> RequiredIntList { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredStringList { get { throw null; } }
    }
}
