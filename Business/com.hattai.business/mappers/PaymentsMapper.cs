using com.hattai.business.entities;
using com.hattai.mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.business.mappers
{
    public class PaymentsMapper : IEntityMapper<Payments>
    {
        public Payments Map(System.Data.IDataRecord parent)
        {
            return new Payments()
            {
                ID = int.Parse(parent["ID"].ToString()),
                CardHolderCvc = parent["CardHolderCvc"].ToString(),
                CardHolderName = parent["CardHolderName"].ToString(),
                ExpMonth = parent["ExpMonth"].ToString(),
                ExpYear = parent["ExpYear"].ToString(),
                CardHolderNumber = parent["CardHolderNumber"].ToString(),
                Currency = parent["Currency"].ToString(),
                Ip = parent["Ip"].ToString(),
                Client = int.Parse(parent["Client"].ToString()),
                Reference = parent["Reference"].ToString(),
                ShopperEmail = parent["ShopperEmail"].ToString(),
                SignatureImage = parent["SignatureImage"].ToString(),
                Uuid = parent["Uuid"].ToString(),
                Amount = parent["Amount"].ToString(),
                AuthCode = parent["AuthCode"].ToString(),
                PspReference = parent["PspReference"].ToString(),
                Result = parent["Result"].ToString(),
                Longitude = parent["Longitude"].ToString(),
                Latitude = parent["Latitude"].ToString(),
                TimeStamp = parent["TimeStamp"].ToString()
            };
        }
    }
}
