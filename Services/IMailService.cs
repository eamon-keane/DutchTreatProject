namespace DutchTreat.Services
{
    public interface IMailService
    {
        void SendMessage(string toEmail, string subject, string body);
    }
}