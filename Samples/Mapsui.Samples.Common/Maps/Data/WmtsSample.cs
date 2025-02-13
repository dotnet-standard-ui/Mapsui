﻿using System.Linq;
using System.Threading.Tasks;
using BruTile.Cache;
using BruTile.Wmts;
using Mapsui.Cache;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Tiling.Layers;
using Mapsui.UI;

namespace Mapsui.Samples.Common.Maps.Data
{
    public class WmtsSample : ISample
    {
        public string Name => "3 WMTS";
        public string Category => "Data";
        public static IPersistentCache<byte[]>? DefaultCache { get; set; }

        public async Task<Map> CreateMapAsync()
        {
            var map = new Map
            {
                CRS = "EPSG:28992"
            };
            map.Layers.Add(await CreateLayerAsync());
            map.Layers.Add(GeodanOfficesSample.CreateLayer());
            return map;
        }

        public static async Task<ILayer> CreateLayerAsync()
        {
            var url = "http://geodata.nationaalgeoregister.nl/wmts/top10nl?VERSION=1.0.0&request=GetCapabilities";

            using var response = await (DefaultCache as IUrlPersistentCache).UrlCachedStreamAsync(url);
            var tileSources = WmtsParser.Parse(response);
            var nature2000TileSource = tileSources.First(t => t.Name == "natura2000");
            if (DefaultCache != null)
            {
                nature2000TileSource.PersistentCache = DefaultCache;
            }
            
            return new TileLayer(nature2000TileSource) { Name = nature2000TileSource.Name };
            
        }
    }
}