using Copper.Messaging;
using Copper.Proxy;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Copper.Common;
using Copper.Common.Context;
using Copper.Diagnostics;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging;
using Trivia.Manager.Answer.Interface;

namespace Trivia.Client
{
    class Program
    {
        private static void Main()
        {
            Run().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        private static async Task Run()
        {
            // Set correct settings for Application Insights
            TelemetryConfiguration.Active.InstrumentationKey =
                ConfigurationManager.AppSettings["ApplicationInsightsInstrumentationKey"];

            // Add CorrelationIdTelemetryInitializer to log all under same correlationId
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new CorrelationIdTelemetryInitializer());

            // Create Proxy
            var logger = new ClientLoggerFactory().CreateDiagnosticsLogger<Program>();
            var managerProxy = new ServiceBusManagerProxy(BusDriverResolver.ResolveByServiceBusConnectionString());
            var manager = managerProxy.For<IAnswerManager>();

            Console.WriteLine("████████╗██████╗ ██╗██╗   ██╗██╗ █████╗ \r\n╚══██╔══╝██╔══██╗██║██║   ██║██║██╔══██╗\r\n   ██║   ██████╔╝██║██║   ██║██║███████║\r\n   ██║   ██╔══██╗██║╚██╗ ██╔╝██║██╔══██║\r\n   ██║   ██║  ██║██║ ╚████╔╝ ██║██║  ██║\r\n   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚═╝╚═╝  ╚═╝\r\n                                        " + "\r\n\r\n");

            Console.Write("GameId: ");
            var gameId = Console.ReadLine();

            Console.Write("UserId: ");
            var userId = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("----------");
            Console.WriteLine("----------");

            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                try
                {
                    using (new OperationContext())
                    {
                        // Explicitly set a CorrelationId for demo purposes, normally this is set automatically.
                        var explicitCorrelationId = Guid.NewGuid().ToString();
                        Console.WriteLine($"Explicitly set correlationId value: {explicitCorrelationId}");
                        GenericContext<CorrelationId>.Current = new GenericContext<CorrelationId>(new CorrelationId(explicitCorrelationId));

                        Console.WriteLine();
                        Console.WriteLine("Write answer");
                        Console.Write("> ");
                        var answer = Console.ReadLine();

                        logger.LogInformation("Hi, from within the client, right before the actual Answer call.");

                        await manager.Answer(gameId, userId, answer);

                        Console.WriteLine("\r\nFinished...");
                    }
                }
                catch
                {
                }

                Console.WriteLine("----------");
                Console.WriteLine();
            }
        }
    }
}
