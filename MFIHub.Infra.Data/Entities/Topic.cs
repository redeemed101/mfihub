using CommonLibraries.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFIHub.Infra.Data.Entities
{
    public class Topic : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }

        public string TopicName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
