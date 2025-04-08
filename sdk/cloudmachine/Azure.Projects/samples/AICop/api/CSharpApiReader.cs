using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

internal class CSharpApiReader {

    public static void Main(string filename)
    {
        using var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var peReader = new PEReader(fileStream);
        MetadataReader mr = peReader.GetMetadataReader();
    }

    public static string[] ReadNamespaces(MetadataReader reader)
    {
        HashSet<string> namespaces = new();
        foreach (TypeDefinitionHandle typeHandle in reader.TypeDefinitions)
        {
            TypeDefinition type = reader.GetTypeDefinition(typeHandle);
            if (type.Attributes.HasFlag(TypeAttributes.Public))
            {
                string nspace = reader.GetString(type.Namespace);
                namespaces.Add(nspace);
            }
        }
        return namespaces.ToArray();
    }

    public static string[] ReadStatistics(MetadataReader reader)
    {
        List<string> namespaces = new List<string>();
        int typeCount = 0;
        int methodCount = 0;
        int propertyGetterCount = 0;
        int propertySetterCount = 0;
        foreach (TypeDefinitionHandle typeHandle in reader.TypeDefinitions)
        {
            TypeDefinition type = reader.GetTypeDefinition(typeHandle);
            if (type.Attributes.HasFlag(TypeAttributes.Public))
            {
                typeCount++;

                foreach (MethodDefinitionHandle methodHandle in type.GetMethods())
                {
                    MethodDefinition method = reader.GetMethodDefinition(methodHandle);
                    if (method.Attributes.HasFlag(MethodAttributes.Public))
                    {
                        methodCount++;
                    }
                }

                foreach (PropertyDefinitionHandle propertyHandle in type.GetProperties())
                {
                    PropertyDefinition property = reader.GetPropertyDefinition(propertyHandle);
                    PropertyAccessors acessors = property.GetAccessors();
                    MethodDefinitionHandle getterHandle = acessors.Getter;

                    if (!getterHandle.IsNil)
                    {
                        MethodDefinition getter = reader.GetMethodDefinition(getterHandle);
                        if (getter.Attributes.HasFlag(MethodAttributes.Public))
                        {
                            propertyGetterCount++;
                        }
                    }

                    MethodDefinitionHandle setterHandle = acessors.Setter;
                    if (!setterHandle.IsNil)
                    {
                        MethodDefinition setter = reader.GetMethodDefinition(setterHandle);
                        if (setter.Attributes.HasFlag(MethodAttributes.Public))
                        {
                            propertySetterCount++;
                        }
                    }
                }
            }
        }
        return namespaces.ToArray();
    }
}
