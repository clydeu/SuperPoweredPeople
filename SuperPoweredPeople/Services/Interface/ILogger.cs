using System;
using System.Collections.Generic;

namespace SuperPoweredPeople.Services.Interface
{
    public interface ILogger
    {
        void TrackEvent(string @event, IDictionary<string, string> properties = null);
        void TrackError(Exception ex);
    }
}
