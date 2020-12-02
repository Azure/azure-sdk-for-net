#! "net5"
// Determines if assembly is Debug or Release Configuration.

var AssemblyPath = Args[0];
var ReflectedAssembly = System.Reflection.Assembly.LoadFile(AssemblyPath);
object[] Attributes = ReflectedAssembly.GetCustomAttributes(typeof(DebuggableAttribute), false);

if (Attributes.Length > 0) {
    DebuggableAttribute debuggableAttribute = Attributes[0] as DebuggableAttribute;
    if (debuggableAttribute.IsJITOptimizerDisabled)
    {
        return 1;
    }
}
return 0;
