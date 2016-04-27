namespace CodeGenerationLibrary
{
    using System.IO;
    using Newtonsoft.Json;

    public class FileReader
    {
        private readonly string fileName;
        public FileReader(string fileName) { this.fileName = fileName; }

        public Model ReadTypes()
        {
            var input = File.ReadAllText(this.fileName);
            Model m = JsonConvert.DeserializeObject<Model>(input);

            return m;
        }

        public void WriteTypes(Model model)
        {
            string output = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(this.fileName, output);
        }
    }
}
