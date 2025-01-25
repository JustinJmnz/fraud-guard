var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("fraud-guard-sql-server")
    .WithLifetime(ContainerLifetime.Session);

var db = sqlServer.AddDatabase("fraud-guard");

var apiService = builder.AddProject<Projects.FraudGuard_ApiService>("apiservice");
apiService
    .WithReference(db)
    .WaitFor(db);       


builder.AddProject<Projects.FraudGuard_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
