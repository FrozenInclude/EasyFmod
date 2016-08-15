# EasyFmod
You can make a music player easily.
# How to use
Download this project and add class files in your csproject solution
#Basic tutorial
- Load mp3file and play
```js
EasyFmod a = new EasyFmod();
a.CreateStream("test.mp3", FMOD.MODE.SOFTWARE);
a.PlaySound(FMOD.CHANNELINDEX.FREE);
or
EasyFmod a = new EasyFmod();
a.CreateSound("test.mp3", FMOD.MODE.SOFTWARE);
a.PlaySound(FMOD.CHANNELINDEX.FREE);
```
- Set volume
```js
a.SetVolume(float);
```
- control pitch and Tempo
```js
a.SetPich(float);
a.SetTempo(float);
```
- Set Fmod DSP EFFECT
```js
EasyFmodSoundEffect b = new EasyFmodSoundEffect(a, EasyFmodSoundeffect.CHORUS);
b.SetEffect();
```
- Get/Set playposition
```js
a.SetPlayPosition(float,TIMEUNIT)
a.GetPlayPosition(TIMEUNIT)//return uint value
a.GetPlayPositionTime(TIMEUNIT)//return play position length to timeformat string ex)05:49
```
- Get position length
```js
a.GetPositionLength(TIMEUNIT)//return uint value
a.GetPositionTime(TIMEUNIT)//return position length to timeformat string ex)05:49
```
- Set reverb effect
```js
a.SetReverbEffect(EasyFmodReverbpreset.LIVINGROOM);
```
- Set Equalizer
```js
EasyFmodSoundEqualizer c=new EasyFmodSoundEqualizer(32f, 1f, 0f);
c.SetEQ();
```
#Event
- OnCreateStream
- OnCreateSound
- OnPlay
- OnPause
- OnPositionChanged   
- OnPitchChanged        
- OnPitchChangedHandler     
- OnTempoChanged        
- OnVolumeChanged        
쓰기귀찮네
