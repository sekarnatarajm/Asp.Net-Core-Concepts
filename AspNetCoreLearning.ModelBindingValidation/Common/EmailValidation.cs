using System.Text.RegularExpressions;

namespace AspNetCoreLearning.ModelBindingValidation.Common
{
    public static class EmailValidation
    {
        public static bool EmailDomainValidate(string email, List<string> domains)
        {
            string domainPattern = string.Join("|", domains.ConvertAll(d => Regex.Escape(d.ToLower())));
            string blockedDomainsPattern = $@"^[^@]+@({domainPattern})$";
            bool resukt = Regex.IsMatch(email, blockedDomainsPattern, RegexOptions.IgnoreCase);
            return resukt;
        }
    }
}
