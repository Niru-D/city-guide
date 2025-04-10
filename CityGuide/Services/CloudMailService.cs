namespace CityGuide.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = string.Empty;
        private string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["MailSettings:mailToAddress"];
            _mailFrom = configuration["MailSettings:mailFromAddress"];
        }

        public void sendEmail(string subject, string message)
        {
            Console.WriteLine($"Cloud: Sent mail from {_mailFrom} to {_mailTo}, with subject: {subject} and with message: {message}");
        }
    }
}
