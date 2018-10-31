using System;
using System.Configuration;
using Microsoft.ApplicationInsights.Extensibility;

namespace Trivia.Client
{
    internal class Program
    {
        private static void Main()
        {
            // Set correct settings for Application Insights
            TelemetryConfiguration.Active.InstrumentationKey =
                ConfigurationManager.AppSettings["ApplicationInsightsInstrumentationKey"];


            Console.WriteLine(
                "████████╗██████╗ ██╗██╗   ██╗██╗ █████╗ \r\n╚══██╔══╝██╔══██╗██║██║   ██║██║██╔══██╗\r\n   ██║   ██████╔╝██║██║   ██║██║███████║\r\n   ██║   ██╔══██╗██║╚██╗ ██╔╝██║██╔══██║\r\n   ██║   ██║  ██║██║ ╚████╔╝ ██║██║  ██║\r\n   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚═╝╚═╝  ╚═╝\r\n                                        " +
                "\r\n\r\n");

            Console.ReadLine();

            // Write your logic here :)
        }
    }
}