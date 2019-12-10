﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhateverProject.Installer
{
    public interface IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
