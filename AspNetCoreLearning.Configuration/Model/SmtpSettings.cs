using Microsoft.Extensions.Options;

namespace AspNetCoreLearning.Configuration.Model
{
    public interface ISmtpSettings
    {
        public int GetPort();
        public bool GetEnableSsl();
        public string GetUserName();
        public string GetPassword();
        public string GetFrom();
    }

    public class SmtpModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }

    public class SmtpSettings : ISmtpSettings
    {
        private SmtpModel _smtpModel;
        public SmtpSettings(IOptions<SmtpModel> smptOption)
        {
            _smtpModel = smptOption.Value;
        }

        public bool GetEnableSsl() => _smtpModel.EnableSsl;

        public string GetFrom() => _smtpModel.From;

        public string GetPassword() => _smtpModel.Password;

        public int GetPort() => _smtpModel.Port;

        public string GetUserName() => _smtpModel.UserName;
    }
    public class MongoSettings
    {
        public string mongo_database { get; set; }
        public string mongo_uri { get; set; }
    }

    public class MySettings
    {
        public string ApiKey { get; set; }
        public bool FeatureEnabled { get; set; }
    }

}
