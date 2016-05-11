namespace ObjectModelCodeGenerator
{
    using System.IO;
    using System.Linq;
    using CodeGenerationLibrary;

    public class Program
    {
        public static void Main(string[] args)
        {
            GenerateModelFiles();
        }

        private static void GenerateModelFiles()
        {
            var inputFile = @"BatchProperties.json";
            var model = new FileReader(inputFile).ReadTypes();

            foreach (var type in model.Types)
            {
                string templateDirectory = CreateResultDirectoryIfNotExist("Generated");
                string outputFilePath = Path.Combine(templateDirectory, type.Name + ".cs");

                string innerClassString;
                if (!type.IsStaticallyReadOnly || type.IsTopLevelObject)
                {
                    ModifiableClassTemplate modifiableClass = new ModifiableClassTemplate(type);
                    innerClassString = modifiableClass.TransformText();
                }
                else
                {
                    //If any property is complex throw an exception because it will look read only and yet
                    //will not be.
                    if (type.Properties.Select(kvp => kvp.Key).Any(prop => CodeGenerationUtilities.IsTypeComplex(prop.Type)))
                    {
                        //TODO: Can't enforce this right now because of some get-only types which we autogenerate
                        //throw new InvalidOperationException(string.Format("Statically readonly type {0} cannot have complex properties",
                        //    type.Name));
                    }
                    StaticReadOnlyClassTemplate staticReadOnlyClass = new StaticReadOnlyClassTemplate(type);
                    innerClassString = staticReadOnlyClass.TransformText();
                }
                ModelClassTemplate batchModel = new ModelClassTemplate(type, innerClassString);


                File.WriteAllText(outputFilePath, batchModel.TransformText());
            }
        }

        private static string CreateResultDirectoryIfNotExist(string directoryName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string generatedCodeDirectory = Path.Combine(currentDirectory, directoryName);
            Directory.CreateDirectory(generatedCodeDirectory);

            return generatedCodeDirectory;
        }
    }
}
