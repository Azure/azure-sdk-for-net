<h1>Windows Azure Storage Client Library for Windows 8 and .NET 4 (2.0.6.1)</h1>

<p>This library allows you to build Windows Azure applications that take advantage of
Azure Storage resources: table, queue, and blob storage; messaging through
Service Bus; distributed caching through cache.</p>

<p>For documentation please see the 
<a href="http://www.windowsazure.com/en-us/develop/net/">Windows Azure .NET Developer Center</a>.</p>

<h1>Features</h1>
<ul>
    <li>Tables
        <ul>
            <li>Create/Delete Tables</li>
            <li>Query/Create/Read/Update/Delete Entities</li>
		</ul>
    </li>
    <li>Blobs
        <ul>
            <li>Create/Read/Update/Delete Blobs</li>
		</ul>
    </li>
    <li>Queues
        <ul>
            <li>Create/Delete Queues</li>
            <li>Insert/Peek Queue Messages</li>
            <li>Advanced Queue Operations</li>
		</ul>
    </li>
    <li>Media - Available in separate <a href="http://github.com/WindowsAzure/azure-sdk-for-media-services/tree/master/src/net/Client">Media Services repository</a>
    </li>
</ul>
        
<h1>Getting Started</h1>

<h2>Download</h2>

<h3>GitHub</h3>

<p>To download the SDK source code from git, use the following commands:<br/>

<pre>git clone git://github.com/WindowsAzure/azure-sdk-for-net.git

cd ./azure-sdk-for-net</pre>

<h3>NuGet</h3>

<p>To download the SDK binaries from Microsoft for use in your Visual Studio project, use the <a href="http://www.nuget.org/packages/WindowsAzure.Storage/">NuGet Package Manager</a>:<br/>
<pre>Install-Package WindowsAzure.Storage</pre></p>

<h3>Windows Azure SDK</h3>

<p>The Windows Azure Storage Client Library is also available in the Windows Azure SDK from <a href="http://www.windowsazure.com/en-us/downloads/?sdk=net">http://www.windowsazure.com/en-us/downloads/?sdk=net</a>.</p>

<h2>Requirements</h2>
<ul>
    <li>Azure Storage Account. If you don't have one already, please
    <a href="https://account.windowsazure.com/Home/Index">create an account</a>.</li>
	<li>Microsoft .NET 4.0 or 4.5 Framework</li>
    <li>Windows 8 for Windows 8 and Windows RT app development</li>
</ul>

<h2>Dependencies</h2>

<p>This version depends on three libraries (collectively referred to as ODataLib), which are resolved through the ODataLib (version 5.2.0) packages available through NuGet and not the WCF Data Services installer which currently contains 5.0.0 versions.  
The ODataLib libraries can be downloaded directly or referenced by your code project through NuGet.  
The specific ODataLib packages are:</p>

<ul>
<li><a href="http://nuget.org/packages/Microsoft.Data.OData/5.2.0">http://nuget.org/packages/Microsoft.Data.OData/5.2.0</a<</li>
<li><a href="http://nuget.org/packages/Microsoft.Data.Edm/5.2.0">http://nuget.org/packages/Microsoft.Data.Edm/5.2.0</a></li>
<li><a href="http://nuget.org/packages/System.Spatial/5.2.0">http://nuget.org/packages/System.Spatial/5.2.0</a></li>
</ul>

<p>FiddlerCore is required by:</p>
<ul>
<li>Test\Unit\FaultInjection\HttpMangler</li>
<li>Test\Unit\FaultInjection\XStoreMangler</li>
<li>Test\Unit\DotNet40</li>
</ul>

<p>This dependency is not included and must be downloaded from <a href="http://www.fiddler2.com/Fiddler/Core/">http://www.fiddler2.com/Fiddler/Core/</a>.</p>

<p>Once installed:</p>

<ul>
<li>Copy <em>FiddlerCore.dll</em> to \azure-sdk-for-net\microsoft-azure-api\Services\Storage\Test\Unit\FaultInjection\Dependencies\DotNet2</li>
<li>Copy <em>FiddlerCore4.dll</em> to azure-sdk-for-net\microsoft-azure-api\Services\Storage\Test\Unit\FaultInjection\Dependencies\DotNet4</li>
</ul>

<h2>Code Samples</h2>
<p>Note: How-Tos focused around accomplishing specific tasks are available on the <a href="http://www.windowsazure.com/en-us/develop/net/">Windows Azure .NET Developer Center</a>.</p>

<h3>Creating A Table</h3>
<p>First, include the classes you need. In this case we'll include the Storage and Table namespaces:<br/>
<pre>using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;</pre></p>

<p>To perform an operation on any Windows Azure resource you will first instantiate
a <strong>client</strong> which allows performing actions on it. The resource is known as an
<strong>entity</strong>. To do so for Table you also have to authenticate your request:<br/>
<pre>var storageAccount = CloudStorageAccount.Parse(
     CloudConfigurationManager.GetSetting("StorageConnectionString"));
var tableClient = storageAccount.CreateCloudTableClient();</pre></p>

<p>Now, to create a table entity using the client:<br/>
<pre>CloudTable peopleTable = tableClient.GetTableReference("people");
peopleTable.Create();
</pre></p> 

<h1>Need Help?</h1>
<p>Be sure to check out the Windows Azure <a href="http://go.microsoft.com/fwlink/?LinkId=234489">
Developer Forums on MSDN</a> if you have trouble with the provided code.</p>

<h1>Feedback</h1>
<p>For feedback related specificically to this client library, please use the Issues
section of the repository.</p>
<p>For general suggestions about Windows Azure please use our
<a href="http://www.mygreatwindowsazureidea.com/forums/34192-windows-azure-feature-voting">UserVoice forum</a>.</p>

<h1>Learn More</h1>
<ul>
    <li><a href="http://www.windowsazure.com/en-us/develop/net/">Windows Azure .NET
    Developer Center</a></li>
    <li><a href="http://msdn.microsoft.com/en-us/library/dd179380.aspx">
    Windows Azure SDK Reference for .NET (MSDN)</a></li>
</ul>
