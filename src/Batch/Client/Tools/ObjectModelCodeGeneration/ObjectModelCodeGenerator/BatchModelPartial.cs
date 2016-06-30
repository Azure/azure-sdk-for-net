namespace ObjectModelCodeGenerator
{
    using CodeGenerationLibrary;

    public partial class ModelClassTemplate
    {
        public ModelClassTemplate(ObjectModelTypeData type, string classContent)
        {
            this._classContentField = classContent;
            this._typeField = type;
        }
    }
}
