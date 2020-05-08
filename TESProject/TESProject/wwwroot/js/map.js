var TILE_URL = 'http://127.0.0.1:8887/{z}/{x}/{y}';

var map;
var mapEl;
var layer;
var layerID = 'my-custom-layer';

window.initMap = function () {
    mapEl = document.querySelector('#map');

    map = new google.maps.Map(mapEl, {
        //restriction: {
        //    latLngBounds: {
        //        north: 0,
        //        south: 0,E
        //        west: 0,
        //        east: 0
        //    }
        //},
        center: new google.maps.LatLng(0, 0),      //78, 150
        zoom: 6,
        disableDefaultUI: true
    });


    layer = new google.maps.ImageMapType({
        name: layerID,
        getTileUrl: function (coord, zoom) {
            console.log(coord);
            var url = TILE_URL
                .replace('{x}', coord.x)
                .replace('{y}', coord.y)
                .replace('{z}', zoom);
            return url;
            
        },
        tileSize: new google.maps.Size(325, 512),
        minZoom: 3,
        maxZoom: 6
    });

    map.mapTypes.set(layerID, layer);
    map.setMapTypeId(layerID);
};