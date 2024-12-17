using System.CodeDom.Compiler;

namespace CodeGen;

internal static class IndentedTextWriterExtensions
{
    public static void OpenBrace(this IndentedTextWriter writer)
    {
        writer.WriteLine("{");
        writer.Indent++;
    }

    public static void CloseBrace(this IndentedTextWriter writer)
    {
        writer.Indent--;
        writer.WriteLine("}");
    }

    public static void CloseBrace(this IndentedTextWriter writer, char terminator)
    {
        writer.Indent--;
        writer.WriteLine($"}}{terminator}");
    }
}