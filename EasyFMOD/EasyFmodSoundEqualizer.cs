using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easyfmod;
using FMOD;

namespace EasyFmodSoundEqualizer
{
    class EasyFmodSoundEqualizer
    {
        private EasyFmod easyfm;
        private DSP SoundEQ;
        public EasyFmodSoundEqualizer(EasyFmod easyfmod,float centerValue, float bandwithValue, float gainValue)
        {
            this.easyfm = easyfmod;
            if (!easyfm.fmod_system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ,ref SoundEQ).ERRCHECK())
            {
                return;
            }
            if (! easyfm.fmod_system.getMasterChannelGroup(ref easyfm.master_channelgroup).ERRCHECK())
            {
                return;
            }

            int numDSPs;
        }

    }
}
}
