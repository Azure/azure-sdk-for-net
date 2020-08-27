using System;
using System.IO;
using Avro;
using Avro.File;
using Avro.Generic;
using Avro.Specific;
using TestSchema;

namespace ApacheAvroTestTool
{
    class Program
    {

        static void Main(string[] args)
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


            //var writerType = ;
            //https://stackoverflow.com/a/1151470/294804
            var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(typeof(Employee));
            //https://stackoverflow.com/a/2451341/294804
            dynamic writer = Activator.CreateInstance(datumWriterType, schema);


            //https://stackoverflow.com/a/4667999/294804
            var writerType = typeof(DataFileWriter<>).MakeGenericType(typeof(Employee));
            //var openWriterMethod = writerType.GetMethod("OpenWriter", BindingFlags.Public | BindingFlags.Static);
            var datumBaseType = typeof(DatumWriter<>).MakeGenericType(typeof(Employee));
            var openWriterMethod = writerType.GetMethod("OpenWriter", new[] { datumBaseType, typeof(Stream) });
            dynamic fileWriter = openWriterMethod?.Invoke(null, new[] { writer, writeFileStream });

            //var writer = new SpecificDatumWriter<Employee>(schema);
            //var fileWriter = DataFileWriter<Employee>.OpenWriter(writer, employeePath);







            fileWriter?.Append(employee);
            fileWriter?.Close();


            writeFileStream.Close();




            var readFileStream = new FileStream(employeePath, FileMode.Open);


            //var reader = new SpecificDatumReader<Employee>(schema, schema);
            //var fileReader = DataFileReader<Employee>.OpenReader(readFileStream, schema, (ws, rs) => reader);

            //var fileReader = DataFileReader<Employee>.OpenReader(readFileStream);


            //https://stackoverflow.com/a/4667999/294804
            var readerType = typeof(DataFileReader<>).MakeGenericType(typeof(Employee));
            var openReaderMethod = readerType.GetMethod("OpenReader", new[] { typeof(Stream) });
            dynamic fileReader = openReaderMethod?.Invoke(null, new object[] { readFileStream });




            // Not the right solution. Reads schema on the avro data.
            var readSchema = fileReader?.GetSchema() as Schema;








            Employee readEmployee = null;
            while (fileReader?.HasNext())
            {
                readEmployee = fileReader.Next() as Employee;
                break;
            }
            //Employee readEmployee = fileReader?.NextEntries.First();


            Console.WriteLine(readEmployee?.Name);
            Console.WriteLine(readEmployee?.Age);

            fileReader?.Dispose();
            readFileStream.Close();


            //var classThing = new DotnetClass(typeof(Employee))
            //Schema.p
        }
    }
}
