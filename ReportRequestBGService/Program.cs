using ReportAPI.BusinessLayer;
using ReportAPI.Infrastructure;
using ReportRequestBGService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IReportService, ReportService>();
        services.AddSingleton<IContactService, ContactService>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    })
    .Build();

await host.RunAsync();
