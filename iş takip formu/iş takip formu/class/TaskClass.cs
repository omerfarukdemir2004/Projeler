using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iş_takip_formu
{
    public class TaskClass
    {
        public int id { get; set; }

        public string gorev { get; set; }

        public TaskClass(int id ,string gorev)
        {
            this.id = id;
            this.gorev = gorev;
        }
        public override string ToString()
        {
            return gorev; // ListBox'ta sadece görev adını göstermek için
        }
    }
}
