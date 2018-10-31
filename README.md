# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started

1. Rebuild to make sure everything installs correctly.
2. Build your client! 😎


###Help!

```cs
// Create a new ProxyFactory
var proxyFactory = new ServiceBusManagerProxy(BusDriverResolver.ResolveByServiceBusConnectionString());

// Create a proxy for IAnswerManager
var manager = proxyFactory.For<IAnswerManager>();
await manager.Answer(gameId, userId, answer);
```

*Good luck!*

# Tips

1. Leave the .config files as is. 😉
2. Connecting to the Copper service may take a while. Don't panic. 🤦‍♂️
