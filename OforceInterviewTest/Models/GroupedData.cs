using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OforceInterviewTest.Models
{
    public class GroupedData
    {
        public Guid Id { get; set; }
        public decimal GrossCommissions { get; set; }
        public decimal GrossDeductions { get; set; }
        public decimal NetTotal { get; set; }
    }
}
