namespace API.Helpers;

public static class Utilities
{
    public static string GetConnectionStringFromEnv()
    {
        var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
        var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
        var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
        var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
        var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

        return $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    }
}
