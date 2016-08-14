using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FMOD;

namespace Easyfmod
{
    public enum EasyFmodReverbpreset {UNDERWATER,CAVE,CONCERTHALL,CITY,HALLWAY,LIVINGROOM,PARKINGLOT,ARENA,BATHROOM,PLAIN,HANGAR,FOREST,MOUNTAIN,STONEROOM,ALLEY,PIPE, AUDITORIUM,GENERAL,CARPETTEDHALLWAY,QUARRY,GENERIC,ROOM};
    public  partial class EasyFmod
    {
        public FMOD.System fmod_system;
        public Sound sound_instance;
        public Channel fmod_channel;
        public ChannelGroup master_channelgroup;
        private FMOD.DSP dsp = null;
        private DSPConnection dspc = null;
        private REVERB_PROPERTIES reverbEffect;
        private string path;
        public string PlayPath{ get {return this.path; }}
        public uint Position { get { return GetPlayPosition(TIMEUNIT.MS);}}
        public uint Version { get { return GetVersion(false); } }
        public EasyFmod()
        {
            fmod_system = new FMOD.System();
            sound_instance = new Sound();
            fmod_channel = new Channel();
            master_channelgroup = new ChannelGroup();
            Factory.System_Create(ref fmod_system);
            if (fmod_system.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)null) != RESULT.OK &&
              fmod_system.setStreamBufferSize(64 * 1024, FMOD.TIMEUNIT.RAWBYTES) != RESULT.OK)
            {
                return;
            }
        }
        public uint GetVersion(bool checknewest = false)
        {
            uint version = 0;
            if (fmod_system.getVersion(ref version) != RESULT.OK) {
                return 0;
            }
            if (checknewest)
            {
                if (version < FMOD.VERSION.number)
                {
                    MessageBox.Show("fmod 라이브러리의 최신버전이 발견되었습니다." + version.ToString("X") + ".현재프로그램버전:" + FMOD.VERSION.number.ToString("X") + ".");
                    Application.Exit();
                }
            }
            return version;
        }
        public void CreateStream(string mp3Path, MODE stereamMod)
        {
            if (sound_instance.release() != RESULT.OK && fmod_system.createStream(mp3Path, stereamMod, ref sound_instance) != RESULT.OK)
            {
                return;
            }
            this.path = mp3Path;
  
            if (OnCreateStream != null)
            {
                OnCreateStream(this, new CreateStreamEventArgs(mp3Path,stereamMod,this.fmod_system,TIMEUNIT.RAWBYTES));
            }
        }
        public void PlaySound(CHANNELINDEX channel)
        {
            fmod_channel.stop();
            fmod_system.playSound(channel, sound_instance, false, ref fmod_channel);
            fmod_channel.setChannelGroup(master_channelgroup);
            if (OnPlay != null)
            {
                OnPlay(this, new PlayEventArgs(this.path, this.fmod_system,fmod_channel, TIMEUNIT.RAWBYTES));
            }
            return;
        }
        public void PlayStop()
        {
            fmod_channel.stop();
            if (OnStop != null)
            {
                OnStop(this, new StopEventArgs(this.path, this.fmod_system, this.fmod_channel, TIMEUNIT.RAWBYTES));
            }
            return;
        }
        public void Pause(bool pause)
        {
            fmod_channel.setPaused(true);
            if (OnPause != null)
            {
                OnPause(this, new PauseEventArgs(this.path, this.fmod_system,fmod_channel, TIMEUNIT.RAWBYTES));
            }
            return;
        }
        public bool GetPause()
        {
            bool paused = false;
            fmod_channel.getPaused(ref paused);
            return paused;
        }
        public void SetVolume(float volume)
        {
            fmod_channel.setVolume(volume);
            if (OnVolumeChanged != null)
            {
                OnVolumeChanged(this, new VolumeChangedEventArgs(this.path, this.fmod_system, this.fmod_channel, TIMEUNIT.RAWBYTES,volume));
            }
            return;
        }
        public void GetSpectrum(float[] specArr,int size,int channeloffSet,FMOD.DSP_FFT_WINDOW type)
        {
            fmod_system.getSpectrum(specArr,size,channeloffSet,type);
        }
        public void GetSoftwareFormat(ref int samplerate, ref SOUND_FORMAT format, ref int numoutputchannels, ref int maxinputchannels, ref DSP_RESAMPLER resamplemethod, ref int bits)
        {
            fmod_system.getSoftwareFormat(ref samplerate, ref format, ref numoutputchannels, ref maxinputchannels, ref resamplemethod, ref bits);
        }
        public void GetWaveData(float[] wavearray, int numvalues, int channeloffset)
        {
            fmod_system.getWaveData(wavearray,numvalues,channeloffset);
        }
        public uint GetPlayPosition(TIMEUNIT timeunit)
        {
            uint ms = 0;
            fmod_channel.getPosition(ref ms, timeunit);
            return ms;
        }
        public void SetPlayPosition(float position, TIMEUNIT timeunit)
        {
            fmod_channel.setPosition((uint)position, timeunit);
            if (OnPositionChanged != null)
            {
                OnPositionChanged(this, new PositionChangedEventArgs(this.path, this.fmod_system,this.fmod_channel, TIMEUNIT.RAWBYTES));
            }
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
            else if (value == 2)
            {
                fmod_channel.setFrequency(old - 5000);
            }
            else if (value == 3)
            {
                fmod_channel.setFrequency(old - 4000);
            }
            else if (value == 4)
            {
                fmod_channel.setFrequency(old - 3000);
            }
            else if (value == 5)
            {
                fmod_channel.setFrequency(old - 2000);
            }
            else if (value == 6)
            {
                fmod_channel.setFrequency(old);
            }
            else if (value == 7)
            {
                fmod_channel.setFrequency(old + 1000);
            }
            else if (value == 8)
            {
                fmod_channel.setFrequency(old + 3000);
            }
            else if (value == 9)
            {
                fmod_channel.setFrequency(old + 5000);
            }
            else if (value == 10)
            {
                fmod_channel.setFrequency(old + 7000);
            }
            else if (value == 11)
            {
                fmod_channel.setFrequency(old + 9000);
            }
            else if (value == 12)
            {
                fmod_channel.setFrequency(49000);
            }
            else
            {
                if (OnTempoChanged != null)
                {
                    OnTempoChanged(this, new TempoChangedEventArgs(this.path, this.fmod_system, this.fmod_channel, TIMEUNIT.RAWBYTES,0f));
                }
                return;
            }
            if (OnTempoChanged != null)
            {
                OnTempoChanged(this, new TempoChangedEventArgs(this.path, this.fmod_system, this.fmod_channel, TIMEUNIT.RAWBYTES, value));
            }
            return;
        }
        public void SetReverbEffect(EasyFmodReverbpreset PRESET)
        { 
             if (PRESET == EasyFmodReverbpreset.CAVE)
            {
                initreverb();
                PRESET a = new PRESET();
              reverbEffect= a.CAVE();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.CONCERTHALL)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.CONCERTHALL();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.QUARRY)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.QUARRY();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.CITY)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.CITY();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.UNDERWATER)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.UNDERWATER();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.GENERAL)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.OFF();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.HALLWAY)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.HALLWAY();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.LIVINGROOM)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.LIVINGROOM();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.PARKINGLOT)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.PARKINGLOT();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.BATHROOM)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.BATHROOM();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.ARENA)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.ARENA();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.PLAIN)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.PLAIN();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.HANGAR)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.HANGAR();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.MOUNTAIN)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.MOUNTAINS();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.FOREST)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.FOREST();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.STONEROOM)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.STONEROOM();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.AUDITORIUM)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.AUDITORIUM();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.PIPE)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.SEWERPIPE();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.CARPETTEDHALLWAY)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.CARPETTEDHALLWAY();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.ALLEY)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.ALLEY();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.GENERIC)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.GENERIC();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
            else if (PRESET == EasyFmodReverbpreset.ROOM)
            {
                initreverb();
                PRESET a = new PRESET();
                reverbEffect = a.ROOM();
                fmod_system.setReverbProperties(ref reverbEffect);
            }
        }
        public void SetPitch(float value)
        {
         if(dsp!=null)dsp.release();
         fmod_system.createDSPByType(DSP_TYPE.PITCHSHIFT,ref dsp);
          fmod_system.addDSP(dsp,ref dspc);
            dsp.setParameter((int)DSP_PITCHSHIFT.PITCH, 1.0f + ((1.0f / 12.0f) * value));
            if (OnPitchChanged != null)
            {
                OnPitchChanged(this, new PitchChangedEventArgs(this.path, this.fmod_system, this.fmod_channel, TIMEUNIT.RAWBYTES,value));
            }
            return;
        }
        public uint GetPositionLength(TIMEUNIT timeunit)
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
        public string GetPlayPositionTime(TIMEUNIT timeunit)
        {
            return ConvertToTimeFormat(GetPlayPosition(timeunit));
        }
        public string ConvertToTimeFormat(long num)
        {
        TimeSpan ds = TimeSpan.FromMilliseconds(num);
            return ds.Minutes.ToString("0") + ":" + ds.Seconds.ToString("00");
        }
      private void initreverb()
        {
            reverbEffect = new REVERB_PROPERTIES();
            reverbEffect.Flags = REVERB_FLAGS.HIGHQUALITYREVERB;
            return;
        }
    }
}
