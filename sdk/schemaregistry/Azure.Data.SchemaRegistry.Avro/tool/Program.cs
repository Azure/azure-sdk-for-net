using System.IO;
using Avro;

namespace ApacheAvroTestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var examplePath = Path.Combine(currentDirectory, "Example.avro");
            var schema = Schema.Parse(File.ReadAllText(examplePath));
            var codeGen = new CodeGen();
            codeGen.AddSchema(schema);
            var compileUnit = codeGen.GenerateCode();
            //compileUnit.  ??????????????
            codeGen.WriteTypes(currentDirectory);

            //Schema.GetTypeString(typeof(Employee));
        }
    }
}
