using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Avro;
using Avro.IO;
using Avro.Specific;
using Azure.Data.SchemaRegistry;
using Azure.Data.SchemaRegistry.Avro;
using Azure.Data.SchemaRegistry.Models;
using Azure.Identity;
using TestSchema;

namespace ApacheAvroTestTool
{
    class Program
    {

        static void Main(string[] args)
        {
            //Testing();
            var employee = new Employee { Age = 42, Name = "Caketown" };
            var schemaName = "test1";
            var groupName = "miyanni_srgroup";
            var schemaType = SerializationType.Avro;
            var endpoint = "";
            var creds = new ClientSecretCredential(
                "",
                "",
                ""
            );
            var client = new SchemaRegistryClient(endpoint, creds);
            var memoryStream = new MemoryStream();

            var serializer = new AvroObjectSerializer(client, groupName, new AvroObjectSerializerOptions { AutoRegisterSchemas = true });
            serializer.Serialize(memoryStream, employee, typeof(Employee), CancellationToken.None);

            var deserializedObject = serializer.Deserialize(memoryStream, typeof(Employee), CancellationToken.None) as Employee;
            Console.WriteLine(deserializedObject?.Name);
            Console.WriteLine(deserializedObject?.Age);
        }

        private static void Testing()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var examplePath = Path.Combine(currentDirectory, "Example.avsc");
            var schema = Schema.Parse(File.ReadAllText(examplePath));
            var codeGen = new CodeGen();
            codeGen.AddSchema(schema);
            var compileUnit = codeGen.GenerateCode();
            //compileUnit.  ??????????????
            codeGen.WriteTypes(currentDirectory);

            var employeePath = Path.Combine(currentDirectory, "Employee.avro");
            var employee = new Employee { Age = 42, Name = "Caketown" };
            var writeFileStream = new FileStream(employeePath, FileMode.Create);


            ////var writerType = ;
            ////https://stackoverflow.com/a/1151470/294804
            //var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(typeof(Employee));
            ////https://stackoverflow.com/a/2451341/294804
            //dynamic writer = Activator.CreateInstance(datumWriterType, schema);


            ////https://stackoverflow.com/a/4667999/294804
            //var writerType = typeof(DataFileWriter<>).MakeGenericType(typeof(Employee));
            ////var openWriterMethod = writerType.GetMethod("OpenWriter", BindingFlags.Public | BindingFlags.Static);
            //var datumBaseType = typeof(DatumWriter<>).MakeGenericType(typeof(Employee));
            //var openWriterMethod = writerType.GetMethod("OpenWriter", new[] { datumBaseType, typeof(Stream) });
            //dynamic fileWriter = openWriterMethod?.Invoke(null, new[] { writer, writeFileStream });

            //var writer = new SpecificDatumWriter<Employee>(schema);
            //var fileWriter = DataFileWriter<Employee>.OpenWriter(writer, employeePath);




            //fileWriter?.Append(employee);
            //fileWriter?.Close();


            var employeeType = typeof(Employee);

            var isSpecific = typeof(ISpecificRecord).IsAssignableFrom(employeeType);



            //https://stackoverflow.com/a/5898469/294804
            var schemaField = employeeType.GetField("_SCHEMA", BindingFlags.Public | BindingFlags.Static);
            var reflectionSchema = schemaField?.GetValue(null) as Schema;


            //var writer = new SpecificDatumWriter<Employee>(schema);
            //https://stackoverflow.com/a/1151470/294804
            var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(employeeType);
            //https://stackoverflow.com/a/2451341/294804
            dynamic writer = Activator.CreateInstance(datumWriterType, reflectionSchema);
            var binaryEncoder = new BinaryEncoder(writeFileStream);

            writer?.Write(employee, binaryEncoder);
            binaryEncoder.Flush();




            writeFileStream.Close();




            var readFileStream = new FileStream(employeePath, FileMode.Open);


            //var reader = new SpecificDatumReader<Employee>(schema, schema);
            //var fileReader = DataFileReader<Employee>.OpenReader(readFileStream, schema, (ws, rs) => reader);

            //var fileReader = DataFileReader<Employee>.OpenReader(readFileStream);


            ////https://stackoverflow.com/a/4667999/294804
            //var readerType = typeof(DataFileReader<>).MakeGenericType(typeof(Employee));
            //var openReaderMethod = readerType.GetMethod("OpenReader", new[] { typeof(Stream) });
            //dynamic fileReader = openReaderMethod?.Invoke(null, new object[] { readFileStream });




            // Not the right solution. Reads schema on the avro data.
            //var readSchema = fileReader?.GetSchema() as Schema;





            var binaryDecoder = new BinaryDecoder(readFileStream);


            //var reader = new SpecificDatumReader<Employee>(schema, schema);
            //https://stackoverflow.com/a/1151470/294804
            var datumReaderType = typeof(SpecificDatumReader<>).MakeGenericType(employeeType);
            //https://stackoverflow.com/a/2451341/294804
            dynamic reader = Activator.CreateInstance(datumReaderType, reflectionSchema, reflectionSchema);

            var readEmployee = reader?.Read(null, binaryDecoder);


            //Employee readEmployee = null;
            //while (fileReader?.HasNext())
            //{
            //    readEmployee = fileReader.Next() as Employee;
            //    break;
            //}
            //Employee readEmployee = fileReader?.NextEntries.First();


            Console.WriteLine(readEmployee?.Name);
            Console.WriteLine(readEmployee?.Age);

            //fileReader?.Dispose();
            readFileStream.Close();


            //var classThing = new DotnetClass(typeof(Employee))
            //Schema.p
        }
    }
}
