using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ContainerInstance;
using Azure.ResourceManager.Logic;
using System;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.RecoveryServicesBackup;
using Azure.ResourceManager.ContainerInstance.Models;
using System.Reflection;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.AppContainers;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.ClientModel.Primitives;
using MgmtTest;
using System.Text.Json;

//Console.WriteLine("Hello, World!");

//string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
//string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
//string tenantId = Environment.GetEnvironmentVariable("TENANT_ID");
//string subscription = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID");

//var client = new ArmClient(new ClientSecretCredential(tenantId, clientId, clientSecret), subscription);

//var sub = await client.GetDefaultSubscriptionAsync();
//var resourceGroup = (await sub.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, "deleteme1110", new ResourceGroupData(AzureLocation.EastUS))).Value;

//var resourceGroup = (await sub.GetResourceGroups().GetAsync("sdktest4546")).Value;

try
{
    //var accountData = new IntegrationAccountData(AzureLocation.EastUS)
    //{
    //    SkuName = IntegrationAccountSkuName.Standard
    //};
    //var account = (await resourceGroup.GetIntegrationAccounts().CreateOrUpdateAsync(WaitUntil.Completed, "sdktest1564", accountData)).Value;
    //Console.WriteLine(account.Data.Name);

    //var xml = "<?xml version=\"1.0\" encoding=\"UTF-16\"?>\r\n<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" xmlns:msxsl=\"urn:schemas-microsoft-com:xslt\" xmlns:var=\"http://schemas.microsoft.com/BizTalk/2003/var\" exclude-result-prefixes=\"msxsl var s0 userCSharp\" version=\"1.0\" xmlns:ns0=\"http://BizTalk_Server_Project4.StringFunctoidsDestinationSchema\" xmlns:s0=\"http://BizTalk_Server_Project4.StringFunctoidsSourceSchema\" xmlns:userCSharp=\"http://schemas.microsoft.com/BizTalk/2003/userCSharp\">\r\n  <xsl:import href=\"http://btsfunctoids.blob.core.windows.net/functoids/functoids.xslt\" />\r\n  <xsl:output omit-xml-declaration=\"yes\" method=\"xml\" version=\"1.0\" />\r\n  <xsl:template match=\"/\">\r\n    <xsl:apply-templates select=\"/s0:Root\" />\r\n  </xsl:template>\r\n  <xsl:template match=\"/s0:Root\">\r\n    <xsl:variable name=\"var:v1\" select=\"userCSharp:StringFind(string(StringFindSource/text()) , &quot;SearchString&quot;)\" />\r\n    <xsl:variable name=\"var:v2\" select=\"userCSharp:StringLeft(string(StringLeftSource/text()) , &quot;2&quot;)\" />\r\n    <xsl:variable name=\"var:v3\" select=\"userCSharp:StringRight(string(StringRightSource/text()) , &quot;2&quot;)\" />\r\n    <xsl:variable name=\"var:v4\" select=\"userCSharp:StringUpperCase(string(UppercaseSource/text()))\" />\r\n    <xsl:variable name=\"var:v5\" select=\"userCSharp:StringLowerCase(string(LowercaseSource/text()))\" />\r\n    <xsl:variable name=\"var:v6\" select=\"userCSharp:StringSize(string(SizeSource/text()))\" />\r\n    <xsl:variable name=\"var:v7\" select=\"userCSharp:StringSubstring(string(StringExtractSource/text()) , &quot;0&quot; , &quot;2&quot;)\" />\r\n    <xsl:variable name=\"var:v8\" select=\"userCSharp:StringConcat(string(StringConcatSource/text()))\" />\r\n    <xsl:variable name=\"var:v9\" select=\"userCSharp:StringTrimLeft(string(StringLeftTrimSource/text()))\" />\r\n    <xsl:variable name=\"var:v10\" select=\"userCSharp:StringTrimRight(string(StringRightTrimSource/text()))\" />\r\n    <ns0:Root>\r\n      <StringFindDestination>\r\n        <xsl:value-of select=\"$var:v1\" />\r\n      </StringFindDestination>\r\n      <StringLeftDestination>\r\n        <xsl:value-of select=\"$var:v2\" />\r\n      </StringLeftDestination>\r\n      <StringRightDestination>\r\n        <xsl:value-of select=\"$var:v3\" />\r\n      </StringRightDestination>\r\n      <UppercaseDestination>\r\n        <xsl:value-of select=\"$var:v4\" />\r\n      </UppercaseDestination>\r\n      <LowercaseDestination>\r\n        <xsl:value-of select=\"$var:v5\" />\r\n      </LowercaseDestination>\r\n      <SizeDestination>\r\n        <xsl:value-of select=\"$var:v6\" />\r\n      </SizeDestination>\r\n      <StringExtractDestination>\r\n        <xsl:value-of select=\"$var:v7\" />\r\n      </StringExtractDestination>\r\n      <StringConcatDestination>\r\n        <xsl:value-of select=\"$var:v8\" />\r\n      </StringConcatDestination>\r\n      <StringLeftTrimDestination>\r\n        <xsl:value-of select=\"$var:v9\" />\r\n      </StringLeftTrimDestination>\r\n      <StringRightTrimDestination>\r\n        <xsl:value-of select=\"$var:v10\" />\r\n      </StringRightTrimDestination>\r\n    </ns0:Root>\r\n  </xsl:template>\r\n</xsl:stylesheet>";
    var xml = "\u0022\u003C?xml version=\u00221.0\u0022 encoding=\u0022UTF-16\u0022?\u003E\u0022";
    //var mapData = new IntegrationAccountMapData(new AzureLocation("westus"), IntegrationAccountMapType.Xslt)
    //{
    //    Content = BinaryData.FromString(xml),
    //    ContentType = new ContentType("application/xml"),
    //    Metadata = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    //    {
    //    }),
    //};
    //var map = (await account.GetIntegrationAccountMaps().CreateOrUpdateAsync(WaitUntil.Completed, "sdktest1364", mapData)).Value;
    //Console.WriteLine(map.Data.Name);
    //var testfile = File.ReadAllText("stringtest.txt");
    //var data = JsonSerializer.Deserialize<Dictionary<string, object>>(testfile);
    //var foo = new Foo()
    //{
    //    Content = BinaryData.FromString(xml)
    //};
    //var data = ModelReaderWriter.Write(foo);
    //var test = JsonSerializer.Serialize(data);
    //Console.WriteLine(test);
    //var content = @"""abc\""def""";
    //using var doc = JsonDocument.Parse(content);
    //using var stream = new MemoryStream();
    //using (var writer = new Utf8JsonWriter(stream))
    //{
    //    doc.WriteTo(writer);
    //}
    //stream.Position = 0;
    //var test = Encoding.UTF8.GetString(stream.ToArray());
    //JsonDocument.Parse(test);
    //Console.WriteLine(Encoding.UTF8.GetString(stream.ToArray()));
}
catch (Exception e)
{
    Console.WriteLine("Failed");
    Console.WriteLine(e.Message);
}
finally
{
    //await resourceGroup.DeleteAsync(WaitUntil.Completed);
    Console.WriteLine("Done");
}
