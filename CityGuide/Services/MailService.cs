namespace CityGuide.Services
{
    public class MailService : IMailService
    {
        private string _mailTo = string.Empty;
        private string _mailFrom = string.Empty;

        public MailService(IConfiguration configuration)
        {
            _mailTo = configuration["MailSettings:mailToAddress"];
            _mailFrom = configuration["MailSettings:mailToAddress"];
        }

        public void sendEmail(string subject, string message)
        {
            Console.WriteLine($"Sent mail from {_mailFrom} to {_mailTo}, with subject: {subject} and with message: {message}");
        }
    }
}
