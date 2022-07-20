namespace Azure.Template.Models
{
    public partial class InputModel
    {
        public InputModel(string requiredString, int requiredInt) { }
        public int RequiredInt { get { throw null; } }
        public string RequiredString { get { throw null; } }
    }
}
