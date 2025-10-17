using Leviatas.MicroRabbit.MVC.Models.DTO;

namespace Leviatas.MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri = "api/Banking";
            var transferContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(transferDTO),
                System.Text.Encoding.UTF8,
                "application/json");
            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
