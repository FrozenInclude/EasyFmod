using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;

namespace EasyFm
{
    public  class EasyFmod
    {
        protected FMOD.System fmod_system;
        protected Sound sound_instance;
        protected Channel fmod_channel;
        protected ChannelGroup master_channelgroup;
        public EasyFmod()
        {
            fmod_system = new FMOD.System();
            sound_instance = new Sound();
            fmod_channel = new Channel();
            master_channelgroup = new ChannelGroup();
        }
       public void CreateStream(string mp3Path,MODE stereamMod)
        {
            fmod_system.createStream(mp3Path,stereamMod, ref sound_instance);
            fmod_channel.setChannelGroup(master_channelgroup);
        }
        public void PlaySound(CHANNELINDEX channel)
        {
            fmod_system.playSound(channel, sound_instance, false, ref fmod_channel);
        }
        public void SetVolume(float volume)
        {
            fmod_channel.setVolume(volume);
        }
        public uint getPlayPosition(TIMEUNIT timeunit)
        {
            uint ms = 0;
            fmod_channel.getPosition(ref ms, timeunit);
            return ms;
        }
        public uint getPositionLength(TIMEUNIT timeunit)
        {
            uint len = 0;
            Sound currentsound = null;
            fmod_channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len,timeunit);
            }
            return len;
        }
        public string getPlayPositionTime(TIMEUNIT timeunit)
        {
            return ConvertToTimeFormat(getPlayPosition(timeunit));
        }
        public string ConvertToTimeFormat(long num)
        {
        TimeSpan ds = TimeSpan.FromMilliseconds(num);
            return ds.Minutes.ToString("0") + ":" + ds.Seconds.ToString("00");
        }
    }
}
