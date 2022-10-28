using System.Data;

namespace ConsoDb_DAL.Services;

public static class CommandService
{
    public static void AddParametersWithValues(this IDbCommand cmd, string name, object value)
    {
        var par = cmd.CreateParameter();
        par.ParameterName = name;
        par.Value = value;
        cmd.Parameters.Add(par);
    }
}