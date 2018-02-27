using System;

namespace SpeakerMeet.Exceptions
{
    public class SpeakerNotFoundException : Exception
    {
        public SpeakerNotFoundException() : base("Speaker Not Found")
        {
        }
    }
}
