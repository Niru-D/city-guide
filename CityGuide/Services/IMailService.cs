namespace CityGuide.Services
{
    public interface IMailService
    {
        void sendEmail(string subject, string message);
    }
}