﻿namespace Chloe.Server.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public bool IsDeleted { get; set; }
    }
}