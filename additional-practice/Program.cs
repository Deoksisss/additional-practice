using additional_practice;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

var inputFile = Input.GetInputFile();
var outputFile = Path.ChangeExtension(inputFile, ".csv");
using var writer =  new StreamWriter(outputFile);

SyntaxTree tree = CSharpSyntaxTree.ParseText(File.ReadAllText(inputFile));
CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
var rootClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
var properties = rootClass.Members.OfType<PropertyDeclarationSyntax>();
foreach (var prop in properties)
{
    var propName = prop.Identifier.Text;
    
    
    var propType = prop.Type.ToString();
    var type = Switcher.SwitchTypes(propType);
    
    
    var accessorList = prop.DescendantNodes().OfType<AccessorDeclarationSyntax>().ToList();
    string accessors = "";
    if (accessorList.Count == 1 || accessorList.Count == 2)
    {
        foreach (var accessor in accessorList)
        {
            accessors += Switcher.SwitchAccessors(accessor.ToString());
        }
    }
    else
    {
        throw new ArgumentException("many accessors");
    }
    
    writer.WriteLine($"{propName};{type};{accessors}");
}