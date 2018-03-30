using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Synergy.Scrambler.Model.Configuration
{
    public class MappingConfigConverter:JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IMappingConfig));
        } 
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
          
            JObject obj = JObject.Load(reader);


            //   existingValue = serializer.Deserialize<Scramble>(reader);
            if ( (string)obj["Criteria"] == "Data Replacement")
            {
                var SC = new ReplaceDS();
                if (obj["Criteria"] != null)
                    SC.Criteria = (String)obj["Criteria"];
                if (obj["Name"] != null)
                    SC.Name = (String)obj["Name"];
                if (obj["NumberOfRows"] != null)
                    SC.NumberOfRows = (Int32)obj["NumberOfRows"];
              

                if (obj["ReplaceWith"] != null)
                    SC.ReplaceWith = (String)obj["ReplaceWith"];

                return SC;

            }
            if ((string)obj["Criteria"] == "Data Scramble")
            {
                var SC = new Scramble();
                if (obj["Criteria"] != null)
                    SC.Criteria = (String)obj["Criteria"];
                if (obj["Name"] != null)
                    SC.Name = (String)obj["Name"];
                if (obj["NumofRows"] != null)
                    SC.NumofRows = (Int32)obj["NumofRows"];
                if (obj["Rows"] != null)
                    SC.Rows = (Int32)obj["Rows"];

                return SC;

            }

            if ((string)obj["Criteria"] == "Data Mask")
            {
                var SC = new DataMask();
                if (obj["Criteria"] != null)
                    SC.Criteria = (String)obj["Criteria"];
                if (obj["Name"] != null)
                    SC.Name = (String)obj["Name"];
                if (obj["NumberOfRows"] != null)
                    SC.NumberOfRows = (Int32)obj["NumberOfRows"];
                if (obj["Rows"] != null)
                    SC.Rows = (Int32)obj["Rows"];

                if (obj["MaskingLength"] != null)
                    SC.MaskingLength = (Int32)obj["MaskingLength"];
                if (obj["ML"] != null)
                    SC.ML = (Int32)obj["ML"];
                if (obj["MaskChar"] != null)
                    SC.MaskChar = (String)obj["MaskChar"];

                return SC;

            }
            if ((string)obj["Criteria"] == "ParagraphMask")
            {
                var SC = new ParagraphMask();
                if (obj["Criteria"] != null)
                    SC.Criteria = (String)obj["Criteria"];
                if (obj["Name"] != null)
                    SC.Name = (String)obj["Name"];
                if (obj["NumberOfRows"] != null)
                    SC.NumberOfRows = (Int32)obj["NumberOfRows"];
                if (obj["Rows"] != null)
                    SC.Rows = (Int32)obj["Rows"];
                return SC;

            }
            if ((string)obj["Criteria"] == "Data Hash")
            {
                var SC = new Hashing();
                if (obj["Criteria"] != null)
                    SC.Criteria = (String)obj["Criteria"];
                if (obj["Name"] != null)
                    SC.Name = (String)obj["Name"];
                if (obj["NumberOfRows"] != null)
                    SC.NumberOfRows = (Int32)obj["NumberOfRows"];
                if (obj["Rows"] != null)
                    SC.Rows = (Int32)obj["Rows"];
                if (obj["HashCriteria"] != null)
                    SC.HashCriteria = (String)obj["HashCriteria"];


                return SC;

            }

            return obj;

            throw new NotSupportedException(string.Format("Type {0} unexpected.", objectType));
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Left as an exercise to the reader :)
            throw new NotImplementedException();
        }
    }
}