using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Common;

namespace Model
{
    public class CongratsOnTheBirthOfYourChild:MessageBase
    {
        public Gender Gender { get; set; }
        
        [XmlIgnore]
        public DateTime BabyBirthDayDate { get; set; }

        public string BabyBirthDay { get; set; }
 
        public override void Flush()
        {
            this.Name = EncodeTo64(this.Name);
            this.BabyBirthDay = this.BabyBirthDayDate.ToString("dd MMM yyyy");

            Serialize(this);
        }

        private void Serialize(CongratsOnTheBirthOfYourChild details)
        {
            var serializer = new XmlSerializer(typeof(CongratsOnTheBirthOfYourChild));
            using (TextWriter writer = new StreamWriter(string.Format(@"./BabyBirth/{0}.txt", this.MessageId)))
            {
                serializer.Serialize(writer, details);
            }
        }

        private string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.Encoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
}
