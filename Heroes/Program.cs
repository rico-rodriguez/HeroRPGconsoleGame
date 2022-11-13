using Microsoft.Extensions.Configuration;

namespace Heroes
{
    public class Program
    {
        public static IConfigurationRoot _configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            var charSelect = new SelectCharacter();
            charSelect.WelcomeScreen();
        }
    }



}