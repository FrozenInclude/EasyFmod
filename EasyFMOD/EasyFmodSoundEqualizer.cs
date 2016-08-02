using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easyfmod;
using FMOD;

namespace Easyfmod
{
    public class EasyFmodSoundEqualizer
    {
        private EasyFmod easyfm;
        private DSP SoundEQ;
        private DSPConnection soundEQ;
        private float centerValue;
        private float bandwithValue;
        private float gainValue;
        public EasyFmodSoundEqualizer(EasyFmod easyfmod, float centerValue, float bandwithValue, float gainValue)
        {
           this.easyfm= easyfmod ;
            if (easyfm.fmod_system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, ref SoundEQ) != FMOD.RESULT.OK)
            {
                return;
            }
            if (easyfm.fmod_system.getMasterChannelGroup(ref easyfm.master_channelgroup) != FMOD.RESULT.OK)
            {
                return;
            }
            if(easyfm.fmod_system.addDSP(SoundEQ, ref soundEQ) != FMOD.RESULT.OK){
                return;
            }
            this.centerValue = centerValue;
            this.bandwithValue = bandwithValue;
            this.gainValue = gainValue;
        }
        public void SetEQ()
        {
            if (SoundEQ.setParameter((int)FMOD.DSP_PARAMEQ.CENTER, centerValue) != FMOD.RESULT.OK)
            {
                return;
            }

            if (SoundEQ.setParameter((int)FMOD.DSP_PARAMEQ.BANDWIDTH, bandwithValue) != FMOD.RESULT.OK)
            {
                return;
            }

            if (SoundEQ.setParameter((int)FMOD.DSP_PARAMEQ.GAIN, gainValue) != FMOD.RESULT.OK)
            {
                return;
            }

            if (SoundEQ.setActive(true) != FMOD.RESULT.OK)
            {
                return;
            }
        }
        public void DeleteEQ()
        {
            if (this.SoundEQ != null)
            {
                this.SoundEQ.setActive(false);
                ChannelGroup masterChannelGroup = null;
                this.easyfm.fmod_system.getMasterChannelGroup(ref masterChannelGroup);
                this.SoundEQ.remove();
                this.SoundEQ.release();
                this.SoundEQ = null;
                this.easyfm = null;
            }
        }
    }
}
