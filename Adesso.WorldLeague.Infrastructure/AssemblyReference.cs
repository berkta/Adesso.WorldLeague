using System.Reflection;

namespace Adesso.WorldLeague.Infrastructure;

public static class AssemblyReference
{ 
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}