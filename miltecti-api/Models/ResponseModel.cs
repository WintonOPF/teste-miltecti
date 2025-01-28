namespace miltecti_api.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ResponseModel<T>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; } 
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? Errors { get; set; }

        public ResponseModel(T Data)
        {
           this.Data = Data;
           
        }
        public ResponseModel(Dictionary<string, string> Errors)
        {
            this.Errors = Errors;
            
        }
        public ResponseModel(T? Data, Dictionary<string,string>? Errors)
        {
            this.Errors = Errors;
            this.Data = Data;
        }

    }

}
