using global::Azure.Core.HttpMessage message = this.CreateFooRequest(context);
return Pipeline.ProcessMessage(message, context);
