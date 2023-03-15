using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFIHub.Shared.Models
{
    public class Topic
    {
        public int RecordId { get; set; }

        public string TopicName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
