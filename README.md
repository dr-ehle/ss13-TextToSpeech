# ss13-TextToSpeech
### Formalities
This is a FonixTalk wrapper for Space Station 13, modified from JaggerEstep's wrapper released in September.

It uses SharpTalk, a .NET wrapper for the FonixTalk Text-to-Speech engine. SharpTalk's libraries are used in Speak, the C# program that reads input from the message queue and produces a corresponding `.wav` file.

Speak is a derivation of JaggerEstep's TTS wrapper, which is itself a modification of the original. The creator of SharpTalk is also the creator of Speak.

`texttospeech_tg.dm` is a heavy modification of JaggerEstep's `texttospeech.dm`. Unlike his original, mobs do not use a `.dll` to write to the message queue. Instead, they uses core Byond procedures. This file is optimized for tgstation, and will most likely not work on other codebases.

`writevoice.dll` is JaggerEstep's implementation that he used for writing to the message queue. For an unknown reason, it did not function on virtual dedicated servers when used by mobs. However, clients attempting to write to the message queue over OOC chat had no issues, so I am including it in case someone wants text-to-speech over OOC.
### How to Implement
Unfortunately, due to FonixTalk being proprietary software, I cannot distribute the libraries required for this wrapper to function. Before anything will work, you must obtain your own FonixTalk libraries.

Place the FonixTalk libraries and the SharpTalk libraries in the same directory as `Speak.exe`. While it should work with any directory, the safest place would be to put everything in the main folder where your `.dmb` and `.dme` files are.

Open Dream Maker and enable whichever `texttospeech` file coincides with your codebase. Currently, the only option is tgstation.

Find where the "Say" command for mobs is defined. For tgstation, look for the function header `/mob/verb/say_verb(message as text)`, located in the file `/code/modules/mob/say.dm`.  At the bottom of the function, add this line: `usr.texttospeech(message)`.

If you wish to implement text-to-speech for OOC chat, find where the "OOC" command for clients is defined. For tgstation, look for the function header `/client/verb/ooc(msg as text`, located in the file `/code/modules/client/verbs/ooc.dm`. Under the line `log_ooc("[mob.name]/[key] : [raw_msg]")`, add this line: `usr.texttospeech(raw_msg, ckey)`.
### Moving Forward
I will continue to update this wrapper for my own uses. Anyone is free to make use of any improvement that I implement. I will also attempt to port this wrapper to other codebases. I will add documentation for them as they're ported. 
