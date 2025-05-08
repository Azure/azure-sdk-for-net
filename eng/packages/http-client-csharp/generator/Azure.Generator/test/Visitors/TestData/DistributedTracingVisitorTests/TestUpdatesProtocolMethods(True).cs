using global::Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("TestClient.Foo");
scope.Start();
try
{
    global::System.Console.WriteLine("Hello World");
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
