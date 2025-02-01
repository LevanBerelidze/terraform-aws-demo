using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text;
using System.Text.Json;

namespace ExampleApp
{
    public class AmazonSecretsManagerConfigurationProvider : ConfigurationProvider
    {
        private readonly string secretName;

        public AmazonSecretsManagerConfigurationProvider(string secretName)
        {
            this.secretName = secretName;
        }

        public override void Load()
        {
            string secret = GetSecret();
            Data = JsonSerializer.Deserialize<Dictionary<string, string>>(secret);
        }

        private string GetSecret()
        {
            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
            };

            using (AmazonSecretsManagerClient client = new AmazonSecretsManagerClient())
            {
                GetSecretValueResponse response = client.GetSecretValueAsync(request).Result;

                string secretString;
                if (response.SecretString != null)
                {
                    secretString = response.SecretString;
                }
                else
                {
                    MemoryStream memoryStream = response.SecretBinary;
                    StreamReader reader = new StreamReader(memoryStream);
                    secretString = Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
                }

                return secretString;
            }
        }
    }
}
