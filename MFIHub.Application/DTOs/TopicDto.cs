using CommonLibraries.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFIHub.Application.DTOs
{
    public class TopicDto  : DTO
    {
        public int RecordId { get; set; }

        public string TopicName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
