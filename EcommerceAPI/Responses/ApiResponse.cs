using EcommerceAPI.Models;

namespace EcommerceAPI.Responses
{
    public class ApiResponse<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }

        private ApiResponse(bool sucesso, string mensagem, T? dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public static ApiResponse<T> Ok(T dados, string mensagem = "Operação realizada com sucesso.")
            => new ApiResponse<T>(true, mensagem, dados);

        public static ApiResponse<T> Falha(string mensagem)
            => new ApiResponse<T>(false, mensagem, default);
    }
}
