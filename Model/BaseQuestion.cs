using System.Runtime.Serialization;

namespace coreApi_QusAns.Model
{
    public class BaseQuestion
    {
        [DataMember(Order =1)]
        public string category { get; set; }
        [DataMember (Order =2)]
        public string Title { get; set; }
        [DataMember (Order =3)]
        public string description { get; set; }
    }
}
