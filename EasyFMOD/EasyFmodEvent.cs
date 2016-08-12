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
    public delegate void OnCreateStreamHandler(object sender, CreateStreamEventArgs e);
    public delegate void OnPlayHandler(object sender, PlayEventArgs e);
    public delegate void OnPauseHandler(object sender, PauseEventArgs e);
    public delegate void OnPositionChangedHandler(object sender, PositionChangedEventArgs e);
    public delegate void OnStopHandler(object sender,StopEventArgs e);

    public partial class EasyFmod
        {
        public event OnCreateStreamHandler OnCreateStream;
        public event OnPlayHandler OnPlay;
        public event OnPauseHandler OnPause;
        public event OnPositionChangedHandler OnPositionChanged;
        public event OnStopHandler OnStop;
    }
}
