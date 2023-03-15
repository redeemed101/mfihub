using CommonLibraries.Application.Services;
using MFIHub.Application.DTOs;
using MFIHub.Infra.Data.Context;
using MFIHub.Infra.Data.Entities;
using MFIHub.Server.Hubs;
using MFIHub.Server.Services;
using Microsoft.AspNetCore.SignalR;

namespace MFIHub.Server.Background
{
    public class TopicChecker : BackgroundService
    {
        private readonly IHubContext<TopicHub> _reportHub;
        private readonly IServiceProvider _serviceProvider;


        public TopicChecker(IHubContext<TopicHub> reportHub, IServiceProvider serviceProvider)
        {
            _reportHub = reportHub;
            _serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var topicDataService = scope.ServiceProvider.GetRequiredService<ITopicService>();


                var reportData = await topicDataService.GetTopicsAsync();
                var methodName = "TransferTopicData";


                await _reportHub.Clients.All.SendAsync(
                    methodName,
                    reportData,
                    stoppingToken);


                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}
