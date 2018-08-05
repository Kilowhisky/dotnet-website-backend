using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    /// <summary>
    /// Handles any setup specific to AWS
    /// </summary>
    public class AwsEnvironment
    {
        /// <summary>
        /// This reads the AWS config and sets the environment variables that AWS cannot set because of stupidity.
        /// </summary>
        /// <see cref="https://stackoverflow.com/questions/40127703/aws-elastic-beanstalk-environment-variables-in-asp-net-core-1-0/50354329#50354329"/>
        internal static void SetEbConfig()
        {
            var tempConfigBuilder = new ConfigurationBuilder();

            tempConfigBuilder.AddJsonFile(
                @"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration",
                optional: true,
                reloadOnChange: true
            );

            var configuration = tempConfigBuilder.Build();

            var ebEnv =
                configuration.GetSection("iis:env")
                    .GetChildren()
                    .Select(pair => pair.Value.Split(new[] { '=' }, 2))
                    .ToDictionary(keypair => keypair[0], keypair => keypair[1]);

            foreach (var keyVal in ebEnv)
            {
                Environment.SetEnvironmentVariable(keyVal.Key, keyVal.Value);
            }
        }
    }
}
