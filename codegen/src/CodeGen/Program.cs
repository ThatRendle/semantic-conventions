// See https://aka.ms/new-console-template for more information

using CodeGen;
using CodeGen.Models;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

Console.WriteLine("Hello, World!");

var path = Path.GetFullPath(args[0]);

var loader = new Loader();

foreach (var file in Directory.EnumerateFiles(path, "*.yaml"))
{
    var yamlStream = new YamlStream();
    using var reader = new StreamReader(file);
    yamlStream.Load(reader);
    loader.Load(yamlStream.Documents[0]);
}

Console.WriteLine(loader.Objects.Count);

var generator = new MetricsGenerator(loader.Objects, Path.GetFullPath(args[1]));

generator.Generate();
