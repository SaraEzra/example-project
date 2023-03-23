using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Core.Models
{
    public class BaseModel
    {
        public virtual int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
