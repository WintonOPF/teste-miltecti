namespace miltecti_api.Models
{
    using System.Collections.Generic;

    public class ResponseModel<T>
    {
        public T? Data { get; set; } // Dados da resposta (pode ser nulo em caso de erro)
        public string Status { get; set; } // Status da resposta (ex: "success", "error")
        public Dictionary<string, List<string>>? Errors { get; set; } // Erros por campo (nulo se não houver erros)

        public ResponseModel(T Data, string Status)
        {
           this.Data = Data;
           this.Status = Status;
        }

        public ResponseModel(Dictionary<string, List<string>> Errors, string Status)
        {
            this.Errors = Errors;
            this.Status = Status;
        }

    }

}
