using Newtonsoft.Json;
using SuperPoweredPeople.Services.Interface;
using System;
using System.Collections.Generic;

namespace SuperPoweredPeople.Services
{
    public class Logger : ILogger
    {
        public void TrackError(Exception ex)
        {
            try
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception)
            {

            }
        }

        public void TrackEvent(string @event, IDictionary<string, string> properties = null)
        {
            try
            {
                Console.WriteLine($"[{@event}]:{JsonConvert.SerializeObject(properties)}");
            }
            catch (Exception)
            {

            }
        }
    }
}
