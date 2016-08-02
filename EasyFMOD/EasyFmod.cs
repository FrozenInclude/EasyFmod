using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;

namespace Easyfmod
{
    public  class EasyFmod
    {
        public FMOD.System fmod_system;
        public Sound sound_instance;
        public Channel fmod_channel;
        public ChannelGroup master_channelgroup;
        FMOD.DSP dsp = null;
        DSPConnection dspc = null;
        public EasyFmod()
        {
            fmod_system = new FMOD.System();
            sound_instance = new Sound();
            fmod_channel = new Channel();
            master_channelgroup = new ChannelGroup();
           Factory.System_Create(ref fmod_system);
            fmod_system.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
            fmod_system.setStreamBufferSize(64 * 1024, FMOD.TIMEUNIT.RAWBYTES);
        }
       public void CreateStream(string mp3Path,MODE stereamMod)
        {
            sound_instance.release();
            fmod_system.createStream(mp3Path,stereamMod, ref sound_instance);
            return;
        }
        public void PlaySound(CHANNELINDEX channel)
        {
           fmod_channel.stop();
            fmod_system.playSound(channel, sound_instance, false, ref fmod_channel);
            fmod_channel.setChannelGroup(master_channelgroup);
            return;
        }
        public void PlayStop()
        {
            fmod_channel.stop();
            return;
        }
        public void Pause(bool pause)
        {
            fmod_channel.setPaused(true);
            return;
        }
        public bool GetPause()
        {
            bool paused=false;
            fmod_channel.getPaused(ref paused);
            return paused;
        }
        public void SetVolume(float volume)
        {
            fmod_channel.setVolume(volume);
            return;
        }
        public uint getPlayPosition(TIMEUNIT timeunit)
        {
            uint ms = 0;
            fmod_channel.getPosition(ref ms, timeunit);
            return ms;
        }
        public void setPlayPosition(float position,TIMEUNIT timeunit)
        {
            fmod_channel.setPosition((uint)position,timeunit);
            return;
        }
        public void SetTempo(float value)
        {
            float old = 0;
            fmod_channel.getFrequency(ref old);
            if (value == 1)
            {
                fmod_channel.setFrequency(old - 6000);
            }
            if (value == 2)
            {
                fmod_channel.setFrequency(old - 5000);
            }
            if (value == 3)
            {
                fmod_channel.setFrequency(old - 4000);
            }
            if (value == 4)
            {
                fmod_channel.setFrequency(old - 3000);
            }
            if (value == 5)
            {
                fmod_channel.setFrequency(old - 2000);
            }
            if (value == 6)
            {
                fmod_channel.setFrequency(old);
            }
            if (value == 7)
            {
                fmod_channel.setFrequency(old + 1000);
            }
            if (value == 8)
            {
                fmod_channel.setFrequency(old + 3000);
            }
            if (value == 9)
            {
                fmod_channel.setFrequency(old + 5000);
            }
            if (value == 10)
            {
                fmod_channel.setFrequency(old + 7000);
            }
            if (value == 11)
            {
                fmod_channel.setFrequency(old + 9000);
            }
            if (value == 12)
            {
                fmod_channel.setFrequency(49000);
            }
        }
        public void SetPitch(float value)
        {
         if(dsp!=null)dsp.release();
         fmod_system.createDSPByType(DSP_TYPE.PITCHSHIFT,ref dsp);
          fmod_channel.addDSP(dsp,ref dspc);
            dsp.setParameter((int)DSP_PITCHSHIFT.PITCH, 1.0f + ((1.0f / 12.0f) * value));
            return;
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
