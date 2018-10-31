Introduction
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project.

Getting Started
Install the Trivia.Manager.Answer.Interface NuGet package from the Copper.Demo pacakge feed.
Use an instance of ServiceBusManagerProxy to create a proxy for IAnswerManager which comes from the previously installed NuGet package.
Use your superb coding skills to create a client application to submit answers! 😃
ServiceBusManagerProxy Example

var proxy = new ServiceBusManagerProxy(BusDriverResolver.ResolveByServiceBusConnectionString());
var answerManager = proxy.For<IAnswerManager>();
Good luck!

Tips
RTFM
Leave the App.config as is. 😃
Connecting to the Copper service may take a while. Don't panic.