using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
    public class BirthdayWish:MessageBase
    {
        public DateTime BirthDate { get; set; }

        public string Gift { get; set; }

        public override void Flush()
        {
            this.StandardMessageText = this.StandardMessageText.ToUpper();

            string json = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(string.Format(@"./Birthdays/{0}.txt",this.MessageId), json);
        }
    }
}
