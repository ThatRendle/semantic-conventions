using System.Diagnostics.Metrics;
using OTel;

var meter = new Meter("Sandbox");
var counter = meter.CreateCounter<long>(Metrics.Dotnet.Gc.Collections);
static void Write(string s)
{
    Console.WriteLine(s);
}