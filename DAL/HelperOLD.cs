﻿using System;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public static class HelperOLD
    {
        public static string BlogConnectionStringValue(IConfiguration configuration, string name)
        {
            return configuration.GetSection("ConnectionStrings")[name];

        }
    }
}