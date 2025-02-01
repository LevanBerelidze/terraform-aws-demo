namespace ExampleApp
{
    public class AmazonSecretsManagerConfigurationSource : IConfigurationSource
    {
        public AmazonSecretsManagerConfigurationSource()
        {
        }

        public string SecretName { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            if (string.IsNullOrEmpty(SecretName))
            {
                throw new InvalidOperationException($"Unable to create an instance of {nameof(AmazonSecretsManagerConfigurationProvider)} without {nameof(SecretName)}");
            }

            return new AmazonSecretsManagerConfigurationProvider(SecretName);
        }
    }
}
