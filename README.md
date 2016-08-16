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
- play,stop,pause

play
```js
a.PlaySound(FMOD.CHANNELINDEX.FREE);
```
stop
```js
a.PlayStop();
```
pause
```js
a.Pause(!a.GetPause());
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
- Check Fmod Version
```js
a.GetVersion();//return fmod version uint
```
if you want to check your library is the newest version
```js
a.GetVersion(true);
```
#Event
- OnCreateStream
```cs 
a.OnCreateStream += this.createStreamevent; 
private void createStreamevent(object sender,CreateStreamEventArgs e)
{
MessageBox.Show(e.StreamMode);
}
```
CreateStreamEventArgs
<pre><code>FilePath:musicfile path

StreamMode:stream's mode

BufferSize:stream's buffer size
</code></pre>
- OnCreateSound
```cs 
a.OnCreateSound += this.createSoundevent; 
private void createSoundevent(object sender,CreateSoundEventArgs e)
{
MessageBox.Show(e.SoundMode);
}
```
CreateSoundEventArgs
<pre><code>FilePath:musicfile path

SoundMode:sound's mode

BufferSize:sound's buffer size
</code></pre>
- OnPlay
```cs 
a.OnPlay += this.playevent; 
private void playevent(object sender,PlaySoundEventArgs e)
{
MessageBox.Show(e.FilePath);
}
```
PlaySoundEventArgs
<pre><code>FilePath:musicfile path

PositionLength:music file's duration length
</code></pre>
- OnPause
- OnPositionChanged   
- OnPitchChanged        
- OnTempoChanged        
- OnVolumeChanged        
쓰기귀찮네
