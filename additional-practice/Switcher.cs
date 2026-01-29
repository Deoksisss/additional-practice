namespace additional_practice;

public static class Switcher
{
    public static string SwitchAccessors(string accessor)
    {
        return accessor switch
        {
            "get;" => "R",
            "set;" => "W",
            _ => throw new ArgumentException("Unknown accessor: " + accessor)
        };
    }

    public static string SwitchTypes(string type)
    {
        return type switch
        {
            "int" => "Int",
            "double" => "Real",
            "float" => "Real",
            "string" => "String",
            "bool" => "Bool",
            _ => throw new ArgumentException("Unknown type: " + type)
        };
    }
}