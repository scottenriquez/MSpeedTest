﻿using System.Collections.Generic;
using System.Device.Location;
using System.Xml.Serialization;

namespace MSpeedTest.Models
{
    [XmlRoot("settings")]
    public class ServersList
    {
        [XmlArray("servers")]
        [XmlArrayItem("server")]
        public List<Server> Servers { get; set; }

        public ServersList()
        {
            Servers = new List<Server>();
        }

        public void CalculateDistances(GeoCoordinate clientCoordinate)
        {
            foreach (var server in Servers)
            {
                server.Distance = clientCoordinate.GetDistanceTo(server.GeoCoordinate);
            }
        }
    }
}
