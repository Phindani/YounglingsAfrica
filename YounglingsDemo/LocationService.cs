using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace YounglingsDemo
{
    public class LocationService : ILocationService
    {
        public async Task<string> GetLocation()
        {
            string devicelocation = "";
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                var lat = location.Latitude;
                var lon = location.Longitude;
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);
                var placemark = placemarks?.FirstOrDefault();

                //Lindani's suggestion. And is a great way 
                devicelocation = location != null && placemark != null ?
                        devicelocation = placemark.SubLocality + ", " + placemark.Thoroughfare : placemark.SubLocality == null ?
                        devicelocation = placemark.Locality : null;

                //My old way of doing things
                /*if (location != null)
                  {
                    if (placemark != null)
                    {
                        devicelocation = placemark.SubLocality + ", " + placemark.Thoroughfare;
                       if (placemark.SubLocality == null)
                            devicelocation = placemark.Locality;
                    }
                  }*/
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return devicelocation;
        }
    }
}