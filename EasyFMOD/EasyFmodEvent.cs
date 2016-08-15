using System;
using FMOD;

namespace Easyfmod
{
    public class CreateStreamEventArgs : EventArgs
    {
        private FMOD.System system;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public MODE StreamMode { get; private set; }
        public uint BufferSize { get { return getBufferSize(); } }
        public CreateStreamEventArgs(string FilePath,MODE StreamMode,FMOD.System system,TIMEUNIT timeunit)
        {
            this.FilePath = FilePath;
            this.StreamMode = StreamMode;
            this.system = system;
            this.timeunit = timeunit;
        }
        private uint getBufferSize()
        {
            uint size = 0;
            if (this.system != null)
                system.getStreamBufferSize(ref size,ref this.timeunit);
            return size;
        }
    }
    public class CreateSoundEventArgs : EventArgs
    {
        private FMOD.System system;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public MODE SoundMode { get; private set; }
        public uint BufferSize { get { return getBufferSize(); } }
        public CreateSoundEventArgs(string FilePath, MODE SoundMode, FMOD.System system, TIMEUNIT timeunit)
        {
            this.FilePath = FilePath;
            this.SoundMode = SoundMode;
            this.system = system;
            this.timeunit = timeunit;
        }
        private uint getBufferSize()
        {
            uint size = 0;
            if (this.system != null)
                system.getStreamBufferSize(ref size, ref this.timeunit);
            return size;
        }
    }
    public class PlayEventArgs : EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public uint PositionLength { get { return getPositionLength(); } }
        public PlayEventArgs(string FilePath, FMOD.System system,Channel channel,TIMEUNIT timeunit)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
        }
        private uint getPositionLength()
        {
            uint len = 0;
            Sound currentsound = null;
          this.channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len, timeunit);
            }
            return len;
        }
    }
    public class PauseEventArgs : EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public uint CurrentPosition { get { return getPosition(); } }
        public uint PositionLength { get { return getPositionLength(); } }
        public PauseEventArgs(string FilePath, FMOD.System system,Channel channel,TIMEUNIT timeunit)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
            this.channel = channel;
        }
        private uint getPositionLength()
        {
            uint len = 0;
            Sound currentsound = null;
            this.channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len, timeunit);
            }
            return len;
        }
        private uint getPosition()
        {
        uint ms = 0;
        channel.getPosition(ref ms, timeunit);
            return ms;
        }
     
    }
    public class PositionChangedEventArgs : EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public uint CurrentPosition { get { return getPosition(); } }
        public uint PositionLength { get { return getPositionLength(); } }
        public PositionChangedEventArgs(string FilePath, FMOD.System system,Channel channel, TIMEUNIT timeunit)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
            this.channel = channel;
        }
        private uint getPositionLength()
        {
            uint len = 0;
            Sound currentsound = null;
            this.channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len, timeunit);
            }
            return len;
        }
        private uint getPosition()
        {
            uint ms = 0;
            channel.getPosition(ref ms, timeunit);
            return ms;
        }

    }
    public class PitchChangedEventArgs : EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public uint CurrentPosition { get { return getPosition(); } }
        public float Pitch { get; set; }
        public uint PositionLength { get { return getPositionLength(); } }
        public PitchChangedEventArgs(string FilePath, FMOD.System system, Channel channel, TIMEUNIT timeunit,float Pitch)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
            this.channel = channel;
            this.Pitch = Pitch;
        }
        private uint getPositionLength()
        {
            uint len = 0;
            Sound currentsound = null;
            this.channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len, timeunit);
            }
            return len;
        }
        private uint getPosition()
        {
            uint ms = 0;
            channel.getPosition(ref ms, timeunit);
            return ms;
        }

    }

    public class TempoChangedEventArgs : EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public uint CurrentPosition { get { return getPosition(); } }
        public float Tempo { get; set; }
        public uint PositionLength { get { return getPositionLength(); } }
        public TempoChangedEventArgs(string FilePath, FMOD.System system, Channel channel, TIMEUNIT timeunit, float Tempo)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
            this.channel = channel;
            this.Tempo= Tempo;
        }
        private uint getPositionLength()
        {
            uint len = 0;
            Sound currentsound = null;
            this.channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len, timeunit);
            }
            return len;
        }
        private uint getPosition()
        {
            uint ms = 0;
            channel.getPosition(ref ms, timeunit);
            return ms;
        }

    }

    public class StopEventArgs: EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public uint PositionLength { get { return getPositionLength(); } }
        public StopEventArgs(string FilePath, FMOD.System system,Channel channel, TIMEUNIT timeunit)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
            this.channel = channel;
        }
        private uint getPositionLength()
        {
            uint len = 0;
            Sound currentsound = null;
            this.channel.getCurrentSound(ref currentsound);
            if (currentsound != null)
            {
                currentsound.getLength(ref len, timeunit);
            }
            return len;
        }
    }

    public class VolumeChangedEventArgs : EventArgs
    {
        private FMOD.System system;
        private Channel channel;
        private TIMEUNIT timeunit;
        public string FilePath { get; private set; }
        public float Volume { get; set; }
        public VolumeChangedEventArgs(string FilePath, FMOD.System system, Channel channel, TIMEUNIT timeunit, float Volume)
        {
            this.FilePath = FilePath;
            this.system = system;
            this.timeunit = timeunit;
            this.channel = channel;
            this.Volume = Volume;
        }
    }

    public delegate void OnCreateStreamHandler(object sender, CreateStreamEventArgs e);
    public delegate void OnCreateSoundHandler(object sender, CreateSoundEventArgs e);
    public delegate void OnPlayHandler(object sender, PlayEventArgs e);
    public delegate void OnPauseHandler(object sender, PauseEventArgs e);
    public delegate void OnPositionChangedHandler(object sender, PositionChangedEventArgs e);
    public delegate void OnStopHandler(object sender,StopEventArgs e);
    public delegate void OnPitchChangedHandler(object sender, PitchChangedEventArgs e);
    public delegate void OnTempoChangedHandler(object sender,TempoChangedEventArgs e);
    public delegate void OnVolumeChangedHandler(object sender, VolumeChangedEventArgs e);

    public partial class EasyFmod
        {
        public event OnCreateStreamHandler OnCreateStream;
        public event OnCreateSoundHandler OnCreateSound;
        public event OnPlayHandler OnPlay;
        public event OnPauseHandler OnPause;
        public event OnPositionChangedHandler OnPositionChanged;
        public event OnStopHandler OnStop;
        public event OnPitchChangedHandler OnPitchChanged;
        public event OnTempoChangedHandler OnTempoChanged;
        public event OnVolumeChangedHandler OnVolumeChanged;
    }
}
