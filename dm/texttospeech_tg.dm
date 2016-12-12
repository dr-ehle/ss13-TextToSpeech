/mob/proc/texttospeech(var/text)
	var/name2
	if (!name2)
		if(!src.ckey || src.ckey == "")
			name2 = "\ref[src]"
		else
			name2 = src.ckey
	spawn(0)
		var/list/voiceslist = list()

		voiceslist["msg"] = text
		voiceslist["ckey"] = name2
		var/params = list2params(voiceslist)

		text2file(params,"scripts/voicequeue.txt")

		//call("writevoice.dll", "writevoicetext")(params)

		shell("Speak.exe")

		if(fexists("scripts/voicequeue.txt"))
			fdel("scripts/voicequeue.txt")

	spawn(10)
		if(fexists("sound/playervoices/[name2].wav"))
			for(var/mob/M in range(13))

				M.playsound_local(src.loc, "sound/playervoices/[name2].wav", 70)

/client/proc/texttospeech(var/text, var/clientkey)
	spawn(0)
		var/list/voiceslist = list()

		voiceslist["msg"] = text
		voiceslist["ckey"] = clientkey
		var/params = list2params(voiceslist)

		call("writevoice.dll", "writevoicetext")(params)