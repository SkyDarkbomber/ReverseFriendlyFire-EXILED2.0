using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseFriendlyFire_EXILED
{
    public sealed class Config : IConfig
    {
        [Description("Enable or disable the plugin")]
        public bool IsEnabled { get; set; } = true;


        [Description("Set the Max amount of friendly fire damage before reverse friendly fire is activated")]
        public float MaxFriendlyFire { get; set; } = 250;


    }
}
