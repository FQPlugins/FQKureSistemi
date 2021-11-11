using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FQKureSistemi
{
    public class Config : IRocketPluginConfiguration
    {
        public void LoadDefaults()
        {
        }

        public Vector3 kureSpawn;
    }
}
