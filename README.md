<h1>Windows Azure SDK for Windows 8 and .NET 4(2.0.0.0)</h1>
<p>This SDK allows you to build Windows Azure applications that take advantage of
Azure scalable cloud computing resources: table and blob storage, messaging through
Service Bus, distributed caching through cache.</p>
<p>For documentation please see the 
<a href="http://www.windowsazure.com/en-us/develop/net/">Windows Azure .NET Developer Center</a>.</p>

<h1>Features</h1>
<ul>
    <li>Tables
        <ul>
            <li>Create/Delete Tables</li>
            <li>Query/Create/Read/Update/Delete Entities</li>
    </li>
    <li>BLOBs
        <ul>
            <li>Create/Read/Update/Delete BLOBs</li>
    </li>
    <li>Queues
        <ul>
            <li>Create/Delete Queues</li>
            <li>Insert/Peek Queue Messages</li>
            <li>Advanced Queue Operations</li>
    </li>
</ul>
        
<h1>Getting Started</h1>
<h2>Download</h2>

<h3>Option 1: Via Git</h3>
<p>To get the source code of the SDK via git just type:<br/>
<pre>git clone git://github.com/WindowsAzure/azure-sdk-for-net.git<br/>
cd ./azure-sdk-for-net</pre>

<h3>Option 2: Via NuGet</h3>
<p>To get the binaries of this library as distributed by Microsoft, ready for use
within your project you can also have them installed by the .NET package manager NuGet.<br/>
<pre>Install-Package WindowsAzure.Storage</pre></p>

<h2>Requirements</h2>
<ul>
    <li>Account: To use this SDK to call Windows Azure services, you need to first
    create an account.</li>
    <li>Hosting: To host your .Net code in Windows Azure, you additionally need
    to download the full Windows Azure SDK for .NET - which includes packaging,
    emulation, and deployment tools.</li>
    <li>Windows 8 or .NET Framework 4.0</li>
</ul>

<h2>Dependencies</h2>
<p>
The 2.0.0.0 version depends on three libraries (collectively referred to as ODataLib), which are resolved through the ODataLib (version 5.0.2) packages available through NuGet and not the WCF Data Services installer which currently contains 5.0.0 versions.  
The ODataLib libraries can be downloaded directly or referenced by your code project through NuGet.  
The specific ODataLib packages are:<br/>
http://nuget.org/packages/Microsoft.Data.OData/5.0.2<br/>
http://nuget.org/packages/Microsoft.Data.Edm/5.0.2<br/>
http://nuget.org/packages/System.Spatial/5.0.2<br/>
</p>

<h2>Code Samples</h2>
<p>Note:</p>
<ul>
    <li>How-Tos focused around accomplishing specific tasks are available on the
    <a href="http://www.windowsazure.com/en-us/develop/net/">Windows Azure .NET
    Developer Center</a>.</li>
</ul>

<p>First, include the classes you need (in this case we'll include the Storage and Table
and further demonstrate creating a table):<br/>
<pre>using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;</pre></p>

<p>To perform an operation on any Windows Azure resource you will first instantiate
a <strong>client</strong> which allows performing actions on it. The resource is known as an
<strong>entity</strong>. To do so for Table you also have to authenticate your request:<br/>
<pre>var storageAccount = 
    CloudStorageAccount.DevelopmentStorageAccount;
var tableClient = storageAccount.CreateCloudTableClient();</pre></p>

<p>Now, to create a table entity using the client:<br/>
<pre>CloudTable peopleTable = tableClient.GetTableReference("people");
peopleTable.Create();
</pre></p>

<h1>Need Help?</h1>
<p>Be sure to check out the Windows Azure <a href="http://go.microsoft.com/fwlink/?LinkId=234489">
Developer Forums on MSDN</a> if you have trouble with the provided code.</p>

<h1>Feedback</h1>
<p>For feedback related specificically to this SDK, please use the Issues
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
