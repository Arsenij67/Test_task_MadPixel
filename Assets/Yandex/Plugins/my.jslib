mergeInto(LibraryManager.library, {

LoadingAPIReady: function(){
console.log("--------Podkluchaem API--------");
ysdk.features.LoadingAPI.ready();
console.log("--------Podkluchili API--------");
},

GameplayAPIStart: function(){
ysdk.features.GameplayAPI.start()
console.log("--------Start API--------");
},

GameplayAPIStop: function(){
ysdk.features.GameplayAPI.stop()
console.log("--------Stop API--------");
},

GetLang: function()
{
	var lang = ysdk.environment.i18n.lang;
	var bufferSize = lenghtBytesUTF8(lang)+1;
	var buffer = _malloc(bufferSize);
	stringToUTF8(lang, buffer, bufferSize);
	return buffer;
}


});