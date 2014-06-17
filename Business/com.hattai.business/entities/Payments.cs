using com.hattai.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.business.entities
{
    [DataContract]
    public class Payments : Entity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Currency {get;set;}
        [DataMember]
        public string Amount {get;set;}
        [DataMember]
        public string CardHolderCvc { get; set; }
        [DataMember]
        public string ExpMonth {get;set;}
        [DataMember]
        public string ExpYear {get;set;}
        [DataMember]
        public string CardHolderName {get;set;}
        [DataMember]
        public string CardHolderNumber {get;set;}
        [DataMember]
        public string ShopperEmail {get;set;}
        [DataMember]
        public string Reference {get;set;}
        [DataMember]
        public string Ip {get;set;}
        [DataMember]
        public string SignatureImage {get;set;}
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public int Client { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string AuthCode { get; set; }
        [DataMember]
        public string PspReference { get; set; }
        [DataMember]
        public string TimeStamp { get; set; }
    }
}
