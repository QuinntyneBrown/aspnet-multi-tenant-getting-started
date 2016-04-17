using Chloe.Server.Config.Contracts;
using System;

namespace Chloe.Server.Config
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public T Get<T>() where T : class
        {
            if (typeof(T) == typeof(ISmtpConfiguration))
                return SmtpConfiguration.Config as T;

            throw new InvalidOperationException();
        }
    }
}