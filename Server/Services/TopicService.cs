using CommonLibraries.Application.Services;
using MFIHub.Application.DTOs;
using MFIHub.Infra.Data.Context;
using MFIHub.Infra.Data.Entities;
using MFIHub.Server.Mapping;

namespace MFIHub.Server.Services
{
    public class TopicService : ITopicService
    {
        private readonly IService<Topic, TopicDto, MFIHubContext> _topicService;

        public TopicService(IService<Topic, TopicDto, MFIHubContext> topicService)
        {
            _topicService = topicService;
        }
        public async Task<ICollection<Shared.Models.Topic>> GetTopicsAsync()
        {
            var topics = await _topicService.GetAsync();
            return MappingInstance.MainMapper.Map<ICollection<Shared.Models.Topic>>(topics);
        }
    }
}
