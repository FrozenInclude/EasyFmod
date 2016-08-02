using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;
using Easyfmod;

namespace Easyfmod
{
    public class EasyFmodEffect
    {
        public enum EasyFmodSoundeffect { LOWPASS, HIGHPASS, ECHO, CHORUS, FLANGE, SFXREVERVE, ITLOWPASS, SHIFTFX, DISTORTION, PARAMEQ, SIMPLE_LOWPASS };
    }
    public class EasyFmodSoundEffect
    {
        private EasyFmod easyF;
        private DSP soundEFFDsp;
        private DSP VSTDSP;
        private bool vstloaded = false;
        private DSPConnection VSTDSPCONNEC;
        private DSPConnection soundEFFDSPConnection;
        private uint DSPhandler;
        public EasyFmodSoundEffect(EasyFmod easy, EasyFmodEffect.EasyFmodSoundeffect a)
        {
            easyF = easy;
            if (a == EasyFmodEffect.EasyFmodSoundeffect.CHORUS)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.CHORUS, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.LOWPASS)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.LOWPASS, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.HIGHPASS)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.HIGHPASS, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.SFXREVERVE)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.SFXREVERB, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.ITLOWPASS)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.ITLOWPASS, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.ECHO)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.ECHO, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.DISTORTION)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.DISTORTION, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.PARAMEQ)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.SIMPLE_LOWPASS)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.LOWPASS_SIMPLE, ref soundEFFDsp);
            else if (a == EasyFmodEffect.EasyFmodSoundeffect.FLANGE)
                easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.FLANGE, ref soundEFFDsp);
        }
        public void SetEffect()
        {
            ApplyDsp(soundEFFDsp);
            return;
        }
        public void LoadVSTPluginWithDLL(string dllPath)
        {
            easyF.fmod_system.loadPlugin(dllPath, ref DSPhandler, 0);
            easyF.fmod_system.createDSPByType(FMOD.DSP_TYPE.VSTPLUGIN, ref VSTDSP);
            easyF.fmod_system.addDSP(VSTDSP, ref VSTDSPCONNEC);
            vstloaded = true;
            return;
        }
        public void ShowVSTPlugin(IntPtr displayHwnd)
        {
            if (!vstloaded) throw new Exception("vst플러그인이 로드되지않았습니다.");
            VSTDSP.showConfigDialog(displayHwnd, true);
            return;
        }
        private void ApplyDsp(DSP dsp)
        {
            bool active = false;
            dsp.getActive(ref active);
            if (active == false)
            {
                easyF.fmod_system.addDSP(dsp, ref soundEFFDSPConnection);
            }
            else
            {
                dsp.remove();
            }
            easyF.fmod_system.update();
            return;
        }

    }
}
