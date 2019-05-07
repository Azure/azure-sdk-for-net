# Overview 

Azure.Core is a reusable library used to implement .NET Azure SDK components. 
It contains APIs that make it easy to call Azure service endpoints in a convinient, performant, and consistent manner.

# Installing

Nuget package Azure.Core avaliable on https://www.nuget.org/packages/Azure.Core/

# Hello World

```c#
public async Task HelloWorld()
{
    // create http pipeline
    var options = new HttpPipeline.Options();
    HttpPipeline pipeline = HttpPipeline.Create(options, sdkName: "test", sdkVersion: "1.0");

    // create http message
    using (HttpMessage message = pipeline.CreateMessage(options, cancellation: default)) {

        // set message URI
        var uri = new Uri(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/README.md");
        message.SetRequestLine(HttpVerb.Get, uri);

        // add headers
        message.AddHeader("Host", uri.Host);

        // send message
        await pipeline.SendMessageAsync(message).ConfigureAwait(false);

        // process response
        Response response = message.Response;
        if (response.Status == 200) {
            var reader = new StreamReader(response.ContentStream);
            string responseText = reader.ReadToEnd();
        }
        else throw new RequestFailedException(response);
    }       
}
```

# Other Samples

Comming soon ...
