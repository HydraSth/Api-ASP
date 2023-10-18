using System.Security.Cryptography;

namespace Api
{
    public class TokenGenerator
    {
        private List<string> tokens;
        public TokenGenerator()
        {
            tokens = new List<string>();
        }
        public string CrearToken()
        {
            string secureRandomString = string.Empty;
            using (var RandomCreate = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[4096];
                RandomCreate.GetBytes(buffer);
                secureRandomString = Convert.ToBase64String(buffer);
            }
            tokens.Add(secureRandomString);
            return secureRandomString;
        }
        public bool TokenAuthentication(string token)
        {
            return tokens.FirstOrDefault(x => x == token) != null;
        }
        
    }
}
