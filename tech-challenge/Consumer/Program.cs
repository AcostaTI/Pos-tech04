using Consumer;
using Consumer.Events;
using Core.Domain.Entities;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var fila = configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;
        var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
        

        services.AddHostedService<Worker>();

        services.AddMassTransit((x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(conexao);

                //cfg.ReceiveEndpoint(fila, c =>
                //{
                //    c.Consumer<AddDebitoConsumer>();
                //});

                cfg.SubscriptionEndpoint("sub-1", configuration.GetSection("MassTransitAzure")["Topic"] ?? string.Empty, c =>
                {
                    c.Consumer<AddDebitoConsumer>();
                });

            });
        }));
    })
    .Build();

host.Run();
