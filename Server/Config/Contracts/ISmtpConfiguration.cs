using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chloe.Server.Config.Contracts
{
    public interface ISmtpConfiguration
    {
        string Host { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}