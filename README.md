# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started

1. Install the `Trivia.Manager.Answer.Interface` NuGet package from the Copper.Demo pacakge feed.
2. Use an instance of `ServiceBusManagerProxy` to create a proxy for `IAnswerManager` which comes from the previously installed NuGet package.
3. Use your superb coding skills to create a client application to submit answers! :)


ServiceBusManagerProxy Example

```cs
var proxy = new ServiceBusManagerProxy(BusDriverResolver.ResolveByServiceBusConnectionString());
var answerManager = proxy.For<IAnswerManager>();
```



*Good luck!*

# Tips

1. RTFM
2. Leave the App.config as is. :)
3. Connecting to the Copper service may take a while. Don't panic.
